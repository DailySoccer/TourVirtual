using UnityEngine;
using Soomla;
using Soomla.Store;
using System.Collections;
using System.Collections.Generic;

public class GoodiesShopController : MonoBehaviour {

	public static GoodiesShopController Instance { get; private set; }	
	public GUIPopUpScreen thisModal;
	public delegate void callback();
	private callback okCallback;

    public UnityEngine.UI.Text item1;
    public UnityEngine.UI.Text item2;
    public UnityEngine.UI.Text item3;
    public UnityEngine.UI.Text item4;
    public UnityEngine.UI.Text item5;
    public UnityEngine.UI.Text item6;

	void Awake () {
		Instance = this;
		thisModal.IsOpen = false;
		thisModal = GetComponent<GUIPopUpScreen> ();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public static void Show(callback _callback=null) {
		Instance.okCallback = _callback;
		Instance.thisModal.IsOpen = true;
	}

	public static void CloseModal() {
		if (Instance.okCallback != null) Instance.okCallback();
		Instance.thisModal.IsOpen = false;
	}

	public void CloseGoodiesShop() {
		GoodiesShopController.CloseModal ();
	}

    public void ItemsRefresh(List<MarketItem> items)
    {
        foreach (var item in items)
        {
            switch (item.ProductId)
            {
                case "100coins":
                    item1.text = item.MarketPriceAndCurrency;
                    break;
                case "375coins":
                    item1.text = item.MarketPriceAndCurrency;
                    break;
                case "700coins":
                    item1.text = item.MarketPriceAndCurrency;
                    break;
                case "1600coins":
                    item1.text = item.MarketPriceAndCurrency;
                    break;
                case "3600coins":
                    item1.text = item.MarketPriceAndCurrency;
                    break;
                case "10000coins":
                    item1.text = item.MarketPriceAndCurrency;
                    break;
            }
        }
    }

    public void Product_ClickHandle(string iapId) {
        
        Debug.LogError(">>>> " + iapId);
        StartCoroutine(Buy("100coins"));
    }

    IEnumerator Buy(string id)
    {
        LoadingCanvasManager.Show();
        yield return null;
        StoreInventory.BuyItem(id);

    }
}
