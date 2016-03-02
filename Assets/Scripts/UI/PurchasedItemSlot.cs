using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PurchasedItemSlot : MonoBehaviour {

	public Text ItemName;
	public Image Picture;

	PopUpWindow theParentController;

	// Use this for initialization
	void Start () {	
	}
	
	// Update is called once per frame
	void Update () {	
	}

	public void Reset() {
		ItemName.text = "";
	}

	public void SetupSlot(PopUpWindow parentController, string productName, string ProductPicture) {
		StartCoroutine( LoadSprite (ProductPicture) );
		ItemName.text = productName;
		theParentController = parentController;
	}

	public void PurchasedItemSlot_ClickHandle() {
		theParentController.PurchasedItemSlot_Click(this);
	}
	
	IEnumerator LoadSprite( string url)
	{
		WWW www = new WWW(url);
		yield return www; 
		
		Picture.sprite = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), Vector2.zero, 100.0f);
		//yield return true;
	}
}
