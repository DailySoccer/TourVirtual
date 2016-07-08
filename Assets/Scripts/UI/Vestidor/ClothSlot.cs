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

	public bool isClicked{ get; set;}

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

		UpdateSelection (UserAPI.AvatarDesciptor);

		StartCoroutine(MyTools.LoadSpriteFromURL (item.Image, Picture.gameObject));
	}

	public void UpdateSelection(AvatarAPI tmpAvatar) {
		Background.color = CheckSelected (tmpAvatar) ? new Color (38.0f/255.0f, 109.0f/255.0f, 174.0f/255.0f) : new Color (1.0f, 1.0f, 1.0f);
	}

	bool CheckSelected(AvatarAPI tmpAvatar) {

		if (virtualGood == null) {
			Debug.LogError (">>>>> [ClothSlot] in " + name + ": ClothSlot con VirtualGood NULL. Mi subtipo es: " + VirtualGoodSubtype);
			return false;
		}
		//indexes { Gender, Hair, Hat || Head, Torso, Legs, Feet, Compliment };

		switch (virtualGood.IdSubType) {
			case "HTORSO":
			case "MTORSO":
			return tmpAvatar.Torso  == virtualGood.GUID && isClicked;
				break;
			case "HLEG":
			case "MLEG":
				return tmpAvatar.Legs  == virtualGood.GUID && isClicked;
				break;
			case "HSHOE":
			case "MSHOE":
				return tmpAvatar.Feet  == virtualGood.GUID && isClicked;
				break;
			case "HCOMPLIMENT":
			case "MCOMPLIMENT":
				return tmpAvatar.Compliment  == virtualGood.GUID && isClicked;
				break;
			case "HHAT":
			case "MHAT":
				return tmpAvatar.Hat == virtualGood.GUID && isClicked;
				break;
			case "HPACK":
			case "MPACK":
				return tmpAvatar.Pack == virtualGood.GUID && isClicked;
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
            Material mat = Picture.material;
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
