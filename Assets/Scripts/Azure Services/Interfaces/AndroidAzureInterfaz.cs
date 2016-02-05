using UnityEngine;
using System.Collections;

#if UNITY_ANDROID
public class AndroidAzureInterfaz : AzureInterfaz {

    public AndroidAzureInterfaz(MonoBehaviour component) : base(component){ }

    private static AndroidJavaClass JavaClass
    {
        get
        {
            if (_class == null)
            {
                _class = new AndroidJavaClass("com.microsoft.mdp.sdk.DigitalPlatformClient");
                if (_class != null)
                {
                    Debug.Log("MicrosoftSDK::DigitalPlatformClient class");
                }
            }
            return _class;
        }
    }
    private static AndroidJavaClass _class;

    public override void Init(string environment, string clientId, string sessionId = "")
    {
        this.clientId = clientId;
        //        DigitalPlatformClient.Init(environment, clientId);


        ApplicationContext.Init(environment, clientId);
        DBContext.InitDb();
        // NetworkHandler.getInstance(ctx);
        NetworkHandler networkHandler = NetworkHandler.Instance;
        // context.setAuthHandler(new AuthHandler(ctx));
        DigitalPlatformClient.Instance.AuthHandler = AuthHandler.Instance;

    }

    // LogIn
    public override void SignIn()
    {
        component.StartCoroutine(WaitAccessToken());
    }

	private IEnumerator WaitAccessToken() {
// Intentamos entrar de forma sileciosa.
//        yield return component.StartCoroutine(DigitalPlatformClient.Instance.InitialAccess());
        yield return component.StartCoroutine(DigitalPlatformClient.Instance.SignIn());
        AccessToken = DigitalPlatformClient.Instance.AccessToken;
		if (OnAccessToken != null) OnAccessToken();
	}

    public override void SignUp()
    {

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

}

#endif