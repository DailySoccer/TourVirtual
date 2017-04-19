using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public enum ProductType {
	TShirt,
	Complement,
	Shoe,
	Pack
}

public class ClothesListController : MonoBehaviour {

	public GameObject Slot;

	public GameObject TShirtsListWrapperParent;
	public VestidorTab TShirtsTab;
	private Transform TShirtsList;

	public GameObject ComplimentsListWrapperParent;
	public VestidorTab ComplimentsTab;
	private Transform ComplimentsList;

	public GameObject ShoesListWrapperParent;
	public VestidorTab ShoesTab;
	private Transform ShoesList;

	public GameObject PacksListWrapperParent;
	public VestidorTab PacksTab;
	private Transform PacksList;

	ProductType currentProductList;

	//VirtualGoodsAPI.VirtualGood tshirts;

	public List<GameObject> currentClothesLsit = new List<GameObject>();

	public static ClothesListController Instance { get; private set; }

	AvatarAPI _currentAvatar;


	//Virtualgood Item subtypes
	enum SubType {
		TORSO, 
		SHOE, 
		COMPLIMENT,
		HAT,
		PACK
	};


	void Awake() {
		Instance = this;
	}

	void Start() {
        // asignamos las listas;
        try
        {
            TShirtsList = GameObject.FindGameObjectWithTag("TShirtsList").transform;
            ComplimentsList = GameObject.FindGameObjectWithTag("ComplimentsList").transform;
            ShoesList = GameObject.FindGameObjectWithTag("ShoesList").transform;
            PacksList = GameObject.FindGameObjectWithTag("PacksList").transform;
			
			if( MainManager.VestidorMode != VestidorCanvasController_Lite.VestidorState.SELECT_AVATAR )
            	ShowTShirtsList();

        }
        catch (UnityException e){
            Debug.LogError("<<<<< ERROR!!!! MIRARA ESTO!!!!! >>>>>: " + e.Message);
        }
	}
	
	// Update is called once per frame
	void Update () {
	}
	 
	void CleanProductLists() {
		foreach (GameObject go in currentClothesLsit) {
			Destroy (go);
		}
		currentClothesLsit.Clear ();
	}

	public void SetupVestidor(ProductType pType) {
		CleanProductLists ();

        if (UserAPI.VirtualGoodsDesciptor == null || UserAPI.VirtualGoodsDesciptor.VirtualGoods == null) return;

		foreach (var vg in UserAPI.VirtualGoodsDesciptor.VirtualGoods) {

			VirtualGoodsAPI.VirtualGood item = (VirtualGoodsAPI.VirtualGood)vg.Value;
			if (pType == GetTVGType (item.IdSubType)) {

				GameObject cloth = Instantiate (Slot);					

				ClothSlot cs = cloth.GetComponent<ClothSlot> ();

				cs.name = item.Description;
				cs.SetupSlot (item);
				// Añadimos el elemento a la lista correspondiente
				switch (item.IdSubType) {
				case "MTORSO":
				case "HTORSO":
					cloth.transform.SetParent (TShirtsList);
					currentClothesLsit.Add(cloth);
					break;
				case "MSHOE":
				case "HSHOE":
					cloth.transform.SetParent (ShoesList);
					currentClothesLsit.Add(cloth);
					break;
				case "MPACK":
				case "HPACK":
					cloth.transform.SetParent (PacksList);
					currentClothesLsit.Add(cloth);
					break;
				case "MHAT":
				case "HHAT":
				case "MCOMPLIMENT":
				case "HCOMPLIMENT":
					cloth.transform.SetParent (ComplimentsList);
					currentClothesLsit.Add(cloth);
					break;
				default:
					Destroy (cloth);
					break;
				}
				if (item.count > 0) cloth.transform.SetAsFirstSibling();
				cloth.name = item.Description;
				cloth.transform.localScale = Vector3.one;
			}
		}
		// Actualizamos la/s selección tras cargar la lista.
		UpdateSelectedSlots ();
	}
	
	ProductType GetTVGType(string vgSubType) {
		if (vgSubType == "MTORSO" || vgSubType == "HTORSO") {
			return ProductType.TShirt;
		} else if (vgSubType == "MSHOE" || vgSubType == "HSHOE") {
			return ProductType.Shoe;
		} else if (vgSubType == "MPACK" || vgSubType == "HPACK") {
			return ProductType.Pack;
		} else if (vgSubType == "MHAT" || vgSubType == "HHAT" || vgSubType == "MCOMPLIMENT" || vgSubType == "HCOMPLIMENT") {
			return ProductType.Complement;
		}
		// Si es algun otro tipo que no conozco, asumo que es un complemento
		return ProductType.Complement;
	}


	public void SetCurrentAvatar(AvatarAPI tmpAvatar) {
		_currentAvatar = tmpAvatar.Copy ();
		UpdateSelectedSlots ();
	}

	public void UpdateSelectedSlots() {
		foreach (GameObject go in currentClothesLsit) {
			ClothSlot cs = go.GetComponent<ClothSlot>();
			cs.UpdateSelection (_currentAvatar);
		}
	}

    public void RefreshList() {
        SetupVestidor (currentProductList);
    }

	public void ShowTShirtsList() {
		HideAllLists();
		TShirtsListWrapperParent.SetActive (true);
		TShirtsTab.IsTabActive = true;
		SetupVestidor (ProductType.TShirt);
		currentProductList = ProductType.TShirt;
	}

	public void ShowComplementsList() {
		HideAllLists();
		ComplimentsListWrapperParent.SetActive (true);
		ComplimentsTab.IsTabActive = true;
		SetupVestidor (ProductType.Complement);
		currentProductList = ProductType.Complement;
	}

	public void ShowShoesList() {
		HideAllLists();
		ShoesListWrapperParent.SetActive (true);
		ShoesTab.IsTabActive = true;
		SetupVestidor (ProductType.Shoe);
		currentProductList = ProductType.Shoe;
	}

	public void ShowPacksList() {
		HideAllLists();
		PacksListWrapperParent.SetActive (true);
		PacksTab.IsTabActive = true;
		SetupVestidor (ProductType.Pack);
		currentProductList = ProductType.Pack;
	}

	private void HideAllLists() {
		TShirtsListWrapperParent.SetActive(false);
		ComplimentsListWrapperParent.SetActive(false);
		ShoesListWrapperParent.SetActive(false);
		PacksListWrapperParent.SetActive(false);

		DeactivateAllTabs ();
	}

	private void DeactivateAllTabs() {
		TShirtsTab.IsTabActive = false;
		ComplimentsTab.IsTabActive = false;
		ShoesTab.IsTabActive = false;
		PacksTab.IsTabActive = false;
	}
}
