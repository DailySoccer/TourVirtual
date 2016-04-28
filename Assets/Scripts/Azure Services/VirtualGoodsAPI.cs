using SmartLocalization;

using UnityEngine;
using System.Collections.Generic;

public class VirtualGoodsAPI { 
    public class VirtualGood {
        public string GUID;
        public string IdSubType;
        public string Description;
        public string Thumb;
        public string Image;
        public float Price;
        public int count;
        public VirtualGood(string _GUID, string _IdSubType, string _Description, float _Price, string _Thumb, string _Image) {
            GUID = _GUID;
            IdSubType = _IdSubType;
            Description = _Description;
            Price = _Price;
            Thumb = _Thumb;
            Image = _Image;
            count = 0;
        }
    }

    public Dictionary<string, VirtualGood> VirtualGoods;

    public VirtualGood GetByGUID(string guid) {
        if (VirtualGoods.ContainsKey(guid))
            return VirtualGoods[guid];
        return null;
    }

    public System.Collections.IEnumerator AwaitRequest(){
        VirtualGoods = new Dictionary<string, VirtualGood>();
        bool needRequest = true;
        int page = 1;

        while (needRequest) {
            yield return Authentication.AzureServices.AwaitRequestGet(string.Format("api/v1/virtualgoods?idType=AVATARVG&ct={0}&language={1}", page, Authentication.AzureServices.MainLanguage), (res) => {
                if (res != "null") {
                    Dictionary<string, object> virtualgoods = BestHTTP.JSON.Json.Decode(res) as Dictionary<string, object>;
                    if (virtualgoods != null) {
                        List<object> results = virtualgoods["Results"] as List<object>;
                        foreach (Dictionary<string, object> vg in results) {
                            if ((bool)vg["Enabled"])
                            {
                                string guid = vg["IdVirtualGood"] as string;
                                string subtype = vg["IdSubType"] as string;                                
                                string desc = ((vg["Description"] as List<object>)[0] as Dictionary<string, object>)["Description"] as string;
//                                string IID = ((vg["Url"] as List<object>)[0] as Dictionary<string, object>)["Description"] as string;
                                float value = vg.ContainsKey("Price") ? (float)(double)(((vg["Price"] as List<object>)[0] as Dictionary<string, object>)["Price"]):0.0f;
								string thburl = vg["ThumbnailUrl"] as string;
                                string imgurl = vg["PictureUrl"] as string;

                                VirtualGood tmp = new VirtualGood(guid, subtype, desc, value, thburl, imgurl);
                                VirtualGoods.Add(guid, tmp);
                            }
                        }
                        // Vemos si tiene que seguir paginando.
                        needRequest = false;
                        if (virtualgoods.ContainsKey("HasMoreResults"))
                        {
                            needRequest = (bool)virtualgoods["HasMoreResults"];
                            page++;
                        }
                    }
                }
            });
        }
        needRequest = true;
        string service = "api/v1/fan/me/VirtualGoods?type=AVATARVG";
        string url = string.Format("{0}&language={1}", service, Authentication.AzureServices.MainLanguage);
        while (needRequest) {
            yield return Authentication.AzureServices.AwaitRequestGet(url, (res) => {
                if (res != "null"){
                    //Debug.LogError(">>> MY virtualgoods " + res);
                    Dictionary<string, object> myvirtualgoods = BestHTTP.JSON.Json.Decode(res) as Dictionary<string, object>;
                    if (myvirtualgoods != null){
                        List<object> myresults = myvirtualgoods["Results"] as List<object>;
                        foreach (Dictionary<string, object> vg in myresults){
                            string guid = vg["IdVirtualGood"] as string;
                            if (VirtualGoods.ContainsKey(guid)){
                                VirtualGood myvg = (VirtualGood)VirtualGoods[guid];
                                myvg.count++;
                            }
                        }
                        needRequest = false;
                        if (myvirtualgoods.ContainsKey("HasMoreResults")) {
                            needRequest = (bool)myvirtualgoods["HasMoreResults"];
                            url = string.Format("{0}&language={1}&ct={2}", service, Authentication.AzureServices.MainLanguage, WWW.EscapeURL(myvirtualgoods["ContinuationTokenB64"] as string));
                        }
                    }
                }
            });
        }
        //  Buy("1bf6687b-bdf3-4906-83d7-118018f71b37");
    }

    public void FilterBySex( ) {
        Dictionary<string, VirtualGood> tmp = new Dictionary<string, VirtualGood>();
        foreach (var pair in VirtualGoods) {
			char stype = (pair.Value as VirtualGood).IdSubType[0];
			if (UserAPI.AvatarDesciptor.Gender == "Man" ) {
				if (stype == 'H' || stype == 'U' || stype == 'C' ){
					VirtualGood vg = pair.Value as VirtualGood;
                    tmp.Add(pair.Key, pair.Value);
				}
            }
            else {
				if (stype == 'M' || stype == 'U' || stype == 'C' )
					tmp.Add(pair.Key, pair.Value);
            }
        }
        VirtualGoods = tmp;
    }


    public void BuyByGUID(string guid, bool multiple = false, UserAPI.callback onOk = null, UserAPI.callback onError=null) {
        if (VirtualGoods.ContainsKey(guid)) {
            VirtualGood vg = (VirtualGood)VirtualGoods[guid];
            if ((vg.count <= 0 || multiple) && vg.Price <= UserAPI.Instance.Points){
                // No lo tengo y tengo la pasta.
                List<object> ar = new List<object>();
                ar.Add(guid.ToString());
                Authentication.AzureServices.RequestPostJSON(string.Format("api/v1/purchases/redeem/VirtualGoods?idClient={0}", Authentication.IDClient), ar, (res) => {
                    //Debug.LogError("Buy VirtualGood >>>> " + res);
                    vg.count++;                    
                    UserAPI.Instance.Points -= (int)vg.Price;
                    UserAPI.Contents.CheckContent(vg);
                    if(vg.IdSubType=="CONTENT") UserAPI.Achievements.SendAction("VIRTUALTOUR_ACC_DESBLO_PACK");
                    if (onOk != null) onOk();
                },(error)=> {
                    ModalTextOnly.ShowText(SmartLocalization.LanguageManager.Instance.GetTextValue("TVB.Error.CantPurchase"));
                });
            }
            else {
                Debug.LogError(">>>>>>>>>>>> BuyByGUID 4");

                if (vg.count > 0 && !multiple)
                {
                    Debug.LogError("Ya tienes este VG y no es multiple >>>> " + guid + " count " + vg.count);
                    //Debug.LogError("VG PRICE >>>> " + vg.Price + " USER POINTS " +  UserAPI.Instance.Points );
                }
                else
                {
                    Debug.LogError(">>>>>>>>>>>> BuyByGUID 6");

                    if (vg.Price > UserAPI.Instance.Points)
                    {
                        Debug.LogError(">>>>>>>>>>>> BuyByGUID 7");

                        LoadingCanvasManager.Hide();
                        ModalTextOnly.ShowText(LanguageManager.Instance.GetTextValue("TVB.Error.NoCredit"), () =>
                        {
                            Debug.LogError(">>>>>>>>>>>> BuyByGUID 8");
                            GoodiesShopController.Show();
                        });
                        return;
                    }
                }
                if (onError != null)
                {
                    Debug.LogError(">>>>>>>>>>>> BuyByGUID 1");
                    onError();
                }
            }
        }
    }
}