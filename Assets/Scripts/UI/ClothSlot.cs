using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ClothSlot : MonoBehaviour {

	public Text ClothName;
	public Image Picture;
	public Text Price;

	// Use this for initialization
	void Start () {
		Reset ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Reset() {
		ClothName.text = "";
		Price.text = "";
	}

	public void SetupSlot(string productName, Sprite ProductPicture, string ProductPrice) {
		ClothName.text = productName;
		Picture.sprite = ProductPicture;
		Price.text = ProductPrice;
	}

}
