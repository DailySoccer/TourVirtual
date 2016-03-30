#if !LITE_VERSION

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ContentAPI
{

    public enum AssetType
    {
        Photo = 0,
        Video = 1,
        ContentTitleImage = 2,
        Audio = 3,
        Binary = 4,
        Model3D = 5
    };

    public class Asset
    {
        public string Title;
        public string Body;
        public string AssetUrl;
        public string ThumbnailUrl;
        public AssetType Type;
        public Asset(string _Title, string _Body, string _AssetUrl, string _ThumbnailUrl, AssetType _Type)
        {
            Title = _Title;
            Body = _Body;
            AssetUrl = _AssetUrl;
            ThumbnailUrl = _ThumbnailUrl;
            Type = _Type;
        }

    };

    public class Content
    {

        public string GUID;
        public string VirtualGoodID;
        public string Title;
        public string Description;
        public string PackURL;
        public string ThumbURL;
        public bool owned;

        public Content(string _GUID, string _VirtualGoodID, string _Title, string _Description, string _PackURL, string _ThumbURL)
        {
            GUID = _GUID;
            VirtualGoodID = _VirtualGoodID;
            Title = _Title;
            Description = _Description;
            PackURL = _PackURL;
            ThumbURL = _ThumbURL;
            // Ver si tengo el VG.


            VirtualGoodsAPI.VirtualGood vg = UserAPI.VirtualGoodsDesciptor.GetByGUID(_VirtualGoodID);
            if ( vg!=null) {
                if (vg.count > 0) owned = true;
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
            if (pair.Value.VirtualGoodID == id)
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
        if (string.IsNullOrEmpty(vg.GUID)) return;

        Content cnt = GetContentByID(vg.GUID);
        if (cnt != null) {
            if (vg.count > 0) {
                Debug.LogError(">>>> Desbloqueado " + vg.GUID);
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
        			""ThumbnailUrl"": ""https://az726872.vo.msecnd.net/global-contentasset/asset_6a29a830-d506-4a75-b411-61823664fe4e_thumbnail.jpg"",
        			""Type"": 2,
        			""VideoUrlType"": null

                },
        		""CreationDate"": ""2016-02-11T08:05:28.1858037Z"",
        		""Links"":[
                              {  
                                 ""Url"":""4d229050-fd95-4492-bcff-2ceecf8115b8"",
                                 ""Text"":""4d229050-fd95-4492-bcff-2ceecf8115b8"",
                                 ""Order"":0
                              }
                           ],
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
		TotalContents = 0;
		Contents = new Dictionary<string, Content> ();

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


	/* Asset Types
		Photo 				= 0,
        Video 				= 1,
        ContentTitleImage 	= 2,
        Audio 				= 3,
        Binary 				= 4,
        Model3D 			= 5
	 */


    string auxData2 = @"{  
   ""IdContent"":""6ffa6413-4e53-4556-b406-17a40fe8ff93"",
   ""SourceId"":""TESTPACK1"",
   ""Type"":""VIRTUALTOUR"",
   ""HashTag"":""#virtualtour"",
   ""Title"":""Test Pack 1"",
   ""Description"":""Test Pack 1"",
   ""Body"":[
      {  
         ""Title"":""Paquete de ejemplo"",
         ""Body"":""Paquete de ejemplo\n""
      },
      {  
         ""Title"":""Imagen de ejemplo"",
         ""Body"":""Imagen de ejemplo\n""
      }




	 ,{  
         ""Title"":""Test Photo"",
         ""Body"":""Test Photo\n""
      }
	 ,{  
         ""Title"":""Test Video"",
         ""Body"":""Test Video\n""
      }
	 ,{  
         ""Title"":""Test Audio"",
         ""Body"":""Test Photo\n""
      }
	 ,{  
         ""Title"":""Test 3D"",
         ""Body"":""Test Photo\n""
      }


   ],
   ""Assets"":[
      {  
         ""AssetUrl"":""https://az726872.vo.msecnd.net/global-contentasset/asset_6a29a830-d506-4a75-b411-61823664fe4e.jpg"",
         ""ThumbnailUrl"":""https://az726872.vo.msecnd.net/global-contentasset/asset_6a29a830-d506-4a75-b411-61823664fe4e_thumbnail.jpg"",
         ""Type"":2,
         ""VideoUrlType"":null
      },
      {  
         ""AssetUrl"":""https://az726872.vo.msecnd.net/global-contentasset/asset_6eba5209-8195-4363-8163-b375e916e228.png"",
         ""ThumbnailUrl"":""https://az726872.vo.msecnd.net/global-contentasset/asset_6eba5209-8195-4363-8163-b375e916e228_thumbnail.png"",
         ""Type"":0,
         ""VideoUrlType"":null
      }



	 ,{  
         ""AssetUrl"":""https://az726872.vo.msecnd.net/global-contentasset/asset_6eba5209-8195-4363-8163-b375e916e228.png"",
         ""ThumbnailUrl"":""https://az726872.vo.msecnd.net/global-contentasset/asset_6eba5209-8195-4363-8163-b375e916e228_thumbnail.png"",
         ""Type"":0,
         ""VideoUrlType"":null
      }
	 ,{  
         ""AssetUrl"":""https://az726872.vo.msecnd.net/global-contentasset/asset_6eba5209-8195-4363-8163-b375e916e228.png"",
         ""ThumbnailUrl"":""https://az726872.vo.msecnd.net/global-contentasset/asset_6eba5209-8195-4363-8163-b375e916e228_thumbnail.png"",
         ""Type"":1,
         ""VideoUrlType"":null
      }
	 ,{  
         ""AssetUrl"":""https://az726872.vo.msecnd.net/global-contentasset/asset_6eba5209-8195-4363-8163-b375e916e228.png"",
         ""ThumbnailUrl"":""https://az726872.vo.msecnd.net/global-contentasset/asset_6eba5209-8195-4363-8163-b375e916e228_thumbnail.png"",
         ""Type"":3,
         ""VideoUrlType"":null
      }
	 ,{  
         ""AssetUrl"":""https://az726872.vo.msecnd.net/global-contentasset/asset_6eba5209-8195-4363-8163-b375e916e228.png"",
         ""ThumbnailUrl"":""https://az726872.vo.msecnd.net/global-contentasset/asset_6eba5209-8195-4363-8163-b375e916e228_thumbnail.png"",
         ""Type"":5,
         ""VideoUrlType"":null
      }
   ],
   ""CreationDate"":""2016-02-11T08:05:28.1858037Z"",
   ""LastUpdateDate"":""2016-02-11T08:05:28.1858037Z"",
   ""PublishedDate"":""2016-02-11T08:38:10.4779949Z"",
   ""OrderInDay"":0,
   ""HighLight"":false,
   ""OrderInHighLight"":0,
   ""NotificationTags"":[

   ],
   ""Visible"":true,
   ""Published"":true,
   ""LocaleId"":""en-us"",
   ""CommentsIdThread"":""ce27ccf1-4e15-4607-90f9-f79049ab45a0"",
   ""Links"":[
      {  
         ""Url"":""4d229050-fd95-4492-bcff-2ceecf8115b8"",
         ""Text"":""4d229050-fd95-4492-bcff-2ceecf8115b8"",
         ""Order"":0
      }
   ],
   ""HasGamification"":false,
   ""RelatedNews"":[

   ],
   ""RelatedPlayers"":[

   ],
   ""LinkId"":null,
   ""AllowReplaceFromSource"":false
}";

    public delegate void GetContentCallback(List<Asset> values);

    /// <summary>
    /// Solicita asincronamente la infromación de un paquete de contenido.
    /// </summary>
    /// <param name="contenid">GUID del paquete solicitado.</param>
    /// <param name="callback">callback con una Lista de ContentAPI.Asset, que describe cada Asset </param>
    /// <returns></returns>
    public IEnumerator GetContent(string contenid, GetContentCallback callback=null )
    {
		Debug.LogError(">>>>>>> Pidiendo contenido del pack");
        if (!UserAPI.Instance.Online)
        {
            if (callback != null) callback(ParseContent(auxData2));
        }
        else {
            yield return Authentication.AzureServices.AwaitRequestGet(string.Format("api/v1/content/{0}", contenid), (res) =>
            {
                if (res != "null")
                {
                    if (callback != null) callback(ParseContent(res));
					Debug.LogError(">>>>>>> >>>>>>> Retornando contenido");
                }
            });
        }
    }

    List<Asset> ParseContent(string res) {
        List<Asset> ret = new List<Asset>();
        Dictionary<string, object> contents = BestHTTP.JSON.Json.Decode(res) as Dictionary<string, object>;
        List<object>.Enumerator assets = (contents["Assets"] as List<object>).GetEnumerator();
        List<object>.Enumerator bodies = (contents["Body"] as List<object>).GetEnumerator();

        while (assets.MoveNext())
        {
            bodies.MoveNext();
            var asset = assets.Current as Dictionary<string, object>;
            var body = bodies.Current as Dictionary<string, object>;

            ret.Add( new Asset(body["Title"] as string, body["Body"] as string,
                asset["AssetUrl"] as string, asset["ThumbnailUrl"] as string, (AssetType)(double)asset["Type"]));
        }
        return ret;
    }

    public IEnumerator AwaitRequest() {
		TotalContents = 0;
		Contents = new Dictionary<string, Content>();
        bool needRequest = true;
        int page = 1;        
        while (needRequest) {
            yield return Authentication.AzureServices.AwaitRequestGet(string.Format("api/v1/content/VIRTUALTOUR?ct={0}&language={1}", page, Authentication.AzureServices.MainLanguage), (res) => {
                if (res != "null") {

//                    Debug.Log(">>> Contents\n" + res);                    
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
#endif