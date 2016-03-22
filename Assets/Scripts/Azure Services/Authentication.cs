#define DEV
//#define PRE
//#define PRO

using System.Collections;
using UnityEngine;

public class Authentication : MonoBehaviour {
    public static string IDClient = "";
    public static AzureInterfaz AzureServices;
	static public Authentication Instance {
        get; private set; 
    }

    public bool IsOk { get { return !string.IsNullOrEmpty(AzureServices.AccessToken); } }

    public bool AuthorizationValid { get { return Authentication.Instance != null && Authentication.Instance.IsOk; } }

	public void OnToken(string token){
		if (token != "Error") {
			AzureServices.AccessToken = token;
			if(AzureServices.OnAccessToken !=null) AzureServices.OnAccessToken();
        }
        else
        {
            Debug.LogError("Login mal!!!");
        }
	
	}


	public void OnTokenReceive(string token){
		if (token != "Error") {
			AzureServices.AccessToken = token;
		}
	}

    void Awake() {
        Instance = this;
        UserAPI ua = new UserAPI();
    }

    IEnumerator Start()
    {
#if UNITY_EDITOR
    #if PRO
        IDClient = "1416e63a-8998-4243-99f7-8c9ebf516157";
    #else
        #if PRE
            IDClient = "b992508b-b9ed-49fb-998d-6f8cdb810b8a";
        #else
            IDClient = "41f64a6e-edf8-4d7d-86cf-6146cc69f978";
        #endif
    #endif
    AzureServices = new EditorAzureInterfaz(this);
#else
#if UNITY_ANDROID
    #if PRO
        IDClient = "1416e63a-8998-4243-99f7-8c9ebf516157";
    #else
        #if PRE
            IDClient = "b992508b-b9ed-49fb-998d-6f8cdb810b8a";
        #else
            IDClient = "41f64a6e-edf8-4d7d-86cf-6146cc69f978";
        #endif
    #endif
    AzureServices = new AndroidAzureInterfaz(this);
        
#else
#if UNITY_IOS
    #if PRO
        IDClient = "5926acc9-15ff-44e0-a2f7-a5026db1ca78";
    #else
        #if PRE
            IDClient = "0ef88203-46a5-4db7-aa8f-bbee4a5b24c3";
        #else
            IDClient = "17525b4e-8a03-4950-a5cd-dcdc6004aaaf";
    #endif
#endif
        AzureServices = new IOSAzureInterfaz(this);
#else
#if UNITY_WSA
    #if PRO
        IDClient = "43bb526b-84fc-47f9-822c-2f47aae59529";
    #else
        #if PRE
            IDClient = "ec6a70f6-27d4-4e99-80fa-34883da0bcd5";
        #else
            IDClient = "c0c95635-cdfc-447b-bdab-d4a833fc52ca";
        #endif
    #endif
         AzureServices = new WSAAzureInterfaz(this); // Es instanciado desde el lado de WP
#endif
#endif
#endif
#endif

		yield return new WaitForEndOfFrame();
		
		if (DLCManager.Instance != null)
		{
			// Descargar el fichero de versiones.
			yield return StartCoroutine(DLCManager.Instance.LoadVersion());
			yield return StartCoroutine(DLCManager.Instance.CacheResources());
            if (PlayerManager.Instance != null)
                yield return StartCoroutine(PlayerManager.Instance.CacheClothes());
        }

        if (!UserAPI.Instance.Online) {
            
			UserAPI.Instance.CallOnUserLogin();
			yield break;
		}
#if PRO
            AzureServices.WebApiBaseAddress = "https://api.realmadrid.com/";
#else
#if PRE
            AzureServices.WebApiBaseAddress = "https://apipre.realmadrid.com/";
#else
            AzureServices.WebApiBaseAddress = "https://eu-rm-dev-web-api.azurewebsites.net/";
#endif
#endif
        AzureServices.Init ("development", IDClient, "p=B2C_1_SignInSignUp_TourVirtual&nonce=defaultNonce&scope=openid", "p=B2C_1_SignInSignUp_TourVirtual&nonce=defaultNonce&scope=openid");//"7c0557e9-8e0b-4045-b2d6-ccb074cd6606");
        AzureServices.OnAccessToken = () => {
            StartCoroutine( UserAPI.Instance.Request() );
        };
        AzureServices.SignIn();
    }

    void Update() {
#if UNITY_WSA && !UNITY_EDITOR
        (AzureServices as WSAAzureInterfaz).Update();
#endif
    }


    private string _urlCode = "";
#if UNITY_EDITOR
    void OnGUI() {
        if (UserAPI.Instance.Online && string.IsNullOrEmpty(AzureServices.AccessToken) )
        {
            if (GUI.Button(new Rect(0, Screen.height - 150, 75, 80), "Create"))
                AzureServices.SignUp();
            if (GUI.Button(new Rect(75, Screen.height - 150, 75, 80), "Login"))
                AzureServices.SignIn();
            if (GUI.Button(new Rect(150, Screen.height - 150, 75, 80), "Signout"))
                AzureServices.SignOut();

            if (GUI.Button(new Rect(320, Screen.height - 150, 150, 25), "Token ")) {
                StartCoroutine(AzureServices.GetAccessToken(_urlCode) );
            }
            GUI.Label(new Rect(320, Screen.height - 125, 300, 25), "URL Response: http://localhost/?code=XXX");
            _urlCode = GUI.TextField(new Rect(320, Screen.height - 100, 300, 25), _urlCode);
        }
    }
#endif

#if UNITY_ANDROID
    AndroidJavaObject _activityContext;
	AndroidJavaObject _authContext;
#endif
}
