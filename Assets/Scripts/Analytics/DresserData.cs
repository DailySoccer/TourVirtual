using UnityEngine;
using UnityEngine.Analytics;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public class DresserData {
    private float _enterTime;
    IDictionary<ProductType, IDictionary<string, int>> viewedClothes;

    private float _enterBuyTime;
    public VirtualGoodsAPI.VirtualGood VirtualGoodToBuy;
    public bool BuyResult;

    public float TotalTimeInSeconds {
        get {
            return Time.time - _enterTime;
        }
    }

    public float TotalBuyTimeInSeconds {
        get {
            return Time.time - _enterBuyTime;
        }
    }

    public string MostViewedCloth(ProductType productType) {
        int countViewed = 0;
        string mostViewed = "";
        if (viewedClothes.ContainsKey(productType)) {
            IDictionary<string, int> clothes = viewedClothes[productType];
            foreach(string clothKey in clothes.Keys) {
                if (clothes[clothKey] > countViewed) {
                    mostViewed = clothKey;
                    countViewed = clothes[clothKey];
                }
            }
        }
        return mostViewed;
    }

    public int CountViewedClothes(ProductType productType) {
        int count = 0;
        if (viewedClothes.ContainsKey(productType)) {
            IDictionary<string, int> clothes = viewedClothes[productType];
            foreach(string clothKey in clothes.Keys) {
                count += clothes[clothKey];
            }
        }
        return count;
    }

	public void Enter() {
		// reset necessary data
		_enterTime = Time.time;
        viewedClothes = new Dictionary<ProductType, IDictionary<string, int>>();
	}

	public void CloseAccept() {
	}

	public void CloseCancel() {
	}

    public void SelectCloth(VirtualGoodsAPI.VirtualGood dress) {
        ProductType productType = ClothesListController.Instance.GetTVGType(dress.IdSubType);
        if (!viewedClothes.ContainsKey(productType)) {
            viewedClothes[productType] = new Dictionary<string, int>();
        }
        IDictionary<string, int> clothesMap = viewedClothes[productType];
        if (!clothesMap.ContainsKey(dress.GUID)) {
            clothesMap.Add(dress.GUID, 0);
        }
        clothesMap[dress.GUID]++;
	}

    public void OpenBuy(VirtualGoodsAPI.VirtualGood virtualGood) {
        _enterBuyTime = Time.time;
        VirtualGoodToBuy = virtualGood;
        BuyResult = false;
	}

    public void BuySuccess() {
        BuyResult = true;
	}

    public void BuyCancel() {
        BuyResult = false;
	}


}
