﻿using UnityEngine;
using System.Collections;

public class VirtualGoodsAPI { 
    public class VirtualGood {
        public string GUID;
        public string IdSubType;
        public string Description;
        public string Image;
        public string InternalID;
        public float Price;
        public int count;
        public VirtualGood(string _GUID, string _InternalID, string _IdSubType, string _Description, float _Price, string _Image) {
            GUID = _GUID;
            IdSubType = _IdSubType;
            Description = _Description;
            Price = _Price;
            Image = _Image;
            InternalID = _InternalID;
            count = 0;
        }
    }

    public Hashtable VirtualGoods;

    public VirtualGood GetByGUID(string guid)
    {
        if (VirtualGoods.ContainsKey(guid))
            return VirtualGoods[guid] as VirtualGood;
        return null;
    }

    public VirtualGood GetByID(string id)
    {
        foreach (DictionaryEntry pair in VirtualGoods) {
            VirtualGood v = pair.Value as VirtualGood;            
            if (v.InternalID == id) return v;
        }
        return null;
    }

    string auxData = @"{
            ""CurrentPage"":1, 
            ""PageSize"":10,
            ""PageCount"":1,
            ""TotalItems"":6,
            ""Results"": [ 
                {""IdVirtualGood"":""1bf6687b-bdf3-4906-83d7-118018f71b37"",""Description"":[{""Locale"":""en-us"",""Description"":""MTorso11""}],""PictureUrl"":""https://az726872.vo.msecnd.net/global-virtualgoods/1bf6687b-bdf3-4906-83d7-118018f71b37.png"",""ThumbnailUrl"":""https://az726872.vo.msecnd.net/global-virtualgoods/1bf6687b-bdf3-4906-83d7-118018f71b37_thumbnail.png"",""Url"":[{""Locale"":""en-us"",""Description"":""MTorso11""}],""ValueInPoints"":0,""Price"":[{""UserType"":0,""Price"":0.0,""CoinType"":1}],""Enabled"":true,""MinAge"":0,""ExpirationInDays"":0,""CanBeGiven"":false,""CanBeUsed"":false,""IdType"":""AVATARVG"",""Highlight"":false,""HighLightInCategory"":false,""IdSubType"":""MTORSO"",""CanBeUsedInAvatar"":true},
                {""IdVirtualGood"":""1dfcd4f6-6f38-4dd2-bfa9-6f7641d6253a"",""Description"":[{""Locale"":""en-us"",""Description"":""HPiernas01""}], ""PictureUrl"":""https://az726872.vo.msecnd.net/global-virtualgoods/1dfcd4f6-6f38-4dd2-bfa9-6f7641d6253a.png"", ""ThumbnailUrl"":""https://az726872.vo.msecnd.net/global-virtualgoods/1dfcd4f6-6f38-4dd2-bfa9-6f7641d6253a_thumbnail.png"", ""Url"":[{""Locale"":""en-us"",""Description"":""HPiernas01""}], ""ValueInPoints"":0, ""Price"":[{""UserType"":0,""Price"":1.0,""CoinType"":1}], ""Enabled"":true, ""MinAge"":0, ""ExpirationInDays"":0, ""CanBeGiven"":false, ""CanBeUsed"":false,""IdType"":""AVATARVG"",""Highlight"":false,""HighLightInCategory"":false,""IdSubType"":""MLEG"",""CanBeUsedInAvatar"":true},
                {""IdVirtualGood"":""2252658f-738a-4fb9-a21b-ee6ec88b5dee"",""Description"":[{""Locale"":""en-us"",""Description"":""MPies01""}],""PictureUrl"":""https://az726872.vo.msecnd.net/global-virtualgoods/2252658f-738a-4fb9-a21b-ee6ec88b5dee.png"",""ThumbnailUrl"":""https://az726872.vo.msecnd.net/global-virtualgoods/2252658f-738a-4fb9-a21b-ee6ec88b5dee_thumbnail.png"",""Url"":[{""Locale"":""en-us"",""Description"":""MPies01""}],""ValueInPoints"":0,""Price"":[{""UserType"":0,""Price"":1.0,""CoinType"":1}],""Enabled"":true,""MinAge"":0,""ExpirationInDays"":0,""CanBeGiven"":false,""CanBeUsed"":false,""IdType"":""AVATARVG"",""Highlight"":false,""HighLightInCategory"":false,""IdSubType"":""MSHOE"",""CanBeUsedInAvatar"":true},
                {""IdVirtualGood"":""438ca85c-b364-429a-88ee-78ac14d7b47d"",""Description"":[{""Locale"":""en-us"",""Description"":""HCabeza01""}],""PictureUrl"":""https://az726872.vo.msecnd.net/global-virtualgoods/438ca85c-b364-429a-88ee-78ac14d7b47d.png"",""ThumbnailUrl"":""https://az726872.vo.msecnd.net/global-virtualgoods/438ca85c-b364-429a-88ee-78ac14d7b47d_thumbnail.png"",""Url"":[{""Locale"":""en-us"",""Description"":""HCabeza01""}],""ValueInPoints"":0,""Price"":[{""UserType"":0,""Price"":0.0,""CoinType"":1}],""Enabled"":true,""MinAge"":0,""ExpirationInDays"":300,""CanBeGiven"":false,""CanBeUsed"":true,""IdType"":""AVATARVG"",""Highlight"":false,""HighLightInCategory"":false,""IdSubType"":""HHEAD"",""CanBeUsedInAvatar"":true},
                {""IdVirtualGood"":""66092685-b049-46dd-8f53-04f333e3b1c4"",""Description"":[{""Locale"":""en-us"",""Description"":""MPiernas01""}],""PictureUrl"":""https://az726872.vo.msecnd.net/global-virtualgoods/66092685-b049-46dd-8f53-04f333e3b1c4.png"",""ThumbnailUrl"":""https://az726872.vo.msecnd.net/global-virtualgoods/66092685-b049-46dd-8f53-04f333e3b1c4_thumbnail.png"",""Url"":[{""Locale"":""en-us"",""Description"":""MPiernas01""}],""ValueInPoints"":0,""Price"":[{""UserType"":0,""Price"":0.0,""CoinType"":1}],""Enabled"":false,""MinAge"":0,""ExpirationInDays"":300,""CanBeGiven"":false,""CanBeUsed"":false,""IdType"":""AVATARVG"",""Highlight"":false,""HighLightInCategory"":false,""IdSubType"":""MLEG"",""CanBeUsedInAvatar"":true},
                {""IdVirtualGood"":""8dd68e06-ab9e-4dab-9f28-a6f5c697e18f"",""Description"":[{""Locale"":""en-us"",""Description"":""HPies01""}],""PictureUrl"":""https://az726872.vo.msecnd.net/global-virtualgoods/8dd68e06-ab9e-4dab-9f28-a6f5c697e18f.png"",""ThumbnailUrl"":""https://az726872.vo.msecnd.net/global-virtualgoods/8dd68e06-ab9e-4dab-9f28-a6f5c697e18f_thumbnail.png"",""Url"":[{""Locale"":""en-us"",""Description"":""HPies01""}],""ValueInPoints"":0,""Price"":[{""UserType"":0,""Price"":1.0,""CoinType"":1}],""Enabled"":true,""MinAge"":0,""ExpirationInDays"":0,""CanBeGiven"":false,""CanBeUsed"":false,""IdType"":""AVATARVG"",""Highlight"":false,""HighLightInCategory"":false,""IdSubType"":""HSHOE"",""CanBeUsedInAvatar"":true},
                {""IdVirtualGood"":""bfd1a844-5a6e-4b7f-bdb2-aba2cc8983a3"",""Description"":[{""Locale"":""en-us"",""Description"":""MCabeza01""}],""PictureUrl"":""https://az726872.vo.msecnd.net/global-virtualgoods/bfd1a844-5a6e-4b7f-bdb2-aba2cc8983a3.png"",""ThumbnailUrl"":""https://az726872.vo.msecnd.net/global-virtualgoods/bfd1a844-5a6e-4b7f-bdb2-aba2cc8983a3_thumbnail.png"",""Url"":[{""Locale"":""en-us"",""Description"":""MCabeza01""}],""ValueInPoints"":0,""Price"":[{""UserType"":0,""Price"":0.0,""CoinType"":1}],""Enabled"":true,""MinAge"":0,""ExpirationInDays"":0,""CanBeGiven"":false,""CanBeUsed"":false,""IdType"":""AVATARVG"",""Highlight"":false,""HighLightInCategory"":false,""IdSubType"":""HEADS"",""CanBeUsedInAvatar"":true},
                {""IdVirtualGood"":""d8551f4f-8301-47b2-87be-8c0077afbb05"",""Description"":[{""Locale"":""en-us"",""Description"":""HTorso01""}],""PictureUrl"":""https://az726872.vo.msecnd.net/global-virtualgoods/d8551f4f-8301-47b2-87be-8c0077afbb05.png"",""ThumbnailUrl"":""https://az726872.vo.msecnd.net/global-virtualgoods/d8551f4f-8301-47b2-87be-8c0077afbb05_thumbnail.png"",""Url"":[{""Locale"":""en-us"",""Description"":""HTorso01""}],""ValueInPoints"":0,""Price"":[{""UserType"":0,""Price"":1.0,""CoinType"":1}],""Enabled"":true,""MinAge"":0,""ExpirationInDays"":0,""CanBeGiven"":false,""CanBeUsed"":false,""IdType"":""AVATARVG"",""Highlight"":false,""HighLightInCategory"":false,""IdSubType"":""HTORSO"",""CanBeUsedInAvatar"":true}
            ],
        ""HasMoreResults"":false 
        }";

    string auxData2 = @"{
        ""ContinuationToken"":null,
        ""ContinuationTokenB64"":null,
        ""Results"":[
            {
                ""IdUser"":""03edad5e-f581-4aed-b217-cc117e3556b4"",
                ""IdVirtualGood"":""4d229050-fd95-4492-bcff-2ceecf8115b8"",
                ""AdquisitionDate"":""2016-02-26T12:25:00.481Z"",
                ""PictureUrl"":""https://az726872.vo.msecnd.net/global-virtualgoods/4d229050-fd95-4492-bcff-2ceecf8115b8.png"",
                ""ThumbnailUrl"":""https://az726872.vo.msecnd.net/global-virtualgoods/4d229050-fd95-4492-bcff-2ceecf8115b8_thumbnail.png"",
                ""Description"":[{""Locale"":""en-us"",""Description"":""Content Test Pack  1""}],
                ""Url"":[{""Locale"":""en-us"",""Description"":""TESTPACK1""}],
                ""IdVirtualGoodType"":""AVATARVG""
            }
        ],""HasMoreResults"":false}
    }";

    public void FAKE()
    {
        VirtualGoods = new Hashtable();
        Hashtable virtualgoods = JSON.JsonDecode(auxData) as Hashtable;
        if (virtualgoods != null)
        {
            ArrayList results = virtualgoods["Results"] as ArrayList;
            foreach (Hashtable vg in results)
            {
                if ((bool)vg["CanBeUsedInAvatar"])
                {
                    string guid = vg["IdVirtualGood"] as string;
                    string subtype = vg["IdSubType"] as string;
                    string desc = ((vg["Description"] as ArrayList)[0] as Hashtable)["Description"] as string;
                    string IID = ((vg["Url"] as ArrayList)[0] as Hashtable)["Description"] as string;
                    float value = vg.ContainsKey("Price") ? (float)(((vg["Price"] as ArrayList)[0] as Hashtable)["Price"]) : 0.0f;
                    VirtualGood tmp = new VirtualGood(guid, IID, subtype, desc, value, vg["PictureUrl"] as string);
                    VirtualGoods.Add(guid, tmp);
                }
            }
        }
        // Mis virtual goods.
        Hashtable myvirtualgoods = JSON.JsonDecode(auxData2) as Hashtable;
        if (myvirtualgoods != null)
        {
            ArrayList myresults = myvirtualgoods["Results"] as ArrayList;
            foreach (Hashtable vg in myresults)
            {
                string guid = vg["IdVirtualGood"] as string;
                if (VirtualGoods.ContainsKey(guid))
                {
                    VirtualGood myvg = (VirtualGood)VirtualGoods[guid];
                    myvg.count++;
                }
            }
        }



    }

    public IEnumerator AwaitRequest(){
        VirtualGoods = new Hashtable();
        bool needRequest = true;
        int page = 1;

        while (needRequest) {
            yield return Authentication.AzureServices.AwaitRequestGet(string.Format("api/v1/virtualgoods?idType=AVATARVG&ct={0}&language={1}", page, Authentication.AzureServices.MainLanguage), (res) => {
                if (res != "null") {
                    Debug.LogError(">>> virtualgoods " + res);
                    Hashtable virtualgoods = JSON.JsonDecode(res) as Hashtable;
                    if (virtualgoods != null) {
                        ArrayList results = virtualgoods["Results"] as ArrayList;
                        foreach (Hashtable vg in results) {
//                            if ((bool)vg["CanBeUsedInAvatar"])
                            {
                                string guid = vg["IdVirtualGood"] as string;
                                string subtype = vg["IdSubType"] as string;                                
                                string desc = ((vg["Description"] as ArrayList)[0] as Hashtable)["Description"] as string;
                                string IID = ((vg["Url"] as ArrayList)[0] as Hashtable)["Description"] as string;
                                float value = vg.ContainsKey("Price") ? (float)(((vg["Price"] as ArrayList)[0] as Hashtable)["Price"]):0.0f;
                                VirtualGood tmp = new VirtualGood(guid, IID, subtype, desc, value, vg["PictureUrl"] as string );
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
                    Debug.LogError(">>> MY virtualgoods " + res);

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
                        if (myvirtualgoods.ContainsKey("HasMoreResults")) {
                            needRequest = (bool)myvirtualgoods["HasMoreResults"];
                            url = string.Format("{0}&language={1}&ct={2}", service, Authentication.AzureServices.MainLanguage, myvirtualgoods["ContinuationToken"] as string);
                        }
                    }
                }
            });
        }
        //  Buy("1bf6687b-bdf3-4906-83d7-118018f71b37");
    }

    public void FilterBySex( )
    {
        Hashtable tmp = new Hashtable();
        foreach(DictionaryEntry pair in VirtualGoods) {
            if (UserAPI.AvatarDesciptor.Gender == "Male") {
                if ((pair.Value as VirtualGood).IdSubType[0] == 'H')
                    tmp.Add(pair.Key, pair.Value);
            }
            else {
                if ((pair.Value as VirtualGood).IdSubType[0] == 'M')
                    tmp.Add(pair.Key, pair.Value);
            }
        }
        VirtualGoods = tmp;
    }


    public void BuyByID(string id, bool multiple = false) {
        BuyByGUID(GetByID(id).GUID, multiple);
    }

    public void BuyByGUID(string guid, bool multiple = false) {
        if (VirtualGoods.ContainsKey(guid)) {
            VirtualGood vg = (VirtualGood)VirtualGoods[guid];
            if ((vg.count <= 0 || multiple) && vg.Price <= UserAPI.Instance.Points){
                // No lo tengo y tengo la pasta.
                ArrayList ar = new ArrayList();
                ar.Add(guid.ToString());
                Authentication.AzureServices.RequestPostJSON(string.Format("api/v1/purchases/redeem/VirtualGoods?idClient={0}", Authentication.IDClient), ar, (res) => {
                    Debug.LogError("Buy VirtualGood >>>> " + res);
                    vg.count++;
                    UserAPI.Instance.Points -= (int)vg.Price;
                    UserAPI.Contents.CheckContent(vg);
                });
            }
            else {
                if(vg.count > 0 || !multiple) {
                    Debug.LogError("Ya tienes este VG y no es multiple >>>> " + guid + " count " + vg.count);
                    Debug.LogError("VG PRICE >>>> " + vg.Price + " USER POINTS " +  UserAPI.Instance.Points );
                }
                else
                if ( vg.Price >= UserAPI.Instance.Points) {
                    Debug.LogError("NO hay dinero para comprar >>>> " + guid);
                }
            }
        }
    }
}