#if !LITE_VERSION
//        gameObject.GetComponent<AllViewer>().Show("https://az726872.vo.msecnd.net/global-contentasset/asset_92d476d9-7c95-4102-8d7d-b9f18c1fadc7.jpg", AllViewer.ViewerMode.Image);
using UnityEngine;
using System.Collections;

public class AllViewer : MonoBehaviour {
    public delegate void callback();
    ContentAPI.AssetType currentMode = ContentAPI.AssetType.Binary;
    Coroutine lastCoroutine;
    Camera ViewerCamera;
//    Light ViewerLight;
    GameObject model;
    Vector2 lastTouch;
    AssetBundle assetbundle;

    bool draggin = false;

    callback endCallback;

    Vector2 textureSize;
    Texture2D texture;
    float zoomSize = 1;
    Vector2 midScreen;
    float orthoZoomSpeed = 5f;
    Vector2 offset = Vector2.zero;

    public UIScreen visorCanvas;
    public UnityEngine.UI.Text txtTitle;
    public UnityEngine.UI.Image image;
    RectTransform rectTransform;

    bool oldUICameraStatus;
    bool oldMainCameraStatus;

    public Canvas[] toHide;
    Canvas canvas;

    public static AllViewer Instance { get; private set;  }

    void Awake() {
        Instance = this;
        enabled = false;
    }

    // Use this for initialization
    public void Show(string url, ContentAPI.AssetType mode, string title="", callback endCallback = null ) {
        this.endCallback = endCallback;

        offset = Vector2.zero;
        canvas = gameObject.GetComponent<Canvas>();
        currentMode = mode;
        enabled = true;
        //cm.ShowScreen(visorCanvas);
        visorCanvas.IsOpen = true;
        txtTitle.text = title;

        CanvasManager cm = GameObject.FindGameObjectWithTag("GameCanvasManager").GetComponent<CanvasManager>();
        oldUICameraStatus = cm.UIScreensCamera.GetActive();
        oldMainCameraStatus = cm.MainCamera.GetActive();

        cm.UIScreensCamera.SetActive(false);
        cm.MainCamera.SetActive(false);
        
        switch (mode) {
            case ContentAPI.AssetType.Photo:
				image.sprite = null;
				image.color = new Color (1.0f, 1.0f, 1.0f, 0.0f);
                lastCoroutine = StartCoroutine(DownloadImage(url));
                midScreen = new Vector2(canvas.pixelRect.width, canvas.pixelRect.height) * 0.5f;
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
                Handheld.PlayFullScreenMovie(url, Color.black, FullScreenMovieControlMode.Minimal);
                enabled = false;
                break;
        }
    }

    // mostrar descarga...
    IEnumerator DownloadModel(string url) {
        LoadingCanvasManager.Show();

        WWW www = new WWW(url);
        yield return www;
        LoadingCanvasManager.Hide();
        if (!string.IsNullOrEmpty(www.error))
        {
//            Camera.current.backgroundColor = Color.red;
            yield break;
        }
        assetbundle = www.assetBundle;
        var names = assetbundle.GetAllAssetNames();
        model = GameObject.Instantiate<GameObject>(assetbundle.LoadAsset<GameObject>(names[0]));
        float size = model.GetComponent<Renderer>().bounds.size.y;
        model.layer = LayerMask.NameToLayer("Model3D");
        model.transform.position = new Vector3(0, -size * 0.5f, size * 2);
        model.transform.rotation = Quaternion.Euler(0, 180, 0) * model.transform.rotation;
    }

    IEnumerator DownloadImage(string url) {
        LoadingCanvasManager.Show();

        yield return StartCoroutine(MyTools.LoadSpriteFromURL(url, image.gameObject));
		image.color = new Color (1.0f, 1.0f, 1.0f, 1.0f);
        LoadingCanvasManager.Hide();

        image.SetNativeSize();
        rectTransform = image.GetComponent<RectTransform>();
        textureSize = rectTransform.offsetMax - rectTransform.offsetMin;        
        if (textureSize.x > textureSize.y)
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
        }
        zoomSize = textureSize.x;
    }


    void Update() {
        switch (currentMode) {
            case ContentAPI.AssetType.Model3D: UpdateModel(); break;
            case ContentAPI.AssetType.Photo: UpdateImage(); break;
        }
    }

    void UpdateModel() {
        if (model == null) return;
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                lastTouch = touch.position;
                draggin = true;
            }
            else if (touch.phase == TouchPhase.Moved && draggin)
            {
                Vector3 diff = touch.position - lastTouch;
                model.transform.rotation = Quaternion.Euler(0, -diff.x * 0.5f, 0) * model.transform.rotation;
                lastTouch = touch.position;
            }
        }
        else
            draggin = false;
    }

    void UpdateImage() {
#if UNITY_EDITOR
        if( Input.GetMouseButton(0) ) {
            float dx = canvas.pixelRect.width / 1280.0f;
            float dy = canvas.pixelRect.height / 720.0f;
            if (!draggin) {
                lastTouch = Input.mousePosition;
                draggin = true;
            }
            else {
                Vector2 diff = ((Vector2)Input.mousePosition - lastTouch) ;
                lastTouch = Input.mousePosition;
                offset += new Vector2(diff.x / dx, -diff.y / dy);
            }
            if (!Input.GetKey(KeyCode.LeftShift)) zoomSize -= 10;
            if (!Input.GetKey(KeyCode.RightShift)) zoomSize += 10;
            if (zoomSize < textureSize.x) zoomSize = textureSize.x;
            if (zoomSize > textureSize.x*4) zoomSize = textureSize.x * 4;

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
                    float dx = canvas.pixelRect.width / 1280.0f;
                    float dy = canvas.pixelRect.height / 720.0f;
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
            rectTransform.offsetMin = new Vector2(offset.x - textureSize.x * 0.5f * zoom, -textureSize.y * 0.5f * zoom - offset.y);
            rectTransform.offsetMax = new Vector2(offset.x + textureSize.x * 0.5f * zoom,  textureSize.y * 0.5f * zoom - offset.y);
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
//        if (ViewerLight != null) Destroy(ViewerLight.gameObject);
        if (ViewerCamera!=null) Destroy(ViewerCamera.gameObject);
        if (model != null) Destroy(model);
        if (assetbundle != null) assetbundle.Unload(true);
        if (image.sprite != null) { Destroy(image.sprite); image.sprite = null; }

        if (this.endCallback != null) this.endCallback();

    }

    public void Close() {
        enabled = false;
    }
}
#endif