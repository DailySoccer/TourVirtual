using UnityEngine;
using Soomla;
using Soomla.Store;
using System.Collections;
using System.Collections.Generic;

public class GoodiesShopController : MonoBehaviour {


    public UnityEngine.UI.Text item1;
    public UnityEngine.UI.Text item2;
    public UnityEngine.UI.Text item3;
    public UnityEngine.UI.Text item4;
    public UnityEngine.UI.Text item5;
    public UnityEngine.UI.Text item6;


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
