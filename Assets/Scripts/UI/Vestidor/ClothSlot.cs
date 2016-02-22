using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ClothSlot : MonoBehaviour {

	VestidorCanvasController VestidorControllerInstance;

	public Text ClothName;
	public Image Picture;
	public Text Price;
	VirtualGoodsAPI.VirtualGood virtualGood;

	// Use this for initialization
	void Start () {
		GameObject vcc = GameObject.FindGameObjectWithTag ("VestidorController");
		VestidorControllerInstance = vcc.GetComponent<VestidorCanvasController> ();
	}

	public void Reset() {
		ClothName.text = "";
		Price.text = "";
	}

	public void SetupSlot (VirtualGoodsAPI.VirtualGood item) {
		virtualGood = item;

		ClothName.text = item.Description;
		
		Price.text = item.Price.ToString();

		StartCoroutine( LoadSprite (item.Image) );
	}

	public void Slot_ClickHandle() {
		VestidorControllerInstance.TryToDressPlayer (this);
	}


	IEnumerator LoadSprite( string url)
	{
		WWW www = new WWW(url);
		yield return www; 

		Picture.sprite = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), Vector2.zero, 100.0f);
		//yield return true;
	}

}
