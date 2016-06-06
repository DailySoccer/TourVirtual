#if UNITY_ANDROID

using UnityEngine;
using System.Collections.Generic;


public class AndroidAzureInterfaz : AzureInterfaz {
#region Init
    private static AndroidJavaObject _activity;
    private static AndroidJavaObject activity { get { if (_activity == null) _activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity"); return _activity; } }

    void Start() {
        TryDeepLinking();
    }

    void OnApplicationPause(bool pauseStatus) {
        if (!pauseStatus) TryDeepLinking();
    }

    void TryDeepLinking() {
        var dl = this.GetDeepLinking();
        if (!string.IsNullOrEmpty(dl)) DeepLinking(dl);

    }

    public override void Init(string signin) {
#if PRO
        this.clientId = "1416e63a-8998-4243-99f7-8c9ebf516157";
        string environment = "production";
#elif PRE
        string environment = "preproduction";
        this.clientId = "b992508b-b9ed-49fb-998d-6f8cdb810b8a";
#else
        string environment = "development";
        this.IDClient = "41f64a6e-edf8-4d7d-86cf-6146cc69f978";
#endif
        Debug.Log(">>>>>> activity.Call(Init, "+environment+" ,"+ this.IDClient+ " ," + signin+")");
        activity.Call("Init", environment, this.IDClient, signin);
    }

    public override void SignIn(AzureEvent OnSignIn=null) {
        if(OnSignIn!=null) this.OnSignIn = OnSignIn;
        activity.Call("Login", false);
    }


    public void OnSignInEvent(string success) {
        if(OnSignIn!=null) OnSignIn(success=="OK");
    }

    public override void SignOut() {
        activity.Call("Logout");
    }

    public override string GetDeepLinking() { return activity.Call<string>("GetDeepLinking"); }

    public void OnResponseOK(string response) {
        AsyncOperation.EndOperation(true, response);
    }

    public void OnResponseKO(string response) {
        AsyncOperation.EndOperation(false, response);
    }
#endregion

    public override Coroutine GetFanApps(AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null) {
        var op = AsyncOperation.Create(OnSucess, OnError);
        activity.Call("GetFanApps", SystemInfo.deviceUniqueIdentifier, op.Hash);
        return StartCoroutine( op.Wait() );
    }

// Profile ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public override Coroutine GetFanMe(AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null) {
        var op = AsyncOperation.Create(OnSucess, OnError);
        activity.Call("GetFanMe", op.Hash);
        return StartCoroutine(op.Wait());
    }

    public override Coroutine GetProfileAvatar(AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null) {
        var op = AsyncOperation.Create(OnSucess, OnError);
        activity.Call("GetProfileAvatar", op.Hash);
        return StartCoroutine(op.Wait());
    }

    public override Coroutine SetProfileAvatar(object profile, AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null) {
        var op = AsyncOperation.Create(OnSucess, OnError);
        activity.Call("SetProfileAvatar", MiniJSON.Json.Serialize(profile), op.Hash);
        return StartCoroutine(op.Wait());
    }

    public override Coroutine CheckAlias(string nick, AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null) {
        var op = AsyncOperation.Create(OnSucess, OnError);
        activity.Call("CheckAlias", nick, op.Hash);
        return StartCoroutine(op.Wait());
    }

    public override Coroutine UpdateAlias(string nick, AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null) {
        var op = AsyncOperation.Create(OnSucess, OnError);
        activity.Call("UpdateAlias", nick, op.Hash);
        return StartCoroutine(op.Wait());
    }
    
    public override Coroutine SendAvatarImage(byte[] bitmap, AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null) {
        var op = AsyncOperation.Create(OnSucess, OnError);
        activity.Call("SendAvatarImage", bitmap, op.Hash);
        return StartCoroutine(op.Wait());
    }

// Scores ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public override Coroutine SendScore(string IDMinigame, int score, AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null) {
        var op = AsyncOperation.Create(OnSucess, OnError);
        activity.Call("SendScore", IDMinigame, score, op.Hash);
        return StartCoroutine(op.Wait());
        
    }

    public override Coroutine GetMaxScore(string IDMinigame, AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null) {
        var op = AsyncOperation.Create(OnSucess, OnError);
        activity.Call("GetMaxScore", IDMinigame, op.Hash);
        return StartCoroutine(op.Wait());
    }

    public override Coroutine GetRanking(string IDMinigame, AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null) {
        var op = AsyncOperation.Create(OnSucess, OnError);
        activity.Call("GetRanking", IDMinigame, op.Hash);
        return StartCoroutine(op.Wait());
    }

// Virtual Goods ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public override Coroutine GetVirtualGoods(string type, int page, string subtype = null, bool onlyPurchasables = false, AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null) {
        var op = AsyncOperation.Create(OnSucess, OnError);
        activity.Call("GetVirtualGoods", type, page, MainLanguage, subtype, onlyPurchasables, op.Hash);
        return StartCoroutine(op.Wait());
    }

    public override Coroutine GetVirtualGoodsPurchased(string type, string token = null, AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null) {
        var op = AsyncOperation.Create(OnSucess, OnError);
        activity.Call("GetVirtualGoodsPurchased", type, MainLanguage, token, op.Hash);
        return StartCoroutine(op.Wait());
    }

    public override Coroutine PurchaseVirtualGood(string IDVirtualGood, AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null) {
        var op = AsyncOperation.Create(OnSucess, OnError);
        activity.Call("PurchaseVirtualGood", IDVirtualGood, op.Hash);
        return StartCoroutine(op.Wait());
    }

// Achievements ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public override Coroutine GetAchievements(string type, AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null) {
        var op = AsyncOperation.Create(OnSucess, OnError);
        activity.Call("GetAchievements", type, MainLanguage, op.Hash);
        return StartCoroutine(op.Wait());
    }

    public override Coroutine GetAchievementsEarned(string type, string token = null, AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null) {
        var op = AsyncOperation.Create(OnSucess, OnError);
        activity.Call("GetAchievementsEarned", type, MainLanguage, token, op.Hash);
        return StartCoroutine(op.Wait());
    }

// Contents ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public override Coroutine GetContents(string type, int page, AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null) {
        var op = AsyncOperation.Create(OnSucess, OnError);
        activity.Call("GetContents", type, page, MainLanguage, op.Hash);
        return StartCoroutine(op.Wait());
    }

    public override Coroutine GetContent(string IDContent, AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null) {
        var op = AsyncOperation.Create(OnSucess, OnError);
        activity.Call("GetContent", IDContent, op.Hash);
        return StartCoroutine(op.Wait());
    }

// Gamificación ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public override Coroutine GamificationStatus(AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null) {
        var op = AsyncOperation.Create(OnSucess, OnError);
        activity.Call("GamificationStatus", MainLanguage, op.Hash);
        return StartCoroutine(op.Wait());
    }
    public override Coroutine SendAction(string IDAction, AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null) {
        var op = AsyncOperation.Create(OnSucess, OnError);
        activity.Call("SendAction", IDAction, op.Hash);
        return StartCoroutine(op.Wait());
    }

// InApp Purchases ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public override Coroutine InAppPurchase(string IDProduct, string Receipt, AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null) {
        var op = AsyncOperation.Create(OnSucess, OnError);
        activity.Call("InAppPurchase", IDProduct, Receipt, op.Hash);
        return StartCoroutine(op.Wait());
    }
}

#endif