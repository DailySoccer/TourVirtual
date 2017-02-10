using UnityEngine;
using System.Collections.Generic;

public class DeepLinkingManager : Photon.PunBehaviour {
    public static bool IsEditAvatar;
    public static string URL;
    public static Dictionary<string, object> Parameters = new Dictionary<string, object>();

// He quitado esto porque hace que se logue n veces.
        
    void OnApplicationFocus(bool focusStatus) {
        if (focusStatus ) {
            var url = Authentication.AzureServices.CheckDeepLinking();
            if(!string.IsNullOrEmpty(url)){
                Debug.LogError(">>>>> SetDeepLinking ---> "+url);
                DeepLinkingManager.IsEditAvatar = false;
                if (string.IsNullOrEmpty(url)) return;
                System.Uri uri = new System.Uri(url);

                url = WWW.UnEscapeURL(url);
                var pair = url.Split('?');

                DeepLinkingManager.Parameters.Clear();
                if (pair.Length == 2) {
                    var pars = pair[1].Split('&');
                    foreach (var p in pars) {
                        var par = p.Split('=');
                        if (par.Length == 2) {
                            DeepLinkingManager.Parameters.Add(par[0], par[1]);
                        }
                    }
                }

                // Miro, primero que este logado...
                if(!string.IsNullOrEmpty(UserAPI.Instance.UserID) && UserAPI.Instance.CheckIsOtherUser() ){
                    // Mostrar la ventana de carga
                    StartCoroutine(CanvasRootController.Instance.FadeOut(2));
                    Debug.LogError(">>>> Es otro usuario ");
                    return;
                }

                // Mira si no esta editando el avatar.
                if(uri.Host!="editavatar"){
//                    if (RoomManager.Instance.Room.Id != "VESTIDORLITE") RoomManager.Instance.GotoRoom("VESTIDORLITE");
                    return;
                }

                DeepLinkingManager.IsEditAvatar = true;
                DeepLinkingManager.URL = url;
                Debug.LogError(">>>> OnDeepLinking");
                // Tengo que ver para que viene el deeplinking.
                if (RoomManager.Instance != null && UserAPI.Instance.Online && !UserAPI.Instance.errorLogin ) {
                    if (RoomManager.Instance.Room.Id != "VESTIDORLITE") RoomManager.Instance.GotoRoom("VESTIDORLITE");
                    else FindObjectOfType<VestidorCanvasController_Lite>().ShowClothesShop();
                }
            }
        }
    }
}

