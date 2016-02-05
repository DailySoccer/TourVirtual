using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public enum PurchasedContentType {
	VIDEO,
	PICTURE,
	AUDIO,
	MODEL3D
}

[ExecuteInEditMode]
public class PurchasedContentSlot : MonoBehaviour {

	public PurchasedContentType CurrentType;

	public Sprite VideoIcon;
	public Sprite PictureIcon;
	public Sprite Audioicon;
	public Sprite Model3DIcon;

	public Image ItemPictureObject;
	public Image IconForContentTypeObject;
	public Text DesprictionText;

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

	public void Reset() {
		ItemPictureObject.sprite = null;
		DesprictionText.text = "";
		CurrentType = PurchasedContentType.VIDEO;
	}
}
