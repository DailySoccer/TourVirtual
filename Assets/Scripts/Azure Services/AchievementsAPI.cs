using UnityEngine;
using System.Collections;



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
    public Hashtable Achievements;

    public int TotalAchievements;
    public int EarnedAchievements;

    string auxData = @"[
    {
 	    ""IdAchievement"": ""dd2f0fdf-5d8d-4a0b-b376-c9d59349eb72"",
 	    ""Name"": ""VIRTUALTOUR_ACHIEVEMENT1"",
 	    ""Description"": [{ ""Locale"": ""en-us"", ""Description"": ""Achievement test."" }],
 	    ""ImageUrl"": ""https://az726872.vo.msecnd.net/global-achievement/achievement_04bc0735-50ac-414d-b588-8684b27e537a.png"",
 	    ""BackgroundImageUrl"": ""https://az726872.vo.msecnd.net/global-achievementbackground/achievementbackground_5da57ebe-b2a6-4d77-bbc2-077cd93f3e87.png"",
 	    ""Level"": 1,
 	    ""LevelName"": [{ ""Locale"": ""en-us"", ""Description"": ""Achievement test."" }],
 	    ""Points"": 0,
 	    ""VirtualGoods"": [],
 	    ""Rules"": [{ ""IdAction"": ""VIRTUALTOUR_ACTION1"", ""ExecsCount"": 1, ""PrefixMode"": false }],
 	    ""Game"": 0,
 	    ""IdType"": ""VIRTUALTOUR"",
 	    ""ExpirationDate"": ""9999-12-30T23:00:00Z"",
 	    ""IdGroup"": ""b361ba7c-d5dc-43f6-8d9a-2e5e524cf629""
    }]";

    string auxData2 = @"{
        ""ContinuationToken"":null,
        ""ContinuationTokenB64"":null,
        ""Results"":[
            {
                ""IdUser"":""03edad5e-f581-4aed-b217-cc117e3556b4"",
                ""IdAchievement"":""b8c18e1b-fdb2-42d6-8cf0-344209dd1d11"",
                ""Level"":2,
                ""AchievedDate"":""2016-02-26T11:44:56.395Z"",
                ""LevelName"":[{""Locale"":""en-us"",""Description"":""Welcome!""}],
                ""Type"":""FAN"",
                ""Description"":[{""Locale"":""en-us"",""Description"":""User sign up""}],
                ""ImageUrl"":""https://az726872.vo.msecnd.net/global-achievement/FAN_Register.png""
            },
            {
                ""IdUser"":""03edad5e-f581-4aed-b217-cc117e3556b4"",
                ""IdAchievement"":""dd2f0fdf-5d8d-4a0b-b376-c9d59349eb72"",
                ""Level"":1,
                ""AchievedDate"":""2016-02-26T11:44:55.661Z"",
                ""LevelName"":[{""Locale"":""en-us"",""Description"":""Achievement test.""}],
                ""Type"":""VIRTUALTOUR"",
                ""Description"":[{""Locale"":""en-us"",""Description"":""Achievement test.""}],
                ""ImageUrl"":""https://az726872.vo.msecnd.net/global-achievement/achievement_04bc0735-50ac-414d-b588-8684b27e537a.png""
            }
        ],
        ""HasMoreResults"":false
    }";

    public void FAKE()
    {
		TotalAchievements = 0;
		Achievements = new Hashtable();
        ArrayList results = JSON.JsonDecode(auxData) as ArrayList;
        foreach (Hashtable ele in results)
        {
            string guid = ele["IdAchievement"] as string;
            string iname = ele["Name"] as string;
            string name = ((ele["Description"] as ArrayList)[0] as Hashtable)["Description"] as string;
            int points = (int)ele["Points"];
            int level = (int)ele["Level"];
            string description = ((ele["LevelName"] as ArrayList)[0] as Hashtable)["Description"] as string;
            string imageUrl = ele["ImageUrl "] as string;
            // string rule = ((ele["Rules"] as ArrayList)[0] as Hashtable)["IdAction"] as string;
            Achievement tmp = new Achievement(guid, name, iname, description, level, points, imageUrl);
            Achievements.Add(guid + "|" + level, tmp);
            TotalAchievements++;
        }

        Hashtable myachievements = JSON.JsonDecode(auxData2) as Hashtable;
        if (myachievements != null)
        {
            ArrayList myresults = myachievements["Results"] as ArrayList;
            foreach (Hashtable ele in myresults)
            {
                string guid = ele["IdAchievement"] as string;
                int level = (int)ele["Level"];
                string aux = guid + "|" + level;
                if (Achievements.ContainsKey(aux))
                {
                    Achievement myvg = (Achievement)Achievements[aux];
                    myvg.earned = true;
                    EarnedAchievements++;
                }
            }
        }
    }

    public IEnumerator AwaitRequest()
    {
        TotalAchievements = 0;
        Achievements = new Hashtable();
        yield return Authentication.AzureServices.AwaitRequestGet(string.Format("api/v1/achievements?achievementConfigurationType=VIRTUALTOUR&idClient={0}&language={1}", Authentication.IDClient, Authentication.AzureServices.MainLanguage), (res) =>
        {
            if (res != "null")
            {
                Debug.LogError(">>> Achievements " + res);
                ArrayList results = JSON.JsonDecode(res) as ArrayList;
                foreach (Hashtable ele in results)
                {
                    string guid = ele["IdAchievement"] as string;
                    string iname = ele["Name"] as string;
                    string name = ((ele["Description"] as ArrayList)[0] as Hashtable)["Description"] as string;
                    int points = (int)ele["Points"];
                    int level = (int)ele["Level"];
                    string description = ((ele["LevelName"] as ArrayList)[0] as Hashtable)["Description"] as string;
                    string imageUrl = ele["ImageUrl "] as string;
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

    public IEnumerator AwaitAchievementEarned(bool refresh =true) {
        bool needRequest = true;
        EarnedAchievements = 0;
//        string service = "api/v1/fan/me/Achievements?type=VIRTUALTOUR?";
        string service = "api/v1/fan/me/Achievements?";
        string url = string.Format("{0}?language={1}", service, Authentication.AzureServices.MainLanguage);
        while (needRequest) {            
            yield return Authentication.AzureServices.AwaitRequestGet(url, (res) => {
                if (res != "null")
                {
                    Debug.LogError(">>> MY achievements " + res);
                    Hashtable myachievements = JSON.JsonDecode(res) as Hashtable;
                    if (myachievements != null)
                    {
                        ArrayList myresults = myachievements["Results"] as ArrayList;
                        foreach (Hashtable ele in myresults)
                        {
                            string guid = ele["IdAchievement"] as string;
                            int level = (int)ele["Level"];
                            string aux = guid + "|" + level;
                            if (Achievements.ContainsKey(aux))
                            {
                                Achievement myvg = (Achievement)Achievements[aux];
                                myvg.earned = true;
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
                                url = string.Format("{0}?language={1}&ct={2}", service, Authentication.AzureServices.MainLanguage, myachievements["ContinuationToken"] as string);
                        }
                    }
                }
                else
                    needRequest=false;
            });
        }
        
    }

    public void SedAction(string guid ) {
        Hashtable hs = new Hashtable();
        hs.Add("ActionId", guid );
        hs.Add("ClientId", Authentication.IDClient);
        Authentication.AzureServices.RequestPostJSON( "api/v1/useractions", hs, (res) => {
            Debug.LogError(">>>>>>>>>> " + res);
        });
    }
}