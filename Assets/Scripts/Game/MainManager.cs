using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SmartLocalization;

#if !LITE_VERSION
using Soomla;
using Soomla.Store;
#endif

public enum TourVirtualBuildMode {
	Debug,
	Release
}

// Application.OpenURL("rmapp://");


public class MainManager : Photon.PunBehaviour {

	static public MainManager Instance { get; private set; }

	public delegate void ChangeEvent();
	public event ChangeEvent OnLanguageChange;
	public event ChangeEvent OnInternetConnection;

	public delegate void MessagesUnreadedEvent(int counter);
	public event MessagesUnreadedEvent OnMessagesUnreadedEvent;

	public string PlayerName;

	public bool InternetConnection = false;

    public static VestidorCanvasController_Lite.VestidorState VestidorMode = VestidorCanvasController_Lite.VestidorState.VESTIDOR;

    public GameObject GameInput;
#if !LITE_VERSION
	public bool GameInputEnabled {
		get {
			return GameInput != null ? GameInput.GetComponent<Controller3DExample>().enabled : true;
		}
		set {
			if (GameInput != null) {
				// TODO: En android da problemas el desactivar la camara o el gameobject (p.ej. cuando se está en el estadio viendo el cubemap)
				//GameInput.GetComponent<Camera>().enabled = value;
				GameInput.GetComponent<Controller3DExample>().enabled = value;
			}
		}
	}
#endif
	[SerializeField]
	private string _currentLanguage;
	public string CurrentLanguage {
		get {return _currentLanguage;} 
		set{
			if (!_currentLanguage.Equals(value)) {
				_currentLanguage = value;

				if (OnLanguageChange != null) {
					OnLanguageChange();
				}

				//TODO: guardar valor en archivo de configuracion
			}
		}
	}
	
	[SerializeField]
	private bool _musicEnabled;
	public bool MusicEnabled {
		get {return _musicEnabled;}
		set {
			_musicEnabled = value;
			//TODO: guardar valor en archivo de configuracion
		}
	}
	 
	[SerializeField]
	private bool _soundEnabled;
	public bool SoundEnabled {
		get {return _soundEnabled;}
		set {
			_soundEnabled = value;
			//TODO: guardar valor en archivo de configuracion
		}
	}

	[SerializeField]
	private int _unreadedChatMessages;
	public int UnreadedChatMessages {
		get {return _unreadedChatMessages;}
		set {
			_unreadedChatMessages = value;
			OnMessagesUnreadedEvent(_unreadedChatMessages);
		}
	}

	public bool OfflineMode = false;

	public TourVirtualBuildMode BuildMode;

	public bool Ready {
		get {
#if !LITE_VERSION
			return OfflineMode || (InternetConnection && PhotonNetwork.connectedAndReady);
#else
            return InternetConnection;
#endif

        }

	}

	public void ChangeLanguage(string lang) {
		if (LanguageManagerInstance.IsLanguageSupported(lang)) {
			LanguageManagerInstance.ChangeLanguage(lang);
			CurrentLanguage = lang;
		}
		else {
			Debug.LogWarning("El lenguaje seleccionado no está soportado aún: " + lang);
		}
	}

	public LanguageManager LanguageManagerInstance {
		get {
			return LanguageManager.Instance;
		}
	}

    public static bool IsDeepLinking = true;
    public static Dictionary<string, object> DeepLinkinParameters;



    public static string DeepLinkingURL;
    public void DeepLinking(string url){
        DeepLinkingURL = url;
        if (!string.IsNullOrEmpty(url))
        {
            IsDeepLinking = true;
            Debug.LogError(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> DeepLinking !!!! [" + url + "]");
            System.Uri uri = new System.Uri(url);
            DeepLinkinParameters = BestHTTP.JSON.Json.Decode(WWW.UnEscapeURL(DecodeQueryParameters(uri)["parameters"])) as Dictionary<string, object>;
        }
       
    }

    public static Dictionary<string, string> DecodeQueryParameters(System.Uri uri)
    {
        if (uri.Query.Length == 0)
            return new Dictionary<string, string>();

        return uri.Query.TrimStart('?')
                        .Split(new[] { '&', ';' }, System.StringSplitOptions.RemoveEmptyEntries)
                        .Select(kvp => kvp.Split(new[] { '=' }, System.StringSplitOptions.RemoveEmptyEntries))
                        .ToDictionary(kvp => kvp[0],
                                      kvp => kvp.Length > 2 ? string.Join("=", kvp, 1, kvp.Length - 1) : (kvp.Length > 1 ? kvp[1] : ""));
    }

    public void GetDeepLinkingURL() {
#if UNITY_ANDROID
        try {
            using (AndroidJavaClass jclass = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
            {
                AndroidJavaObject activity = jclass.GetStatic<AndroidJavaObject>("currentActivity");
                AndroidJavaObject intent = activity.Call<AndroidJavaObject>("getIntent");
                AndroidJavaObject uri = intent.Call<AndroidJavaObject>("getData");
                DeepLinking( uri.Call<string>("toString"));
            }
        }
        catch (System.Exception ex) {
            Debug.LogWarning(ex.Message);

        }
#else
#if UNITY_WSA
        if (!string.IsNullOrEmpty(UnityEngine.WSA.Application.arguments))
            DeepLinking(UnityEngine.WSA.Application.arguments);
#endif
#endif

    }

    void Awake() {
        Instance = this;


		OfflineMode = Application.internetReachability == NetworkReachability.NotReachable;

		Screen.sleepTimeout = SleepTimeout.NeverSleep;
		Screen.autorotateToPortrait = Screen.autorotateToPortraitUpsideDown = false;
		Screen.autorotateToLandscapeLeft = Screen.autorotateToLandscapeRight = true;
		Screen.orientation = ScreenOrientation.AutoRotation;
#if !LITE_VERSION
        PhotonNetwork.logLevel = PhotonLogLevel.ErrorsOnly;
		PhotonNetwork.autoJoinLobby = true;
		PhotonNetwork.offlineMode = OfflineMode;
		// PhotonNetwork.autoCleanUpPlayerObjects = true;

		// Load name from PlayerPrefs
		PhotonNetwork.playerName = string.IsNullOrEmpty(PlayerName) ? PlayerPrefs.GetString("playerName", "Guest" + Random.Range(1, 9999)) : PlayerName;
		Debug.Log("PlayerName: " + PhotonNetwork.playerName);
		// Cargamos las Setting Options
#endif
		MusicEnabled = true; // TODO: Cargar desde archivo de configuracion
		SoundEnabled = true; // TODO: Cargar desde archivo de configuracion
		CurrentLanguage = LanguageManagerInstance.CurrentlyLoadedCulture.languageCode; // TODO: Cargar desde archivo de configuracion
	}

	void Start() {
        GetDeepLinkingURL();

        DeepLinking("rmvt:editavatar?parameters={ \"idVirtualGood\": \"1d053141-b548-4299-a067-263a4549663d\" }");

        if (UserAPI.Instance != null /* && UserAPI.Instance.Online*/ ) {
            UserAPI.Instance.OnUserLogin += HandleOnUserLogin;
            StartCoroutine(CheckForInternetConnection());
		}
        //		else StartCoroutine(Connect ());
#if !LITE_VERSION
#if (UNITY_ANDROID || UNITY_IOS)
        InitializeStore();
#endif
#endif

    }

    void OnApplicationPause(bool pauseStatus) {
        if (!pauseStatus) {
            GetDeepLinkingURL();
            // Ojo de no ir al vestidor si estoy en AVATAR o antes.
            if (IsDeepLinking && RoomManager.Instance!=null)
                RoomManager.Instance.GotoRoom("VESTIDOR");
        }
        // Ver como evitar este tema.
        //		Application.Quit();
    }
#if !LITE_VERSION
	void InitializeStore() {
		_tourEventHandler = new TourEventHandler();

		StoreEvents.OnSoomlaStoreInitialized += onSoomlaStoreInitialized;
		StoreEvents.OnCurrencyBalanceChanged += onCurrencyBalanceChanged;
		StoreEvents.OnUnexpectedStoreError += onUnexpectedStoreError;        

        // firstLaunchReward = new VirtualItemReward("first-launch", "Give Money at first launch", MuffinRushAssets.MUFFIN_CURRENCY_ITEM_ID, 4000);

        SoomlaStore.Initialize(new TourStoreAssets());
	}

	public void onSoomlaStoreInitialized() {
		if (StoreInfo.Currencies.Count > 0) {
			try {
				/*
				//First launch reward
				if(!firstLaunchReward.Owned)
				{
					firstLaunchReward.Give();
				}
				*/

				// Ejemplo de PurchaseWithMarket
				/*
				VirtualCurrencyPack vg = StoreInfo.CurrencyPacks[0];
				StoreInventory.BuyItem(vg.ItemId);
				*/
			} catch (VirtualItemNotFoundException ex){
				SoomlaUtils.LogError("SOOMLA InitializedException", ex.Message);
			}
		}
	}

	public void onCurrencyBalanceChanged(VirtualCurrency virtualCurrency, int balance, int amountAdded) {
	}
	
	public void onUnexpectedStoreError(int errorCode) {
		SoomlaUtils.LogError ("EventHandler", "error with code: " + errorCode);
	}
#endif
    void HandleOnUserLogin () {
#if !LITE_VERSION
		PhotonNetwork.playerName = UserAPI.Instance.Nick;
#endif
		StartCoroutine(Connect ());
	}

/*
public void OnGUI()	{
    if (!InternetConnection && !OfflineMode) {
        GUIStyle centeredStyle = GUI.skin.GetStyle("Button");
        centeredStyle.alignment = TextAnchor.MiddleCenter;
        centeredStyle.fontSize = 30;
        GUI.Box(new Rect (Screen.width/2-100, Screen.height/2-25, 200, 50), "Internet...", centeredStyle);

        if (GUI.Button(new Rect (Screen.width-300, Screen.height-100, 200, 50), "Offline")) {
            OfflineMode = true;
            StartCoroutine(Connect ());
        }
    }
}
*/

	IEnumerator Connect() {
		yield return StartCoroutine(CheckForInternetConnection());
 
#if !LITE_VERSION
        Debug.Log ("Connect...");
		PhotonNetwork.offlineMode = OfflineMode;
		// Connect to the main photon server. This is the only IP and port we ever need to set(!)
		if (!PhotonNetwork.connected)
			PhotonNetwork.ConnectUsingSettings("v0.1"); // version of the game/demo. used to separate older clients from newer ones (e.g. if incompatible)

		if (ChatManager.Instance != null && !OfflineMode) {
			yield return StartCoroutine(ChatManager.Instance.Connect());
		}
		/*
		if (RoomManager.Instance != null) {
			StartCoroutine(RoomManager.Instance.Connect());
		}
		*/
#endif
        UserAPI.Instance.Ready = true;
    }

    public IEnumerator CheckForInternetConnection()	{
		while (!InternetConnection && !OfflineMode) {
			InternetConnection = Application.internetReachability != NetworkReachability.NotReachable;//string.IsNullOrEmpty(www.error);
			if (InternetConnection) {
				if (OnInternetConnection != null) OnInternetConnection();
			}
			else {
				yield return new WaitForSeconds(3);
			}
		}
	}
#if !LITE_VERSION
	TourEventHandler _tourEventHandler;
#endif
}
