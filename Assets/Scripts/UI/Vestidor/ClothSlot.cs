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

		StartCoroutine(MyTools.LoadSpriteFromURL (item.Image, Picture.gameObject));
	}

	public void Slot_ClickHandle() {
		VestidorControllerInstance.TryToDressPlayer (this);
	}
}
