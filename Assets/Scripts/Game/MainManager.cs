using UnityEngine;
using System.Collections;
using SmartLocalization;
using Soomla;
using Soomla.Store;

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

	void Awake() {
		OfflineMode = Application.internetReachability == NetworkReachability.NotReachable;

		Screen.sleepTimeout = SleepTimeout.NeverSleep;
		Screen.autorotateToPortrait = Screen.autorotateToPortraitUpsideDown = false;
		Screen.autorotateToLandscapeLeft = Screen.autorotateToLandscapeRight = true;
		Screen.orientation = ScreenOrientation.AutoRotation;

//		PhotonNetwork.logLevel = PhotonLogLevel.Full;

//		PhotonNetwork.autoJoinLobby = true;

		PhotonNetwork.offlineMode = OfflineMode;
		// PhotonNetwork.autoCleanUpPlayerObjects = true;

		/*
		// Connect to the main photon server. This is the only IP and port we ever need to set(!)
		if (!PhotonNetwork.connected)
			PhotonNetwork.ConnectUsingSettings("v0.1"); // version of the game/demo. used to separate older clients from newer ones (e.g. if incompatible)
		*/

		// Load name from PlayerPrefs
		PhotonNetwork.playerName = string.IsNullOrEmpty(PlayerName) ? PlayerPrefs.GetString("playerName", "Guest" + Random.Range(1, 9999)) : PlayerName;
		Debug.Log("PlayerName: " + PhotonNetwork.playerName);

		// Cargamos las Setting Options
		MusicEnabled = true; // TODO: Cargar desde archivo de configuracion
		SoundEnabled = true; // TODO: Cargar desde archivo de configuracion
		CurrentLanguage = LanguageManagerInstance.CurrentlyLoadedCulture.languageCode; // TODO: Cargar desde archivo de configuracion
		Debug.Log ("Language: " + LanguageManagerInstance.CurrentlyLoadedCulture.languageCode);

		if (UserAPI.Instance != null) {
			UserAPI.Instance.OnUserLogin += HandleOnUserLogin;
		}
	}

	void Start() {
		if (UserAPI.Instance != null) {
			StartCoroutine(CheckForInternetConnection());
		}
		else {
			StartCoroutine(Connect ());
		}
#if UNITY_ANDROID || UNITY_IOS
        InitializeStore();
#endif

	}

	void OnApplicationPause(bool pauseStatus) {
		Application.Quit();
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
		Debug.Log ("UserName: " + UserAPI.Instance.UserName);

		// TODO: Temporalmente no obtendremos el nombre del usuario de Azure para no tener que obligar a registrarse en su servicio
		// PhotonNetwork.playerName = UserAPI.Instance.UserName;

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
		if (DLCManager.Instance != null) {
            // Descargar el fichero de versiones.
            yield return StartCoroutine(DLCManager.Instance.LoadVersion());
            Debug.Log(">>>>>>>>>>>>>>>>>>>>>>>>>>>>> a descargar los ficheros");

            Debug.Log ("CacheResources...");
			yield return StartCoroutine(DLCManager.Instance.CacheResources());
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
//			WWW www = new WWW("http://google.com");
//			yield return www;
			InternetConnection = Application.internetReachability != NetworkReachability.NotReachable;//string.IsNullOrEmpty(www.error);

			if (InternetConnection) {
				Debug.Log ("InternetConnection: OK");
				if (OnInternetConnection != null) OnInternetConnection();
			}
			else {
				yield return new WaitForSeconds(3);
			}
		}
	}

	TourEventHandler _tourEventHandler;
}
