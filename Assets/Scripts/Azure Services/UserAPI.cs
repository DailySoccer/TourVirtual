using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SmartLocalization;

// TODO:    No funciona el ranking global personal.
//          Tenemos un problema con los niveles si coincide justo la xp con la division entre niveles.
//          Que pasa con la energia? Otra tarea nueva para mi?
//          Recibos de compras en tiendas.
//          POST api/v1/purchases
//          Leer correctamente los virtualgoods de un avatar

public class UserAPI {
#if UNITY_EDITOR
   //TODO: put this value to 'true'
    public bool Online = true;
#else
	public bool Online = true;
#endif

    public bool Ready { get; set;  }

    public string   UserID      { get; private set; }
    public string   Nick        { get; private set; }
    public int      Points      { get; set; } // Tokens
    public int      Level       { get; set; } // Nivel de usuario
    public int      Exp         { get; set; } // Exp. total.
    // Fakes
    public int      Energy      { get; set; } // Energia minijuegos. FAKE!!!
    public float    NextLevel   { get {
            if (Level == 0) return 0;
            int[] levels = { 0, 25, 50, 85, 125, 175, 235, 300, 385, 485, 605, 745, 920, 1125, 1370, 1660, 2015, 2435, 2935, 3540, 3540 };
            float val = (Exp - levels[Level - 1]) / (float)(levels[Level] - levels[Level - 1]);
            if (val < 0) val = 0;
            else if (val > 1) val = 1;
            return val;
        }  }
    // Tools

    public int GetScore(MiniGame game) {
        return HighScore[(int)game];
    }

    public ScoreEntry[] GetHighScore(MiniGame game) {
        return HighScores[(int)game];
    }

    public int GetAchievements(out int max) {
        max = Achievements.TotalAchievements;
        return Achievements.EarnedAchievements;
    }

    public int ContentPack(out int max) {
        max = Contents.TotalContents;
        return Contents.GetOwned();
    }
    public static AchievementsAPI Achievements { get; private set; }
    public static ContentAPI Contents { get; private set; }

    public static AvatarAPI AvatarDesciptor =  new AvatarAPI();
    public static VirtualGoodsAPI VirtualGoodsDesciptor { get; private set; }

    static UserAPI instance;
    public static UserAPI Instance { get { if (instance == null) instance = new UserAPI(); return instance; } }

    public delegate void UserLogin();
    public delegate void callback();
    public delegate void callbackParam(string param);
    public event UserLogin OnUserLogin;

	public void CallOnUserLogin(){
		OnUserLogin ();
	}

    public UserAPI() {
        Ready = false;
        Contents = new ContentAPI();
        Achievements = new AchievementsAPI();
        VirtualGoodsDesciptor = new VirtualGoodsAPI();
    }

    public bool CheckIsOtherUser() {
        return Authentication.AzureServices.IsDeepLinking && Authentication.AzureServices.DeepLinkinParameters != null && Authentication.AzureServices.DeepLinkinParameters.ContainsKey("idUser") && Authentication.AzureServices.DeepLinkinParameters["idUser"] as string != UserAPI.Instance.UserID;
    }


    public IEnumerator Request() {
        LoadingCanvasManager.Show();

        LoadingContentText.SetText("API.User");
        yield return Authentication.AzureServices.GetFanApps();

        yield return Authentication.AzureServices.GetFanMe((res) => {
            Dictionary<string, object> hs = MiniJSON.Json.Deserialize(res) as Dictionary<string, object>;
            MainManager.Instance.ChangeLanguage(hs["Language"] as string);
            UserID = hs["IdUser"] as string;
            Nick = hs["Alias"] as string;
        });

        if (string.IsNullOrEmpty(UserAPI.Instance.UserID)) yield break;;
        if (CheckIsOtherUser()) { // USUARIO DISTINTO
            LoadingCanvasManager.Hide();
            Authentication.AzureServices.SignOut();
            ModalTextOnly.ShowText( LanguageManager.Instance.GetTextValue("TVB.Error.BadUserID"), ()=> {
                Authentication.AzureServices.SignIn();
            });
            yield break;
        }
        LoadingContentText.SetText("API.VirtualGoods");
        yield return Authentication.Instance.StartCoroutine( VirtualGoodsDesciptor.AwaitRequest() );
        LoadingContentText.SetText("API.Achievements");

        yield return Authentication.Instance.StartCoroutine( Achievements.AwaitRequest());
        LoadingContentText.SetText("API.Contents");
        yield return Authentication.Instance.StartCoroutine( Contents.AwaitRequest());

        LoadingContentText.SetText("API.ProfileAvatar");
        yield return Authentication.AzureServices.GetProfileAvatar((res) => {
            if (string.IsNullOrEmpty(res) || res == "null") {
                // Es la primera vez que entra el usuario!!!
                PlayerManager.Instance.SelectedModel = "";
                MainManager.VestidorMode = VestidorCanvasController_Lite.VestidorState.SELECT_AVATAR;
            }
            else {
                AvatarDesciptor.Parse(MiniJSON.Json.Deserialize(res) as Dictionary<string, object>);
                PlayerManager.Instance.SelectedModel = AvatarDesciptor.ToString();

                VirtualGoodsDesciptor.FilterBySex();
                MainManager.VestidorMode = VestidorCanvasController_Lite.VestidorState.VESTIDOR;
            }
//            PlayerManager.Instance.SelectedModel = "";
//            MainManager.VestidorMode = VestidorCanvasController_Lite.VestidorState.SELECT_AVATAR;
        });

        LoadingContentText.SetText("API.GamificationStatus");
        yield return Authentication.AzureServices.GamificationStatus( (res) => {
                if (res != "null") {
                    Dictionary<string, object> gamificationstatus = MiniJSON.Json.Deserialize(res) as Dictionary<string, object>;
                    Points = (int)(long)gamificationstatus["Points"];
                    Level = (int)(long)gamificationstatus["LevelNumber"];
                    Exp = (int)(long)gamificationstatus["GamingScore"];
                }
            });
        //        LoadingContentText.SetText("API.Rankings");
        //        yield return Authentication.Instance.StartCoroutine(AwaitGlobalRanking());
        //        yield return Authentication.Instance.StartCoroutine(GetRanking(MiniGame.FreeShoots));
        //        yield return Authentication.Instance.StartCoroutine(GetRanking(MiniGame.FreeKicks));
        //        yield return Authentication.Instance.StartCoroutine(GetRanking(MiniGame.HiddenObjects));
        LoadingContentText.SetText("API.MaxScores");
        yield return Authentication.Instance.StartCoroutine(GetMaxScore(MiniGame.FreeShoots));
        yield return Authentication.Instance.StartCoroutine(GetMaxScore(MiniGame.FreeKicks));
        yield return Authentication.Instance.StartCoroutine(GetMaxScore(MiniGame.HiddenObjects));
        LoadingContentText.SetText("");

        /// Test de compra contra MS!
        //        Purchase("100coins", "{ \"orderId\":\"GPA.1333-6426-9614-43683\",\"packageName\":\"com.realmadrid.virtualworld\",\"productId\":\"com.realmadrid.virtualworld.100coins\",\"purchaseTime\":1462444788449,\"purchaseState\":0,\"purchaseToken\":\"bdgloghieomillmdmdofcoem.AO-J1OybYtDs5EkM7WRkK5Kzw1jbtNMUZFPG7wXR2NpkM1VrdSsQDnY1AuKXwIjZQ1muUJi-hEXM1NRpzS3FcATFm1e6vsDbhbWw8eMUlryTNAKSHe9Bm0pRWAWyD1kMdorh6vZACur2-yKgurb-Iq2mIRF8o_HqGlvnFQV8OCd8-wF0X1BZl_w\"}");
        PlayerManager.Instance.DataModel = RemotePlayerHUD.GetDataModel(this);
        if (OnUserLogin != null) OnUserLogin();
        LoadingCanvasManager.Hide();
    }

    public void UpdateAvatar() {
        if (Online) {
            Authentication.AzureServices.SetProfileAvatar( AvatarDesciptor.GetProperties(), (res) =>{
                Debug.LogError("UpdateAvatar " + res);
            });
        }
    }

    public void UpdateNick(string nick, callback onok = null, callback onerror=null) {
        if (!Online) return;
        Authentication.AzureServices.CheckAlias(nick, (res) => {
            if (res == "true") {
                Authentication.AzureServices.UpdateAlias(nick, (res2) => {
                    if (onok != null) onok();
                });
            }
            else {
                if (onerror != null) onerror();
            }
        }, (err)=> {
            if (onerror != null) onerror();
        });
    }

    public void SendAvatar(byte[] bytes, callback onSendAvatar=null) {
        if (!Online) return;
        Authentication.AzureServices.SendAvatarImage(bytes, (res) => {
            if (onSendAvatar != null) onSendAvatar();
        });
    }

    /*
public IEnumerator AwaitGlobalRanking() {
    // Global.

    yield return Authentication.AzureServices.AwaitRequestGet(string.Format("api/v1/fan/me/Rankings/{0}",Authentication.IDClient), (res) => {
        if (res != "null"){
        }
        else {
            Debug.LogError(">>>> Rankings ERROR " + res);
        }

    });
    // Del usuario.
    yield return Authentication.AzureServices.AwaitRequestGet(string.Format("api/v1/Rankings/{0}/{1}", Authentication.IDClient, UserAPI.Instance.UserID), (res) => {
        if (res != "null") {
        }
        else {
            Debug.LogError(">>>> Rankings2 ERROR " + res);
        }
    });

}
    */
    public enum MiniGame {
        FreeKicks,
        FreeShoots,
        HiddenObjects
    };

    string[] MiniGameID = new string[] {
        "64c478e3-a3dd-441e-94e5-f5f4fe64ceae",
        "9ca1aacd-9104-404d-87bb-909a64957c4c",
        "9c45010a-eb1c-4b51-9c2c-e2339b824e21"
    };

    int[] HighScore = new int[3] { 0, 0, 0 };

    public struct ScoreEntry {
        public string Nick;
        public int Score;
        public ScoreEntry(string nick, int score) {
            Nick = nick;
            Score = score;
        }
    };

    ScoreEntry[][] HighScores = new ScoreEntry[3][];
    public void SetScore(MiniGame game, int score) {
        Authentication.AzureServices.SendScore( MiniGameID[(int)game], score, (res) => {
            if (score > HighScore[(int)game])
                HighScore[(int)game] = score;
        });
    }

    public IEnumerator GetMaxScore(MiniGame game) {
        yield return Authentication.AzureServices.GetMaxScore(MiniGameID[(int)game], (res) => {
            if (res != "null") {
                Dictionary<string, object> MaxScore = MiniJSON.Json.Deserialize(res) as Dictionary<string, object>;
                HighScore[(int)game] = (int)(long)MaxScore["Score"];
            }
            else
                HighScore[(int)game] = 0;
        });
    }

    public void GetRanking(MiniGame game, callback onRanking) {
        Authentication.AzureServices.GetRanking(MiniGameID[(int)game], (res) => {
            if (res != "null"){
                int cnt = 0;
                List<object> scores = MiniJSON.Json.Deserialize(res) as List<object>;
                var tmp = new ScoreEntry[scores.Count];
                foreach (Dictionary<string, object> entry in scores)
                    tmp[cnt++] = new ScoreEntry(entry["Alias"] as string, (int)(long)entry["Score"]);
                HighScores[(int)game] = tmp;
            }
            if (onRanking != null) onRanking();
        },(err)=> {
            if (onRanking != null) onRanking();
        });
    }
/*
    public void Purchase(string IdProduct, string Receipt, callback onok = null, callbackParam onerror = null) {
        Dictionary<string, object> hs = new Dictionary<string, object>();
        hs.Add("IdClient", Authentication.IDClient);
        hs.Add("IdProduct", IdProduct);
        hs.Add("Receipt", Receipt);
        hs.Add("UseVirtualGoods", false);
        Authentication.AzureServices.RequestJSON("post", "api/v1/purchases", hs, (res) => {
            Debug.LogError("Purchase OK-> " + res);
            if (onok != null) onok();
        }, (res) => {
            Debug.LogError("Purchase KO-> " + res);
            if (onerror != null) onerror(res);
        });
    }
*/
}
