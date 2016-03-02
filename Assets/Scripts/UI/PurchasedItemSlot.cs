using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PurchasedItemSlot : MonoBehaviour {

	public Text PurchasedPackName;
	public Image Picture;

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

	public void SetupSlot(PopUpWindow parentController, string productName, string pictureUrl) {
		StartCoroutine(MyTools.LoadSpriteFromURL(pictureUrl, Picture.sprite));
		PurchasedPackName.text = productName;
		theParentController = parentController;
	}

	public void PurchasedItemSlot_ClickHandle() {
		theParentController.PurchasedItemSlot_Click(this);
	}

}
