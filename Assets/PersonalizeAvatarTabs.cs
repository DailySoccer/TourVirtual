using UnityEngine;
using System.Collections;

public class PersonalizeAvatarTabs : MonoBehaviour {

	public ClothesTab TShirtsTab;
	public ClothesTab ComplementsTab;
	public ClothesTab ShoesTab;
	public ClothesTab PacksTab;


	public GameObject TShirtList;
	public GameObject ComplementsList;
	public GameObject ShoesList;
	public GameObject PacksList;

	// Use this for initialization
	void OnEnable () {
		ShowTShirtsList ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void ShowTShirtsList() {
		HideAllLists();
		TShirtList.SetActive (true);
		TShirtsTab.IsTabActive = true;
	}

	public void ShowComplementsList() {
		HideAllLists();
		ComplementsList.SetActive (true);
		ComplementsTab.IsTabActive = true;
	}

	public void ShowShoesList() {
		HideAllLists();
		ShoesList.SetActive (true);
		ShoesTab.IsTabActive = true;
	}

	public void ShowPacksList() {
		HideAllLists();
		PacksList.SetActive (true);
		PacksTab.IsTabActive = true;
	}

	private void HideAllLists() {
		TShirtList.SetActive(false);
		ComplementsList.SetActive(false);
		ShoesList.SetActive(false);
		PacksList.SetActive(false);

		DeactivateAllTabs ();
	}

	private void DeactivateAllTabs() {
		TShirtsTab.IsTabActive = false;
		ComplementsTab.IsTabActive = false;
		ShoesTab.IsTabActive = false;
		PacksTab.IsTabActive = false;
	}

}
