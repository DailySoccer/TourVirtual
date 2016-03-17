using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ClothSlot : MonoBehaviour {
#if !LITE_VERSION
		VestidorCanvasController VestidorControllerInstance;
#else
		VestidorCanvasController_Lite VestidorControllerInstance;
#endif

	public Text ClothName;
	public Image Picture;
	public Text Price;
	public VirtualGoodsAPI.VirtualGood virtualGood;

	// Use this for initialization
	void Start () {
		GameObject vcc = GameObject.FindGameObjectWithTag ("VestidorController");
#if !LITE_VERSION
		VestidorControllerInstance = vcc.GetComponent<VestidorCanvasController> ();
#else
		VestidorControllerInstance = vcc.GetComponent<VestidorCanvasController_Lite> ();
#endif
	}

	public void Reset() {
		ClothName.text = "";
		Price.text = "";
	}

	public void SetupSlot (VirtualGoodsAPI.VirtualGood item) {
		virtualGood = item;

		ClothName.text = item.Description;

		Price.text = item.Price.ToString();
		if (item.count > 0)
			Price.gameObject.SetActive (false);


		StartCoroutine(MyTools.LoadSpriteFromURL (item.Image, Picture.gameObject));
	}

	public void Slot_ClickHandle() {
		VestidorControllerInstance.TryToDressPlayer (this);
	}
}
