#if UNITY_EDITOR

using UnityEngine;
using BestHTTP;
using System.Collections;
using System.Collections.Generic;

public class EditorAzureInterfaz : AzureInterfaz
{
#region Init

    public string AccessToken { get; set; }

    public override void Init(string signin) {
#if PRO
        this.WebApiBaseAddress = "https://api.realmadrid.com/";
        this.IDClient = "1416e63a-8998-4243-99f7-8c9ebf516157";
#elif PRE
        this.WebApiBaseAddress = "https://apipre.realmadrid.com/";
        this.IDClient = "b992508b-b9ed-49fb-998d-6f8cdb810b8a";
#else
        this.WebApiBaseAddress = "https://eu-rm-dev-web-api.azurewebsites.net/";
        this.IDClient = "41f64a6e-edf8-4d7d-86cf-6146cc69f978";
#endif
    }

    // LogIn
    public override void SignIn(AzureEvent OnSignInEvent=null)
    {
        if (OnSignInEvent != null) this.OnSignIn = OnSignInEvent;
        string parameters = string.Format("?response_type=code&client_id={0}&redirect_uri={1}&resource={2}", IDClient, redirectUri, webApiResourceId);
        string extraParameters = "p=B2C_1_SignIn&nonce=defaultNonce&scope=openid";
        string url = string.Format("{0}/oauth2/authorize{1}&{2}", authority, parameters, extraParameters);
        Application.OpenURL(url);
    }

    IEnumerator _SignOut(AsyncOperation op) {
        yield return  new WaitForSeconds(2); 
        AsyncOperation.EndOperation(true, op.Hash + ":TimeOut");
    }
    public override Coroutine SignOut(AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null) { 
        var op = AsyncOperation.Create(OnSucess, OnError);
        return StartCoroutine(_SignOut(op));
    }
    // Tools
    protected static string KEY_ACCESS_TOKEN = "access_token";
    protected static string KEY_REFRESH_TOKEN = "refresh_token";
    protected static string webApiResourceId = "https://rmaddev.onmicrosoft.com/webapi";
    protected static string redirectUri = "http://localhost/";
    protected static string aadInstance = "https://login.microsoftonline.com/{0}";
    protected static string tenant = "rmadb2cdev.onmicrosoft.com";
    protected static string authority = string.Format(aadInstance, tenant);

    public IEnumerator GetAccessToken(string _code)
    {
        _code = extractCodeFromURL(_code);
        WWWForm form = new WWWForm();
        form.AddField("resource", webApiResourceId);
        form.AddField("client_id", IDClient);
        form.AddField("code", _code);
        form.AddField("grant_type", "authorization_code");
        form.AddField("redirect_uri", redirectUri);
        string url = string.Format("{0}/oauth2/token?p={1}&nonce=defaultNonce&scope=openid", authority, "B2C_1_SignIn");

        WWW www = new WWW(url, form);
        yield return www;
        if (string.IsNullOrEmpty(www.error))
        {
            ProcessTokenResponse(www.text);
        }
        else
        {
            Debug.LogError("ERROR!!! ProcessTokenResponse");
        } // ERROR!!!
    }

    private string extractCodeFromURL(string url)
    {
        string code = "";
        if (url.Contains("http://localhost/?code="))
        {
            string[] parameters = url.Split('?');
            string[] values = parameters[1].Split('=');
            code = WWW.UnEscapeURL(values[1]);
        }
        return code;
    }

    public void ProcessTokenResponse(string text)
    {
        object json = BestHTTP.JSON.Json.Decode(text);
        if (json is Dictionary<string, object>)
        {
            Dictionary<string, object> jsonDic = json as Dictionary<string, object>;
            if (jsonDic.ContainsKey(KEY_ACCESS_TOKEN))
            {
                AccessToken = jsonDic[KEY_ACCESS_TOKEN] as string;
                if (OnSignIn != null) OnSignIn(true);
            }
        }
    }

    string urlCode = "";
    void OnGUI()
    {
		/*
        if (string.IsNullOrEmpty(AccessToken)) {
            if (GUI.Button(new Rect(320, Screen.height - 150, 150, 25), "Token ")) {
                StartCoroutine(GetAccessToken(urlCode));
            }
            if (GUI.Button(new Rect(520, Screen.height - 150, 150, 25), "Error ")) {
                if (OnSignIn != null) OnSignIn(false);
            }
            GUI.Label(new Rect(320, Screen.height - 125, 300, 25), "URL Response: http://localhost/?code=XXX");
            urlCode = GUI.TextField(new Rect(320, Screen.height - 100, 300, 25), urlCode);
        }
        */
    }

    public string AsciiToString(byte[] bytes)
    {
        return System.Text.Encoding.UTF8.GetString(bytes, 0, bytes.Length);
    }

    public static byte[] StringToAscii(string str)
    {
        return System.Text.Encoding.UTF8.GetBytes(str);
    }


    HTTPRequest SendJSonRequest(HTTPMethods method, string url, object json)
    {
        return SendRequest(method, url, StringToAscii(BestHTTP.JSON.Json.Encode(json)));
    }

    HTTPRequest SendRequest(HTTPMethods method, string url, byte[] array = null)
    {
        HTTPRequest request = new HTTPRequest(new System.Uri(string.Format("{0}{1}", WebApiBaseAddress, url)));
        request.MethodType = method;
        if (array != null)
        {
            request.AddHeader("Content-Type", "application/json");
            request.RawData = array;
        }

        request.DisableCache = true;
        request.AddHeader("Authorization", "Bearer " + AccessToken);
        request.Send();
        return request;
    }

    IEnumerator WaitForEnd(HTTPRequest request, AsyncOperation op)
    {
        while (request.State < HTTPRequestStates.Finished) yield return null;
        if (request.Response.StatusCode != 200)
            AsyncOperation.EndOperation(false, op.Hash + ":" + request.Response.StatusCode + ":" + request.Response.Message);
        else
            AsyncOperation.EndOperation(true, op.Hash + ":" + AsciiToString(request.Response.Data));
    }
#endregion

    public override Coroutine PostFanApps(AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null)
    {
        HTTPRequest request = SendRequest(HTTPMethods.Get, string.Format("api/v1/fan/me/Apps/{0}/{1}", this.IDClient, SystemInfo.deviceUniqueIdentifier));
        var op = AsyncOperation.Create(OnSucess, OnError);
        return StartCoroutine(WaitForEnd(request, op));
    }

// Profile //////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public override Coroutine GetFanMe(AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null)
    {
        var request = SendRequest(HTTPMethods.Get, "api/v1/fan/me");
        var op = AsyncOperation.Create(OnSucess, OnError);
        return StartCoroutine(WaitForEnd(request, op));
    }

    public override Coroutine GetProfileAvatar(AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null)
    {
        var request = SendRequest(HTTPMethods.Get, "api/v1/fan/me/ProfileAvatar");
        var op = AsyncOperation.Create(OnSucess, OnError);
        return StartCoroutine(WaitForEnd(request, op));
    }
    /*
    public override Coroutine SetProfileAvatar(object profile, AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null)
    {
        var request = SendJSonRequest(HTTPMethods.Put, "api/v1/fan/me/ProfileAvatar", profile);
        var op = AsyncOperation.Create(OnSucess, OnError);
        return StartCoroutine(WaitForEnd(request, op));
    }
    */
    public override Coroutine CreateProfileAvatar(object profile, AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null)
    {
        var request = SendJSonRequest(HTTPMethods.Post, "api/v1/fan/me/ProfileAvatar", profile);
        var op = AsyncOperation.Create(OnSucess, OnError);
        return StartCoroutine(WaitForEnd(request, op));
    }

    public override Coroutine CheckAlias(string nick, AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null)
    {
        HTTPRequest request = SendRequest(HTTPMethods.Get, string.Format("api/v1/fan/CheckAlias?alias={0}", nick));
        var op = AsyncOperation.Create(OnSucess, OnError);
        return StartCoroutine(WaitForEnd(request, op));
    }

    public override Coroutine UpdateAlias(string nick, AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null)
    {
        Dictionary<string, object> hs = new Dictionary<string, object>();
        hs.Add("Alias", nick);
        HTTPRequest request = SendJSonRequest(HTTPMethods.Put, "api/v1/fan/me/updatealias", hs);
        var op = AsyncOperation.Create(OnSucess, OnError);
        return StartCoroutine(WaitForEnd(request, op));
    }

    public override Coroutine SendAvatarImage(byte[] bitmap, AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null)
    {
        HTTPRequest request = SendRequest(HTTPMethods.Put, "api/v1/fan/me/ProfileAvatar/UploadPicture", bitmap);
        var op = AsyncOperation.Create(OnSucess, OnError);
        return StartCoroutine(WaitForEnd(request, op));
    }

// Scores  //////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public override Coroutine SendScore(string IDMinigame, int score, AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null)
    {
        HTTPRequest request = SendRequest(HTTPMethods.Post, string.Format("api/v1/scores/{0}", IDMinigame), StringToAscii(score.ToString()));
        var op = AsyncOperation.Create(OnSucess, OnError);
        return StartCoroutine(WaitForEnd(request, op));
    }

    public override Coroutine GetMaxScore(string IDMinigame, AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null)
    {
        HTTPRequest request = SendRequest(HTTPMethods.Get, string.Format("api/v1/fan/me/MaxScore/{0}", IDMinigame));
        var op = AsyncOperation.Create(OnSucess, OnError);
        return StartCoroutine(WaitForEnd(request, op));
    }

    public override Coroutine GetRanking(string IDMinigame, AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null)
    {
        HTTPRequest request = SendRequest(HTTPMethods.Get, string.Format("api/v1/scores/{0}", IDMinigame));
        var op = AsyncOperation.Create(OnSucess, OnError);
        return StartCoroutine(WaitForEnd(request, op));
    }

    public override Coroutine GetFanRanking(AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null)
    {
        HTTPRequest request = SendRequest(HTTPMethods.Get, string.Format("api/v1/fan/me/Rankings/{0}", this.IDClient));
        var op = AsyncOperation.Create(OnSucess, OnError);
        return StartCoroutine(WaitForEnd(request, op));
    }

// Virtual Goods //////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public override Coroutine GetVirtualGoods(string type, int page, string subtype=null, bool onlyPurchasables=false, AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null)
    {
        string url = string.Format("api/v1/virtualgoods?idType={0}&ct={1}&language={2}&onlyPurchasables={3}", type, page, MainLanguage, onlyPurchasables);
        if(subtype!=null) url+= "&idSubType="+ subtype;
        HTTPRequest request = SendRequest(HTTPMethods.Get,url);
        var op = AsyncOperation.Create(OnSucess, OnError);
        return StartCoroutine(WaitForEnd(request, op));
    }

    public override Coroutine GetVirtualGoodsPurchased(string type, string token = null, AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null)
    {
        HTTPRequest request;
        if (token == null) request = SendRequest(HTTPMethods.Get, string.Format("api/v1/fan/me/VirtualGoods?type={0}&language{1}", type, MainLanguage));
        else request = SendRequest(HTTPMethods.Get, string.Format("api/v1/fan/me/VirtualGoods?type={0}&language={1}&ct={2}", type, MainLanguage, WWW.EscapeURL(token)));
        var op = AsyncOperation.Create(OnSucess, OnError);
        return StartCoroutine(WaitForEnd(request, op));
    }

    public override Coroutine PurchaseVirtualGood(string IDVirtualGood, AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null)
    {
        List<object> ar = new List<object>();
        ar.Add(IDVirtualGood);
        HTTPRequest request = SendJSonRequest(HTTPMethods.Get, string.Format("api/v1/purchases/redeem/VirtualGoods?idClient={0}", this.IDClient), ar);
        var op = AsyncOperation.Create(OnSucess, OnError);
        return StartCoroutine(WaitForEnd(request, op));
    }

// Achievements  //////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public override Coroutine GetAchievements(string type, AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null)
    {
        HTTPRequest request = SendRequest(HTTPMethods.Get, string.Format("api/v1/achievements?achievementConfigurationType={0}&idClient={1}&language={2}", type, this.IDClient, MainLanguage));
        var op = AsyncOperation.Create(OnSucess, OnError);
        return StartCoroutine(WaitForEnd(request, op));
    }

    public override Coroutine GetAchievementsEarned(string type, string token = null, AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null)
    {
        HTTPRequest request;
        if (token == null) request = SendRequest(HTTPMethods.Get, string.Format("api/v1/fan/me/Achievements?language={0}", MainLanguage));
        else request = SendRequest(HTTPMethods.Get, string.Format("api/v1/fan/me/Achievements?language={0}&ct={1}", MainLanguage, WWW.EscapeURL(token)));
        var op = AsyncOperation.Create(OnSucess, OnError);
        return StartCoroutine(WaitForEnd(request, op));
    }

// Contents  //////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public override Coroutine GetContents(string type, int page, AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null)
    {
        HTTPRequest request = SendRequest(HTTPMethods.Get, string.Format("api/v1/content/{0}?ct={1}&language={2}", type, page, MainLanguage));
        var op = AsyncOperation.Create(OnSucess, OnError);
        return StartCoroutine(WaitForEnd(request, op));
    }

    public override Coroutine GetContent(string IDContent, AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null)
    {
        HTTPRequest request = SendRequest(HTTPMethods.Get, string.Format("api/v1/content/{0}", IDContent));
        var op = AsyncOperation.Create(OnSucess, OnError);
        return StartCoroutine(WaitForEnd(request, op));
    }

// Gamificación  //////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public override Coroutine GamificationStatus(AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null)
    {
        HTTPRequest request = SendRequest(HTTPMethods.Get, string.Format("api/v1/fan/me/GamificationStatus?language={0}&idClient={1}", MainLanguage, this.IDClient));
        var op = AsyncOperation.Create(OnSucess, OnError);
        return StartCoroutine(WaitForEnd(request, op));
    }

    public override Coroutine SendAction(string IDAction, AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null)
    {
        Dictionary<string, object> hs = new Dictionary<string, object>();
        hs.Add("ActionId", IDAction);
        hs.Add("ClientId", this.IDClient);
        HTTPRequest request = SendJSonRequest(HTTPMethods.Post, "api/v1/useractions", hs);
        var op = AsyncOperation.Create(OnSucess, OnError);
        return StartCoroutine(WaitForEnd(request, op));
    }

// InApp Purchases //////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public override Coroutine InAppPurchase(string IdProduct, string Receipt, AsyncOperation.RequestEvent OnSucess = null, AsyncOperation.RequestEvent OnError = null)
    {
        Dictionary<string, object> hs = new Dictionary<string, object>();
        hs.Add("IdClient", this.IDClient);
        hs.Add("IdProduct", IdProduct);
        hs.Add("Receipt", Receipt);
        hs.Add("UseVirtualGoods", false);

        HTTPRequest request = SendJSonRequest(HTTPMethods.Post, "api/v1/purchases", hs);
        var op = AsyncOperation.Create(OnSucess, OnError);
        return StartCoroutine(WaitForEnd(request, op));
    }
}
#endif