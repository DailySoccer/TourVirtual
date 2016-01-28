using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ClothSlot : MonoBehaviour {

	public Text Name;
	public Sprite Picture;
	public Text Price;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetupSlot(string productName, Sprite ProductPicture, string ProductPrice) {
		Name.text = productName;
		Picture = ProductPicture;
		Price.text = ProductPrice;
	}

}
