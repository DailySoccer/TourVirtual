#if !LITE_VERSION

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
	public Text     DescriptionText;

	public void SetupSlot(ContentAPI.AssetType type, string thumbURL, string description) {

		StartCoroutine(MyTools.LoadSpriteFromURL (thumbURL, ItemPictureObject.gameObject));
		DescriptionText.text = description;

		switch (type) {
		case ContentAPI.AssetType.Video:
			IconForContentTypeObject.sprite = VideoIcon;
			break;
		case ContentAPI.AssetType.Photo:
			IconForContentTypeObject.sprite = PictureIcon;
			break;
		case ContentAPI.AssetType.Audio:
			IconForContentTypeObject.sprite = Audioicon;
			break;
		case ContentAPI.AssetType.Model3D:
			IconForContentTypeObject.sprite = Model3DIcon;
			break;
		}
	}
	/*
	public void Reset() {
		ItemPictureObject.sprite = null;
		DescriptionText.text = "";
		CurrentType = ContentType.VIDEO;
	}*/
}

#endif