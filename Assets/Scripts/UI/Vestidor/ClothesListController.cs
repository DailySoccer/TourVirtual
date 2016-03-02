using UnityEngine;
using UnityEngine.UI;
using System.Collections;

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

	VirtualGoodsAPI.VirtualGood tshirts;

	//Virtualgood Item subtypes
	enum SubType {
		TORSO, 
		SHOE, 
		COMPLIMENT,
		HAT,
		PACK
	};

	// Use this for initialization
	void Start () {
		// asignamos las listas;
		TShirtsList = GameObject.FindGameObjectWithTag ("TShirtsList").transform;
		ComplimentsList = GameObject.FindGameObjectWithTag ("ComplimentsList").transform;
		ShoesList = GameObject.FindGameObjectWithTag ("ShoesList").transform;
		PacksList = GameObject.FindGameObjectWithTag ("PacksList").transform;

		ShowTShirtsList ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void CleanProductLists() {
		foreach (Transform t in TShirtsList) {
			Destroy(t.gameObject);
		}
		foreach (Transform t in ShoesList) {
			Destroy(t.gameObject);
		}
		foreach (Transform t in PacksList) {
			Destroy(t.gameObject);
		}
		foreach (Transform t in ComplimentsList) {
			Destroy(t.gameObject);
		}
	}

	public void SetupVestidor() {
		CleanProductLists ();
		//UserAPI.VirtualGoodsDesciptor.VirtualGoods

		foreach (var vg in UserAPI.VirtualGoodsDesciptor.VirtualGoods) {
			GameObject cloth = Instantiate(Slot);
			VirtualGoodsAPI.VirtualGood item = (VirtualGoodsAPI.VirtualGood)vg.Value;
			ClothSlot cs = cloth.GetComponent<ClothSlot>();
			cs.SetupSlot(item);		
			
			// Añadimos el elemento a la lista correspondiente
			switch(item.IdSubType){
			case "MTORSO":
			case "HTORSO":
				cloth.transform.SetParent(TShirtsList);
				break;
			case "MSHOE":
			case "HSHOE":
				cloth.transform.SetParent(ShoesList);
				break;
			case "MPACK":
			case "HPACK":
				cloth.transform.SetParent(PacksList);
				break;
			case "MHAT":
			case "HHAT":
			case "MCOMPLIMENT":
			case "HCOMPLIMENT":
				cloth.transform.SetParent(ComplimentsList);
				break;
			default:
				Destroy (cloth);
				//Debug.LogError("VESTIDOR CONTROLLER: Me llegan elementos a la tienda que contemplo, como por ejemplo [" + item.IdSubType + "]" );
				break;
			}
			cloth.name = item.Description;
			cloth.transform.localScale = Vector3.one;
		}
	}

	public void ShowTShirtsList() {
		HideAllLists();
		TShirtsListWrapperParent.SetActive (true);
		TShirtsTab.IsTabActive = true;
		SetupVestidor ();
		currentProductList = ProductType.TShirt;
	}

	public void ShowComplementsList() {
		HideAllLists();
		ComplimentsListWrapperParent.SetActive (true);
		ComplimentsTab.IsTabActive = true;
		SetupVestidor ();
		currentProductList = ProductType.Complement;
	}

	public void ShowShoesList() {
		HideAllLists();
		ShoesListWrapperParent.SetActive (true);
		ShoesTab.IsTabActive = true;
		SetupVestidor ();
		currentProductList = ProductType.Shoe;
	}

	public void ShowPacksList() {
		HideAllLists();
		PacksListWrapperParent.SetActive (true);
		PacksTab.IsTabActive = true;
		SetupVestidor ();
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

	/*
	public void AddSloth(ProductType productType, string productName, Sprite productPicture, string productPrice) {
		GameObject slot = Instantiate(Slot);
		switch (productType) {
		case ProductType.TShirt:
			slot.transform.parent = TShirtsList;
			break;
		case ProductType.Complement:
			slot.transform.parent = ComplimentsList;
			break;
		case ProductType.Shoe:
			slot.transform.parent = ShoesList;
			break;
		case ProductType.Pack:
			slot.transform.parent = PacksList;
			break;
		}
		slot.transform.localScale = Vector3.one;
		slot.name = "Slot_" + productName;
		slot.GetComponent<ClothSlot> ().SetupSlot (productName, productPicture, productPrice);
	}*/

}
