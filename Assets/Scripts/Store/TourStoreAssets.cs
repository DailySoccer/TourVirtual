using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Soomla.Store;


public class TourStoreAssets : IStoreAssets
{

    public int GetVersion() {
        return 4;
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
            MONEDAS10000_PACK
        };
    }
    public VirtualCurrencyPack[] GetCurrencyPacks()
    {
        return new VirtualCurrencyPack[] { };
    }
    public VirtualCategory[] GetCategories()
    {
        return new VirtualCategory[] { };
    }

    public static VirtualGood MONEDAS100_PACK = new SingleUseVG(
     "100 monedas",                                   // name
     "100 monedas",                       // description
     "and_rmvt_pack_coins_100",                                   // item id
     new PurchaseWithMarket("and_rmvt_pack_coins_100", 0)
     );

    public static VirtualGood MONEDAS375_PACK = new SingleUseVG(
        "375 monedas",                                   // name
        "375 monedas",                       // description
        "and_rmvt_pack_coins_375",                                   // item id
        new PurchaseWithMarket("and_rmvt_pack_coins_375", 0)
        );
    public static VirtualGood MONEDAS700_PACK = new SingleUseVG(
        "700 monedas",                                   // name
        "700 monedas",                       // description
        "and_rmvt_pack_coins_700",                                   // item id
        new PurchaseWithMarket("and_rmvt_pack_coins_700", 0)
        );
    public static VirtualGood MONEDAS1600_PACK = new SingleUseVG(
     "1600 monedas",                                   // name
     "1600 monedas",                       // description
     "and_rmvt_pack_coins_1600",                                   // item id
     new PurchaseWithMarket("and_rmvt_pack_coins_1600", 0)
     );
    public static VirtualGood MONEDAS3600_PACK = new SingleUseVG(
        "3600 monedas",                                   // name
        "3600 monedas",                       // description
        "and_rmvt_pack_coins_3600",                                   // item id
    new PurchaseWithMarket("and_rmvt_pack_coins_3600", 0)
  );

    public static VirtualGood MONEDAS10000_PACK = new SingleUseVG(
        "10000 monedas",                                    // name
        "10000 monedas",                                    // description
        "and_rmvt_pack_coins_10000",                        // item id
    new PurchaseWithMarket("and_rmvt_pack_coins_10000", 0)
  );

}