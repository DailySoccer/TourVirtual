using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Soomla.Store;


public class TourStoreAssets : IStoreAssets
{

    public int GetVersion() {
        return 3;
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
     "100coins",                                   // item id
     new PurchaseWithMarket("com.realmadrid.virtualworld.100coins", 0)
     );

    public static VirtualGood MONEDAS375_PACK = new SingleUseVG(
        "375 monedas",                                   // name
        "375 monedas",                       // description
        "375coins",                                   // item id
        new PurchaseWithMarket("com.realmadrid.virtualworld.375coins", 0)
        );
    public static VirtualGood MONEDAS700_PACK = new SingleUseVG(
        "700 monedas",                                   // name
        "700 monedas",                       // description
        "700coins",                                   // item id
        new PurchaseWithMarket("com.realmadrid.virtualworld.700coins", 0)
        );
    public static VirtualGood MONEDAS1600_PACK = new SingleUseVG(
     "1600 monedas",                                   // name
     "1600 monedas",                       // description
     "1600coins",                                   // item id
     new PurchaseWithMarket("com.realmadrid.virtualworld.1600coins", 0)
     );
    public static VirtualGood MONEDAS3600_PACK = new SingleUseVG(
        "3600 monedas",                                   // name
        "3600 monedas",                       // description
        "3600coins",                                   // item id
    new PurchaseWithMarket("com.realmadrid.virtualworld.3600coins", 0)
  );

    public static VirtualGood MONEDAS10000_PACK = new SingleUseVG(
        "10000 monedas",                                   // name
        "10000 monedas",                       // description
        "10000coins",                                   // item id
    new PurchaseWithMarket("com.realmadrid.virtualworld.10000coins", 0)
  );

}