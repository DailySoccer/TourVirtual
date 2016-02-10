using UnityEngine;
using System.Collections;


/*

{"IdAchievement":"2ca451db-ffff-4f1e-b68a-6372f0946284","Name":"CHAMPIONS_CHALLENGE_BRONZE","Description":[{"Locale":"en-us","Description":"10 Champions League Challenge. Bernabéu"}],"ImageUrl":"https://az726872.vo.msecnd.net/global-achievement/CHECKIN_10.png","BackgroundImageUrl":"https://az726872.vo.msecnd.net/global-achievementbackground/BronzeBadge.png","Level":1,"LevelName":[{"Locale":"en-us","Description":"Checkin in Santiago Bernabéu Stadium"}],"Points":0,"VirtualGoods":[],"Rules":[{"IdAction":"CHECKIN_SANTIAGO_BERNABEU","ExecsCount":1,"PrefixMode":false}],"Game":0,"IdType":"CHECKIN","ExpirationDate":"9999-12-31T00:00:00Z","IdGroup":null},
{"IdAchievement":"2ca451db-ffff-4f1e-b68a-6372f0946284","Name":"CHAMPIONS_CHALLENGE_SILVER","Description":[{"Locale":"en-us","Description":"10 Champions League Challenge. 2 Stadiums"}],"ImageUrl":"https://aaz726872.vo.msecnd.net/global-achievement/CHECKIN_10.png","BackgroundImageUrl":"https://az726872.vo.msecnd.net/global-achievementbackground/SilverBadge.png","Level":2,"LevelName":[{"Locale":"en-us","Description":"Checkin in Bernabéu and in 1 stadium where Real Madrid won a Champions League"}],"Points":0,"VirtualGoods":[],"Rules":[{"IdAction":"CHECKIN_SANTIAGO_BERNABEU","ExecsCount":1,"PrefixMode":false},{"IdAction":"CHECKIN_CHAMPION_","ExecsCount":1,"PrefixMode":true}],"Game":0,"IdType":"CHECKIN","ExpirationDate":"9999-12-31T00:00:00Z","IdGroup":null},
{"IdAchievement":"2ca451db-ffff-4f1e-b68a-6372f0946284","Name":"CHAMPIONS_CHALLENGE_GOLD","Description":[{"Locale":"en-us","Description":"10 Champions League Challenge. 4 Stadiums"}],"ImageUrl":"https://az726872.vo.msecnd.net/global-achievement/CHECKIN_10.png","BackgroundImageUrl":"https://az726872.vo.msecnd.net/global-achievementbackground/GoldBadge.png","Level":3,"LevelName":[{"Locale":"en-us","Description":"Checkin in Bernabéu and in 3 stadiums where Real Madrid won a Champions League"}],"Points":0,"VirtualGoods":[],"Rules":[{"IdAction":"CHECKIN_SANTIAGO_BERNABEU","ExecsCount":1,"PrefixMode":false},{"IdAction":"CHECKIN_CHAMPION_","ExecsCount":3,"PrefixMode":true}],"Game":0,"IdType":"CHECKIN","ExpirationDate":"9999-12-31T00:00:00Z","IdGroup":null},
{"IdAchievement":"2ca451db-ffff-4f1e-b68a-6372f0946284","Name":"CHAMPIONS_CHALLENGE_PLATINUM","Description":[{"Locale":"en-us","Description":"10 Champions League Challenge. 6 Stadiums"}],"ImageUrl":"https://az726872.vo.msecnd.net/global-achievement/CHECKIN_10.png","BackgroundImageUrl":"https://az726872.vo.msecnd.net/global-achievementbackground/PlatinumBadge.png","Level":4,"LevelName":[{"Locale":"en-us","Description":"Checkin in Bernabéu and in 5 stadiums where Real Madrid won a Champions League"}],"Points":0,"VirtualGoods":[],"Rules":[{"IdAction":"CHECKIN_SANTIAGO_BERNABEU","ExecsCount":1,"PrefixMode":false},{"IdAction":"CHECKIN_CHAMPION_","ExecsCount":5,"PrefixMode":true}],"Game":0,"IdType":"CHECKIN","ExpirationDate":"9999-12-31T00:00:00Z","IdGroup":null},
{"IdAchievement":"2ca451db-ffff-4f1e-b68a-6372f0946284","Name":"CHAMPIONS_CHALLENGE_DIAMOND","Description":[{"Locale":"en-us","Description":"10 Champions League Challenge. 8 Stadiums"}],"ImageUrl":"https://az726872.vo.msecnd.net/global-achievement/CHECKIN_10.png","BackgroundImageUrl":"https://az726872.vo.msecnd.net/global-achievementbackground/DiamondBadge.png","Level":5,"LevelName":[{"Locale":"en-us","Description":"Checkin in all stadium where Real Madrid won a Champions League"}],"Points":0,"VirtualGoods":[],"Rules":[{"IdAction":"CHECKIN_SANTIAGO_BERNABEU","ExecsCount":1,"PrefixMode":false},{"IdAction":"CHECKIN_CHAMPION_","ExecsCount":7,"PrefixMode":true}],"Game":0,"IdType":"CHECKIN","ExpirationDate":"9999-12-31T00:00:00Z","IdGroup":null},
{"IdAchievement":"482c2f37-00bd-43f5-b5e5-f8504e7459c9","Name":"INTERNATIONAL_CHALLENGE_BRONZE","Description":[{"Locale":"en-us","Description":"International Challenge. Bernabéu"}],"ImageUrl":"https://az726872.vo.msecnd.net/global-achievement/CHECKIN_Inter.png","BackgroundImageUrl":"https://az726872.vo.msecnd.net/global-achievementbackground/BronzeBadge.png","Level":1,"LevelName":[{"Locale":"en-us","Description":"Checkin in Santiago Bernabéu Stadium"}],"Points":0,"VirtualGoods":[],"Rules":[{"IdAction":"CHECKIN_SANTIAGO_BERNABEU","ExecsCount":1,"PrefixMode":false}],"Game":0,"IdType":"CHECKIN","ExpirationDate":"9999-12-31T00:00:00Z","IdGroup":null},
{"IdAchievement":"482c2f37-00bd-43f5-b5e5-f8504e7459c9","Name":"INTERNATIONAL_CHALLENGE_SILVER","Description":[{"Locale":"en-us","Description":"International Challenge. 2 Stadiums"}],"ImageUrl":"https://az726872.vo.msecnd.net/global-achievement/CHECKIN_Inter.png","BackgroundImageUrl":"https://az726872.vo.msecnd.net/global-achievementbackground/SilverBadge.png","Level":2,"LevelName":[{"Locale":"en-us","Description":"Checkin in Bernabéu and 1 Stadium where Real Madrid won an international title"}],"Points":0,"VirtualGoods":[],"Rules":[{"IdAction":"CHECKIN_SANTIAGO_BERNABEU","ExecsCount":1,"PrefixMode":false},{"IdAction":"CHECKIN_INTERNATIONAL_","ExecsCount":1,"PrefixMode":true}],"Game":0,"IdType":"CHECKIN","ExpirationDate":"9999-12-31T00:00:00Z","IdGroup":null},
{"IdAchievement":"482c2f37-00bd-43f5-b5e5-f8504e7459c9","Name":"INTERNATIONAL_CHALLENGE_GOLD","Description":[{"Locale":"en-us","Description":"International Challenge. 4 Stadiums"}],"ImageUrl":"https://az726872.vo.msecnd.net/global-achievement/CHECKIN_Inter.png","BackgroundImageUrl":"https://az726872.vo.msecnd.net/global-achievementbackground/GoldBadge.png","Level":3,"LevelName":[{"Locale":"en-us","Description":"Checkin in Bernabéu and 3 Stadiums where Real Madrid won an international title"}],"Points":0,"VirtualGoods":[],"Rules":[{"IdAction":"CHECKIN_SANTIAGO_BERNABEU","ExecsCount":1,"PrefixMode":false},{"IdAction":"CHECKIN_INTERNATIONAL_","ExecsCount":3,"PrefixMode":true}],"Game":0,"IdType":"CHECKIN","ExpirationDate":"9999-12-31T00:00:00Z","IdGroup":null},
{"IdAchievement":"482c2f37-00bd-43f5-b5e5-f8504e7459c9","Name":"INTERNATIONAL_CHALLENGE_PLATINUM","Description":[{"Locale":"en-us","Description":"International Challenge. 6 Stadiums"}],"ImageUrl":"https://az726872.vo.msecnd.net/global-achievement/CHECKIN_Inter.png","BackgroundImageUrl":"https://az726872.vo.msecnd.net/global-achievementbackground/PlatinumBadge.png","Level":4,"LevelName":[{"Locale":"en-us","Description":"Checkin in Bernabéu and 5 Stadiums where Real Madrid won an international title"}],"Points":0,"VirtualGoods":[],"Rules":[{"IdAction":"CHECKIN_SANTIAGO_BERNABEU","ExecsCount":1,"PrefixMode":false},{"IdAction":"CHECKIN_INTERNATIONAL_","ExecsCount":5,"PrefixMode":true}],"Game":0,"IdType":"CHECKIN","ExpirationDate":"9999-12-31T00:00:00Z","IdGroup":null},
{"IdAchievement":"482c2f37-00bd-43f5-b5e5-f8504e7459c9","Name":"INTERNATIONAL_CHALLENGE_DIAMOND","Description":[{"Locale":"en-us","Description":"International Challenge. 10 Stadiums"}],"ImageUrl":"https://az726872.vo.msecnd.net/global-achievement/CHECKIN_Inter.png","BackgroundImageUrl":"https://az726872.vo.msecnd.net/global-achievementbackground/DiamondBadge.png","Level":5,"LevelName":[{"Locale":"en-us","Description":"Checkin in Bernabéu, 8 Stadiums where Real Madrid won an international title and in Real Madrid Café Dubai."}],"Points":0,"VirtualGoods":[],"Rules":[{"IdAction":"CHECKIN_SANTIAGO_BERNABEU","ExecsCount":1,"PrefixMode":false},{"IdAction":"CHECKIN_INTERNATIONAL_","ExecsCount":9,"PrefixMode":true}],"Game":0,"IdType":"CHECKIN","ExpirationDate":"9999-12-31T00:00:00Z","IdGroup":null},
{"IdAchievement":"c10bfe37-a096-42a1-944c-24efa3ec648f","Name":"MADRID_CHALLENGE_BRONZE","Description":[{"Locale":"en-us","Description":"Challenge in Madrid. Bernabéu"}],"ImageUrl":"https://az726872.vo.msecnd.net/global-achievement/CHECKIN_Madrid.png","BackgroundImageUrl":"https://az726872.vo.msecnd.net/global-achievementbackground/BronzeBadge.png","Level":1,"LevelName":[{"Locale":"en-us","Description":"Checkin in Santiago Bernabeu Stadium"}],"Points":0,"VirtualGoods":[],"Rules":[{"IdAction":"CHECKIN_SANTIAGO_BERNABEU","ExecsCount":1,"PrefixMode":false}],"Game":0,"IdType":"CHECKIN","ExpirationDate":"9999-12-31T00:00:00Z","IdGroup":null},
{"IdAchievement":"c10bfe37-a096-42a1-944c-24efa3ec648f","Name":"MADRID_CHALLENGE_SILVER","Description":[{"Locale":"en-us","Description":"Challenge in Madrid. 3 locations"}],"ImageUrl":"https://az726872.vo.msecnd.net/global-achievement/CHECKIN_Madrid.png","BackgroundImageUrl":"https://az726872.vo.msecnd.net/global-achievementbackground/SilverBadge.png","Level":2,"LevelName":[{"Locale":"en-us","Description":"Checkin in Bernabéu and two of these locations (Valdebebas, Cibeles or Barclaycard Center)"}],"Points":0,"VirtualGoods":[],"Rules":[{"IdAction":"CHECKIN_SANTIAGO_BERNABEU","ExecsCount":1,"PrefixMode":false},{"IdAction":"CHECKIN_MADRID_","ExecsCount":2,"PrefixMode":true}],"Game":0,"IdType":"CHECKIN","ExpirationDate":"9999-12-31T00:00:00Z","IdGroup":null},
{"IdAchievement":"c10bfe37-a096-42a1-944c-24efa3ec648f","Name":"MADRID_CHALLENGE_GOLD","Description":[{"Locale":"en-us","Description":"Challenge in Madrid. 4 locations"}],"ImageUrl":"https://az726872.vo.msecnd.net/global-achievement/CHECKIN_Madrid.png","BackgroundImageUrl":"https://az726872.vo.msecnd.net/global-achievementbackground/GoldBadge.png","Level":3,"LevelName":[{"Locale":"en-us","Description":"Checkin in all these locations (Bernabéu, Valdebebas, Cibeles and Barclaycard Center)"}],"Points":0,"VirtualGoods":["35580ed3-726b-4c71-8f84-2da4f1768c4c"],"Rules":[{"IdAction":"CHECKIN_SANTIAGO_BERNABEU","ExecsCount":1,"PrefixMode":false},{"IdAction":"CHECKIN_MADRID_","ExecsCount":3,"PrefixMode":true}],"Game":0,"IdType":"CHECKIN","ExpirationDate":"9999-12-31T00:00:00Z","IdGroup":null}
    */

public class AchievementsAPI{ 
    public class Achievement{
        public string GUID;
        public string Name;
        public string Description;
        public int Level;
        public string Image;
        public int Points;
        public bool earned;
        public Achievement(string _GUID, string _Name, string _Description, int _Level, int _Points, string _Image) {
            GUID = _GUID;
            Name = _Name;
            Description = _Description;
            Level = _Level;
            Points = _Points;
            Image = _Image;
            earned = false;
        }
    }

    public Hashtable Achievements;

    public IEnumerator AwaitRequest(){
        Achievements = new Hashtable();
        // VIRTUALTOUR
        yield return Authentication.AzureServices.AwaitRequestGet(string.Format("api/v1/achievements?achievementConfigurationType=CHECKIN&idClient={0}&language={1}", Authentication.IDClient, Authentication.AzureServices.MainLanguage), (res) => {
            ArrayList results = JSON.JsonDecode(res) as ArrayList;
            foreach (Hashtable ele in results) {
                string guid = ele["IdAchievement"] as string;
                string name = ((ele["Description"] as ArrayList)[0] as Hashtable)["Description"] as string;
                int points = (int)ele["Points"];
                int level = (int)ele["Level"];
                string description = ((ele["LevelName"] as ArrayList)[0] as Hashtable)["Description"] as string;
                string ImageUrl = ele["ImageUrl "] as string;
                Achievement tmp = new Achievement(guid, name, description, level,  points, ImageUrl);
                Achievements.Add(guid + "|" + level, tmp);
            }
        });

        bool needRequest = true;
        while (needRequest) {
            yield return Authentication.AzureServices.AwaitRequestGet(string.Format("api/v1/fan/me/Achievements?type=CHECKIN&language={0}", Authentication.AzureServices.MainLanguage), (res) => {
                if (res != "null" )
                {
                    Debug.LogError(">>>MyAchievementsAPI " + res);
                    Hashtable myachievements = JSON.JsonDecode(res) as Hashtable;
                    if (myachievements != null)
                    {
                        ArrayList myresults = myachievements["Results"] as ArrayList;
                        foreach (Hashtable ele in myresults)
                        {
                            string guid = ele["IdAchievement"] as string;
                            int level = (int)ele["Level"];
                            if (Achievements.ContainsKey(guid + "|" + level))
                            {
                                Achievement myvg = (Achievement)Achievements[guid];
                                myvg.earned = true;
                            }
                        }
                        needRequest = false;
                        if (myachievements.ContainsKey("HasMoreResults")) needRequest = (bool)myachievements["HasMoreResults"];
                    }
                }
            });
        }
    }

    public void Earn(string guid, bool multiple = false) {
        if (Achievements.ContainsKey(guid)) {
            Achievement vg = (Achievement)Achievements[guid];
        }
    }
}