using UnityEngine;
using System.Collections;

// TODO:    No funciona el ranking global personal.
//          Tenemos un problema con los niveles si coincide justo la xp con la division entre niveles.
//          Que pasa con la energia? Otra tarea nueva para mi?
//          Recibos de compras en tiendas.
//          POST api/v1/purchases
//          Leer correctamente los virtualgoods de un avatar

public class UserAPI {

    public bool Online = true;


    public string   UserID      { get; private set; }
    public string   Nick        { get; private set; }
    public int      Points      { get; set; }
    public int      Level       { get; set; }
    public int      Exp         { get; set; }
    // Fakes
    public int      Energy      { get; set; }
    public float    NextLevel   { get; set; }

    public static AvatarAPI AvatarDesciptor;
    public static VirtualGoodsAPI VirtualGoodsDesciptor { get; private set; }
    public static AchievementsAPI Achievements { get; private set; }
    public static ContentAPI Contents { get; private set; }
    public static UserAPI Instance { get; private set; }


    public delegate void UserLogin();
    public event UserLogin OnUserLogin;


    public UserAPI() {
        Instance = this;
        Contents = new ContentAPI();
        Achievements = new AchievementsAPI();
        VirtualGoodsDesciptor = new VirtualGoodsAPI();
        if (!Online) VirtualGoodsDesciptor.FAKE();
    }

    public IEnumerator Request() {
        yield return Authentication.Instance.StartCoroutine( VirtualGoodsDesciptor.AwaitRequest() );
        yield return Authentication.Instance.StartCoroutine( Achievements.AwaitRequest());
        yield return Authentication.Instance.StartCoroutine( Contents.AwaitRequest() );

        yield return Authentication.AzureServices.AwaitRequestGet("api/v1/fan/me", (res) => {
            Hashtable hs = JSON.JsonDecode(res) as Hashtable;
            UserID = hs["IdUser"] as string;
            Nick = hs["Alias"] as string;
        });

        yield return Authentication.AzureServices.AwaitRequestGet("api/v1/fan/me/ProfileAvatar", (res) => {
            if (string.IsNullOrEmpty(res) || res == "null") {
                // Es la primera vez que entra el usuario!!!
                PlayerManager.Instance.SelectedModel = "";
            }
            else {
                AvatarDesciptor.Parse(JSON.JsonDecode(res) as Hashtable);
                PlayerManager.Instance.SelectedModel = AvatarDesciptor.ToString();
                VirtualGoodsDesciptor.FilterBySex();
            }
        });

        yield return Authentication.AzureServices.AwaitRequestGet(string.Format("api/v1/fan/me/GamificationStatus?language={0}&idClient={1}",
            Authentication.AzureServices.MainLanguage, Authentication.IDClient), (res) => {
                try {
                    Hashtable gamificationstatus = JSON.JsonDecode(res) as Hashtable;
                    Points = (int)gamificationstatus["Points"];
                    Level = int.Parse(gamificationstatus["Level"] as string);
                    // No se porque no devuelve la XP.
                }
                catch { }
            });

        yield return Authentication.Instance.StartCoroutine(AwaitGlobalRanking() );
        if (OnUserLogin != null) OnUserLogin();
        /*
        // Pruebas de rankings de minijuegos
        yield return Authentication.Instance.StartCoroutine(GetRanking(MiniGame.FreeShoots));
        yield return Authentication.Instance.StartCoroutine(GetRanking(MiniGame.FreeKicks));
        yield return Authentication.Instance.StartCoroutine(GetRanking(MiniGame.HiddenObjects));

        // Escritura de puntos.
        SetScore(MiniGame.FreeShoots, 300);
        SetScore(MiniGame.FreeKicks, 300);
        SetScore(MiniGame.HiddenObjects, 300);
        */
    }

    public void UpdateAvatar()
    {
        Authentication.AzureServices.RequestPostJSON("api/v1/fan/me/ProfileAvatar", AvatarDesciptor.GetProperties(), (res) => {
            Debug.LogError("UpdateAvatar " + res);
        }, null);
    }

    public void UpdateNick(string nick) {
        if (!Online) return;
        Authentication.AzureServices.RequestGet(string.Format("api/v1/fan/CheckAlias?alias={0}", nick), (res) => {
            Hashtable hs = new Hashtable();
            hs.Add("Alias", nick);
            Authentication.AzureServices.RequestJSON( "put", "api/v1/fan/me/updatealias", hs, (res2) =>
            {
                Debug.LogError("UpdateNick " + res2);
            });
        }, (err)=>
        {
            Debug.LogError("Nick en uso");
        });
    }

    public void SendAvatar(byte[] bytes) {
        Authentication.AzureServices.Request("put", "api/v1/fan/me/ProfileAvatar/UploadPicture", bytes, (res) => {
            Debug.LogError("SendAvatar " + res);
        });
    }


    public IEnumerator AwaitGlobalRanking() {
        yield return Authentication.AzureServices.AwaitRequestGet(string.Format("api/v1/fan/me/Rankings/{0}",Authentication.IDClient), (res) => {


        });

        yield return Authentication.AzureServices.AwaitRequestGet(string.Format("api/v1/Rankings/{0}/{1}", Authentication.IDClient, UserAPI.Instance.UserID), (res) => {
            if (res != "null") {
                Hashtable globalRanking = JSON.JsonDecode(res) as Hashtable;
                if (globalRanking != null)
                {
                    Exp = (int)globalRanking["GamingScore"];
                }
            }
        });
    }

    public enum MiniGame{
        FreeKicks,
        FreeShoots,
        HiddenObjects
    };

    string[] MiniGameID = new string[] {
        "64c478e3-a3dd-441e-94e5-f5f4fe64ceae",
        "9ca1aacd-9104-404d-87bb-909a64957c4c",
        "9c45010a-eb1c-4b51-9c2c-e2339b824e21"
    };

    public void SetScore(MiniGame game, int score) {
        Authentication.AzureServices.RequestString("post", string.Format("api/v1/scores/{0}", MiniGameID[(int)game]), score.ToString(), (res) => {
            Debug.LogError("SetScore " + res);
        });
    }

    public IEnumerator GetRanking(MiniGame game){
        yield return Authentication.AzureServices.AwaitRequestGet(string.Format("api/v1/scores/{0}", MiniGameID[(int)game]), (res) => {
            Debug.LogError("GetRanking " + res);
        });
    }
}
