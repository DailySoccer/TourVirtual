using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ContentAPI
{
    public class Content
    {
        public string GUID;
        public string InternalID;
        public string Title;
        public string Description;
        public string PackURL;
        public string ThumbURL;
        public bool owned;

        public Content(string _GUID, string _InternalID, string _Title, string _Description, string _PackURL, string _ThumbURL)
        {
            GUID = _GUID;
            InternalID = _InternalID;
            Title = _Title;
            Description = _Description;
            PackURL = _PackURL;
            ThumbURL = _ThumbURL;
            // Ver si tengo el VG.
            VirtualGoodsAPI.VirtualGood vg = UserAPI.VirtualGoodsDesciptor.GetByID(_InternalID);
            if ( vg!=null) {
                if (vg.count > 0) owned = true;
                Debug.LogError("Contenido relaccionado con el VG " + vg.GUID + " OWNED "+ owned);
            }
        }
    }

    public Dictionary<string, Content> Contents;
    public int TotalContents;


       public int GetOwned()
    {
		if (Contents == null)
			return -1;

        int owend = 0;
        foreach (var pair in Contents)
            if (pair.Value.owned)
                owend++;
        return owend;
    }

    public Content GetContentByID(string id){
        foreach (var pair in Contents){
            if (pair.Value.InternalID == id)
                return pair.Value;
        }
        return null;
    }

    public Content GetContentByGUID(string guid){
        if(Contents.ContainsKey(guid))
            return Contents[guid];
        return null;
    }

    public void CheckContent(VirtualGoodsAPI.VirtualGood vg) {
        if (string.IsNullOrEmpty(vg.InternalID)) return;

        Content cnt = GetContentByID(vg.InternalID);
        if (cnt != null) {
            if (vg.count > 0) {
                Debug.LogError(">>>> Desbloqueado " + vg.InternalID);
                cnt.owned = true;
            }
        }
    }
    string auxData = @"{
        	""CurrentPage"": 1,
        	""PageSize"": 10,
        	""PageCount"": 1,
        	""TotalItems"": 1,
        	""Results"": [{
        		""IdContent"": ""6ffa6413-4e53-4556-b406-17a40fe8ff93"",
        		""Type"": ""VIRTUALTOUR"",
        		""Title"": ""Test Pack 1"",
        		""Description"": ""Test Pack 1"",
        		""Asset"": {
        			""AssetUrl"": ""https://az726872.vo.msecnd.net/global-contentasset/asset_6a29a830-d506-4a75-b411-61823664fe4e.jpg"",
        			""ThumbnailUrl"": ""https://az726872.vo.msecnd.net/global-contentasset/TESTPACK1"",
        			""Type"": 2,
        			""VideoUrlType"": null

                },
        		""CreationDate"": ""2016-02-11T08:05:28.1858037Z"",
        		""Links"": [],
        		""PublishedDate"": ""2016-02-11T08:38:10.4779949Z"",
        		""OrderInDay"": 0,
        		""HighLight"": false,
        		""OrderInHighLight"": 0,
        		""Visible"": true,
        		""LinkId"": null
        	}],
        	""HasMoreResults"": false
        }";


    public void FAKE()
    {
        Dictionary<string,object> contents = BestHTTP.JSON.Json.Decode(auxData) as Dictionary<string, object>;
        if (contents != null)
        {
            List<object> results = contents["Results"] as List<object>;
            foreach (Dictionary<string, object> vg in results)
            {
                string guid = vg["IdContent"] as string;
                string title = vg["Title"] as string;
                string desc = vg["Description"] as string;

                string internalID = "";
                List<object> links = vg["Links"] as List<object>;
                if (links.Count > 0) internalID = (links[0] as Dictionary<string, object>)["Text"] as string;

                Dictionary<string, object> asset = vg["Asset"] as Dictionary<string, object>;
                string packURL = asset["AssetUrl"] as string;
                string thumbnailUrl = asset["ThumbnailUrl"] as string;

                Content tmp = new Content(guid, internalID, title, desc, packURL, thumbnailUrl);
                Contents.Add(guid, tmp);
                TotalContents++;
            }
        }
    }

    public IEnumerator AwaitRequest() {
        Contents = new Dictionary<string, Content>();
        bool needRequest = true;
        int page = 1;
        TotalContents = 0;
        while (needRequest) {
            yield return Authentication.AzureServices.AwaitRequestGet(string.Format("api/v1/content/VIRTUALTOUR?ct={0}&language={1}", page, Authentication.AzureServices.MainLanguage), (res) => {
                if (res != "null") {
                    Dictionary<string, object> contents = BestHTTP.JSON.Json.Decode(res) as Dictionary<string, object>;
                    if (contents != null) {
                        List<object> results = contents["Results"] as List<object>;
                        foreach (Dictionary<string, object> vg in results) {
                            string guid = vg["IdContent"] as string;
                            string title = vg["Title"] as string;
                            string desc = vg["Description"] as string;

                            string internalID = "";
                            List<object> links = vg["Links"] as List<object>;
                            if(links.Count>0) internalID = (links[0] as Dictionary<string, object>)["Text"] as string;

                            Dictionary<string, object> asset = vg["Asset"] as Dictionary<string, object>;
                            string packURL = asset["AssetUrl"] as string;
                            string thumbnailUrl = asset["ThumbnailUrl"] as string;

                            Content tmp = new Content(guid, internalID, title, desc, packURL, thumbnailUrl);
                            Contents.Add(guid, tmp);
                            TotalContents++;
                        }
                        // Vemos si tiene que seguir paginando.
                        needRequest = false;
                        if (contents.ContainsKey("HasMoreResults")) {
                            needRequest = (bool)contents["HasMoreResults"];
                            page++;
                        }
                    }
                }
            });
        }
    }
}