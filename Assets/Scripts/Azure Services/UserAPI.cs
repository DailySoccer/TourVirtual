
// Android: Attempt to invoke virtual method 'java.lang.String com.microsoft.mdp.sdk.network.NetworkHandler.unauthorizedGet(java.lang.String)' on a null object reference
// iOS: OnSignInEvent KO No se ha podido completar la operación. Unnable to do exportTokenCacheStore.


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
    public bool Online = false;
#else
	public bool Online = true;
#endif
    public bool errorLogin;

    public bool Ready { get; set;  }

    public string   UserID      { get; set; }
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
            ModalTextOnly.ShowText( LanguageManager.Instance.GetTextValue("TVB.Error.NetError")+" (ERR:1)" );
        };
        
        Ready = false;
        Contents = new ContentAPI();
        Achievements = new AchievementsAPI();
        VirtualGoodsDesciptor = new VirtualGoodsAPI();
    }

    public bool CheckIsOtherUser() {
        
        if( DeepLinkingManager.Parameters != null &&
            DeepLinkingManager.Parameters.ContainsKey("idUser") && 
            DeepLinkingManager.Parameters["idUser"] as string != UserAPI.Instance.UserID ){
            LoadingCanvasManager.Hide();
            UserAPI.Instance.UserID=null;

            ModalTextOnly.ShowText( LanguageManager.Instance.GetTextValue("TVB.Error.BadUserID"), (val)=> {
                Authentication.AzureServices.SignOut ((ret)=>{ Application.Quit(); }, (ret)=>{ Application.Quit(); });
//                Authentication.AzureServices.SignIn();
            });
            return true;
        }
        return false;
    }
    bool requesting=true;
    public IEnumerator Request() {
        requesting=true;
        LoadingCanvasManager.Show();

        LoadingContentText.SetText("API.User");

// Aclarar con Microsoft que llamada es esta.
        yield return Authentication.AzureServices.PostFanApps((ok)=>{Debug.LogError("PostFanApps OK: "+ok); },(err)=>{ Debug.LogError("PostFanApps ERROR: "+err); });
// Evento añadido el dia 9/9/16 por peticion de microsoft.        
        UserAPI.Instance.SendAction("LOGIN_VIRTUAL_TOUR");
        yield return Authentication.AzureServices.GetFanMe((res) => {
            Dictionary<string, object> hs = MiniJSON.Json.Deserialize(res) as Dictionary<string, object>;
			MainManager.Instance.ChangeLanguage(hs.ContainsKey("Language")?hs["Language"] as string:"en-us");
            UserID = hs["IdUser"] as string;
			Nick = hs.ContainsKey("Alias")?hs["Alias"] as string:"";
        });

// Mira si los usuarios son distintos.
        if (string.IsNullOrEmpty(UserAPI.Instance.UserID) || CheckIsOtherUser()) { // USUARIO DISTINTO
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
            if (string.IsNullOrEmpty(res) || res == "null" || res == "{}") {
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
                    Debug.LogError(">>> ERROR REST ProfileAvatar " + e );
                    PlayerManager.Instance.SelectedModel = "";
					MainManager.VestidorMode = VestidorCanvasController_Lite.VestidorState.SELECT_AVATAR;
				}
            }
//            PlayerManager.Instance.SelectedModel = "";
//            MainManager.VestidorMode = VestidorCanvasController_Lite.VestidorState.SELECT_AVATAR;
		},(err)=>{
            Debug.LogError(">>>>> ProfileAvatar "+err);
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
        // ERROR: 6:Invalid response received
        yield return Authentication.Instance.StartCoroutine(GetMaxScore(MiniGame.FreeShoots));
        yield return Authentication.Instance.StartCoroutine(GetMaxScore(MiniGame.FreeKicks));
        // ERROR al solicitar la puntuacion del minijuego de HiddenObjects
        yield return Authentication.Instance.StartCoroutine(GetMaxScore(MiniGame.HiddenObjects));

        yield return Authentication.AzureServices.GetFanRanking((res) => {
            if (res != "null") {
                List<object> scores = MiniJSON.Json.Deserialize(res) as List<object>;
                FanRanking = new ScoreEntry[scores.Count];
                int cnt = 0;
                foreach (Dictionary<string, object> entry in scores){
					FanRanking[cnt++] = new ScoreEntry((int)(long)entry["Position"], entry["Alias"] as string, (int)(long)entry["GamingScore"], (bool)entry["IsCurrentUser"] );
                }

            }
        });

        PlayerManager.Instance.DataModel = RemotePlayerHUD.GetDataModel(this);
        if (OnUserLogin != null) {
            OnUserLogin();
        }
/*
        Debug.LogError(">>>> TEST Acciones de Gamificacion");        
        UserAPI.Instance.SendAction("VIRTUALTOUR_ACC_DESBLO_ALL_PACK",null,(err)=>{ Debug.LogError(">>>> ERROr1: VIRTUALTOUR_ACC_DESBLO_ALL_PACK "+err);});
        UserAPI.Instance.SendAction("VIRTUALTOUR_ACC_DESBLO_PACK",null,(err)=>{ Debug.LogError(">>>> ERROr1: VIRTUALTOUR_ACC_DESBLO_PACK "+err);});

        UserAPI.Instance.SendAction("VIRTUALTOUR_ACC_SCORE_BASKET",null,(err)=>{ Debug.LogError(">>>> ERROr1: VIRTUALTOUR_ACC_SCORE_BASKET "+err);});
        UserAPI.Instance.SendAction("VIRTUALTOUR_ACC_SCORE_GOAL",null,(err)=>{ Debug.LogError(">>>> ERROr1: VIRTUALTOUR_ACC_SCORE_GOAL "+err);});
        UserAPI.Instance.SendAction("VIRTUALTOUR_ACC_SCORE_QUEST",null,(err)=>{ Debug.LogError(">>>> ERROr1: VIRTUALTOUR_ACC_SCORE_QUEST "+err);});

        UserAPI.Instance.SendAction("VIRTUALTOUR_ACC_SALA_00",null,(err)=>{ Debug.LogError(">>>> ERROr1: VIRTUALTOUR_ACC_SALA_00 "+err);});
        UserAPI.Instance.SendAction("VIRTUALTOUR_ACC_SALA_01",null,(err)=>{ Debug.LogError(">>>> ERROr1: VIRTUALTOUR_ACC_SALA_01 "+err);});
        UserAPI.Instance.SendAction("VIRTUALTOUR_ACC_SALA_02",null,(err)=>{ Debug.LogError(">>>> ERROr1: VIRTUALTOUR_ACC_SALA_02"+err);});
        UserAPI.Instance.SendAction("VIRTUALTOUR_ACC_SALA_03",null,(err)=>{ Debug.LogError(">>>> ERROr1: VIRTUALTOUR_ACC_SALA_03"+err);});
        UserAPI.Instance.SendAction("VIRTUALTOUR_ACC_SALA_04",null,(err)=>{ Debug.LogError(">>>> ERROr1: VIRTUALTOUR_ACC_SALA_04"+err);});
        UserAPI.Instance.SendAction("VIRTUALTOUR_ACC_SALA_05",null,(err)=>{ Debug.LogError(">>>> ERROr1: VIRTUALTOUR_ACC_SALA_05"+err);});
        UserAPI.Instance.SendAction("VIRTUALTOUR_ACC_SALA_06",null,(err)=>{ Debug.LogError(">>>> ERROr1: VIRTUALTOUR_ACC_SALA_06"+err);});
        UserAPI.Instance.SendAction("VIRTUALTOUR_ACC_SALA_07",null,(err)=>{ Debug.LogError(">>>> ERROr1: VIRTUALTOUR_ACC_SALA_07"+err);});
        UserAPI.Instance.SendAction("VIRTUALTOUR_ACC_SALA_08",null,(err)=>{ Debug.LogError(">>>> ERROr1: VIRTUALTOUR_ACC_SALA_08"+err);});
        UserAPI.Instance.SendAction("VIRTUALTOUR_ACC_SALA_09",null,(err)=>{ Debug.LogError(">>>> ERROr1: VIRTUALTOUR_ACC_SALA_09"+err);});
        UserAPI.Instance.SendAction("VIRTUALTOUR_ACC_SALA_10",null,(err)=>{ Debug.LogError(">>>> ERROr1: VIRTUALTOUR_ACC_SALA_10"+err);});
        UserAPI.Instance.SendAction("VIRTUALTOUR_ACC_SALA_11",null,(err)=>{ Debug.LogError(">>>> ERROr1: VIRTUALTOUR_ACC_SALA_11"+err);});
        UserAPI.Instance.SendAction("VIRTUALTOUR_ACC_SALA_12",null,(err)=>{ Debug.LogError(">>>> ERROr1: VIRTUALTOUR_ACC_SALA_12"+err);});
        Debug.LogError(">>>> FIN Acciones de Gamificacion");        

        Debug.LogError(">>>> TEST Puntuaciones de juegos");
        SetScore(MiniGame.FreeKicks,10);   
        SetScore(MiniGame.FreeShoots,10);   
        SetScore(MiniGame.HiddenObjects,10);   
        Debug.LogError(">>>> FIN Puntuaciones de juegos");        
*/
        LoadingCanvasManager.Hide();
        requesting=false;
    }

     public IEnumerator UpdateByLanguage() {
        if(requesting) yield break;
        LoadingCanvasManager.Show();
        LoadingContentText.SetText("API.VirtualGoods");
        yield return Authentication.Instance.StartCoroutine( VirtualGoodsDesciptor.AwaitRequest() );
        LoadingContentText.SetText("API.Achievements");
        yield return Authentication.Instance.StartCoroutine( Achievements.AwaitRequest());
        LoadingContentText.SetText("API.Contents");
        yield return Authentication.Instance.StartCoroutine( Contents.AwaitRequest());
        VirtualGoodsDesciptor.FilterBySex();     
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
            if (res == "true") {
                Authentication.AzureServices.UpdateAlias(nick, (res2) => {
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
        if (!Online) {
            if (score > HighScore[(int)game])
                HighScore[(int)game] = score;
            return;
        }
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
        },(err)=>{Debug.LogError("ERR: GetMaxScore("+game+") "+err);});
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
