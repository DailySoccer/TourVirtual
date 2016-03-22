using UnityEngine;
using System.Collections;

#if UNITY_ANDROID
public class AndroidAzureInterfaz : AzureInterfaz {

    public AndroidAzureInterfaz(MonoBehaviour component) : base(component){ }

    private static AndroidJavaObject activity
    {
        get
        {
            if (_activity == null)
                _activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
            return _activity;
        }
    }
    private static AndroidJavaObject _activity;

	public override void Init(string environment, string clientId, string signin, string signup)
    {
        this.clientId = clientId;
        activity.Call("Init", environment, clientId, signin, signup);
    }

    // LogIn
    public override void SignIn() {
        activity.Call("Login", false);
    }

    public override void SignUp() {
        activity.Call("Login", true);
    }

    public override void SignOut() {
        activity.Call("Logout");

    }

    public override bool IsLoggedUser() {
        return false;
    }

    public override void GetProfile() {

    }

    public override void AskForToken()
    {
        activity.Call("GetToken");
    }

}

#endif