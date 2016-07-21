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
            yield return Authentication.AzureServices.GetVirtualGoods("AVATARVG", page, null, false, (res) => {
                Dictionary<string, object> virtualgoods = MiniJSON.Json.Deserialize(res) as Dictionary<string, object>;
                if (virtualgoods != null) {
                    List<object> results = virtualgoods["Results"] as List<object>;
                    foreach (Dictionary<string, object> vg in results) {
                        if ((bool)vg["Enabled"]) {
                            string guid = vg["IdVirtualGood"] as string;
                            string subtype = vg["IdSubType"] as string;
                            string desc = ((vg["Description"] as List<object>)[0] as Dictionary<string, object>)["Description"] as string;
                            float val = 0.0f;
                            if( vg.ContainsKey("Price") )
                                val = float.Parse((((vg["Price"] as List<object>)[0] as Dictionary<string, object>)["Price"]).ToString());
                            string thburl = vg["ThumbnailUrl"] as string;
                            string imgurl = vg["PictureUrl"] as string;

                            VirtualGood tmp = new VirtualGood(guid, subtype, desc, val, thburl, imgurl);
                            if(!VirtualGoods.ContainsKey(guid))
                                VirtualGoods.Add(guid, tmp);
                        }
                    }
                    // Vemos si tiene que seguir paginando.
                    needRequest = false;
                    if (virtualgoods.ContainsKey("HasMoreResults")) {
                        needRequest = (bool)virtualgoods["HasMoreResults"];
                        page++;
                    }
                }
            });
        }
        needRequest = true;
        string token = null;
        while (needRequest) {
            yield return Authentication.AzureServices.GetVirtualGoodsPurchased("AVATARVG", token, (res) => {
                Dictionary<string, object> myvirtualgoods = MiniJSON.Json.Deserialize(res) as Dictionary<string, object>;
                if (myvirtualgoods != null) {
                    List<object> myresults = myvirtualgoods["Results"] as List<object>;
                    foreach (Dictionary<string, object> vg in myresults) {
                        string guid = vg["IdVirtualGood"] as string;
                        if (VirtualGoods.ContainsKey(guid)) {
                            VirtualGood myvg = (VirtualGood)VirtualGoods[guid];
                            myvg.count++;
                        }
                    }
                    needRequest = false;
                    if (myvirtualgoods.ContainsKey("HasMoreResults")) {
                        needRequest = (bool)myvirtualgoods["HasMoreResults"];
                        token = myvirtualgoods.ContainsKey("ContinuationTokenB64") ? myvirtualgoods["ContinuationTokenB64"] as string : "";
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
                Authentication.AzureServices.PurchaseVirtualGood(guid, (res) => {
                    LoadingCanvasManager.Hide();
                    //Debug.LogError("Buy VirtualGood >>>> " + res);
                    vg.count++;                    
                    UserAPI.Instance.Points -= (int)vg.Price;
                    UserAPI.Contents.CheckContent(vg);
					if(vg.IdSubType=="CONTENT") UserAPI.Instance.SendAction("VIRTUALTOUR_ACC_DESBLO_PACK",null,(err)=>{});
                    if (onOk != null) onOk();
                },(error)=> {
                    LoadingCanvasManager.Hide();
                    ModalTextOnly.ShowText(SmartLocalization.LanguageManager.Instance.GetTextValue("TVB.Error.CantPurchase"));
                });
            }
            else {
                if (vg.count > 0 && !multiple)
                {
                    Debug.LogError("Ya tienes este VG y no es multiple >>>> " + guid + " count " + vg.count);
                }
                else
                {
                    if (vg.Price > UserAPI.Instance.Points) {
                        LoadingCanvasManager.Hide();
                        ModalTextOnly.ShowText(LanguageManager.Instance.GetTextValue("TVB.Error.NoCredit"), () => {
                            GoodiesShopController.Show();
                        });
                        return;
                    }
                }
                if (onError != null) {
                    onError();
                }
            }
        }
    }
}