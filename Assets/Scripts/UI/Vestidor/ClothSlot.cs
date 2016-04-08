using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ClothSlot : MonoBehaviour {

	VestidorCanvasController_Lite VestidorControllerInstance;

	public Text ClothName;
	public Image Picture;
	public Text Price;
	public VirtualGoodsAPI.VirtualGood virtualGood;

	// Use this for initialization
	void Start () {
		GameObject vcc = GameObject.FindGameObjectWithTag ("VestidorController");
		VestidorControllerInstance = vcc.GetComponent<VestidorCanvasController_Lite> ();
	}

	public void Reset() {
		ClothName.text = "";
		Price.text = "";
	}

	public void SetupSlot (VirtualGoodsAPI.VirtualGood item) {
		virtualGood = item;
        ClothName.text = "";//item.Description;
		Price.text = item.Price.ToString();
		if (item.count > 0)
			Price.gameObject.SetActive (false);


		StartCoroutine(MyTools.LoadSpriteFromURL (item.Image, Picture.gameObject));
	}

	public void Slot_ClickHandle() {
		VestidorControllerInstance.TryToDressPlayer (this);
	}

    void OnDestroy()
    {
        var sprt = Picture.gameObject.GetComponent<Image>().sprite;
        if (sprt != null)
        {
#if !UNITY_WSA
            DestroyImmediate(sprt.texture, true);
            Destroy(sprt);
            Resources.UnloadUnusedAssets();
#else
            var mat = sprt.material;
            if(mat.texture) DestroyImmediate(mat.texture, true);
            Destroy(mat);
#endif
        }
    }
}
