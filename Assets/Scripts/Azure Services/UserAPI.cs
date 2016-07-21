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
    public string   Nick        { get; set; }
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

    ScoreEntry[] FanRanking = null;

    public ScoreEntry[] GetFanRanking() {        
        return FanRanking;
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
        AsyncOperation.DefaultError = (err)=>{
            LoadingCanvasManager.Hide();
            ModalTextOnly.ShowText( LanguageManager.Instance.GetTextValue("TVB.Error.NetError") );
        };
        
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
			MainManager.Instance.ChangeLanguage(hs.ContainsKey("Language")?hs["Language"] as string:"es-es");
            UserID = hs["IdUser"] as string;
			Nick = hs.ContainsKey("Alias")?hs["Alias"] as string:"";
        });
		
		//UpdateNick ("Pokemos");
		//UpdateNick ("Gazmoño");

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
				try{
                AvatarDesciptor.Parse(MiniJSON.Json.Deserialize(res) as Dictionary<string, object>);
                PlayerManager.Instance.SelectedModel = AvatarDesciptor.ToString();

                VirtualGoodsDesciptor.FilterBySex();
                MainManager.VestidorMode = VestidorCanvasController_Lite.VestidorState.VESTIDOR;
				}catch(System.Exception e){
                    Debug.LogError(">>>>>>> ERROR REST ProfileAvatar " + e );
                    PlayerManager.Instance.SelectedModel = "";
					MainManager.VestidorMode = VestidorCanvasController_Lite.VestidorState.SELECT_AVATAR;
				}
            }
//            PlayerManager.Instance.SelectedModel = "";
//            MainManager.VestidorMode = VestidorCanvasController_Lite.VestidorState.SELECT_AVATAR;
		},(err)=>{
			PlayerManager.Instance.SelectedModel = "";
			MainManager.VestidorMode = VestidorCanvasController_Lite.VestidorState.SELECT_AVATAR;
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

        yield return Authentication.AzureServices.GetFanRanking((res) => {
            if (res != "null") {
                List<object> scores = MiniJSON.Json.Deserialize(res) as List<object>;
                FanRanking = new ScoreEntry[scores.Count];
                int cnt = 0;
                foreach (Dictionary<string, object> entry in scores)
					FanRanking[cnt++] = new ScoreEntry((int)(long)entry["Position"], entry["Alias"] as string, (int)(long)entry["GamingScore"], (bool)entry["IsCurrentUser"] );
            }
        });

        PlayerManager.Instance.DataModel = RemotePlayerHUD.GetDataModel(this);
        if (OnUserLogin != null) OnUserLogin();
        LoadingCanvasManager.Hide();
    }
	
    public void UpdateAvatar() {
        if (Online) {
//            Authentication.AzureServices.SetProfileAvatar(AvatarDesciptor.GetProperties(), (res) => {
            Authentication.AzureServices.CreateProfileAvatar(AvatarDesciptor.GetProperties(), (res) => {
            },(err)=>{
				Debug.LogError("Error UpdateAvatar " + err);
			});
        }
    }

    public void UpdateNick(string nick, callback onok = null, callback onerror=null) {
        if (!Online) return;
        Authentication.AzureServices.CheckAlias(nick, (res) => {
			Debug.Log (">>>> UpdateNick: CheckAlias "+nick + " >> res: " + res.ToString());
            if (res == "true") {
                Authentication.AzureServices.UpdateAlias(nick, (res2) => {
					Debug.Log (">>>> UpdateNick: UpdateAlias: Ok "+nick + " >> res2: " + res2);
                    if (onok != null) onok();
				},(err)=>{
					Debug.Log (">>>> UpdateNick: Error3 "+nick);
					if (onerror != null) onerror();
				});
            }
            else {
				Debug.Log (">>>> UpdateNick: Error1 "+nick);
                if (onerror != null) onerror();
            }
        }, (err)=> {
			Debug.Log (">>>> UpdateNick: Error2 "+nick);
            if (onerror != null) onerror();
        });
    }

    public void SendAvatar(byte[] bytes, callback onSendAvatar=null) {
        if (!Online) return;
        Authentication.AzureServices.SendAvatarImage(bytes, (res) => {
            if (onSendAvatar != null) onSendAvatar();
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
		public int Position;
        public bool IsMe;
        public string Nick;
        public int Score;
		public ScoreEntry(int position, string nick, int score, bool isme) {
			Position = position;
            Nick = nick;
            Score = score;
            IsMe = isme;
        }
    };

    ScoreEntry[][] HighScores = new ScoreEntry[3][];
    public void SetScore(MiniGame game, int score) {
        if (!Online) return;
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
					tmp[cnt++] = new ScoreEntry((int)(long)entry["Position"], entry["Alias"] as string, (int)(long)entry["Score"], (bool)entry["IsCurrentUser"]);
                HighScores[(int)game] = tmp;
            }
            if (onRanking != null) onRanking();
        },(err)=> {
            if (onRanking != null) onRanking();
        });
    }

    public void SendAction(string IDAction, AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null){
        if (!Online) return;
        Authentication.AzureServices.SendAction(IDAction,OnSucess, OnError);
    }
}
