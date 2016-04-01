#if !LITE_VERSION

using UnityEngine;
using System.Collections;

public class ModelViewer : MonoBehaviour
{
    Coroutine lastCoroutine;
    GameObject model;
    Vector2 lastTouch;
    bool draggin = false;

    // Use this for initialization
    void Start() {
//        string AssetsUrl = "file://" + Application.dataPath + "/WebPlayerTemplates/AssetBundles/Android/content/copaforonda";
        string AssetsUrl = "file://" + Application.dataPath + "/WebPlayerTemplates/AssetBundles/Android/content/championsorejona";

        lastCoroutine = StartCoroutine( DownloadModel(AssetsUrl) );
    }
    // mostrar descarga...
    IEnumerator DownloadModel(string url) {
        WWW www = new WWW(url);
        yield return www;
        var names = www.assetBundle.GetAllAssetNames();
        model = GameObject.Instantiate<GameObject>(www.assetBundle.LoadAsset<GameObject>(names[0]) );
    }

    void Update()
    {
        if (Input.touchCount == 1)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                lastTouch = Input.GetTouch(0).position;
                draggin = true;
            }
            else
            if (Input.GetTouch(0).phase == TouchPhase.Moved && draggin)
            {
                Touch touch = Input.GetTouch(0);
                Vector3 diff = Input.GetTouch(0).position - lastTouch;
                lastTouch = Input.GetTouch(0).position;
            }
        }
        else
            draggin = false;
    }
    void OnDisable()
    {
        Destroy(model);

    }

}
#endif