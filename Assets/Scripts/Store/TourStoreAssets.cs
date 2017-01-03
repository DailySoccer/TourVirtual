using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Soomla.Store;


public class TourStoreAssets : IStoreAssets{
    public int GetVersion() {
        return 6;
    }

    public VirtualCurrency[] GetCurrencies() {
        return new VirtualCurrency[] { };
    }

    public VirtualGood[] GetGoods() {
        return new VirtualGood[] {
            MONEDAS100_PACK,
            MONEDAS375_PACK,
            MONEDAS700_PACK,
            MONEDAS1600_PACK,
            MONEDAS3600_PACK,
            MONEDAS10000_PACK,
            UNLOCK_ALL_CONTET_PACK
        };
    }

    public VirtualCurrencyPack[] GetCurrencyPacks(){
        return new VirtualCurrencyPack[] { };
    }

    public VirtualCategory[] GetCategories(){
        return new VirtualCategory[] { };
    }
   
#if UNITY_ANDROID
static string prefix="and";
#elif UNITY_IOS
static string prefix="ios";
#elif UNITY_WSA
static string prefix="win";
#endif
    public static VirtualGood MONEDAS100_PACK = new SingleUseVG(
        "100 monedas",
        "100 monedas",
        prefix+"_rmvt_pack_coins_100",
        new PurchaseWithMarket(prefix+"_rmvt_pack_coins_100", 0)
     );

    public static VirtualGood MONEDAS375_PACK = new SingleUseVG(
        "375 monedas",
        "375 monedas",
        prefix+"_rmvt_pack_coins_375",
        new PurchaseWithMarket(prefix+"_rmvt_pack_coins_375", 0)
    );
    public static VirtualGood MONEDAS700_PACK = new SingleUseVG(
        "700 monedas",
        "700 monedas",
        prefix+"_rmvt_pack_coins_700",
        new PurchaseWithMarket(prefix+"_rmvt_pack_coins_700", 0)
    );
    public static VirtualGood MONEDAS1600_PACK = new SingleUseVG(
        "1600 monedas",
        "1600 monedas",
        prefix+"_rmvt_pack_coins_1600",
        new PurchaseWithMarket(prefix+"_rmvt_pack_coins_1600", 0)
    );
    public static VirtualGood MONEDAS3600_PACK = new SingleUseVG(
        "3600 monedas",
        "3600 monedas",
        prefix+"_rmvt_pack_coins_3600",
        new PurchaseWithMarket(prefix+"_rmvt_pack_coins_3600", 0)
    );

    public static VirtualGood MONEDAS10000_PACK = new SingleUseVG(
        "10000 monedas",
        "10000 monedas",
        prefix+"_rmvt_pack_coins_10000",
        new PurchaseWithMarket(prefix+"_rmvt_pack_coins_10000", 0)
    );

       public static VirtualGood UNLOCK_ALL_CONTET_PACK = new SingleUseVG(
        "Unlock all content",
        "Unlock all content",
        prefix+"_rmvt_pack_all",
        new PurchaseWithMarket(prefix+"_rmvt_pack_all", 0)
    );
}