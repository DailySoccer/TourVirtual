using UnityEngine;
using System.Collections;

public struct VirtualGoodsAPI { 
    public void Request() {
        Authentication.AzureServices.RequestGet( string.Format("api/v1/virtualgoods?idType=CLOTHES&ct={0}&language={1}&onlyPurchasables=true", 1, Authentication.AzureServices.MainLanguage ), (res) => {
            Debug.LogError("VirtualGoodsAPI.Request List " + res);
            Authentication.AzureServices.RequestGet(string.Format("api/v1/fan/me/VirtualGoods?type=CLOTHES&language={0}", Authentication.AzureServices.MainLanguage), (res2) => {
                Debug.LogError("VirtualGoodsAPI.UserRequest List " + res2);
            });
        });
    }
}
