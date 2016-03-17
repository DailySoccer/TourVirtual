using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WSAAzureInterfaz : AzureInterfaz
{
    public WSAAzureInterfaz(MonoBehaviour component): base(component)
    {
    }

    public override void Init(string environment, string clientId, string signin, string signup)
    {
        WP8Plugin.Plugin.Init(environment, clientId, signin, signup);

    }


    // LogIn
    public override void SignIn()
    {
        WP8Plugin.Plugin.Login(OnLoginCallback);
    }

    public override void SignUp()
    {
        WP8Plugin.Plugin.Login(OnLoginCallback);
 
    }

    public override void SignOut()
    {
        WP8Plugin.Plugin.Logout();

    }
    public override bool IsLoggedUser()
    {
        return false;
    }
    string token;
    bool LoginWaiter = false;
    public void OnLoginCallback(string res)
    {
        LoginWaiter = true;
        token = res;

    }

    bool TokenWaiter = false;
    public void OnTokenCallback(string res)
    {
        TokenWaiter = true;
        token = res;
    }

    public void Update()
    {
        if (LoginWaiter)
        {
            LoginWaiter = false;
            Authentication.Instance.OnToken(token);
        }
        if (TokenWaiter)
        {
            TokenWaiter = false;
            Authentication.Instance.OnTokenReceive(token);
        }
    }

    public override void AskForToken()
    {
        WP8Plugin.Plugin.GetToken(OnTokenCallback);
    }

    public override void OpenURL(string url)
    {
        WP8Plugin.Plugin.OpenURI(url);
    }

    
}