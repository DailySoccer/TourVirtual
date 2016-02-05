using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[ExecuteInEditMode]
public class Contenidos : MonoBehaviour {

	public Sprite VideoIcon;
	public Sprite VideoPlaceholder;
	public Sprite PictureIcon;
	public Sprite PicturePlaceHolder;
	public Sprite AudioIcon;
	public Sprite AudioPlaceHolder;
	public Sprite Model3DIcon;
	//public Sprite Model3DPlaceholder;

	public Image ImageSampleContent;
	public GameObject FullScreenButton;
	public Image IconForContentTypeObject;

	public PurchasedContentType CurrentType;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		switch (CurrentType) {
		case PurchasedContentType.VIDEO:
			IconForContentTypeObject.sprite = VideoIcon;
			ImageSampleContent.sprite = VideoPlaceholder;
			FullScreenButton.SetActive(false);
			break;
		case PurchasedContentType.PICTURE:
			IconForContentTypeObject.sprite = PictureIcon;
			ImageSampleContent.sprite = PicturePlaceHolder;
			FullScreenButton.SetActive(true);
			break;
		case PurchasedContentType.AUDIO:
			IconForContentTypeObject.sprite = AudioIcon;
			ImageSampleContent.sprite = AudioPlaceHolder;
			FullScreenButton.SetActive(false);
			break;
		case PurchasedContentType.MODEL3D:
			IconForContentTypeObject.sprite = Model3DIcon;
			ImageSampleContent.sprite = null;
			FullScreenButton.SetActive(true);
			break;
		}
	}
}
