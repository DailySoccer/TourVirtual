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

    public GoodiesShopController GoodiesShopConntroller;

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
			}
		}
	}
	/*
	[SerializeField]
	private bool _musicEnabled;
	public bool MusicEnabled {
		get {return _musicEnabled;}
		set {
			_musicEnabled = value;
			//TODO: guardar valor en archivo de configuracion
			PlayerPrefs.SetString("MusicEnabled", value);
			PlayerPrefs.Save();
		}
	}
	 */
	[SerializeField]
	private bool _soundEnabled;
	public bool SoundEnabled {
		get {
			return _soundEnabled;
		}
		set {
			_soundEnabled = value;
			MusicTheme.enabled = value;
			//TODO: guardar valor en archivo de configuracion
			MyTools.SetPlayerPrefsBool("SoundEnabled", value);
			PlayerPrefs.Save();
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
            return InternetConnection || !UserAPI.Instance.Online;
#endif
        }

	}

	public void ChangeLanguage(string lang) {
        Authentication.AzureServices.MainLanguage = lang;
        var sublang = "es";
        try
        {
            sublang = lang.Split('-')[0];
        }
        catch { }

		SetNewLangManager (sublang, lang);
	}

	public void SetNewLangManager(string newSubLang, string newLang = "") {
	
		if (LanguageManager.Instance.IsLanguageSupported(newSubLang)) {
			LanguageManager.Instance.ChangeLanguage(newSubLang);
			CurrentLanguage = newSubLang;
			PlayerPrefs.SetString("CurrentLanguaje", newSubLang);				
			PlayerPrefs.Save();
			
		}
		else {
			Debug.LogWarning("El lenguaje seleccionado no está soportado aún: " + newLang + " / " + newSubLang);
		}
	}

	public AudioSource MusicTheme;

    public static bool IsDeepLinking = false;
    public static Dictionary<string, object> DeepLinkinParameters;

    public static string DeepLinkingURL;
    public void DeepLinking(string url) {
		try{
			url = WWW.UnEscapeURL(url);
	        DeepLinkingURL = url;
            var pair = url.Split('?');
            DeepLinkinParameters = new Dictionary<string, object>();
            if (pair.Length ==2 ){
                var pars = pair[1].Split('&');
                foreach (var p in pars) {
                    var par = p.Split('=');
                    if (par.Length == 2){
                        DeepLinkinParameters.Add(par[0], par[1]);
                    }
                }
            }
            IsDeepLinking = true;
        }
        catch{
			ModalTextOnly.ShowText( "ERROR1003: "+url );
		}
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
#if UNITY_WSA && !UNITY_EDITOR
        if (!string.IsNullOrEmpty(UnityEngine.WSA.Application.arguments))
            DeepLinking(UnityEngine.WSA.Application.arguments);
#endif
#endif

    }

   void Awake() {
        Application.targetFrameRate = 30;

        Instance = this;
        //StartCoroutine(MyTools.LoadSpriteFromURL("https://az726872.vo.msecnd.net/global-virtualgoods/8a0afa68-55e6-4c6a-ba08-a9c96934351b.png", null));
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
#endif
		SoundEnabled = MyTools.GetPlayerPrefsBool("SoundEnabled");
		CurrentLanguage = PlayerPrefs.GetString ("CurrentLanguage", "en");
		if (CurrentLanguage != string.Empty)
			SetNewLangManager(_currentLanguage);
		MusicTheme.enabled = false;
	}

    void Start() {
        if (Application.internetReachability == NetworkReachability.NotReachable) {
            ModalTextOnly.ShowText(LanguageManager.Instance.GetTextValue("TVB.Error.NoNet"), () => {
                Application.Quit();
            });
            return;
        }

        if (Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork)
        {
            ModalTextOnly.ShowText(LanguageManager.Instance.GetTextValue("TVB.Error.NoWiFi"), () => { Continue(); });
            return;
        }
        Continue();
    }

    void Continue() { 
        StartCoroutine( Authentication.Instance.Init() );

        GetDeepLinkingURL();
#if LITE_VERSION && UNITY_EDITOR
        DeepLinking("rmvt://editavatar?idUser=d1c9f805-054a-4420-a1af-30d37b75dff7&idVirtualGood=54dc043b-5bdb-4c45-9fd3-66f11d11db59");
#endif
#if LITE_VERSION && !UNITY_IOS
        if (!IsDeepLinking || DeepLinkingURL.ToLower().Contains("video")) {
            Application.OpenURL("http://www.astosch.com/project/real-madrid/");
            Application.Quit();
            return;
        }
#endif
        // Fix para el scroll threshold Galaxy 6.
        UnityEngine.EventSystems.EventSystem.current.pixelDragThreshold = (int)(0.5f * Screen.dpi / 2.54f);
        if (UserAPI.Instance != null /* && UserAPI.Instance.Online*/ )
        {
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
        if (!pauseStatus){
            GetDeepLinkingURL();
            // Ojo de no ir al vestidor si estoy en AVATAR o antes.
            if (IsDeepLinking && RoomManager.Instance != null)
                RoomManager.Instance.GotoRoom("VESTIDOR");
        }
    }
#if !LITE_VERSION
	void InitializeStore() {
		_tourEventHandler = new TourEventHandler();

		StoreEvents.OnSoomlaStoreInitialized += onSoomlaStoreInitialized;
		StoreEvents.OnCurrencyBalanceChanged += onCurrencyBalanceChanged;
		StoreEvents.OnUnexpectedStoreError += onUnexpectedStoreError;
        StoreEvents.OnMarketItemsRefreshFinished += OnMarketItemsRefreshFinished;
        StoreEvents.OnMarketPurchaseStarted += OnMarketPurchaseStarted;
        StoreEvents.OnMarketPurchaseCancelled += OnMarketPurchaseCancelled;
        StoreEvents.OnMarketPurchase += OnMarketPurchase;
        StoreEvents.OnItemPurchaseStarted += OnItemPurchaseStarted;
        StoreEvents.OnItemPurchased += OnItemPurchased;

        SoomlaStore.Initialize(new TourStoreAssets());
    }


    public void OnMarketPurchaseStarted(PurchasableVirtualItem pvi)
    {
        Debug.Log("OnMarketPurchaseStarted: " + pvi.ItemId);

    }
    public void OnMarketPurchase(PurchasableVirtualItem pvi, string payload, Dictionary<string,string> ret)
    {
        Debug.Log("OnMarketPurchase: " + pvi.ItemId);
        Debug.LogError(">>>> onMarketPurchase " + ret);
        foreach (var pair in ret)
            Debug.LogError(pair.Key + " " + pair.Value);
        LoadingCanvasManager.Hide();

    }
    public void OnMarketPurchaseCancelled(PurchasableVirtualItem pvi)
    {
        LoadingCanvasManager.Hide();
    }
    public void OnItemPurchaseStarted(PurchasableVirtualItem pvi)
    {
        Debug.Log("OnItemPurchaseStarted: " + pvi.ItemId);

    }

    public void OnItemPurchased(PurchasableVirtualItem pvi, string ret)
    {
        Debug.Log("OnItemPurchased: " + pvi.ItemId);

    }

    public void OnMarketItemsRefreshFinished(List<MarketItem> items)
    {
        GoodiesShopConntroller.ItemsRefresh(items);
    }

    public void onSoomlaStoreInitialized() {
 	}

	public void onCurrencyBalanceChanged(VirtualCurrency virtualCurrency, int balance, int amountAdded) {
	}
	
	public void onUnexpectedStoreError(int errorCode) {
		SoomlaUtils.LogError ("EventHandler", "error with code: " + errorCode);
	}
#endif
    void HandleOnUserLogin () {
        // Contro de mismo usuario.
#if !LITE_VERSION
		PhotonNetwork.playerName = UserAPI.Instance.Nick;
#endif
        StartCoroutine( Connect ());
	}
    /*
    float deltaTime = 0.0f;

    void Update()
    {
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
    }

    public void OnGUI()
    {
        int w = Screen.width, h = Screen.height;

        GUIStyle style = new GUIStyle();

        Rect rect = new Rect(2, 2, w, h * 2 / 100);
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = h * 4 / 100;
        style.normal.textColor = new Color(1f, 1f, 1f, 1.0f);
        float msec = deltaTime * 1000.0f;
        float fps = 1.0f / deltaTime;
        string text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
        GUI.Label(rect, text, style);
        rect.x = 0;
        rect.y = 0;
        style.normal.textColor = new Color(0f, 0f, 0.5f, 1.0f);
        GUI.Label(rect, text, style);
    }
    */
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

        if (RoomManager.Instance != null)
        {

//            _initialized = true;
//            if (startSound != null) startSound.Play();
            // Inicia la conexion con el servidor PUN.
            StartCoroutine( RoomManager.Instance.Connect() );
        }

    }

    public IEnumerator CheckForInternetConnection()	{
#if LITE_VERSION && UNITY_IOS
		yield return new WaitForSeconds(1);
		if (!IsDeepLinking || DeepLinkingURL.ToLower().Contains("video")) {
			Authentication.AzureServices.OpenURL("http://www.astosch.com/project/real-madrid/");
			Application.Quit();
			yield break;
		}
#endif


        int time = 0;
		while (!InternetConnection && !OfflineMode) {
			InternetConnection = Application.internetReachability != NetworkReachability.NotReachable;//string.IsNullOrEmpty(www.error);
			if (InternetConnection) {
				if (OnInternetConnection != null) OnInternetConnection();
			}
			else {
				yield return new WaitForSeconds(3);
                time++;
                if (time == 10) {
                    ModalTextOnly.ShowText(LanguageManager.Instance.GetTextValue("TVB.Error.NetError"));
                }

            }
		}
	}
#if !LITE_VERSION
	TourEventHandler _tourEventHandler;
#endif
}
