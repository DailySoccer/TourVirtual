#if !LITE_VERSION

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PurchasedItemSlot : MonoBehaviour {

	public ContentAPI.Content Content;
	public Text PurchasedPackName;
	public Image Picture;
	public string TheID { get; private set; }

	PopUpWindow theParentController;

	// Use this for initialization
	void Start () {	
	}
	
	// Update is called once per frame
	void Update () {	
	}

	public void Reset() {
		PurchasedPackName.text = "";
		Picture.sprite = null;
	}

	public void SetupSlot(PopUpWindow parentController, ContentAPI.Content item){//string productName, string pictureUrl, string theId) {
		theParentController = parentController;
		Content = item;
		StartCoroutine(MyTools.LoadSpriteFromURL(Content.ThumbURL, Picture.gameObject));
		PurchasedPackName.text = Content.Description;//productName;
		TheID = Content.VirtualGoodID;//theId;
	}

	public void PurchasedItemSlot_ClickHandle() {
		theParentController.PurchasedItemSlot_Click(this);
	}

}

#endif