using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public enum PopUpState {
	PURCHASED_ITEMS_GRID,
	PURCHASED_ITEM_CONTENT_LIST,
}

public class PopUpWindow : MonoBehaviour {

	public Text Title;
	public GameObject CloseButton;
	public GameObject ShareButton;
	//public GameObject ContentGrid;
	//public GameObject ContentVerticalList;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ResetWindow() {
		Title.text = "";
		CloseButton.SetActive (true);
		ShareButton.SetActive (false);
	}
}
