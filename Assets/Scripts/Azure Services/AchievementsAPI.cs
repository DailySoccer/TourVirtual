using UnityEngine;
using System.Collections.Generic;

public class AchievementsAPI{ 
    public class Achievement{
        public string GUID;
        public string Name;
        public string IName;
        public string Description;
        public int Level;
        public string Image;
        public int Points;
        public bool earned;
        public Achievement(string _GUID, string _Name, string _IName, string _Description, int _Level, int _Points, string _Image ) {
            GUID = _GUID;
            Name = _Name;
            IName = _IName;
            Description = _Description;
            Level = _Level;
            Points = _Points;
            Image = _Image;
            earned = false;
        }
    }
    public Dictionary<string, Achievement> Achievements;

    public int TotalAchievements;
    public int EarnedAchievements;

    public System.Collections.IEnumerator AwaitRequest()
    {
        TotalAchievements = 0;
        Achievements = new Dictionary<string, Achievement>();
        yield return Authentication.AzureServices.AwaitRequestGet(string.Format("api/v1/achievements?achievementConfigurationType=VIRTUALTOUR&idClient={0}&language={1}", Authentication.IDClient, Authentication.AzureServices.MainLanguage), (res) =>
        {
            if (res != "null")
            {
                List<object> results = BestHTTP.JSON.Json.Decode(res) as List<object>;
                foreach (Dictionary<string, object> ele in results) {
                    string guid = ele["IdAchievement"] as string;
                    string iname = ele["Name"] as string;
                    string name = ((ele["Description"] as List<object>)[0] as Dictionary<string, object>)["Description"] as string;

                    int points = (int)(double)ele["Points"];
                    int level = (int)(double)ele["Level"];
                    string description = ((ele["LevelName"] as List<object>)[0] as Dictionary<string, object>)["Description"] as string;
                    string imageUrl = ele["ImageUrl"] as string;
                    // string rule = ((ele["Rules"] as ArrayList)[0] as Hashtable)["IdAction"] as string;
                    Achievement tmp = new Achievement(guid, name, iname, description, level, points, imageUrl);
                    Achievements.Add(guid + "|" + level, tmp);
                    TotalAchievements++;
                }
            }
        });

        // Consulta mis logros.
        yield return Authentication.Instance.StartCoroutine(AwaitAchievementEarned(false));
    }

    public System.Collections.IEnumerator AwaitAchievementEarned(bool refresh =true) {
        bool needRequest = true;
        EarnedAchievements = 0;
//        string service = "api/v1/fan/me/Achievements?type=VIRTUALTOUR?";
        string service = "api/v1/fan/me/Achievements?";
        string url = string.Format("{0}?language={1}", service, Authentication.AzureServices.MainLanguage);
        while (needRequest) {            
            yield return Authentication.AzureServices.AwaitRequestGet(url, (res) => {
                if (res != "null")
                {
//                    Debug.LogError(">>> MY achievements " + res);
                    Dictionary<string, object> myachievements = BestHTTP.JSON.Json.Decode(res) as Dictionary<string, object>;
                    if (myachievements != null)
                    {
                        List<object> myresults = myachievements["Results"] as List<object>;
                        foreach (Dictionary<string, object> ele in myresults)
                        {
                            string guid = ele["IdAchievement"] as string;
                            int level = (int)(double)ele["Level"];
                            string aux = guid + "|" + level;
                            if (Achievements.ContainsKey(aux))
                            {
                                Achievements[aux].earned = true;
                                EarnedAchievements++;
                                if (refresh) {
                                    Debug.LogError(">>>>>>>>>> RETO RECIEN GANADO " + aux);
                                }
                            }
                        }
                        needRequest = false;
                        if (myachievements.ContainsKey("HasMoreResults")) {
                            needRequest = (bool)myachievements["HasMoreResults"];
                            //Pedimos la siguiente pagina.
                            if(needRequest)
                                url = string.Format("{0}?language={1}&ct={2}", service, Authentication.AzureServices.MainLanguage, WWW.EscapeURL(myachievements["ContinuationTokenB64"] as string));
                        }
                    }
                }
                else
                    needRequest=false;
            });
        }
        
    }

    public void SendAction(string guid ) {

        if (!UserAPI.Instance.Online) return;
        Dictionary<string, object> hs = new Dictionary<string, object>();
        hs.Add("ActionId", guid );
        hs.Add("ClientId", Authentication.IDClient);
        Authentication.AzureServices.RequestPostJSON( "api/v1/useractions", hs, (res) => {

        });
    }
}