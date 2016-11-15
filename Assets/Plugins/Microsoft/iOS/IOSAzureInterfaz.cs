using UnityEngine;
using System.Runtime.InteropServices;

#if UNITY_IOS
public class IOSAzureInterfaz : AzureInterfaz {
	[DllImport ("__Internal")]
	private static extern void _AzureInit(string environment, string clientId, string signin);
	public override void Init(string signin) {
#if PRO
        this.IDClient = "5926acc9-15ff-44e0-a2f7-a5026db1ca78";
        string environment = "production";
#elif PRE
        this.IDClient = "0ef88203-46a5-4db7-aa8f-bbee4a5b24c3";
        string environment = "preproduction";
#else
        this.IDClient = "17525b4e-8a03-4950-a5cd-dcdc6004aaaf";
        string environment = "qa";
#endif
        _AzureInit(environment, this.IDClient, signin );
    }
    [DllImport ("__Internal")]
    private static extern bool _AzureIsLoggedin();
    [DllImport ("__Internal")]
    private static extern void _AzureCheckLogin(string hash);
    public Coroutine AzureCheckLogin(AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null) {
        var op = AsyncOperation.Create(OnSucess, OnError);
        _AzureCheckLogin(op.Hash);
        return StartCoroutine( op.Wait() );
    }
 
    // LogIn
    [DllImport ("__Internal")]
    private static extern void _AzureSignIn();
    public override void SignIn(AzureEvent OnSignInEvent) {
        if(OnSignInEvent!=null) this.OnSignIn = OnSignInEvent;
        if(_AzureIsLoggedin()) Invoke("QuickSigIn", 1);
	    else _AzureSignIn();
    }

    void QuickSigIn(){
          OnSignIn(true);
    }
    
    public void OnSignInEvent(string success) {
        if(OnSignIn!=null) OnSignIn(success=="OK");
    }
    
    [DllImport ("__Internal")]
    private static extern void _AzureSignOut();
    public override Coroutine SignOut(AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null) {
        var op = AsyncOperation.Create(OnSucess, OnError);
        _AzureSignOut();
        GameObject.Find("Azure Services").SendMessage("OnResponseOK", op.Hash + ":Logout");
        return StartCoroutine(op.Wait());
    }
    
    [DllImport ("__Internal")]
    private static extern string _CheckDeepLinking();
    public override string CheckDeepLinking() { return _CheckDeepLinking(); }

    public void OnResponseOK(string response) {
        AsyncOperation.EndOperation(true, response);
    }

    public void OnResponseKO(string response) {
        AsyncOperation.EndOperation(false, response);
    }
    
	
    [DllImport ("__Internal")]
    private static extern void _OpenURL(string url);
    public override void OpenURL(string url){
		_OpenURL (url);
    }

    [DllImport ("__Internal")]
    private static extern bool _CheckApp(string url);
    public override bool CheckApp(string url) { return _CheckApp(url); }
    
    [DllImport ("__Internal")]
    private static extern void _PostFanApps(string appID, string deviceID,string hash);
    public override Coroutine PostFanApps(AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null) {
        var op = AsyncOperation.Create(OnSucess, OnError);
        _PostFanApps( Application.bundleIdentifier, SystemInfo.deviceUniqueIdentifier, op.Hash);
        return StartCoroutine( op.Wait() );
    }
    
    [DllImport ("__Internal")]
    private static extern void _GetFanMe(string hash);
    public override Coroutine GetFanMe(AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null) {
        var op = AsyncOperation.Create(OnSucess, OnError);
        _GetFanMe(op.Hash);
        return StartCoroutine(op.Wait());
    }
    
    [DllImport ("__Internal")]
    private static extern void _GetProfileAvatar(string hash);
    public override Coroutine GetProfileAvatar(AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null) {
        var op = AsyncOperation.Create(OnSucess, OnError);
        _GetProfileAvatar(op.Hash);
        return StartCoroutine(op.Wait());
    }
    
/*    
    [DllImport ("__Internal")]
    private static extern void _SetProfileAvatar(string json, string hash);
    public override Coroutine SetProfileAvatar(object profile, AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null) {
        var op = AsyncOperation.Create(OnSucess, OnError);
        _SetProfileAvatar(MiniJSON.Json.Serialize(profile), op.Hash);
        return StartCoroutine(op.Wait());
    }
*/
    [DllImport ("__Internal")]
    private static extern void _CreateProfileAvatar(string json, string hash);
    public override Coroutine CreateProfileAvatar(object profile, AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null) {
        var op = AsyncOperation.Create(OnSucess, OnError);
        _CreateProfileAvatar(MiniJSON.Json.Serialize(profile), op.Hash);
        return StartCoroutine(op.Wait());
    }

    [DllImport ("__Internal")]
    private static extern void _CheckAlias(string nick, string hash);
    public override Coroutine CheckAlias(string nick, AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null) {
        var op = AsyncOperation.Create(OnSucess, OnError);
        _CheckAlias(nick, op.Hash);
        return StartCoroutine(op.Wait());
    }
    
    [DllImport ("__Internal")]
    private static extern void _UpdateAlias(string nick, string hash);
    public override Coroutine UpdateAlias(string nick, AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null) {
        var op = AsyncOperation.Create(OnSucess, OnError);
        _UpdateAlias(nick, op.Hash);
        return StartCoroutine(op.Wait());
    }
    
    [DllImport ("__Internal")]
    private static extern void _SendAvatarImage(int length, System.IntPtr byteArrPtr, string hash);
    public override Coroutine SendAvatarImage(byte[] bitmap, AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null) {
        var op = AsyncOperation.Create(OnSucess, OnError);
        GCHandle handle = GCHandle.Alloc(bitmap, GCHandleType.Pinned);
        _SendAvatarImage(bitmap.Length, handle.AddrOfPinnedObject(), op.Hash);
        handle.Free();
        return StartCoroutine(op.Wait());
    }
    
// Scores ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
   [DllImport ("__Internal")]
    private static extern void _SendScore(string IDMinigame, int score, string hash);
    public override Coroutine SendScore(string IDMinigame, int score, AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null) {
        var op = AsyncOperation.Create(OnSucess, OnError);
        _SendScore(IDMinigame, score, op.Hash);
        return StartCoroutine(op.Wait());
    }
    
    [DllImport ("__Internal")]
    private static extern void _GetMaxScore(string IDMinigame, string hash);
    public override Coroutine GetMaxScore(string IDMinigame, AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null) {
        var op = AsyncOperation.Create(OnSucess, OnError);
        _GetMaxScore(IDMinigame, op.Hash);
        return StartCoroutine(op.Wait());
    }
    
    [DllImport ("__Internal")]
    private static extern void _GetRanking(string IDMinigame, string hash);
    public override Coroutine GetRanking(string IDMinigame, AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null) {
        var op = AsyncOperation.Create(OnSucess, OnError);
        _GetRanking(IDMinigame, op.Hash);
        return StartCoroutine(op.Wait());
    }
    
    [DllImport ("__Internal")]
    private static extern void _GetFanRanking(string hash);
    public override Coroutine GetFanRanking(AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null) {
        var op = AsyncOperation.Create(OnSucess, OnError);
        _GetFanRanking(op.Hash);
        return StartCoroutine(op.Wait());
    }
    
// Virtual Goods ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    [DllImport ("__Internal")]
    private static extern void _GetVirtualGoods(string type, string languag, int page, string subtype, bool onlyPurchasables, string hash);
    public override Coroutine GetVirtualGoods(string type, int page, string subtype = null, bool onlyPurchasables = false, AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null) {
        var op = AsyncOperation.Create(OnSucess, OnError);
        _GetVirtualGoods(type, MainLanguage, page, subtype, onlyPurchasables, op.Hash);
        return StartCoroutine(op.Wait());
    }

    [DllImport ("__Internal")]
    private static extern void _GetVirtualGoodsPurchased(string type, string language, string token, string hash);
    public override Coroutine GetVirtualGoodsPurchased(string type, string token = null, AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null) {
        var op = AsyncOperation.Create(OnSucess, OnError);
        _GetVirtualGoodsPurchased(type, MainLanguage, token, op.Hash);
        return StartCoroutine(op.Wait());
    }

    [DllImport ("__Internal")]
    private static extern void _PurchaseVirtualGood(string IDVirtualGood, string hash);
    public override Coroutine PurchaseVirtualGood(string IDVirtualGood, AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null) {
        var op = AsyncOperation.Create(OnSucess, OnError);
        _PurchaseVirtualGood(IDVirtualGood, op.Hash);
        return StartCoroutine(op.Wait());
    }

// Achievements ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    [DllImport ("__Internal")]
    private static extern void _GetAchievements(string type, string language, string hash);
    public override Coroutine GetAchievements(string type, AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null) {
        var op = AsyncOperation.Create(OnSucess, OnError);
        _GetAchievements(type, MainLanguage, op.Hash);
        return StartCoroutine(op.Wait());
    }

    [DllImport ("__Internal")]
    private static extern void _GetAchievementsEarned(string type, string language, string token, string hash);
    public override Coroutine GetAchievementsEarned(string type, string token = null, AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null) {
        var op = AsyncOperation.Create(OnSucess, OnError);
        _GetAchievementsEarned(type, MainLanguage, token, op.Hash);
        return StartCoroutine(op.Wait());
    }

// Contents ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    [DllImport ("__Internal")]
    private static extern void _GetContents(string type, int page, string language, string hash);
    public override Coroutine GetContents(string type, int page, AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null) {
        var op = AsyncOperation.Create(OnSucess, OnError);
        _GetContents(type, page, MainLanguage, op.Hash);
        return StartCoroutine(op.Wait());
    }

    [DllImport ("__Internal")]
    private static extern void _GetContent(string IDContent, string hash);
    public override Coroutine GetContent(string IDContent, AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null) {
        var op = AsyncOperation.Create(OnSucess, OnError);
        _GetContent(IDContent, op.Hash);
        return StartCoroutine(op.Wait());
    }

// Gamificación ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    [DllImport ("__Internal")]
    private static extern void _GamificationStatus(string language, string hash);
    public override Coroutine GamificationStatus(AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null) {
        var op = AsyncOperation.Create(OnSucess, OnError);
        _GamificationStatus(MainLanguage, op.Hash);
        return StartCoroutine(op.Wait());
    }
    [DllImport ("__Internal")]
    private static extern void _SendAction(string IDAction, string hash);
    public override Coroutine SendAction(string IDAction, AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null) {
        var op = AsyncOperation.Create(OnSucess, OnError);
        _SendAction(IDAction, op.Hash);
        return StartCoroutine(op.Wait());
    }

// InApp Purchases ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    [DllImport ("__Internal")]
    private static extern void _InAppPurchase(string IDProduct, string Receipt, string hash);
    public override Coroutine InAppPurchase(string IDProduct, string Receipt, AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null) {
        var op = AsyncOperation.Create(OnSucess, OnError);
        _InAppPurchase(IDProduct, Receipt, op.Hash);
        return StartCoroutine(op.Wait());
    }
}
#endif