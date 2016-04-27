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

    public int GetAchievements(out int max)
    {
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
    public static UserAPI Instance { get; private set; }

    public delegate void UserLogin();
    public delegate void callback();
    public event UserLogin OnUserLogin;

	public void CallOnUserLogin(){
		OnUserLogin ();
	}


    public UserAPI() {
        Instance = this;
        Ready = false;
        Contents = new ContentAPI();
        Achievements = new AchievementsAPI();
        VirtualGoodsDesciptor = new VirtualGoodsAPI();
    }

    public IEnumerator Request() {
        LoadingCanvasManager.Show();

        LoadingContentText.SetText("API.User");
        yield return Authentication.AzureServices.AwaitRequestGet("api/v1/fan/me", (res) => {
            Dictionary<string, object> hs = BestHTTP.JSON.Json.Decode(res) as Dictionary<string, object>;
            MainManager.Instance.ChangeLanguage(hs["Language"] as string);
            UserID = hs["IdUser"] as string;
            Nick = hs["Alias"] as string;

        });
        if(string.IsNullOrEmpty(UserAPI.Instance.UserID)) yield break;;
        if ( MainManager.IsDeepLinking &&
                    MainManager.DeepLinkinParameters != null &&
                    MainManager.DeepLinkinParameters.ContainsKey("idUser") &&
                    MainManager.DeepLinkinParameters["idUser"] as string != UserAPI.Instance.UserID)
        { // USUARIO DISTINTO
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
        yield return Authentication.AzureServices.AwaitRequestGet("api/v1/fan/me/ProfileAvatar", (res) => {
            if (string.IsNullOrEmpty(res) || res == "null") {
                // Es la primera vez que entra el usuario!!!
                PlayerManager.Instance.SelectedModel = "";
                MainManager.VestidorMode = VestidorCanvasController_Lite.VestidorState.SELECT_AVATAR;
            }
            else {
                AvatarDesciptor.Parse(BestHTTP.JSON.Json.Decode(res) as Dictionary<string, object>);
                PlayerManager.Instance.SelectedModel = AvatarDesciptor.ToString();
                VirtualGoodsDesciptor.FilterBySex();
                MainManager.VestidorMode = VestidorCanvasController_Lite.VestidorState.VESTIDOR;
            }
//            PlayerManager.Instance.SelectedModel = "";
//            MainManager.VestidorMode = VestidorCanvasController_Lite.VestidorState.SELECT_AVATAR;
        });
        LoadingContentText.SetText("API.GamificationStatus");
        yield return Authentication.AzureServices.AwaitRequestGet(string.Format("api/v1/fan/me/GamificationStatus?language={0}&idClient={1}",
            Authentication.AzureServices.MainLanguage, Authentication.IDClient), (res) => {
                if (res != "null") {
                    try{
                        Dictionary<string, object> gamificationstatus = BestHTTP.JSON.Json.Decode(res) as Dictionary<string, object>;
                        Points = (int)(double)gamificationstatus["Points"];
                        Level = (int)(double)gamificationstatus["LevelNumber"];
                        Exp = (int)(double)gamificationstatus["GamingScore"];
                    }
                    catch { }
                }
            });

        LoadingContentText.SetText("API.Rankings");
//        yield return Authentication.Instance.StartCoroutine(AwaitGlobalRanking());
        yield return Authentication.Instance.StartCoroutine(GetRanking(MiniGame.FreeShoots));
        yield return Authentication.Instance.StartCoroutine(GetRanking(MiniGame.FreeKicks));
        yield return Authentication.Instance.StartCoroutine(GetRanking(MiniGame.HiddenObjects));
        LoadingContentText.SetText("API.MaxScores");
        yield return Authentication.Instance.StartCoroutine(GetMaxScore(MiniGame.FreeShoots));
        yield return Authentication.Instance.StartCoroutine(GetMaxScore(MiniGame.FreeKicks));
        yield return Authentication.Instance.StartCoroutine(GetMaxScore(MiniGame.HiddenObjects));
        LoadingContentText.SetText("");
        PlayerManager.Instance.DataModel = RemotePlayerHUD.GetDataModel(this);
        if (OnUserLogin != null) OnUserLogin();
        LoadingCanvasManager.Hide();
    }

    public void UpdateAvatar() {
        if (Online) {
            Authentication.AzureServices.RequestPostJSON("api/v1/fan/me/ProfileAvatar", AvatarDesciptor.GetProperties(), (res) =>{
                Debug.LogError("UpdateAvatar " + res);
            });
        }
    }

    public void UpdateNick(string nick, callback onok = null, callback onerror=null) {
        if (!Online) return;
        Authentication.AzureServices.RequestGet(string.Format("api/v1/fan/CheckAlias?alias={0}", nick), (res) => {
            if (res == "true") {
                Dictionary<string, object> hs = new Dictionary<string, object>();
                hs.Add("Alias", nick);
                Authentication.AzureServices.RequestJSON("put", "api/v1/fan/me/updatealias", hs, (res2) => {
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
        Authentication.AzureServices.Request("put", "api/v1/fan/me/ProfileAvatar/UploadPicture", bytes, (res) => {
            if (onSendAvatar != null) onSendAvatar();
        });
    }


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
        Authentication.AzureServices.RequestString("post", string.Format("api/v1/scores/{0}", MiniGameID[(int)game]), score.ToString(), (res) => {
            if (score > HighScore[(int)game])
                HighScore[(int)game] = score;
        });
    }

    public IEnumerator GetMaxScore(MiniGame game) {
        yield return Authentication.AzureServices.AwaitRequestGet(string.Format("api/v1/fan/me/MaxScore/{0}", MiniGameID[(int)game]), (res) => {
            Debug.LogError(">>>> GetMaxScore("+ game + ")" + res);
            if (res != "null") {
                Dictionary<string, object> MaxScore = BestHTTP.JSON.Json.Decode(res) as Dictionary<string, object>;
                HighScore[(int)game] = (int)(double)MaxScore["Score"];
            }
            else
                HighScore[(int)game] = 0;
        });
    }

    public IEnumerator GetRanking(MiniGame game) {
        yield return Authentication.AzureServices.AwaitRequestGet(string.Format("api/v1/scores/{0}", MiniGameID[(int)game]), (res) => {
            if (res != "null"){
                int cnt = 0;
                List<object> scores = BestHTTP.JSON.Json.Decode(res) as List<object>;
                var tmp = new ScoreEntry[scores.Count];
                foreach (Dictionary<string, object> entry in scores)
                    tmp[cnt++] = new ScoreEntry(entry["Alias"] as string, (int)(double)entry["Score"]);
                HighScores[(int)game] = tmp;
            }
        });
    }

}
