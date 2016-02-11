using UnityEngine;
using System.Collections;

public class ContentAPI
{
    public class Content
    {
        public string GUID;
        public string Title;
        public string Description;
        public string PackURL;
        public string ThumbURL;

        public Content(string _GUID, string _Title, string _Description, string _PackURL, string _ThumbURL)
        {
            GUID = _GUID;
            Title = _Title;
            Description = _Description;
            PackURL = _PackURL;
            ThumbURL = _ThumbURL;
        }
    }

    public Hashtable Contents;

    public IEnumerator AwaitRequest() {
        Contents = new Hashtable();
        bool needRequest = true;
        int page = 1;
        while (needRequest) {
            yield return Authentication.AzureServices.AwaitRequestGet(string.Format("api/v1/content/VIRTUALTOUR?ct={0}&language={1}", page, Authentication.AzureServices.MainLanguage), (res) => {
                if (res != "null") {
                    Hashtable contents = JSON.JsonDecode(res) as Hashtable;
                    if (contents != null) {
                        ArrayList results = contents["Results"] as ArrayList;
                        foreach (Hashtable vg in results) {
                            string guid = vg["IdContent"] as string;
                            string title = vg["Title"] as string;
                            string desc = vg["Description"] as string;

                            Hashtable asset = vg["Asset"] as Hashtable;
                            string packURL = asset["AssetUrl"] as string;
                            string thumbnailUrl = asset["ThumbnailUrl"] as string;

                            Content tmp = new Content(guid, title, desc, packURL, thumbnailUrl);
                            Contents.Add(guid, tmp);
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