using UnityEngine;
using System.Collections;

public class UserAPI
{
    // Recibos de compras en tiendas.
    // POST api/v1/purchases
    // Como consulto el perfil de otros usuarios?
    public string UserID { get; set; }
    public string Nick { get; set; }
    public int Points { get; set; }
    public int Level { get; set; }

    public static AvatarAPI AvatarDesciptor;
    public static VirtualGoodsAPI VirtualGoodsDesciptor =  new VirtualGoodsAPI();
    public static AchievementsAPI Achievements =  new AchievementsAPI();

    public static UserAPI Instance { get; private set; }

    public delegate void UserLogin();
    public event UserLogin OnUserLogin;

    public UserAPI() {
        Instance = this;
    }

    public IEnumerator Request() {
        yield return Authentication.Instance.StartCoroutine( VirtualGoodsDesciptor.AwaitRequest() );
        yield return Authentication.Instance.StartCoroutine( Achievements.AwaitRequest());

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
                Hashtable avatar = JSON.JsonDecode(res) as Hashtable;
                if (avatar.Contains("PhysicalProperties")) {
                    AvatarDesciptor.SetProperties(avatar["PhysicalProperties"] as ArrayList);
                    PlayerManager.Instance.SelectedModel = AvatarDesciptor.ToString();
                    PlayerManager.Instance.SelectedModel = "";
                }
            }
        });

        yield return Authentication.AzureServices.AwaitRequestGet(string.Format("api/v1/fan/me/GamificationStatus?language={0}&idClient={1}",
            Authentication.AzureServices.MainLanguage, Authentication.IDClient), (res) => {
                Debug.LogError(">>>>> GamificationStatus " + res);
                Hashtable gamificationstatus = JSON.JsonDecode(res) as Hashtable;
                Points = (int)gamificationstatus["Points"];
                Level = int.Parse( gamificationstatus["Level"] as string);
            });
        if (OnUserLogin != null) OnUserLogin();
        GetGlobalRanking();
        SetScore(MiniGame.FreeKicks, 100);
    }

    public void UpdateAvatar() {
        Authentication.AzureServices.RequestPostJSON("api/v1/fan/me/ProfileAvatar", AvatarDesciptor.GetProperties(), (res) => {
            Debug.LogError("UpdateAvatar " + res);
        }, null);
    }

    public void SendAvatar(byte[] bytes) {
        Authentication.AzureServices.RequestPut("api/v1/fan/me/ProfileAvatar/UploadPicture", bytes, (res) => {
            Debug.LogError("SendAvatar " + res);
        });
    }


    /*
    [{"Alias":"Perico","AvatarUrl":"https://az726872.vo.msecnd.net/global-avatar/06c22acd-0bd7-4d3f-b002-1df33f968f2e_thumbnail.png?v=1362051505","Position":1,"GamingScore":7231,"IsCurrentUser":false},{"Alias":"Jesus1","AvatarUrl":"https://az726872.vo.msecnd.net/global-avatar/134f18c4-24ae-428e-8192-7a1b493aab57_thumbnail.png?v=271519312","Position":2,"GamingScore":7081,"IsCurrentUser":false},{"Alias":"","AvatarUrl":"https://az726872.vo.msecnd.net/global-avatar/default.png","Position":3,"GamingScore":6531,"IsCurrentUser":false},{"Alias":"","AvatarUrl":"https://az726872.vo.msecnd.net/global-avatar/default.png","Position":4,"GamingScore":5900,"IsCurrentUser":false},{"Alias":"rodolfo","AvatarUrl":"https://az726872.vo.msecnd.net/global-avatar/32cbc30a-7ac1-4fa2-8ced-3fe4f45e424d_thumbnail.png?v=-227497956","Position":5,"GamingScore":4731,"IsCurrentUser":false},{"Alias":"","AvatarUrl":"https://az726872.vo.msecnd.net/global-avatar/default.png","Position":6,"GamingScore":4691,"IsCurrentUser":false},{"Alias":"","AvatarUrl":"https://az726872.vo.msecnd.net/global-avatar/default.png","Position":7,"GamingScore":4541,"IsCurrentUser":false},{"Alias":"","AvatarUrl":"https://az726872.vo.msecnd.net/global-avatar/default.png","Position":8,"GamingScore":4251,"IsCurrentUser":false},{"Alias":"","AvatarUrl":"https://az726872.vo.msecnd.net/global-avatar/default.png","Position":9,"GamingScore":3921,"IsCurrentUser":false},{"Alias":"paco22","AvatarUrl":"https://az726872.vo.msecnd.net/global-avatar/e9f64231-2a9c-44b7-a35d-b138b5725c23_thumbnail.png?v=1699964935","Position":10,"GamingScore":3751,"IsCurrentUser":false},{"Alias":null,"AvatarUrl":"https://az726872.vo.msecnd.net/global-avatar/default.png","Position":1999997,"GamingScore":0,"IsCurrentUser":false},{"Alias":"","AvatarUrl":"https://az726872.vo.msecnd.net/global-avatar/default.png","Position":1999998,"GamingScore":0,"IsCurrentUser":false},{"Alias":"","AvatarUrl":"https://az726872.vo.msecnd.net/global-avatar/default.png","Position":1999999,"GamingScore":0,"IsCurrentUser":false},{"Alias":"","AvatarUrl":"https://az726872.vo.msecnd.net/global-avatar/default.png","Position":2000000,"GamingScore":0,"IsCurrentUser":false},{"Alias":null,"AvatarUrl":"https://az726872.vo.msecnd.net/global-avatar/","Position":2000001,"GamingScore":0,"IsCurrentUser":false},{"Alias":"Gunder","AvatarUrl":"https://az726872.vo.msecnd.net/global-avatar/default.png","Position":2000002,"GamingScore":0,"IsCurrentUser":true},{"Alias":"","AvatarUrl":"https://az726872.vo.msecnd.net/global-avatar/default.png","Position":2000003,"GamingScore":0,"IsCurrentUser":false},{"Alias":"","AvatarUrl":"https://az726872.vo.msecnd.net/global-avatar/default.png","Position":2000004,"GamingScore":0,"IsCurrentUser":false},{"Alias":"32eacc5508824bf7aa67d048974895a7","AvatarUrl":"https://az726872.vo.msecnd.net/global-avatar/","Position":2000005,"GamingScore":0,"IsCurrentUser":false},{"Alias":"","AvatarUrl":"https://az726872.vo.msecnd.net/global-avatar/default.png","Position":2000006,"GamingScore":0,"IsCurrentUser":false},{"Alias":null,"AvatarUrl":"https://az726872.vo.msecnd.net/global-avatar/","Position":2000007,"GamingScore":0,"IsCurrentUser":false}]

        */


    public void GetGlobalRanking() {
        //     api/v1/fan/me/Rankings/{idClient} -> XP en GamingScore
        Authentication.AzureServices.RequestGet(string.Format("api/v1/fan/me/Rankings/{1}/{2}",
            Authentication.AzureServices.MainLanguage, Authentication.IDClient, UserAPI.Instance.UserID), (res) => {
                Debug.LogError("GetMyRanking " + res);
                if (res != "null")
                {
                    Hashtable globalRanking = JSON.JsonDecode(res) as Hashtable;
                    Debug.LogError("GetGlobalRanking " + globalRanking["GamingScore"]);
                }
            });

        Authentication.AzureServices.RequestGet(string.Format("api/v1/fan/me/Rankings/{1}",
            Authentication.AzureServices.MainLanguage, Authentication.IDClient), (res) => {
                Debug.LogError("GetGlobalRanking " + res);
            });
    }

    public enum MiniGame{
        FreeKicks,
        FreeShoot,
        HiddenObjects
    };

    string[] MiniGameID = new string[] {
        "64c478e3-a3dd-441e-94e5-f5f4fe64ceae",
        "9ca1aacd-9104-404d-87bb-909a64957c4c",
        "9c45010a-eb1c-4b51-9c2c-e2339b824e21"
    };

    public void SetScore(MiniGame game, int score) {
        Authentication.AzureServices.RequestPostString(string.Format("api/v1/scores/{0}", MiniGameID[(int)game]), score.ToString(), (res) => {
//            Debug.LogError("SetScore " + res);
            GetRanking(game);
        });
    }

    public void GetRanking(MiniGame game){
        Authentication.AzureServices.RequestGet(string.Format("api/v1/scores/{0}", MiniGameID[(int)game]), (res) => {
//            Debug.LogError("GetRanking " + res);
        });
    }

}
