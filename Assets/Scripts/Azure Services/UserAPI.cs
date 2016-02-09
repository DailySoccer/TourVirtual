using UnityEngine;
using System.Collections;

public class UserAPI
{
    // Recibos de compras en tiendas.
    // POST api/v1/purchases
    // Como consulto el perfil de otros usuarios?
    public string UserID { get; set; }
    public string Nick { get; set; }
    public static AvatarAPI AvatarDesciptor;

    public static UserAPI Instance { get; private set; }

    public delegate void UserLogin();
    public event UserLogin OnUserLogin;

    public UserAPI() {
        Instance = this;
    }

    public void Request()
    {
        Authentication.AzureServices.RequestGet("api/v1/fan/me", (res) => {
            Hashtable hs = JSON.JsonDecode(res) as Hashtable;
            UserID = hs["IdUser"] as string;
            Nick = hs["Alias"] as string;
            Authentication.AzureServices.RequestGet("api/v1/fan/me/ProfileAvatar", (res2) => {
                if (string.IsNullOrEmpty(res2) || res2 == "null") {
                    // Es la primera vez que entra el usuario!!!
                    PlayerManager.Instance.SelectedModel = "";
                }
                else {
                    Hashtable avatar = JSON.JsonDecode(res2) as Hashtable;
                    if (avatar.Contains("PhysicalProperties")) {
                        AvatarDesciptor.SetProperties(avatar["PhysicalProperties"] as ArrayList);
                        PlayerManager.Instance.SelectedModel = AvatarDesciptor.ToString();
                        PlayerManager.Instance.SelectedModel = "";
                    }
                }
                if (OnUserLogin != null) OnUserLogin();
                GetGamificationStatus();
                GetGlobalRanking();
                SetScore(MiniGame.FreeKicks, 100);
            });
        });
    }

    public void UpdateAvatar() {
        Authentication.AzureServices.RequestPost("api/v1/fan/me/ProfileAvatar", AvatarDesciptor.GetProperties(), (res) => {
            Debug.LogError("UpdateAvatar " + res);
        }, null);
    }

    public void SendAvatar(byte[] bytes) {
        Authentication.AzureServices.RequestPut("api/v1/fan/me/ProfileAvatar/UploadPicture", bytes, (res) => {
            Debug.LogError("SendAvatar " + res);
        });
    }


    public void GetGlobalRanking()
    {
        //     api/v1/fan/me/Rankings/{idClient} -> XP en GamingScore
        Authentication.AzureServices.RequestGet(string.Format("api/v1/fan/me/Rankings/idClient={1}",
            Authentication.AzureServices.MainLanguage, Authentication.IDClient), (res) => {
                Debug.LogError("GetGlobalRanking " + res);
            });
    }


    public void GetGamificationStatus()
    {
        Authentication.AzureServices.RequestGet(string.Format("api/v1/fan/me/GamificationStatus?language={0}&idClient={1}", 
            Authentication.AzureServices.MainLanguage, Authentication.IDClient), (res) => {
            Debug.LogError("GetGamificationStatus " + res);
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
            Debug.LogError("SetScore " + res);
            GetRanking(game);
        });
    }

    public void GetRanking(MiniGame game){
        Authentication.AzureServices.RequestGet(string.Format("api/v1/scores/{0}", MiniGameID[(int)game]), (res) => {
            Debug.LogError("GetRanking " + res);
        });
    }

}
