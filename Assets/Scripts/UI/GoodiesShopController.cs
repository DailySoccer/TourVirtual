using UnityEngine;
using Soomla;
using Soomla.Store;
using System.Collections;
using System.Collections.Generic;
using SmartLocalization;

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
    public UnityEngine.UI.Text item7;

	//Botón de comprar todos los contenidos
  	public GameObject purchase7;

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

        // FIX: Ximo 19/05/2017
        Instance.purchase7.SetActive(!VirtualGoodsAPI.HasPurchase7);
	}

	public void ShowGoodiesShop() {
#if UNITY_WSA
        ModalTextOnly.ShowText(LanguageManager.Instance.GetTextValue("TVB.Error.CantBuyOnWindows"),()=> { Authentication.AzureServices.OpenURL("rmapp://You"); });

#else
        GoodiesShopController.Show ();
#endif
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
            if (item.ProductId.Contains("all"))         item7.text = item.MarketPriceAndCurrency;
            else if (item.ProductId.Contains("10000"))  item6.text = item.MarketPriceAndCurrency;
            else if (item.ProductId.Contains("3600"))   item5.text = item.MarketPriceAndCurrency;
            else if (item.ProductId.Contains("1600"))   item4.text = item.MarketPriceAndCurrency;
            else if (item.ProductId.Contains("700"))    item3.text = item.MarketPriceAndCurrency;
            else if (item.ProductId.Contains("375"))    item2.text = item.MarketPriceAndCurrency;
            else if (item.ProductId.Contains("100"))    item1.text = item.MarketPriceAndCurrency;
            else Debug.LogError(">>>> Producto raro " + item.ProductId);
        }
		purchase7.SetActive(!VirtualGoodsAPI.HasPurchase7);
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
        if( PlayerPrefs.HasKey("PurchasePendingId") && PlayerPrefs.HasKey("PurchasePendingReceipt")){
            // Compra pendiente.
        }else{
            LoadingCanvasManager.Show("TVB.Message.Buying");
            yield return null;
            StoreInventory.BuyItem(id);
        }
    }

    // XIMO: 18/05/17
    // Compra de todos los contenidos.   
    public void BuyInApp() {
        Product_ClickHandle("_rmvt_pack_all");
    }

}
