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
                else
                    Debug.LogError("ERROR MicrosoftSDK::DigitalPlatformClient class");
            }
            return _class;
        }
    }
    private static AndroidJavaClass _class;

    public override void Init(string environment, string clientId, string sessionId = "")
    {
        this.clientId = clientId;
        Debug.LogError("Paso 1");
        DigitalPlatformClient.Init(environment, clientId);

        /*
        ApplicationContext.Init(environment, clientId);
        Debug.LogError("Paso 2");
        DBContext.InitDb();
        Debug.LogError("Paso 3");
        // NetworkHandler.getInstance(ctx);
        NetworkHandler networkHandler = NetworkHandler.Instance;
        Debug.LogError("Paso 4");
        // context.setAuthHandler(new AuthHandler(ctx));
        DigitalPlatformClient.Instance.AuthHandler = AuthHandler.Instance;
        Debug.LogError("Paso 5");
        */
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