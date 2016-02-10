using UnityEngine;
using System.Collections;


public class AzureInterfaz { 
    protected MonoBehaviour component;
    public AzureInterfaz(MonoBehaviour component) {
        this.component = component;
    }

    public delegate void RequestEvent(string response);

    public delegate void AccessTokenEvent();
    public AccessTokenEvent OnAccessToken { get; set; }

    protected string clientId;


    public string AccessToken { get; protected set; }
    public string RefreshToken{ get; protected set; }

    public string MainLanguage {
        get{
            string language = DEFAULT_LANGUAGE;
            if (MainManager.Instance != null){
                switch (MainManager.Instance.CurrentLanguage){
                    case "es": language = SPANISH_LANGUAGE; break;
                    case "en": language = ENGLISH_LANGUAGE; break;
                }
            }
            return language;
        }
    }

    public virtual void Init(string environment, string clientId, string sessionId = ""){}
    // LogIn
    public virtual void SignIn() { }
    public virtual void SignUp() { }
    public virtual void SignOut() { }
    public virtual bool IsLoggedUser() { return false; }
    // 
    public virtual void GetProfile() { }

    public virtual IEnumerator GetAccessToken(string _code){ yield return null; }

    
    public static string WebApiBaseAddress {
        get {
            return "https://eu-rm-dev-web-api.azurewebsites.net/";
        }
    }

    public static string URL_USER_PROFILE = "api/v1/fan/me";

    public void RequestGet(string url, RequestEvent ok = null, RequestEvent error = null)
    {
        component.StartCoroutine(_RequestGet(url, ok, error));
    }

    
    public IEnumerator AwaitableRequestGet(string url, RequestEvent ok = null, RequestEvent error = null)
    {
        yield return component.StartCoroutine(_RequestGet(url, ok, error));
    }

    public Coroutine AwaitRequestGet(string url, RequestEvent ok = null, RequestEvent error = null)
    {
        return component.StartCoroutine(_RequestGet(url, ok, error));
    }

    public IEnumerator _RequestGet(string url, RequestEvent ok = null, RequestEvent error = null) {
        HTTP.Request request = new HTTP.Request("get", string.Format("{0}{1}", AzureInterfaz.WebApiBaseAddress, url));
        AddAuthorization(request);
        request.Send();
        while (!request.isDone){ yield return null; }
        if (ok != null) ok(request.response.Text);
    }

    public void RequestPost(string url, string json, RequestEvent ok = null, RequestEvent error = null) {
        component.StartCoroutine(_RequestPost(url, JSON.JsonDecode(json), ok, error));
    }

    public void RequestPost(string url, object json, RequestEvent ok = null, RequestEvent error = null) {
        component.StartCoroutine(_RequestPost(url, json, ok, error));
    }

    public IEnumerator _RequestPost(string url, object json, RequestEvent ok = null, RequestEvent error = null) {
        HTTP.Request request = new HTTP.Request("post", string.Format("{0}{1}", AzureInterfaz.WebApiBaseAddress, url), json as object);
        AddAuthorization(request);
        request.Send();
        while (!request.isDone) { yield return null; }
        if (ok != null) ok(request.response.Text);
    }

    public void RequestPostString(string url, string value, RequestEvent ok = null, RequestEvent error = null) {
        component.StartCoroutine(_RequestPostString(url, value, ok, error));
    }

    public IEnumerator _RequestPostString(string url, string value, RequestEvent ok = null, RequestEvent error = null) {
        HTTP.Request request = new HTTP.Request("post", string.Format("{0}{1}", AzureInterfaz.WebApiBaseAddress, url), value);
        AddAuthorization(request);
        request.Send();
        while (!request.isDone) { yield return null; }
        if (ok != null) ok(request.response.Text);
    }

    public void RequestPut(string url, byte[] array, RequestEvent ok = null, RequestEvent error = null)
    {
        component.StartCoroutine(_RequestPut(url, array, ok, error));
    }

    public IEnumerator _RequestPut(string url, byte[] array, RequestEvent ok = null, RequestEvent error = null)
    {
        HTTP.Request request = new HTTP.Request("put", string.Format("{0}{1}", AzureInterfaz.WebApiBaseAddress, url), array);
        AddAuthorization(request);
        request.Send();
        while (!request.isDone) { yield return null; }
        if (ok != null) ok(request.response.Text);
    }

    public void RequestDelete(string url, RequestEvent ok = null, RequestEvent error = null)
    {
        component.StartCoroutine(_RequestDelete(url, ok, error));
    }

    public IEnumerator _RequestDelete(string url, RequestEvent ok = null, RequestEvent error = null)
    {
        HTTP.Request request = new HTTP.Request("delete", string.Format("{0}{1}", AzureInterfaz.WebApiBaseAddress, url));
        AddAuthorization(request);
        request.Send();
        while (!request.isDone) { yield return null; }
        if (ok != null) ok(request.response.Text);
    }


    protected void AddAuthorization(HTTP.Request request)
    {
        string scheme = "Bearer";
        string authorization = string.Format("{0} {1}", scheme, AccessToken);
        request.AddHeader("Authorization", authorization);
        Debug.Log("Authorization: " + authorization);
    }

    private const string SPANISH_LANGUAGE = "es-es";
    private const string ENGLISH_LANGUAGE = "en-us";
    private const string DEFAULT_LANGUAGE = SPANISH_LANGUAGE;


}
