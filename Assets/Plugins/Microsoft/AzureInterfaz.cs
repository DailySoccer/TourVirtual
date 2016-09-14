using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class AzureInterfaz : MonoBehaviour
{
    public delegate void AzureEvent(bool success);
    protected AzureEvent OnSignIn;

    protected string    IDClient;
    protected string    WebApiBaseAddress;
    public string       MainLanguage = "es-es";

    public virtual void Init(string signin) { Debug.LogError(">>>>> AzureInterfaz.Init");  }
    // LogIn
    public virtual void SignIn(AzureEvent OnSignInEvent=null) { }
    public virtual void SignOut() { }
    public virtual void OpenURL(string url) { Application.OpenURL(url); }

    public bool IsDeepLinking = false;
    public string DeepLinkingURL;
    public Dictionary<string, object> DeepLinkinParameters;

    public delegate void DeepLinkingDelegate();
    public event DeepLinkingDelegate OnDeepLinking;


    public virtual void CheckDeepLinking() { }

    public void SetDeepLinking(string url) {
        if (string.IsNullOrEmpty(url)) {
            IsDeepLinking = false;
            return;
        }
        System.Uri uri = new System.Uri(url);
        if( uri.Host!="editavatar") return;

        url = WWW.UnEscapeURL(url);
        DeepLinkingURL = url;
        var pair = url.Split('?');

        DeepLinkinParameters = new Dictionary<string, object>();        
        if (pair.Length == 2) {
            var pars = pair[1].Split('&');
            foreach (var p in pars) {
                var par = p.Split('=');
                if (par.Length == 2) {
                    DeepLinkinParameters.Add(par[0], par[1]);
                }
            }
        }
        IsDeepLinking = true;
        if(OnDeepLinking!=null) OnDeepLinking();
    }
    
// No se para que es esto.
    public virtual Coroutine PostFanApps(AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null) { return null; }
    // Profile
    public virtual Coroutine GetFanMe(AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null) { return null; }
    public virtual Coroutine GetProfileAvatar(AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null) { return null; }
//    public virtual Coroutine SetProfileAvatar(object profile, AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null) { return null; }
	public virtual Coroutine CreateProfileAvatar(object profile, AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null) { return null; }
    public virtual Coroutine CheckAlias(string nick, AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null) { return null; }
    public virtual Coroutine UpdateAlias(string nick, AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null) { return null; }
    public virtual Coroutine SendAvatarImage(byte[] bitmap, AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null) { return null; }

    // Scores
    public virtual Coroutine SendScore(string IDMinigame, int score, AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null) { return null; }
    public virtual Coroutine GetMaxScore(string IDMinigame, AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null) { return null; }
    public virtual Coroutine GetRanking(string IDMinigame, AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null) { return null; }
    public virtual Coroutine GetFanRanking(AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null) { return null; }

    // Virtual Goods
    public virtual Coroutine GetVirtualGoods(string type, int page, string subtype = null, bool onlyPurchasables = false, AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null) { return null; }
    public virtual Coroutine GetVirtualGoodsPurchased(string type, string token = null, AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null) { return null; }
    public virtual Coroutine PurchaseVirtualGood(string IDVirtualGood, AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null) { return null; }

    // Achievements
    public virtual Coroutine GetAchievements(string type, AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null) { return null; }
    public virtual Coroutine GetAchievementsEarned(string type, string token = null, AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null) { return null; }

    // Contents
    public virtual Coroutine GetContents(string type, int page, AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null) { return null; }
    public virtual Coroutine GetContent(string IDContent, AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null) { return null; }

    // Gamificación
    public virtual Coroutine GamificationStatus(AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null) { return null; }
    public virtual Coroutine SendAction(string IDAction, AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null) { return null; }
    

    // InApp Purchases
    public virtual Coroutine InAppPurchase(string IdProduct, string Receipt, AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null) { return null; }
}