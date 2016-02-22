using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public enum DetailedContent2ButtonsLayout {
	GOTOSHOP,
	BUYITEM,
	SHARE
}

public class DetailedContent2Buttons : MonoBehaviour {

	public Text TheName;
	public Image ThePicture;
	public GameObject CancelButton;
	public GameObject GotoShopButton;
	public GameObject BuyButton;
	public GameObject ShareButton;

	[SerializeField]
	private DetailedContent2ButtonsLayout _CurrentLayout;

	public DetailedContent2ButtonsLayout CurrentLayout {
		get{ return _CurrentLayout;}
		set{ _CurrentLayout = value;}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		switch (_CurrentLayout) {
		case DetailedContent2ButtonsLayout.BUYITEM:
			CancelButton.SetActive(true);
			BuyButton.SetActive(true);
			GotoShopButton.SetActive(false);
			ShareButton.SetActive(false);
			break;
		case DetailedContent2ButtonsLayout.GOTOSHOP:
			CancelButton.SetActive(true);
			BuyButton.SetActive(false);
			GotoShopButton.SetActive(true);
			ShareButton.SetActive(false);
			break;
		case DetailedContent2ButtonsLayout.SHARE:
			CancelButton.SetActive(false);
			BuyButton.SetActive(false);
			GotoShopButton.SetActive(false);
			ShareButton.SetActive(true);
			break;
		}
	}
}
