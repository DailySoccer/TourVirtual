using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AllViewer : MonoBehaviour {
    public delegate void callback();

	public UIScreen visorCanvas;
	public Text txtTitle;
	public Text txtDescription;
	public Image image;
	public Canvas[] toHide;

    ContentAPI.AssetType currentMode = ContentAPI.AssetType.Binary;
    
	Coroutine lastCoroutine;
    
	Camera ViewerCamera;
//    Light ViewerLight;
    GameObject model;
    
    AssetBundle assetbundle;
    
    callback endCallback;
    
    Texture2D texture;

	Vector2 lastTouch;
	Vector2 textureSize;
	Vector2 midScreen;
	Vector2 offset = Vector2.zero;


    RectTransform rectTransform;

    bool oldUICameraStatus;
    bool oldMainCameraStatus;
	bool draggin = false;
	
	float zoomSize = 1;    
	float orthoZoomSpeed = 5f;
    
    Canvas canvas;

    public static AllViewer Instance { get; private set;  }

    void Awake() {
        Instance = this;
        enabled = false;
    }

    // Use this for initialization
    public void Show(string url, ContentAPI.AssetType mode, string title="", string desc="", callback endCallback = null ) {
        this.endCallback = endCallback;

        offset = Vector2.zero;
        canvas = gameObject.GetComponent<Canvas>();
        currentMode = mode;
        enabled = true;
        //cm.ShowScreen(visorCanvas);
        visorCanvas.IsOpen = true;
        txtTitle.text = title;
        if(desc!="*"){
            txtDescription.transform.parent.gameObject.SetActive(true);
		    txtDescription.text = desc;
        }
        else
            txtDescription.transform.parent.gameObject.SetActive(false);

        CanvasManager cm = GameObject.FindGameObjectWithTag("GameCanvasManager").GetComponent<CanvasManager>();
        oldUICameraStatus = cm.UIScreensCamera.GetActive();
        oldMainCameraStatus = cm.MainCamera.GetActive();

        cm.UIScreensCamera.SetActive(false);
        cm.MainCamera.SetActive(false);
        image.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);

        switch (mode) {
            case ContentAPI.AssetType.Photo:
				image.sprite = null;				
                lastCoroutine = StartCoroutine(DownloadImage(url));
                midScreen = new Vector2(Screen.width, Screen.height) * 0.5f;
                canvas.renderMode = RenderMode.ScreenSpaceOverlay;
                canvas.worldCamera = null;
                break;
            case ContentAPI.AssetType.Model3D:
                ViewerCamera = new GameObject("ViewerCamera", typeof(Camera)).GetComponent<Camera>();
                ViewerCamera.clearFlags = CameraClearFlags.SolidColor;
                ViewerCamera.backgroundColor = Color.black;
                ViewerCamera.gameObject.layer= LayerMask.NameToLayer("Model3D");
                ViewerCamera.cullingMask = LayerMask.GetMask("UI", "Model3D");
                canvas.renderMode = RenderMode.ScreenSpaceCamera;
                canvas.worldCamera = ViewerCamera;
                if (toHide != null) {
                    foreach (var hide in toHide)
                        hide.enabled = false;
                }
/*
                ViewerLight = new GameObject("Light", typeof(Light)).GetComponent<Light>();
                ViewerLight.transform.rotation = Quaternion.Euler(50, 330, 0);
                ViewerLight.transform.parent = ViewerCamera.transform;
                ViewerLight.cullingMask = LayerMask.GetMask("Model3D");
*/
                lastCoroutine = StartCoroutine(DownloadModel(url));
                break;
            case ContentAPI.AssetType.Video:
                LoadingCanvasManager.Show();
                Handheld.PlayFullScreenMovie(url, Color.black, FullScreenMovieControlMode.CancelOnInput);
                LoadingCanvasManager.Hide();
                enabled = false;
                break;
        }
    }

	// mostrar descarga...
	IEnumerator DownloadModel(string url)
	{
		LoadingCanvasManager.Show("TVB.Message.LoadingData");

		WWW www = new WWW(url);
		yield return www;
        LoadingCanvasManager.Hide();
        if (!string.IsNullOrEmpty(www.error)) {
            // Hack por problemas con los nombres de los directorios.
            Debug.LogError(">>>> Se ha producido un error en la descarga del contenido "+www.error+" > "+url+" <" );
            yield break;
        }

		assetbundle = www.assetBundle;
		var names = assetbundle.GetAllAssetNames();
		model = GameObject.Instantiate<GameObject>(assetbundle.LoadAsset<GameObject>(names[0]));
		if (model.GetComponent<TrophyViewer>() == null)
		{
			model.AddComponent<TrophyViewer>();
		}
		//float size = model.GetComponent<Renderer>().bounds.size.y;
		MyTools.SetLayerRecursively(model, LayerMask.NameToLayer("Model3D"));
		posTarget = new Vector3(0, 0, 1.2f);
		model.transform.position = posTarget;
		model.transform.rotation = Quaternion.Euler(0, 180, 0) * model.transform.rotation;
	}

	IEnumerator DownloadImage(string url)
	{
		LoadingCanvasManager.Show("TVB.Message.LoadingData");

		yield return StartCoroutine(MyTools.LoadSpriteFromURL(url, image.gameObject));
		image.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
		

		Transform refTrans = image.transform;
		do
		{
			refTrans.localScale = Vector3.one;
			refTrans = refTrans.parent;
		} while (refTrans != transform && refTrans != null);
		transform.localScale = Vector3.one;
		
		image.SetNativeSize();
		rectTransform = image.GetComponent<RectTransform>();
		textureSize = rectTransform.offsetMax - rectTransform.offsetMin;
		if (textureSize.x > Screen.width || textureSize.y > Screen.height)
		{
			float scaleX, scaleY;
			scaleX = Screen.width / textureSize.x;
			scaleY = Screen.height / textureSize.y;
			textureSize *= Mathf.Min(scaleX, scaleY);
		}
		/*if (textureSize.x > textureSize.y)
		{
			float scale = 1;
			if (textureSize.x > canvas.pixelRect.width)
			{
				scale = canvas.pixelRect.width / textureSize.x;
				textureSize.x = canvas.pixelRect.width;
				textureSize.y *= scale;
			}
		}
		else
		{
			float scale = 1;
			if (textureSize.y > canvas.pixelRect.height)
			{
				scale = canvas.pixelRect.height / textureSize.y;
				textureSize.y = canvas.pixelRect.height;
				textureSize.x *= scale;
			}
		}*/
		zoomSize = textureSize.x;
		float zoom = zoomSize / textureSize.x;
		if (zoom < 1) zoom = 1;
		if (rectTransform != null)
		{
			rectTransform.offsetMin = new Vector2(offset.x - textureSize.x * 0.5f * zoom, -textureSize.y * 0.5f * zoom - offset.y);
			rectTransform.offsetMax = new Vector2(offset.x + textureSize.x * 0.5f * zoom, textureSize.y * 0.5f * zoom - offset.y);
		}
	}


    void Update() {
        switch (currentMode) {
            case ContentAPI.AssetType.Model3D: UpdateModel(); break;
            case ContentAPI.AssetType.Photo: UpdateImage(); break;
        }
    }

    Vector3 posTarget;
    void UpdateModel() {
        if (model == null) return;
        model.transform.position += (posTarget - model.transform.position)*0.2f;
#if UNITY_EDITOR
        /*if (Input.GetMouseButton(0)) {
            float dx = canvas.pixelRect.width / 1280.0f;
            float dy = canvas.pixelRect.height / 720.0f;
            if (!draggin) {
                lastTouch = Input.mousePosition;
                draggin = true;
            }
            else {
                Vector2 diff = ((Vector2)Input.mousePosition - lastTouch);
                lastTouch = Input.mousePosition;
                offset = new Vector2(diff.x / dx, -diff.y / dy);
            }
            model.transform.rotation = Quaternion.Euler(0, -offset.x * 0.5f, 0) * model.transform.rotation;
            if (Input.GetMouseButton(1)){
                if (posTarget.z != 1.2f)
                    posTarget = new Vector3(0, 0, 1.2f);
                else
                    posTarget = new Vector3(0, 0, 0.6f);
            }
        }
        else*/
            draggin = false;
#else
        /*if (Input.touchCount == 1) {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began) {
                if (Input.GetTouch(0).tapCount == 2) {
                    if (posTarget.z != 1.2f){
                        posTarget = new Vector3(0, 0, 1.2f);
                    }
                    else {
                        posTarget = new Vector3(0, 0, 0.6f);
                    }
                }            
                else{
                    lastTouch = touch.position;
                    draggin = true;
                }
            }
            else if (touch.phase == TouchPhase.Moved && draggin)
            {
                Vector3 diff = touch.position - lastTouch;
                model.transform.rotation = Quaternion.Euler(0, -diff.x * 0.5f, 0) * model.transform.rotation;
                lastTouch = touch.position;
            }
        }
        else*/
            draggin = false;
#endif
    }

	void UpdateImage() {
#if UNITY_EDITOR
		if (Input.GetMouseButton(0)) {
			float dx = 1;// canvas.pixelRect.width / Screen.width;
			float dy = 1;// canvas.pixelRect.height / Screen.height;
			if (!draggin) {
				lastTouch = Input.mousePosition;
				draggin = true;
			}
			else {
				Vector2 diff = ((Vector2)Input.mousePosition - lastTouch);
				lastTouch = Input.mousePosition;
				offset += new Vector2(diff.x / dx, -diff.y / dy);
			}
			if (Input.GetKey(KeyCode.LeftShift)) zoomSize -= 10;
			if (Input.GetKey(KeyCode.RightShift)) zoomSize += 10;
			if (zoomSize < textureSize.x) zoomSize = textureSize.x;
			if (zoomSize > textureSize.x * 4) zoomSize = textureSize.x * 4;

		}
		else
			draggin = false;
#else
        // If there are two touches on the device...
        if (Input.touchCount == 2 && Input.GetTouch(0).phase == TouchPhase.Moved && Input.GetTouch(1).phase == TouchPhase.Moved)
        {
            // Store both touches.
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            // Find the position in the previous frame of each touch.
            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            // Find the magnitude of the vector (the distance) between the touches in each frame.
            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            // Find the difference in the distances between each frame.
            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;
            zoomSize -= deltaMagnitudeDiff * orthoZoomSpeed;
            draggin = false;
        }
        else {
            if (Input.touchCount == 1)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    if (Input.GetTouch(0).tapCount == 2)
                    {
                        if (zoomSize == textureSize.x)
                            zoomSize = textureSize.x * 2f;
                        else {
                            zoomSize = textureSize.x;
                            offset = Vector2.zero;
                        }
                    }
                    else {
                        lastTouch = Input.GetTouch(0).position;
                        draggin = true;
                    }
                }
                else
                if (Input.GetTouch(0).phase == TouchPhase.Moved && draggin)
                {
                    float dx = 1;//canvas.pixelRect.width / Screen.width;
                    float dy = 1;//canvas.pixelRect.height / Screen.height;
                    Touch touch = Input.GetTouch(0);
                    Vector3 diff = Input.GetTouch(0).position - lastTouch;
                    lastTouch = Input.GetTouch(0).position;
                    offset += new Vector2(diff.x/dx, -diff.y/dy);
                }
            }
            else
                draggin = false;
        }
#endif
		float zoom = zoomSize / textureSize.x;
		if (zoom < 1) zoom = 1;
		if (rectTransform != null) {
			Vector2 texZoomSize = textureSize * zoom;
			offset.x = Screen.width >= texZoomSize.x ? 0 : Mathf.Clamp(offset.x, -texZoomSize.x * 0.5f + Screen.width * 0.5f, texZoomSize.x * 0.5f - Screen.width * 0.5f);
			offset.y = Screen.height >= texZoomSize.y ? 0 : Mathf.Clamp(offset.y, -texZoomSize.y * 0.5f + Screen.height * 0.5f, texZoomSize.y * 0.5f - Screen.height * 0.5f);
			rectTransform.offsetMin = new Vector2(offset.x - texZoomSize.x * 0.5f, -texZoomSize.y * 0.5f - offset.y);
			rectTransform.offsetMax = new Vector2(offset.x + texZoomSize.x * 0.5f, texZoomSize.y * 0.5f - offset.y);
		}
	}

    void OnDisable() {
        if (toHide != null){
            foreach (var hide in toHide)
                if(hide.enabled==false)
                hide.enabled = true;
        }
        var gcm = GameObject.FindGameObjectWithTag("GameCanvasManager");
        if (gcm != null){
            CanvasManager cm = GameObject.FindGameObjectWithTag("GameCanvasManager").GetComponent<CanvasManager>();
            if (cm != null) {
                cm.UIScreensCamera.SetActive(oldUICameraStatus);
                cm.MainCamera.SetActive(oldMainCameraStatus);
            }
        }

        visorCanvas.IsOpen = false;
        canvas.worldCamera = null;

        if (ViewerCamera!=null) Destroy(ViewerCamera.gameObject);
        if (model != null) Destroy(model);
        if (image.sprite != null) { if (image.sprite.texture != null) DestroyImmediate(image.sprite.texture, true); Destroy(image.sprite); image.sprite = null; }
        if (assetbundle != null) assetbundle.Unload(true);
        Resources.UnloadUnusedAssets();
        if (this.endCallback != null) this.endCallback();
    }

    public void Close() {
        enabled = false;
    }
}