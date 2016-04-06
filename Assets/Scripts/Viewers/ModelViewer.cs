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
    void Start()
    {
        //string AssetsUrl = "file://" + Application.dataPath + "/WebPlayerTemplates/AssetBundles/Android/content/copaforonda";
        //string AssetsUrl = "file://" + Application.dataPath + "/WebPlayerTemplates/AssetBundles/Android/content/championsorejona";
        string AssetsUrl = "https://googledrive.com/host/0B8a_PPkBFGwNdEhYN2JORGtmRUk/championsorejona";
        lastCoroutine = StartCoroutine(DownloadModel(AssetsUrl));
    }

    // mostrar descarga...
    IEnumerator DownloadModel(string url) {
        WWW www = new WWW(url);
        yield return www;
        if (!string.IsNullOrEmpty(www.error)) {
            Camera.current.backgroundColor = Color.red;
            yield break;
        }
        var names = www.assetBundle.GetAllAssetNames();
        Debug.Log(">>>> " + names[0]);
        model = GameObject.Instantiate<GameObject>(www.assetBundle.LoadAsset<GameObject>(names[0]));
        float size = model.GetComponent<Renderer>().bounds.size.y;
        Debug.Log(">>>> " + size);
        model.transform.position = new Vector3(0, -size * 0.5f, size*2);
    }

    void Update() {
        if (Input.touchCount == 1) {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began) {
                lastTouch = touch.position;
                draggin = true;
            }
            else if (touch.phase == TouchPhase.Moved && draggin) {
                Vector3 diff = touch.position - lastTouch;
                model.transform.rotation *= Quaternion.Euler(0,diff.x,0);
                lastTouch = touch.position;
            }
        }
        else
            draggin = false;
    }

    void OnDisable() {
        Destroy(model);
    }
}
#endif