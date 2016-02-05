using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

#if UNITY_IOS
public class IOSAzureInterfaz : AzureInterfaz {
    MonoBehaviour component;

	[DllImport ("__Internal")]
	private static extern void _AzureInit(string environment, string clientId);
	[DllImport ("__Internal")]
	private static extern void _AzureSignUp();
	[DllImport ("__Internal")]
	private static extern void _AzureSignIn();
	[DllImport ("__Internal")]
	private static extern void _AzureSignOut();

	public IOSAzureInterfaz(MonoBehaviour component)  : base(component){ }

    public override void Init(string environment, string clientId, string sessionId = "")
    {
		_AzureInit(environment, clientId);
    }

    // LogIn
    public override void SignIn()
    {
		_AzureSignIn();
    }

    public override void SignUp()
    {
		_AzureSignUp();
    }

    public override void SignOut()
    {
		_AzureSignOut();
    }

    public override bool IsLoggedUser()
    {
        return false;
    }
    // 
    public override void GetProfile()
    {
    }

}

#endif