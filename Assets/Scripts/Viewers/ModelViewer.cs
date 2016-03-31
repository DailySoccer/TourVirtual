#if !LITE_VERSION
using UnityEngine;
using System.Collections;

public class ModelViewer : MonoBehaviour
{
    Coroutine lastCoroutine;


    // Use this for initialization
    void Start()
    {
//        lastCoroutine = StartCoroutine(DownloadImage("https://az726872.vo.msecnd.net/global-contentasset/asset_92d476d9-7c95-4102-8d7d-b9f18c1fadc7.jpg"));
    }

    IEnumerator DownloadImage(string url)
    {
        yield return null;
    }

    void Update()
    {
    }

}
#endif