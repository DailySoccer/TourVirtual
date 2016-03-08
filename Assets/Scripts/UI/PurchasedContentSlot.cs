using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public enum ContentType {
	VIDEO,
	PICTURE,
	AUDIO,
	MODEL3D
}

//[ExecuteInEditMode]
public class PurchasedContentSlot : MonoBehaviour {

	public ContentType CurrentType;

	public Sprite   VideoIcon;
	public Sprite   PictureIcon;
	public Sprite   Audioicon;
	public Sprite   Model3DIcon;

	public Image    ItemPictureObject;
	public Image    IconForContentTypeObject;
	public Text     DesprictionText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		switch (CurrentType) {
		    case ContentType.VIDEO:
			    IconForContentTypeObject.sprite = VideoIcon;
			    break;
		    case ContentType.PICTURE:
			    IconForContentTypeObject.sprite = PictureIcon;
			    break;
		    case ContentType.AUDIO:
			    IconForContentTypeObject.sprite = Audioicon;
			    break;
		    case ContentType.MODEL3D:
			    IconForContentTypeObject.sprite = Model3DIcon;
			    break;
		}
	}

	public void Reset() {
		ItemPictureObject.sprite = null;
		DesprictionText.text = "";
		CurrentType = ContentType.VIDEO;
	}
}
