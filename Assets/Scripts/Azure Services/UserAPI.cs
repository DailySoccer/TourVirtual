﻿using UnityEngine;
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
                }
            }
        });

        yield return Authentication.AzureServices.AwaitRequestGet(string.Format("api/v1/fan/me/GamificationStatus?language={0}&idClient={1}",
            Authentication.AzureServices.MainLanguage, Authentication.IDClient), (res) => {
                try {
                    Hashtable gamificationstatus = JSON.JsonDecode(res) as Hashtable;
                    Points = (int)gamificationstatus["Points"];
                    Level = int.Parse(gamificationstatus["Level"] as string);
                }
                catch { }
            });

        yield return Authentication.Instance.StartCoroutine(AwaitGlobalRanking() );

        if (OnUserLogin != null) OnUserLogin();
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


    public IEnumerator AwaitGlobalRanking() {
        yield return Authentication.AzureServices.AwaitRequestGet(string.Format("api/v1/fan/me/Rankings/{0}",Authentication.IDClient), (res) => {
//                Debug.LogError("GetGlobalRanking " + res);
        });
        yield return Authentication.AzureServices.AwaitRequestGet(string.Format("api/v1/fan/me/Rankings/{0}/{1}", Authentication.IDClient, UserAPI.Instance.UserID), (res) => {
            if (res != "null")
            {
                Hashtable globalRanking = JSON.JsonDecode(res) as Hashtable;
                if (globalRanking != null)
                {
                    Debug.LogError("GetGlobalRanking " + globalRanking["GamingScore"]);
                }
            }
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
