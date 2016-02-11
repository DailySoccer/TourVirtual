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

    void Awake() {
        UserAPI ua = new UserAPI();
    }

    void Start()
    {
#if UNITY_EDITOR
        IDClient = "a9ae3ecc-765e-45f3-96dd-e367a936dda9";
        AzureServices = new EditorAzureInterfaz(this);
#else
#if UNITY_ANDROID
        IDClient = "a9ae3ecc-765e-45f3-96dd-e367a936dda9";
        AzureServices = new AndroidAzureInterfaz(this);
        
#else
#if UNITY_IOS
        IDClient = "e2e022fc-63c8-4c8b-ad05-c5f819f0d341";
        AzureServices = new IOSAzureInterfaz(this);
#else
#if UNITY_WSA
        IDClient = "9af28d79-4559-4009-b97b-d857e2932615";
        // AzureServices = new WP8AzureInterfaz(); // Es instanciado desde el lado de WP
#endif
#endif
#endif
#endif
        AzureServices.Init("Development", "7c0557e9-8e0b-4045-b2d6-ccb074cd6606");
        AzureServices.OnAccessToken = () => {
            StartCoroutine( UserAPI.Instance.Request() );
        };
        AzureServices.SignIn();
    }

    void Update() { }


    private string _urlCode = "";
    void OnGUI() {
        if (string.IsNullOrEmpty(AzureServices.AccessToken) && UserAPI.Instance.Online )
        {
            if (GUI.Button(new Rect(0, Screen.height - 150, 150, 80), "Register"))
                AzureServices.SignUp();
            if (GUI.Button(new Rect(150, Screen.height - 150, 150, 80), "Login"))
                AzureServices.SignIn();
#if UNITY_EDITOR
            if (GUI.Button(new Rect(320, Screen.height - 150, 150, 25), "Token ")) {
                StartCoroutine(AzureServices.GetAccessToken(_urlCode) );
            }
            GUI.Label(new Rect(320, Screen.height - 125, 300, 25), "URL Response: http://localhost/?code=XXX");
            _urlCode = GUI.TextField(new Rect(320, Screen.height - 100, 300, 25), _urlCode);
#endif
        }
    }

#if UNITY_ANDROID
	AndroidJavaObject _activityContext;
	AndroidJavaObject _authContext;
#endif
}
