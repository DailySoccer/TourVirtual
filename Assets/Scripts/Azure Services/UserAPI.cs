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
            Authentication.AzureServices.RequestGet( "api/v1/fan/me/ProfileAvatar", (res2) => {
                Debug.LogError(">>>> " + res2);
                if (string.IsNullOrEmpty(res2) || res2=="null") {
                    // Es la primera vez que entra el usuario!!!
                    PlayerManager.Instance.SelectedModel = "";
                }
                else {
                    Hashtable avatar = JSON.JsonDecode(res2) as Hashtable;
                    if (avatar.Contains("PhysicalProperties")) {
                        AvatarDesciptor.SetProperties( avatar["PhysicalProperties"] as ArrayList );
                        PlayerManager.Instance.SelectedModel = AvatarDesciptor.ToString();
                        PlayerManager.Instance.SelectedModel = "";
                    }
                }
                if (OnUserLogin != null) OnUserLogin();
            });
        });
    }


    public void UpdateAvatar() {
        Authentication.AzureServices.RequestPost( "api/v1/fan/me/ProfileAvatar", AvatarDesciptor.GetProperties(), (res) => {
            Debug.LogError("UpdateAvatar " + res);
            }, null);
    }

    public void SendAvatar(byte[] bytes) {
        Authentication.AzureServices.RequestPut("api/v1/fan/me/ProfileAvatar/UploadPicture", bytes, (res) => {
            Debug.LogError("SendAvatar " + res);
        });
    }

}
