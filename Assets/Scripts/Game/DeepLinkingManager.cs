using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SmartLocalization;

public class DeepLinkingManager : Photon.PunBehaviour {
    public static bool IsEditAvatar;
    public static string URL;
    public static Dictionary<string, object> Parameters = new Dictionary<string, object>();

    // He quitado esto porque hace que se logue n veces.

    bool checkingDeepLinking = false;

    void OnApplicationFocus(bool focusStatus) {
        // HACK: HACK: HACK:
        // Habría que comprobar si esta "reentrada" evitar algún mal
        // Fue implementada al inicio de la búsqueda de posibles problemas al Editar Avatar
        if (checkingDeepLinking) {
            return;
        }

        if (focusStatus ) {
            StartCoroutine( CheckDeepLinking() );
        }
    }

    private IEnumerator CheckDeepLinking() {
        var url = Authentication.AzureServices.CheckDeepLinking();
        if(!string.IsNullOrEmpty(url)) {
            Debug.LogError(">>>>> SetDeepLinking ---> "+url);
            DeepLinkingManager.IsEditAvatar = false;
            if (string.IsNullOrEmpty(url)) yield break;
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
                checkingDeepLinking = true;

                // Mostrar la ventana de carga
                StartCoroutine(CanvasRootController.Instance.FadeOut(2));
                Debug.LogError(">>>> Es otro usuario ");

                LoadingCanvasManager.Hide();
                UserAPI.Instance.UserID=null;

                ModalTextOnly.ShowText( LanguageManager.Instance.GetTextValue("TVB.Error.BadUserID"), (val)=> {
                    Authentication.AzureServices.SignOut (
                        (ret)=>{ 
                            // Application.Quit(); 
                            Authentication.AzureServices.SignIn( (result) => {
                                StartCoroutine(ChangeAvatar(url));
                            });
                        }
                        , (ret)=>{ Application.Quit(); });
                    //                Authentication.AzureServices.SignIn();
                });

                yield break;
            }

            checkingDeepLinking = false;

            // Mira si no esta editando el avatar.
            if(uri.Host!="editavatar"){
                //                    if (RoomManager.Instance.Room.Id != "VESTIDORLITE") RoomManager.Instance.GotoRoom("VESTIDORLITE");
                yield break;
            }

            DeepLinkingManager.IsEditAvatar = true;
            DeepLinkingManager.URL = url;
            Debug.LogError(">>>> OnDeepLinking");
            // Tengo que ver para que viene el deeplinking.
            if (RoomManager.Instance != null && UserAPI.Instance.Online && !UserAPI.Instance.errorLogin ) {
                if (RoomManager.Instance.Room.Id != "VESTIDORLITE") {
                    RoomManager.Instance.GotoRoom("VESTIDORLITE");
                }
                else {
                    VestidorCanvasController_Lite vestidor = FindObjectOfType<VestidorCanvasController_Lite>();
                    vestidor.ShowClothesShop();
                }
            }
        }

        yield return null;
    }

    IEnumerator ChangeAvatar(string url) {
        yield return StartCoroutine(UserAPI.Instance.Request());

        checkingDeepLinking = false;

        DeepLinkingManager.IsEditAvatar = true;
        DeepLinkingManager.URL = url;
        Debug.LogError(">>>> OnDeepLinking (ChangeAvatar)");
        // Tengo que ver para que viene el deeplinking.
        if (RoomManager.Instance != null && UserAPI.Instance.Online && !UserAPI.Instance.errorLogin ) {
            if (RoomManager.Instance.Room.Id != "VESTIDORLITE") {
                RoomManager.Instance.GotoRoom("VESTIDORLITE");
            }
            else {
                FindObjectOfType<VestidorCanvasController_Lite>().ShowClothesShop();
            }
        }

        StartCoroutine(CanvasRootController.Instance.FadeIn(2));
    }
}