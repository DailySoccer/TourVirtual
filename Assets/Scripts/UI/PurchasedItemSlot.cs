using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PurchasedItemSlot : MonoBehaviour {

	public Text ItemName;
	public Image Picture;
	public Text Price;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Reset() {
		ItemName.text = "";
		Price.text = "";
	}

	public void SetupSlot(string productName, Sprite ProductPicture, string ProductPrice) {
		ItemName.text = productName;
		Picture.sprite = ProductPicture;
		Price.text = ProductPrice;
	}

}
