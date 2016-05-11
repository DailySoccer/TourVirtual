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

	public void ShowGoodiesShop() {
		GoodiesShopController.Show ();
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
        foreach (var item in items){
            if (item.ProductId.Contains("10000"))       item6.text = item.MarketPriceAndCurrency;
            else if (item.ProductId.Contains("3600"))   item5.text = item.MarketPriceAndCurrency;
            else if (item.ProductId.Contains("1600"))   item4.text = item.MarketPriceAndCurrency;
            else if (item.ProductId.Contains("700"))    item3.text = item.MarketPriceAndCurrency;
            else if (item.ProductId.Contains("375"))    item2.text = item.MarketPriceAndCurrency;
            else if (item.ProductId.Contains("100"))    item1.text = item.MarketPriceAndCurrency;
            else Debug.LogError("Producto raro " + item.ProductId);
        }
    }

    public void Product_ClickHandle(string iapId) {
        if (PlayerPrefs.HasKey("PurchasePendingId") && PlayerPrefs.HasKey("PurchasePendingReceipt"))
        {
            // Hay otra compra pendiente...
            LoadingCanvasManager.Show("TVB.Message.BuyPending");
        }
        else
        {
#if UNITY_ANDROID
            iapId = "and" + iapId;
#elif UNITY_IOS
            iapId = "ios" + iapId;
#elif UNITY_WSA
            iapId = "win" + iapId;
#endif
            StartCoroutine(Buy(iapId));
        }
    }

    IEnumerator Buy(string id)
    {
        LoadingCanvasManager.Show("TVB.Message.Buying");
        yield return null;
        StoreInventory.BuyItem(id);

    }
}
