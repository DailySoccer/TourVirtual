using UnityEngine;

public class Authentication : MonoBehaviour {
    public static string IDClient = "";
    public static AzureInterfaz AzureServices;
	static public Authentication Instance {
		get {
			GameObject authenticationObj = GameObject.FindGameObjectWithTag("AzureServices");
			return authenticationObj != null ? authenticationObj.GetComponent<Authentication>() : null;
		}
	}

    public bool IsOk { get { return !string.IsNullOrEmpty(AzureServices.AccessToken); } }

    public bool AuthorizationValid { get { return Authentication.Instance != null && Authentication.Instance.IsOk; } }

	public void OnToken(string token){
		Debug.LogError ("OnToken " + token);
		if (token != "Error") {
			AzureServices.AccessToken = token;
			if(AzureServices.OnAccessToken !=null) AzureServices.OnAccessToken();
		}
	
	}


	public void OnTokenReceive(string token){
#if !UNITY_ANDROID
        Debug.LogError ("OnTokenReceive " + token);
#endif
		if (token != "Error") {
			AzureServices.AccessToken = token;
		}
	}

    void Awake() {
        UserAPI ua = new UserAPI();
    }

    void Start()
    {
#if UNITY_EDITOR
        IDClient = "41f64a6e-edf8-4d7d-86cf-6146cc69f978";
        AzureServices = new EditorAzureInterfaz(this);
#else
#if UNITY_ANDROID
        IDClient = "41f64a6e-edf8-4d7d-86cf-6146cc69f978";        
        AzureServices = new AndroidAzureInterfaz(this);
        
#else
#if UNITY_IOS
        IDClient = "17525b4e-8a03-4950-a5cd-dcdc6004aaaf";
        AzureServices = new IOSAzureInterfaz(this);
#else
#if UNITY_WSA
        IDClient = "c0c95635-cdfc-447b-bdab-d4a833fc52ca";
        // AzureServices = new WP8AzureInterfaz(); // Es instanciado desde el lado de WP
#endif
#endif
#endif
#endif
        if (!UserAPI.Instance.Online) return;
        AzureServices.Init ("development", IDClient, "p=B2C_1_SignInSignUp_TourVirtual&nonce=defaultNonce&scope=openid", "p=B2C_1_SignInSignUp_TourVirtual&nonce=defaultNonce&scope=openid");//"7c0557e9-8e0b-4045-b2d6-ccb074cd6606");
        AzureServices.OnAccessToken = () => {
            StartCoroutine( UserAPI.Instance.Request() );
        };
        AzureServices.SignIn();
    }

    void Update() { }


    private string _urlCode = "";
#if UNITY_EDITOR
    void OnGUI() {
        if (string.IsNullOrEmpty(AzureServices.AccessToken) && UserAPI.Instance.Online )
        {
            if (GUI.Button(new Rect(0, Screen.height - 150, 150, 80), "Register"))
                AzureServices.SignUp();
            if (GUI.Button(new Rect(150, Screen.height - 150, 150, 80), "Login"))
                AzureServices.SignIn();

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
