using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[ExecuteInEditMode]
public class Contenidos : MonoBehaviour {

	public Sprite VideoIcon;
	public Sprite PictureIcon;
	public Sprite Audioicon;
	public Sprite Model3DIcon;

	public PurchasedContentType CurrentType;
	public Image IconForContentTypeObject;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		switch (CurrentType) {
		case PurchasedContentType.VIDEO:
			IconForContentTypeObject.sprite = VideoIcon;
			break;
		case PurchasedContentType.PICTURE:
			IconForContentTypeObject.sprite = PictureIcon;
			break;
		case PurchasedContentType.AUDIO:
			IconForContentTypeObject.sprite = Audioicon;
			break;
		case PurchasedContentType.MODEL3D:
			IconForContentTypeObject.sprite = Model3DIcon;
			break;
		}
	}
}
