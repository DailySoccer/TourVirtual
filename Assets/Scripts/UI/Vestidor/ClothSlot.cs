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

		//UpdateSelection (UserAPI.AvatarDesciptor);

		StartCoroutine(MyTools.LoadSpriteFromURL (item.Thumb, Picture.gameObject));
	}

	public void UpdateSelection(AvatarAPI tmpAvatar) {
		Background.color = CheckSelected (tmpAvatar) ? new Color (38.0f/255.0f, 109.0f/255.0f, 174.0f/255.0f) : new Color (1.0f, 1.0f, 1.0f);
	}

	bool CheckSelected(AvatarAPI tmpAvatar) {

		if (virtualGood == null || tmpAvatar == null) {
			//Debug.LogError (">>>>> [ClothSlot] in " + name + ": ClothSlot con VirtualGood NULL. Mi subtipo es: " + VirtualGoodSubtype);
			return false;
		}
		//indexes { Gender, Hair, Hat || Head, Torso, Legs, Feet, Compliment };

		switch (virtualGood.IdSubType) {
			case "HTORSO":
			case "MTORSO":
				
				if (tmpAvatar.Torso  == virtualGood.GUID)
					return true;
				return false;

				break;
			case "HLEG":
			case "MLEG":
				if (tmpAvatar.Legs  == virtualGood.GUID)
					return true;
				return false;
				break;
			case "HSHOE":
			case "MSHOE":
				if (tmpAvatar.Feet == virtualGood.GUID)
					return true;
				return false;
				break;
			case "HCOMPLIMENT":
			case "MCOMPLIMENT":
				if (tmpAvatar.Compliment  == virtualGood.GUID)
					return true;
				return false;
				break;
			case "HHAT":
			case "MHAT":
				if (tmpAvatar.Hat  == virtualGood.GUID)
					return true;
				return false;
				break;
			case "HPACK":
			case "MPACK":
				if (tmpAvatar.Pack  == virtualGood.GUID)
					return true;
				return false;
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
