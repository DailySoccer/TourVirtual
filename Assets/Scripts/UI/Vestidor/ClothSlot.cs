using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ClothSlot : MonoBehaviour {

	VestidorCanvasController_Lite VestidorControllerInstance;
	ClothesListController MyParent;

	//public Text ClothName;  // Esto se ha comentado porque se ha decidido no ponerlo.
	public Image Picture;
	public Text Price;
	public Image Background;
	public GameObject LabelOwned;
	public VirtualGoodsAPI.VirtualGood virtualGood;

	string VirtualGoodSubtype;
	
	public void SetupSlot (VirtualGoodsAPI.VirtualGood item) {

		VestidorControllerInstance = VestidorCanvasController_Lite.Instance;

		virtualGood = item;
		VirtualGoodSubtype = item.IdSubType;

        //ClothName.text = "";//item.Description;
		Price.text = item.Price.ToString();
		if (item.count > 0) {
			Price.transform.parent.gameObject.SetActive (false);
			LabelOwned.SetActive (true);
		} else {
			Price.transform.parent.gameObject.SetActive (true);
			LabelOwned.SetActive (false);
		}

		UpdateSelection ();

		StartCoroutine(MyTools.LoadSpriteFromURL (item.Image, Picture.gameObject));
	}

	public void UpdateSelection() {
		Background.color = CheckSelected () ? new Color (0.082f, 0.109f, 0.168f) : new Color (1f, 1f, 1f);
	}

	bool CheckSelected() {

		
		if (virtualGood == null) {
			Debug.LogError (">>>>> [ClothSlot] in " + name + ": ClothSlot con VirtualGood NULL. Mi subtipo es: " + VirtualGoodSubtype);
			return false;
		}

		switch (virtualGood.IdSubType) {
			case "HTORSO":
			case "MTORSO":
				return UserAPI.AvatarDesciptor.Torso == virtualGood.GUID;
				break;
			case "HLEG":
			case "MLEG":
				return UserAPI.AvatarDesciptor.Legs == virtualGood.GUID;
				break;
			case "HSHOE":
			case "MSHOE":
			return UserAPI.AvatarDesciptor.Feet == virtualGood.GUID;
				break;
			case "HCOMPLIMENT":
			case "MCOMPLIMENT":
				return UserAPI.AvatarDesciptor.Compliment == virtualGood.GUID;
				break;
			case "HHAT":
			case "MHAT":
				return UserAPI.AvatarDesciptor.Hat == virtualGood.GUID;
				break;
			case "HPACK":
			case "MPACK":
				return UserAPI.AvatarDesciptor.Pack == virtualGood.GUID;
				break;
		}
		return false;
	}

	public void Slot_ClickHandle() {
		VestidorControllerInstance.TryToDressPlayer (this);
	}

    void OnDestroy()
    {
        var sprt = Picture.sprite;
        if (sprt != null){
#if !UNITY_WSA
            if(sprt.texture!=null) DestroyImmediate(sprt.texture, true);
            Destroy(sprt);
#else
            Material mat = Picture..material;
            if(mat!=null) {
				 if(mat.mainTexture!=null)
					DestroyImmediate(mat.mainTexture, true);
            	Destroy(mat);
			}
#endif
            Resources.UnloadUnusedAssets();
        }
    }
}
