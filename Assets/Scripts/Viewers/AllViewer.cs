#if !LITE_VERSION

using UnityEngine;
using System.Collections;

public class AllViewer : MonoBehaviour
{
    public enum ViewerMode{
        None,
        Image,
        Model,
        Video
    };

    ViewerMode currentMode= ViewerMode.None;
    Coroutine lastCoroutine;
    Camera ViewerCamera;
    GameObject model;
    Vector2 lastTouch;
    bool draggin = false;

    Vector2 textureSize;
    Texture2D texture;
    float zoomSize = 1;
    Vector2 midScreen;
    float orthoZoomSpeed = 5f;
    Vector2 offset = Vector2.zero;

    public static AllViewer Instance { get; private set;  }

    void Awake() {
        Instance = this;
        enabled = false;
    }

    // Use this for initialization
    public void Show(string url, ViewerMode mode )
    {
        currentMode = mode;
        enabled = true;
        CanvasManager cm = gameObject.GetComponent<CanvasManager>();

        cm.ShowScreen(null); //<- Esto seria la ventana con el boton de cierre.

        cm.UIScreensCamera.SetActive(false);
        cm.MainCamera.SetActive(false);

        switch(mode) {
            case ViewerMode.Image:
                lastCoroutine = StartCoroutine(DownloadImage("https://az726872.vo.msecnd.net/global-contentasset/asset_92d476d9-7c95-4102-8d7d-b9f18c1fadc7.jpg"));
                midScreen = new Vector2(Screen.width, Screen.height) * 0.5f;
                break;
            case ViewerMode.Model:
                ViewerCamera = new GameObject("ViewerCamera", typeof(Camera)).GetComponent<Camera>();
                ViewerCamera.clearFlags = CameraClearFlags.SolidColor;
                ViewerCamera.backgroundColor = Color.black;
                ViewerCamera.gameObject.layer= LayerMask.NameToLayer("UI");

                var light = new GameObject("Light", typeof(Light)).GetComponent<Light>();
                light.transform.rotation = Quaternion.Euler(50, 330, 0);
                light.transform.parent = ViewerCamera.transform;
                string AssetsUrl = "file://" + Application.dataPath + "/WebPlayerTemplates/AssetBundles/Android/content/copaforonda";
                //string AssetsUrl = "file://" + Application.dataPath + "/WebPlayerTemplates/AssetBundles/Android/content/championsorejona";
                lastCoroutine = StartCoroutine(DownloadModel(AssetsUrl));
                break;
        }
    }

    // mostrar descarga...
    IEnumerator DownloadModel(string url) {
        LoadingCanvasManager.Show();
        WWW www = new WWW(url);
        LoadingCanvasManager.Hide();
        yield return www;
        var names = www.assetBundle.GetAllAssetNames();
        model = GameObject.Instantiate<GameObject>(www.assetBundle.LoadAsset<GameObject>(names[0]));
        float size = model.GetComponent<Renderer>().bounds.size.y;
        model.layer = LayerMask.NameToLayer("UI");
        model.transform.position = new Vector3(0, -size * 0.35f, size*2);
    }

    IEnumerator DownloadImage(string url) {
        LoadingCanvasManager.Show();
        WWW www = new WWW(url);
        yield return www;
        LoadingCanvasManager.Hide();
        texture = www.texture;
        textureSize = new Vector2(texture.width, texture.height);
        if (textureSize.x > textureSize.y) {
            float scale = 1;
            if (textureSize.x > Screen.width) {
                scale = Screen.width / textureSize.x;
                textureSize.x = Screen.width;
                textureSize.y *= scale;
            }
        }
        else {
            float scale = 1;
            if (textureSize.y > Screen.height) {
                scale = Screen.height / textureSize.y;
                textureSize.y = Screen.height;
                textureSize.x *= scale;
            }
        }

        zoomSize = textureSize.x;
    }


    void Update() {
        switch (currentMode) {
            case ViewerMode.Model: UpdateModel(); break;
            case ViewerMode.Image: UpdateImage(); break;
        }
    }

    void UpdateModel() {
        if (Input.touchCount == 1) {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began) {
                lastTouch = touch.position;
                draggin = true;
            }
            else if (touch.phase == TouchPhase.Moved && draggin) {
                Vector3 diff = touch.position - lastTouch;
                model.transform.Rotate(Vector3.up, diff.x);
                lastTouch = touch.position;
            }
        }
        else
            draggin = false;
    }

    void UpdateImage()
    {
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
                    Touch touch = Input.GetTouch(0);
                    Vector3 diff = Input.GetTouch(0).position - lastTouch;
                    lastTouch = Input.GetTouch(0).position;
                    offset += new Vector2(diff.x, -diff.y);
                }
            }
            else
                draggin = false;
        }
    }

    void OnGUI()
    {
        if (texture)
        {
            float zoom = zoomSize / textureSize.x;
            if (zoom < 1) zoom = 1;
            Rect r = new Rect(offset.x + midScreen.x - textureSize.x * 0.5f * zoom, offset.y + midScreen.y - textureSize.y * 0.5f * zoom,
                textureSize.x * zoom, textureSize.y * zoom);
            GUI.DrawTexture(r, texture);
        }
    }


    void OnDisable() {
        Destroy(ViewerCamera);
        Destroy(model);
    }
}
#endif