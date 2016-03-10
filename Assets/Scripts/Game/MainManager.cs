using UnityEngine;
using System.Collections;
using SmartLocalization;
using Soomla;
using Soomla.Store;

public enum TourVirtualBuildMode {
	Debug,
	Release
}

// Application.OpenURL("rmapp://");


public class MainManager : Photon.PunBehaviour {

	static public MainManager Instance {
		get {
			GameObject mainManagerObj = GameObject.FindGameObjectWithTag("MainManager");
			return mainManagerObj != null ? mainManagerObj.GetComponent<MainManager>() : null;
		}
	}

	public delegate void ChangeEvent();
	public event ChangeEvent OnLanguageChange;
	public event ChangeEvent OnInternetConnection;

	public delegate void MessagesUnreadedEvent(int counter);
	public event MessagesUnreadedEvent OnMessagesUnreadedEvent;

	public string PlayerName;

	public bool InternetConnection = false;

	public GameObject GameInput;

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
			return OfflineMode || (InternetConnection && PhotonNetwork.connectedAndReady);
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

    public static bool IsDeepLinking = false;

    string DeepLinkingURL;
    public void DeepLinking(string url){
        DeepLinkingURL = url;
        Debug.LogError(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> DeepLinking !!!! ["+ url + "]");
        if(!string.IsNullOrEmpty(url))
            IsDeepLinking = true;
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
		OfflineMode = Application.internetReachability == NetworkReachability.NotReachable;

		Screen.sleepTimeout = SleepTimeout.NeverSleep;
		Screen.autorotateToPortrait = Screen.autorotateToPortraitUpsideDown = false;
		Screen.autorotateToLandscapeLeft = Screen.autorotateToLandscapeRight = true;
		Screen.orientation = ScreenOrientation.AutoRotation;

		PhotonNetwork.logLevel = PhotonLogLevel.ErrorsOnly;
		PhotonNetwork.autoJoinLobby = true;
		PhotonNetwork.offlineMode = OfflineMode;
		// PhotonNetwork.autoCleanUpPlayerObjects = true;

		// Load name from PlayerPrefs
		PhotonNetwork.playerName = string.IsNullOrEmpty(PlayerName) ? PlayerPrefs.GetString("playerName", "Guest" + Random.Range(1, 9999)) : PlayerName;
		Debug.Log("PlayerName: " + PhotonNetwork.playerName);
		// Cargamos las Setting Options
		MusicEnabled = true; // TODO: Cargar desde archivo de configuracion
		SoundEnabled = true; // TODO: Cargar desde archivo de configuracion
		CurrentLanguage = LanguageManagerInstance.CurrentlyLoadedCulture.languageCode; // TODO: Cargar desde archivo de configuracion
	}

	void Start() {
        GetDeepLinkingURL();
        if (UserAPI.Instance != null /* && UserAPI.Instance.Online*/ ) {
            UserAPI.Instance.OnUserLogin += HandleOnUserLogin;
            StartCoroutine(CheckForInternetConnection());
		}
//		else StartCoroutine(Connect ());
#if UNITY_ANDROID || UNITY_IOS
                InitializeStore();
#endif

    }

    void OnApplicationPause(bool pauseStatus) {
        if (!pauseStatus) {
            GetDeepLinkingURL();
            // Ojo de no ir al vestidor si estoy en AVATAR o antes.
            if (IsDeepLinking)
                RoomManager.Instance.GotoRoom("VESTIDOR");
        }
        // Ver como evitar este tema.
        //		Application.Quit();
    }

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
	
	void HandleOnUserLogin () {
		PhotonNetwork.playerName = UserAPI.Instance.Nick;
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
        /*
		if (DLCManager.Instance != null) {
            // Descargar el fichero de versiones.
            yield return StartCoroutine(DLCManager.Instance.LoadVersion());
			yield return StartCoroutine(DLCManager.Instance.CacheResources());            
            
        }
        */
        if (PlayerManager.Instance != null)
        {
            yield return StartCoroutine(PlayerManager.Instance.CacheClothes());
        }

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

	TourEventHandler _tourEventHandler;
}
