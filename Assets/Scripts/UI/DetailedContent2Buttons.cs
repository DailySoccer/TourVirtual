using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public enum DetailedContent2ButtonsLayout {
    NONE,
	GOTOSHOP,
	BUYITEM,
	SHARE,
	OK_ONLY
}

public class DetailedContent2Buttons : MonoBehaviour {

	public Text TheName;
	public Image ThePicture;
	public GameObject OKButton;
	public GameObject CancelButton;
	public GameObject GotoShopButton;
	public GameObject BuyButton;
	public GameObject ShareButton;

	[SerializeField]
    private DetailedContent2ButtonsLayout _CurrentLayout;
    public DetailedContent2ButtonsLayout CurrentLayout {
		get{ return _CurrentLayout;}
		set{ if (_CurrentLayout != value) MyUpdate(value);  }
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	public void MyUpdate (DetailedContent2ButtonsLayout value) {
        _CurrentLayout = value;
        switch (_CurrentLayout) {
		case DetailedContent2ButtonsLayout.BUYITEM:
			CancelButton.SetActive(true);
			BuyButton.SetActive(true);
			GotoShopButton.SetActive(false);
			if(ShareButton!=null) ShareButton.SetActive(false);
			break;
		case DetailedContent2ButtonsLayout.GOTOSHOP:
			CancelButton.SetActive(true);
			BuyButton.SetActive(false);
			GotoShopButton.SetActive(true);
                if (ShareButton != null) ShareButton.SetActive(false);
			break;
		case DetailedContent2ButtonsLayout.SHARE:
			CancelButton.SetActive(false);
			BuyButton.SetActive(false);
			GotoShopButton.SetActive(false);
                if (ShareButton != null) ShareButton.SetActive(true);
			break;
		case DetailedContent2ButtonsLayout.OK_ONLY:
			OKButton.SetActive(true);
			CancelButton.SetActive(false);
			BuyButton.SetActive(false);
			GotoShopButton.SetActive(false);
                if (ShareButton != null) ShareButton.SetActive(false);
			break;
		}
	}
}
