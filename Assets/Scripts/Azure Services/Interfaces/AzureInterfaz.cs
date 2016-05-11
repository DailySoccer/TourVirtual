using UnityEngine;
using System.Collections;
using BestHTTP;
using SmartLocalization;

public class AzureInterfaz {
    protected MonoBehaviour component;
    public AzureInterfaz(MonoBehaviour component) {
        this.component = component;
    }

    public delegate void RequestEvent(string response);

    public delegate void AccessTokenEvent();
    public AccessTokenEvent OnAccessToken { get; set; }
	public bool waitingForToken=false;

    protected string clientId;

	string _AccessToken;
	public string AccessToken { get{ return _AccessToken; } set { _AccessToken = value; waitingForToken=false; } }

    public string MainLanguage { get;  set; }

    public virtual void Init(string environment, string clientId, string signin, string signup) {}
    // LogIn
    public virtual void SignIn() { }
    public virtual void SignUp() { }
    public virtual void SignOut() { }
	public virtual void OpenURL(string url){ Application.OpenURL (url); }
	public virtual void AskForToken() {
        waitingForToken = false;
    }
    public virtual bool IsLoggedUser() { return false; }
    // 
    public virtual void GetProfile() { }
	public virtual IEnumerator GetAccessToken(string _code) { yield return null; }

	public IEnumerator AskForAccessToken() { 
		waitingForToken = true;
		AskForToken ();
		while(waitingForToken) yield return null;
	}

    public string WebApiBaseAddress { get; set; }
    public void RequestGet(string url, RequestEvent ok = null, RequestEvent error = null) {
        component.StartCoroutine(_Request("get", url, ok, error));
    }

    public IEnumerator AwaitableRequestGet(string url, RequestEvent ok = null, RequestEvent error = null) {
        yield return component.StartCoroutine(_Request("get", url, ok, error));
    }

    public Coroutine AwaitRequestGet(string url, RequestEvent ok = null, RequestEvent error = null) {
        return component.StartCoroutine(_Request("get",url, ok, error));
    }

    public void RequestPost(string url, string json, RequestEvent ok = null, RequestEvent error = null) {
        RequestPostJSON(url, json, ok, error);
    }

    public void RequestPostJSON(string url, object json, RequestEvent ok = null, RequestEvent error = null) {
        component.StartCoroutine(_RequestJSON("post", url, json, ok, error));
    }

    public void RequestPostString(string mode, string url, string value, RequestEvent ok = null, RequestEvent error = null) {
        component.StartCoroutine(_RequestString("post", url, value, ok, error));
    }

    public void Request(string mode, string url, byte[] array, RequestEvent ok = null, RequestEvent error = null) {
        component.StartCoroutine(_RequestByteArray( mode,  url, array, ok, error));
    }

    public void RequestJSON(string mode, string url, object json, RequestEvent ok = null, RequestEvent error = null) {
        component.StartCoroutine(_RequestJSON(mode, url, json, ok, error));
    }

    public void RequestString(string mode, string url, string value, RequestEvent ok = null, RequestEvent error = null) {
        component.StartCoroutine(_RequestString(mode, url, value, ok, error));
    }

    void checkResult(RequestEvent ok, RequestEvent error, HTTPRequest request) {
        try {
            if (request.Response.StatusCode != 200) {
                // Oculatamos la carga
                LoadingCanvasManager.Hide();
                // Sacamos un mensaje genrico.
                ModalTextOnly.ShowText(LanguageManager.Instance.GetTextValue("TVB.Error.NetError"));
                Debug.LogError(">>>>>> " + request.Response.StatusCode.ToString() + ":" + request.Response.Message);
                if (error != null) error(request.Response.StatusCode.ToString() );
            }
            else {
                if (ok != null) ok(MyTools.AsciiToString(request.Response.Data));
            }
        }catch(System.Exception e){
            LoadingCanvasManager.Hide();
            // Sacamos un mensaje genrico.
            ModalTextOnly.ShowText(LanguageManager.Instance.GetTextValue("TVB.Error.NetError"));
            if (error != null) error("404");
        }
    }

    public IEnumerator _Request(string mode, string url, RequestEvent ok = null, RequestEvent error = null) {
        HTTPRequest request = new HTTPRequest(new System.Uri(string.Format("{0}{1}", WebApiBaseAddress, url)));
        request.MethodType = HTTPMethods.Get;
        request.DisableCache = true;
        yield return component.StartCoroutine(AddAuthorization(request));
        request.Send();
        while (request.State < HTTPRequestStates.Finished) yield return null;
        checkResult(ok, error, request );
    }

    public IEnumerator _RequestString(string mode, string url, string value, RequestEvent ok = null, RequestEvent error = null) {
        HTTPRequest request;
        if (mode == "post") request = new HTTPRequest(new System.Uri(string.Format("{0}{1}", WebApiBaseAddress, url)), HTTPMethods.Post);
        else request = new HTTPRequest(new System.Uri(string.Format("{0}{1}", WebApiBaseAddress, url)), HTTPMethods.Put);
        request.AddHeader("Content-Type", "application/json");
        request.RawData = MyTools.GetBytes(value);
        yield return component.StartCoroutine(AddAuthorization(request));
        request.Send();
        while (request.State < HTTPRequestStates.Finished) yield return null;
        checkResult(ok, error, request);
/*
        HTTP.Request request = new HTTP.Request(mode, string.Format("{0}{1}", AzureInterfaz.WebApiBaseAddress, url), value);
		yield return component.StartCoroutine( AddAuthorization(request) );
        request.Send();
        while (!request.isDone) { yield return null; }
        checkResult(ok, error, request);
*/
    }

    public IEnumerator _RequestJSON(string mode, string url, object json, RequestEvent ok = null, RequestEvent error = null)
    {
        HTTPRequest request;
        if (mode == "post") request = new HTTPRequest(new System.Uri(string.Format("{0}{1}", WebApiBaseAddress, url)), HTTPMethods.Post);
        else request = new HTTPRequest(new System.Uri(string.Format("{0}{1}", WebApiBaseAddress, url)), HTTPMethods.Put);
        request.AddHeader("Content-Type", "application/json");
        request.RawData = MyTools.GetBytes(BestHTTP.JSON.Json.Encode(json));
        yield return component.StartCoroutine(AddAuthorization(request));
        request.Send();
        while (request.State < HTTPRequestStates.Finished) yield return null;
        checkResult(ok, error, request);
/*
        HTTP.Request request = new HTTP.Request(mode, string.Format("{0}{1}", AzureInterfaz.WebApiBaseAddress, url), json as object);
		yield return component.StartCoroutine( AddAuthorization(request) );
        request.Send();
        while (!request.isDone) { yield return null; }
        checkResult(ok, error, request);
*/
    }

    public IEnumerator _RequestByteArray(string mode, string url, byte[] array, RequestEvent ok = null, RequestEvent error = null) {
        HTTPRequest request = new HTTPRequest(new System.Uri(string.Format("{0}{1}", WebApiBaseAddress, url)), HTTPMethods.Put);
        request.AddHeader("Content-Type", "application/json");
        request.RawData = array;
        yield return component.StartCoroutine(AddAuthorization(request));
        request.Send();
        while (request.State < HTTPRequestStates.Finished) yield return null;
        checkResult(ok, error, request);

/*
        HTTP.Request request = new HTTP.Request(mode, string.Format("{0}{1}", AzureInterfaz.WebApiBaseAddress, url), array);
		yield return component.StartCoroutine( AddAuthorization(request) );
        request.Send();
        while (!request.isDone) { yield return null; }
        checkResult(ok, error, request);
*/
    }
    
    protected IEnumerator AddAuthorization(HTTPRequest request)
    {
        yield return component.StartCoroutine(AskForAccessToken());
        // pido el token a la liberia
        string scheme = "Bearer";
        string authorization = string.Format("{0} {1}", scheme, AccessToken);
        request.AddHeader("Authorization", authorization);
    }
    /*
    protected IEnumerator AddAuthorization(HTTP.Request request) {
		yield return component.StartCoroutine( AskForAccessToken () );
		// pido el token a la liberia
		string scheme = "Bearer";        
		string authorization = string.Format("{0} {1}", scheme, AccessToken);
        request.AddHeader("Authorization", authorization);
    }
    */
    private const string SPANISH_LANGUAGE = "es-es";
    private const string ENGLISH_LANGUAGE = "en-us";
    private const string DEFAULT_LANGUAGE = SPANISH_LANGUAGE;
}