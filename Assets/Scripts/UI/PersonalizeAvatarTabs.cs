using UnityEngine;
using System.Collections;

public enum ProductType {
	TShirt,
	Complement,
	Shoe,
	Pack
}

public class PersonalizeAvatarTabs : MonoBehaviour {

	public GameObject ClothSlot;

	public GameObject TShirtsListWrapperParent;
	public ClothesTab TShirtsTab;
	private Transform TShirtsList;

	public GameObject ComplementsListWrapperParent;
	public ClothesTab ComplementsTab;
	private Transform ComplementsList;

	public GameObject ShoesListWrapperParent;
	public ClothesTab ShoesTab;
	private Transform ShoesList;

	public GameObject PacksListWrapperParent;
	public ClothesTab PacksTab;
	private Transform PacksList;

	// Use this for initialization
	void OnEnable () {
		ShowTShirtsList ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void ShowTShirtsList() {
		HideAllLists();
		TShirtsListWrapperParent.SetActive (true);
		TShirtsTab.IsTabActive = true;
	}

	public void ShowComplementsList() {
		HideAllLists();
		ComplementsListWrapperParent.SetActive (true);
		ComplementsTab.IsTabActive = true;
	}

	public void ShowShoesList() {
		HideAllLists();
		ShoesListWrapperParent.SetActive (true);
		ShoesTab.IsTabActive = true;
	}

	public void ShowPacksList() {
		HideAllLists();
		PacksListWrapperParent.SetActive (true);
		PacksTab.IsTabActive = true;
	}

	private void HideAllLists() {
		TShirtsListWrapperParent.SetActive(false);
		ComplementsListWrapperParent.SetActive(false);
		ShoesListWrapperParent.SetActive(false);
		PacksListWrapperParent.SetActive(false);

		DeactivateAllTabs ();
	}

	private void DeactivateAllTabs() {
		TShirtsTab.IsTabActive = false;
		ComplementsTab.IsTabActive = false;
		ShoesTab.IsTabActive = false;
		PacksTab.IsTabActive = false;
	}

	public void AddSloth(ProductType productType, string productName, Sprite productPicture, string productPrice) {
		GameObject slot = Instantiate(ClothSlot);
		switch (productType) {
		case ProductType.TShirt:
			slot.transform.parent = TShirtsList;
			break;
		case ProductType.Complement:
			slot.transform.parent = ComplementsList;
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
	}

}
