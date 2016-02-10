using UnityEngine;
using System.Collections;

public class VirtualGoodsAPI { 
    public class VirtualGood {
        public string GUID;
        public string Description;
        public string Image;
        public string Thumbnail;
        public int Price;
        public int count;
        public VirtualGood(string _GUID, string _Description, int _Price, string _Image, string _Thumbnail) {
            GUID = _GUID;
            Description = _Description;
            Price = _Price;
            Image = _Image;
            Thumbnail = _Thumbnail;
            count = 0;
        }
    }

    public Hashtable VirtualGoods;

    public IEnumerator AwaitRequest(){
        VirtualGoods = new Hashtable();
        bool needRequest = true;
        int page = 1;

        while (needRequest) {
            yield return Authentication.AzureServices.AwaitRequestGet(string.Format("api/v1/virtualgoods?idType=AVATARVG&ct={0}&language={1}", page, Authentication.AzureServices.MainLanguage), (res) => {
                if (res != "null") {
                    Hashtable virtualgoods = JSON.JsonDecode(res) as Hashtable;
                    if (virtualgoods != null) {
                        ArrayList results = virtualgoods["Results"] as ArrayList;
                        foreach (Hashtable vg in results) {
                            if ((bool)vg["CanBeUsedInAvatar"]) {
                                string guid = vg["IdVirtualGood"] as string;
                                string desc = ((vg["Description"] as ArrayList)[0] as Hashtable)["Description"] as string;
                                int value = (int)vg["ValueInPoints"];
                                VirtualGood tmp = new VirtualGood(guid, desc, value, vg["PictureUrl"] as string, vg["ThumbnailUrl"] as string);
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
                    Hashtable myvirtualgoods = JSON.JsonDecode(res) as Hashtable;
                    if (myvirtualgoods != null){
                        ArrayList myresults = myvirtualgoods["Results"] as ArrayList;
                        foreach (Hashtable vg in myresults){
                            string guid = vg["IdVirtualGood"] as string;
                            if (VirtualGoods.ContainsKey(guid)){
                                VirtualGood myvg = (VirtualGood)VirtualGoods[guid];
                                myvg.count++;
                            }
                        }
                        needRequest = false;
                        if (myvirtualgoods.ContainsKey("HasMoreResults"))
                        {
                            needRequest = (bool)myvirtualgoods["HasMoreResults"];
                            url = string.Format("{0}&language={1}&ct={2}", service, Authentication.AzureServices.MainLanguage, myvirtualgoods["ContinuationToken"] as string);

                        }
                    }
                }
            });
        }
        //  Buy("1bf6687b-bdf3-4906-83d7-118018f71b37");
    }

    public void Buy(string guid, bool multiple = false) {
        if (VirtualGoods.ContainsKey(guid)) {
            VirtualGood vg = (VirtualGood)VirtualGoods[guid];
            if ((vg.count < 0 || multiple) && vg.Price < UserAPI.Instance.Points){
                // No lo tengo y tengo la pasta.
                ArrayList ar = new ArrayList();
                ar.Add(guid.ToString());
                Authentication.AzureServices.RequestPostJSON(string.Format("api/v1/purchases/redeem/VirtualGoods?idClient={0}", Authentication.IDClient), ar, (res) => {
                    Debug.LogError(">>>> " + res);
                    UserAPI.Instance.Points -= vg.Price;
                });
            }
        }
    }
}