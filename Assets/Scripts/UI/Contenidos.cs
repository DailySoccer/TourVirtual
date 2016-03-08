using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//[ExecuteInEditMode]
public class Contenidos : MonoBehaviour {

	public Sprite VideoIcon;
	public Sprite PictureIcon;
	public Sprite AudioIcon;
	public Sprite Model3DIcon;
	//public Sprite Model3DPlaceholder;

	public Image ImageSampleContent;
	public GameObject FullScreenButton;
	public Image IconForContentTypeObject;

	public ContentType CurrentType;
    Coroutine lastCoroutine;
    // Use this for initialization
    void Start () {
        lastCoroutine = StartCoroutine(DownloadImage("https://az726872.vo.msecnd.net/global-contentasset/asset_92d476d9-7c95-4102-8d7d-b9f18c1fadc7_thumbnail.jpg"));
    }

    IEnumerator DownloadImage(string url){
        WWW www = new WWW(url);
        yield return www;
        Texture2D txt = www.texture;
        if (txt != null) {
            Sprite spr = Sprite.Create(txt, new Rect(0, 0, txt.width, txt.height), new Vector2(0.5f, 0.5f));
            ImageSampleContent.sprite = spr;
        }
        else
            Debug.LogError(">>>> ERROR AL DESCARGAR LA TEXTURA");
    }

    // Update is called once per frame
    void Update () {
		switch (CurrentType) {
		case ContentType.VIDEO:
			IconForContentTypeObject.sprite = VideoIcon;
			FullScreenButton.SetActive(false);
			break;
		case ContentType.PICTURE:
			IconForContentTypeObject.sprite = PictureIcon;
			FullScreenButton.SetActive(true);
			break;
		case ContentType.AUDIO:
			IconForContentTypeObject.sprite = AudioIcon;
			FullScreenButton.SetActive(false);
			break;
		case ContentType.MODEL3D:
			IconForContentTypeObject.sprite = Model3DIcon;
			ImageSampleContent.sprite = null;
			FullScreenButton.SetActive(true);
			break;
		}
	}
}
