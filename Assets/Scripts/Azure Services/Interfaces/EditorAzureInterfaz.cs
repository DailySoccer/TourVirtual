using UnityEngine;
using System.Collections;

public class EditorAzureInterfaz : AzureInterfaz
{
    public EditorAzureInterfaz(MonoBehaviour component): base(component)
    {
    }

    string signin;
    string signup;


    public override void Init(string environment, string clientId, string signin, string signup)
    {
        this.signin = signin;
        this.signup = signup;
        this.clientId = clientId;
    }

    // LogIn
    public override void SignIn()
    {
        string parameters = string.Format("?response_type=code&client_id={0}&redirect_uri={1}&resource={2}", clientId, redirectUri, webApiResourceId);
        string extraParameters = "p=B2C_1_SignIn&nonce=defaultNonce&scope=openid";
        string url = string.Format("{0}/oauth2/authorize{1}&{2}", authority, parameters, extraParameters);
        Application.OpenURL(url);
    }

    public override void SignUp()
    {
        string parameters = string.Format("?response_type=code&client_id={0}&redirect_uri={1}&resource={2}", clientId, redirectUri, webApiResourceId);
        string extraParameters = "p=B2C_1_SignUp&nonce=defaultNonce&scope=openid";
        string url = string.Format("{0}/oauth2/authorize{1}&{2}", authority, parameters, extraParameters);
        Application.OpenURL(url);
    }

    public override void SignOut()
    {

    }
    public override bool IsLoggedUser()
    {
        return false;
    }
    // 
    public override void GetProfile()
    {

    }

    // Tools
    protected static string KEY_ACCESS_TOKEN = "access_token";
    protected static string KEY_REFRESH_TOKEN = "refresh_token";
    protected static string webApiResourceId = "https://rmaddev.onmicrosoft.com/webapi";
    protected static string redirectUri = "http://localhost/";
    protected static string aadInstance = "https://login.microsoftonline.com/{0}";
    protected static string tenant = "rmadb2cdev.onmicrosoft.com";
    protected static string authority = string.Format(aadInstance, tenant);

    public override IEnumerator GetAccessToken(string _code) {
        _code = extractCodeFromURL(_code);
        WWWForm form = new WWWForm();
        form.AddField("resource", webApiResourceId);
        form.AddField("client_id", clientId);
        form.AddField("code", _code);
        form.AddField("grant_type", "authorization_code");
        form.AddField("redirect_uri", redirectUri);
        string url = string.Format("{0}/oauth2/token?p={1}&nonce=defaultNonce&scope=openid", authority, "B2C_1_SignIn");
        Debug.Log("ACCES TOKEN: URL: " + url);

        WWW www = new WWW(url, form);
        yield return www;
        if (string.IsNullOrEmpty(www.error))
            ProcessTokenResponse(www.text);
        else {
            Debug.Log("ERROR!!! ProcessTokenResponse");
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
            Debug.Log("---> Code: " + code);
        }

        return code;
    }



    public void ProcessTokenResponse(string text) {
        Debug.Log("Response: " + text);
        object json = JSON.JsonDecode(text);
        if (json is Hashtable) {
            Hashtable jsonMap = json as Hashtable;
            if (jsonMap.ContainsKey(KEY_ACCESS_TOKEN)) {
                AccessToken = jsonMap[KEY_ACCESS_TOKEN] as string;
                Debug.Log("AccessToken: " + AccessToken);
                if (OnAccessToken != null) OnAccessToken();
            }
        }
    }

}