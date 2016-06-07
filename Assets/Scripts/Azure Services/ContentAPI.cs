using SmartLocalization;
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

    public class Content {

        public string GUID;
        public string VirtualGoodID;
        public string ContenName;
        public string Title;
        public string Description;
        public string PackURL;
        public bool owned;

        public Content(string _GUID, string _VirtualGoodID, string _ContenName, string _Title, string _Description, string _PackURL) {
            GUID = _GUID;
            VirtualGoodID = _VirtualGoodID;
            ContenName = _ContenName;
            Title = _Title;
            Description = _Description;            
            PackURL = DLCManager.Instance.AssetsUrl+"/Contents/" +_ContenName + "/"+_PackURL;
            VirtualGoodsAPI.VirtualGood vg = UserAPI.VirtualGoodsDesciptor.GetByGUID(_VirtualGoodID);
            if ( vg!=null) {
                if (vg.count > 0) owned = true;
            }
        }
    }

    public Dictionary<string, Content> Contents;
    public int TotalContents;


    public int GetOwned() {
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
            if (pair.Value.ContenName == id)
                return pair.Value;
        }
        return null;
    }

    public Content GetContentByVGID(string id)
    {
        foreach (var pair in Contents)
        {
            if (pair.Value.VirtualGoodID == id)
                return pair.Value;
        }
        return null;
    }


    public Content GetContentByGUID(string guid){
        if (Contents.ContainsKey(guid))
            return Contents[guid];
        return null;
    }

    public void CheckContent(VirtualGoodsAPI.VirtualGood vg) {
        if (string.IsNullOrEmpty(vg.GUID)) return;

        Content cnt = GetContentByVGID(vg.GUID);
        if (cnt != null) {
            if (vg.count > 0) {
                Debug.LogError(">>>> Desbloqueado " + vg.GUID);
                cnt.owned = true;
            }
        }
    }

    public delegate void GetContentCallback(List<Asset> values);

    /// <summary>
    /// Solicita asincronamente la infromación de un paquete de contenido.
    /// </summary>
    /// <param name="contenid">GUID del paquete solicitado.</param>
    /// <param name="callback">callback con una Lista de ContentAPI.Asset, que describe cada Asset </param>
    /// <returns></returns>
    public IEnumerator GetContent(string contenid, GetContentCallback callback=null ) {
        yield return Authentication.AzureServices.GetContent(contenid, (res) =>{
            if (res != "null")
                if (callback != null)
                    callback(ParseContent(res));
        },(res)=> {
            ModalTextOnly.ShowText(LanguageManager.Instance.GetTextValue("TVB.Error.NetError"));
        });
    }

    List<Asset> ParseContent(string res) {
        List<Asset> ret = new List<Asset>();
        Dictionary<string, object> contents = MiniJSON.Json.Deserialize(res) as Dictionary<string, object>;
        List<object>.Enumerator assets = (contents["Assets"] as List<object>).GetEnumerator();
        List<object>.Enumerator bodies = (contents["Body"] as List<object>).GetEnumerator();
        var contenidoID = contents["SourceId"] as string;
        while (assets.MoveNext())
        {
            bodies.MoveNext();
            var asset = assets.Current as Dictionary<string, object>;
            var body = bodies.Current as Dictionary<string, object>;

            AssetType at = (AssetType)(double)asset["Type"];

            var sd = "/";
            switch (at)
            {
                case AssetType.Photo: sd = "/pic/"; break;
                case AssetType.Model3D:
                    #if UNITY_ANDROID
                                sd = "/3ds/Android/";
                    #elif UNITY_IOS
			                    sd = "/3ds/ios/";
                    #else
			                    sd = "/3ds/Windows/";
                    #endif
                    break;
                case AssetType.Video: sd = "/vid/"; break;
                
            }
            var resURL = (asset["AssetUrl"] as string).Substring(7);
            var AssetURL = DLCManager.Instance.AssetsUrl + "/Contents/" + contenidoID + sd + resURL;

            int idx = resURL.IndexOf(".");
            if (idx != -1) resURL = resURL.Substring(0, idx);
            resURL += ".jpg";

            var ThumbnailURL = DLCManager.Instance.AssetsUrl + "/Contents/" + contenidoID + "/thumbnails/" + resURL;
            if (at != AssetType.ContentTitleImage)
                ret.Add( new Asset(body["Title"] as string, body["Body"] as string,AssetURL, ThumbnailURL, at));
        }
        return ret;
    }



    public IEnumerator AwaitRequest() {
		TotalContents = 0;
		Contents = new Dictionary<string, Content>();
        bool needRequest = true;
        int page = 1;        
        while (needRequest) {
            yield return Authentication.AzureServices.GetContents("VIRTUALTOUR", page, (res) => {
                if (res != "null") {
					//try{
                    Dictionary<string, object> contents = MiniJSON.Json.Deserialize(res) as Dictionary<string, object>;
                    if (contents != null) {
                        List<object> results = contents["Results"] as List<object>;
                        foreach (Dictionary<string, object> vg in results) {
							string guid = vg.ContainsKey("IdContent")?vg["IdContent"] as string:"";
							string title = vg.ContainsKey("Title")?vg["Title"] as string:"";
							string desc = vg.ContainsKey("Description")?vg["Description"] as string:"";
                            string internalID = "";
                            string contenidoID = "";
                            if (vg.ContainsKey("Links")){
                            	List<object> links = vg["Links"] as List<object>;
                                if (links != null && links.Count > 0) {
                                    Dictionary<string, object> lnks = links[0] as Dictionary<string, object>;
                                    internalID = lnks["Text"] as string;
                                    contenidoID = lnks["Url"] as string;
//                                    var vgdsc = UserAPI.VirtualGoodsDesciptor.GetByGUID(internalID);
//                                    if (vgdsc != null) contenidoID = vgdsc.Description;
                                }
                            }
                            if (vg.ContainsKey("Asset")){
								Dictionary<string, object> asset = vg["Asset"] as Dictionary<string, object>;
								if(asset!=null){
									string packURL = asset.ContainsKey("AssetUrl")?asset["AssetUrl"] as string:"";
									string thumbnailUrl = asset.ContainsKey("ThumbnailUrl")?asset["ThumbnailUrl"] as string:"";
                                    Content tmp = new Content(guid, internalID, contenidoID, title, desc, packURL.Substring(7));
		                            Contents.Add(guid, tmp);
		                            TotalContents++;
                                }else
                                {
                                    Debug.LogError(">>>> " + contenidoID + " Sin assets "+ title + " LANG "+ Authentication.AzureServices.MainLanguage);
                                }
							}
                        }
                        // Vemos si tiene que seguir paginando.
                        needRequest = false;
                        if (contents.ContainsKey("HasMoreResults")) {
                            needRequest = (bool)contents["HasMoreResults"];
                            page++;
                        }
                    }
				//	}catch{ needRequest = false; }
                }
            });
        }
    }
}
