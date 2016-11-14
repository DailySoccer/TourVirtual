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
        yield return Authentication.AzureServices.GetAchievements("VIRTUALTOUR", (res) => {
            if (res != "null") {
                List<object> results = MiniJSON.Json.Deserialize(res) as List<object>;
                foreach (Dictionary<string, object> ele in results) {
                    string guid = ele["IdAchievement"] as string;
                    string iname = ele["Name"] as string;
                    string name = ((ele["LevelName"] as List<object>)[0] as Dictionary<string, object>)["Description"] as string;
                    string description = ((ele["Description"] as List<object>)[0] as Dictionary<string, object>)["Description"] as string;

                    int points = (int)(long)ele["Points"];
                    int level = (int)(long)ele["Level"];
                    string imageUrl = ele["ImageUrl"] as string;
                    // string rule = ((ele["Rules"] as ArrayList)[0] as Hashtable)["IdAction"] as string;
                    Achievement tmp = new Achievement(guid, name, iname, description, level, points, imageUrl);
                    Achievements.Add(guid + "|" + level, tmp);
                    TotalAchievements++;
                }
            }
        },(err)=>{Debug.LogError(">>>> Error: GetAchievements "+err);});

        // Consulta mis logros.
        yield return Authentication.Instance.StartCoroutine(AwaitAchievementEarned(false));
    }

    public System.Collections.IEnumerator AwaitAchievementEarned(bool refresh =true) {
        bool needRequest = true;
        string token = null;
        EarnedAchievements = 0;

        while (needRequest) {            
            yield return Authentication.AzureServices.GetAchievementsEarned("VIRTUALTOUR", token, (res) => {
                var pp = MiniJSON.Json.Deserialize(res);
                Dictionary<string, object> myachievements = pp as Dictionary<string, object>;
                if (myachievements != null)
                {
                    List<object> myresults = myachievements["Results"] as List<object>;
                    foreach (Dictionary<string, object> ele in myresults)
                    {
                        string guid = ele["IdAchievement"] as string;
                        int level = (int)(long)ele["Level"];
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
                        if (needRequest)
                            token = myachievements.ContainsKey("ContinuationTokenB64")?myachievements["ContinuationTokenB64"] as string:"";
                    }
                }
            },(err)=>{Debug.LogError(">>>> Error: GetAchievementsEarned "+err);});
        }
        
    }
}