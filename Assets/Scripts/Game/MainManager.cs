//#define TEST_SHOP
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SmartLocalization;
using Soomla.Store;

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
			//TODO: Setear el AudioMaster a 0 (False) / 1 (True)
			AudioInGameController.Instance.SetMasterVolume(value ? 1f : 0f);
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
			return OfflineMode || (InternetConnection && PhotonNetwork.connectedAndReady);
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

        } else {
			Debug.LogWarning("El lenguaje seleccionado no está soportado aún: " + newLang + " / " + newSubLang);
		}

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

        PhotonNetwork.logLevel = PhotonLogLevel.ErrorsOnly;
		PhotonNetwork.autoJoinLobby = true;
		PhotonNetwork.offlineMode = OfflineMode;
		// PhotonNetwork.autoCleanUpPlayerObjects = true;

		// Load name from PlayerPrefs
		PhotonNetwork.playerName = string.IsNullOrEmpty(PlayerName) ? PlayerPrefs.GetString("playerName", "Guest" + Random.Range(1, 9999)) : PlayerName;

		SoundEnabled = MyTools.GetPlayerPrefsBool("SoundEnabled");
		CurrentLanguage = PlayerPrefs.GetString ("CurrentLanguage", "en");
		if (CurrentLanguage != string.Empty)
			SetNewLangManager(_currentLanguage);
	}

    void Start() {
#if PRE && TEST_SHOP
#if (UNITY_ANDROID || UNITY_IOS)
        LoadingCanvasManager.Show("TVB.Message.LoadingData");
        InitializeStore();
        LoadingCanvasManager.Hide();
#endif
#endif

        if (Application.internetReachability == NetworkReachability.NotReachable && UserAPI.Instance.Online) {
            ModalTextOnly.ShowText(LanguageManager.Instance.GetTextValue("TVB.Error.NoNet"), () => {
                Application.Quit();
            });
            return;
        }

        if (Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork) {
            ModalTextOnly.ShowText(LanguageManager.Instance.GetTextValue("TVB.Error.NoWiFi"), () => {
                StartCoroutine( Continue() );
            });
            return;
        }
        StartCoroutine( Continue() );
    }

    IEnumerator Continue() {

        yield return new WaitForEndOfFrame();
        if (DLCManager.Instance != null) {
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
        //        DeepLinking("rmvt://editavatar?idUser=iduser&idVirtualGood=1");
        // DeepLinking("rmvt://editavatar?idUser=d1c9f805-054a-4420-a1af-30d37b75dff7&idVirtualGood=e94d896c-8daa-42f3-9210-cbc80217d00e");
        Authentication.Instance.Init();
        Authentication.AzureServices.OnDeepLinking += OnDeepLinking;

        // Fix para el scroll threshold Galaxy 6.
        UnityEngine.EventSystems.EventSystem.current.pixelDragThreshold = (int)(0.5f * Screen.dpi / 2.54f);
        if (UserAPI.Instance != null /* && UserAPI.Instance.Online*/ )
        {
            UserAPI.Instance.OnUserLogin += HandleOnUserLogin;
            StartCoroutine(CheckForInternetConnection());
        }
        //		else StartCoroutine(Connect ());
#if !TEST_SHOP
#if (UNITY_ANDROID || UNITY_IOS)
        LoadingCanvasManager.Show("TVB.Message.LoadingData");
        InitializeStore();
        LoadingCanvasManager.Hide();
#endif
#endif
    }


    void OnApplicationFocus(bool focusStatus) {
        if (focusStatus && !Authentication.AzureServices.IsDeepLinking) {
            Authentication.AzureServices.CheckDeepLinking();

        }
    }

    public void OnDeepLinking() {
        if (UserAPI.Instance.CheckIsOtherUser()) { // DeepLinking me dice USUARIO DISTINTO.
            LoadingCanvasManager.Hide();
            Authentication.AzureServices.SignOut();
            ModalTextOnly.ShowText(LanguageManager.Instance.GetTextValue("TVB.Error.BadUserID"), () => {
                Authentication.AzureServices.SignIn();
                if (RoomManager.Instance != null) {
                    if(RoomManager.Instance.Room.Id!= "VESTIDORLITE") RoomManager.Instance.GotoRoom("VESTIDORLITE");
                    else FindObjectOfType<VestidorCanvasController_Lite>().ShowClothesShop();
                }
                
            });
        }else {
            if (RoomManager.Instance != null) {
                if (RoomManager.Instance.Room.Id != "VESTIDORLITE") RoomManager.Instance.GotoRoom("VESTIDORLITE");
                else FindObjectOfType<VestidorCanvasController_Lite>().ShowClothesShop();
            }
        }
    }

    void InitializeStore() {
		_tourEventHandler = new TourEventHandler();

		StoreEvents.OnSoomlaStoreInitialized += OnSoomlaStoreInitialized;
		StoreEvents.OnCurrencyBalanceChanged += OnCurrencyBalanceChanged;
        StoreEvents.OnGoodBalanceChanged += OnGoodBalanceChanged;

        StoreEvents.OnUnexpectedStoreError += OnUnexpectedStoreError;
        StoreEvents.OnMarketItemsRefreshFinished += OnMarketItemsRefreshFinished;
        StoreEvents.OnMarketPurchaseStarted += OnMarketPurchaseStarted;
        StoreEvents.OnMarketPurchaseCancelled += OnMarketPurchaseCancelled;
        StoreEvents.OnMarketPurchase += OnMarketPurchase;
        StoreEvents.OnItemPurchaseStarted += OnItemPurchaseStarted;
        StoreEvents.OnItemPurchased += OnItemPurchased;
        StoreEvents.OnRestoreTransactionsFinished += OnRestoreTransactionsFinished;
        SoomlaStore.Initialize(new TourStoreAssets());
#if UNITY_ANDROID && !UNITY_EDITOR
        SoomlaStore.StartIabServiceInBg();
#endif
        //       SoomlaStore.RestoreTransactions();
    }

    public void OnGoodBalanceChanged(VirtualGood good, int balance, int amountAdded) {
//        Debug.LogError(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> OnGoodBalanceChanged " + good + " "+ balance+" "+ amountAdded);
    }

    public void OnMarketPurchaseStarted(PurchasableVirtualItem pvi) {
//        Debug.Log("OnMarketPurchaseStarted: " + pvi.ItemId);
    }

    public void OnRestoreTransactionsFinished(bool success)
    {
//        Debug.Log("OnRestoreTransactionsFinished: " + success);
    }


    public void OnMarketPurchase(PurchasableVirtualItem pvi, string payload, Dictionary<string,string> extras) {

        string receipt = "";
#if UNITY_ANDROID
        string originalJson = "";
        string signature = "";
        extras.TryGetValue("signature", out signature);
        extras.TryGetValue("originalJson", out originalJson);
        originalJson = originalJson.Replace("\"", "\\\"");
        receipt = "{ \"RESPONSE_CODE\":0, \"INAPP_PURCHASE_DATA\": \"" + originalJson + "\",\"INAPP_DATA_SIGNATURE\": \"" + signature + "\"}";

#elif UNITY_IOS
        // Leer fichero, convertir a B64 y enviar.
        extras.TryGetValue("receiptBase64", out receipt);
#endif
        //        var tmp = BestHTTP.JSON.Json.Decode(originalJson) as Dictionary<string, object>;
        //        tmp.Add("developerPayload", payload);
        //        originalJson = BestHTTP.JSON.Json.Encode(tmp).Replace("\"", "\\\"");
        StoreInventory.TakeItem(pvi.ItemId, 1);
        PlayerPrefs.SetString("PurchasePendingId", pvi.ItemId);
        PlayerPrefs.SetString("PurchasePendingReceipt", receipt);
        CheckPurchasePending();
    }

    public void CheckPurchasePending()
    {
        if( PlayerPrefs.HasKey("PurchasePendingId") && PlayerPrefs.HasKey("PurchasePendingReceipt")){
            var ItemId = PlayerPrefs.GetString("PurchasePendingId");
            var Receipt = PlayerPrefs.GetString("PurchasePendingReceipt");

            Debug.LogError("Compra-> " + Receipt);
            LoadingCanvasManager.Show();
            Authentication.AzureServices.InAppPurchase(ItemId, Receipt, (res) => {
                LoadingCanvasManager.Hide();
                int value = int.Parse(ItemId.Substring(ItemId.IndexOf("coins_") + 6));
                UserAPI.Instance.Points += value;
                PlayerPrefs.DeleteKey("PurchasePendingId");
                PlayerPrefs.DeleteKey("PurchasePendingReceipt");
            }, (errorcode) => {
                LoadingCanvasManager.Hide();
                ModalTextOnly.ShowText(LanguageManager.Instance.GetTextValue("TVB.Error.Buying"),()=> { Application.Quit(); });
                // Errores no esperados por parte de la plataforma.
                /*
                if(errorcode == "412") {
                    PlayerPrefs.DeleteKey("PurchasePendingId");
                    PlayerPrefs.DeleteKey("PurchasePendingReceipt");
                }
                */
            });

        }
    }

    public void OnMarketPurchaseCancelled(PurchasableVirtualItem pvi) {
        ModalTextOnly.ShowText(LanguageManager.Instance.GetTextValue("TVB.Error.Buying"));
        LoadingCanvasManager.Hide();
    }

    public void OnItemPurchaseStarted(PurchasableVirtualItem pvi) {
//        Debug.LogError("OnItemPurchaseStarted: " + pvi.ItemId);

    }

    public void OnItemPurchased(PurchasableVirtualItem pvi, string ret) {
 //       Debug.LogError("OnItemPurchased: " + pvi.ItemId);

    }

    public void OnMarketItemsRefreshFinished(List<MarketItem> items) {
 //       Debug.LogError(">>>> OnMarketItemsRefreshFinished");
        GoodiesShopConntroller.ItemsRefresh(items);
    }

    public void OnSoomlaStoreInitialized() {
 //       Debug.LogError(">>>> OnSoomlaStoreInitialized");
#if PRE && TEST_SHOP
        Invoke("PurchaseTest", 2);
#endif
    }

    void PurchaseTest() {
        StoreInventory.BuyItem("100coins");
    }


    public void OnCurrencyBalanceChanged(VirtualCurrency virtualCurrency, int balance, int amountAdded) {
 //       Debug.LogError(">>>> OnCurrencyBalanceChanged virtualCurrency " + virtualCurrency.Name+ " balance " + balance+ " amountAdded " + amountAdded);
    }

    public void OnUnexpectedStoreError(int errorCode) {
 //       Debug.LogError(">>>> OnUnexpectedStoreError "+ errorCode);
        LoadingCanvasManager.Hide();
    }
    void HandleOnUserLogin () {
        // Mira si hay alguna compra pendiente.
        CheckPurchasePending();
        // Contro de mismo usuario.
        PhotonNetwork.playerName = UserAPI.Instance.Nick;
        StartCoroutine( Connect ());
	}

    IEnumerator Connect() {
        GameObject.Find("Main Camera").GetComponent<Camera>().clearFlags = CameraClearFlags.Skybox;
		yield return StartCoroutine(CheckForInternetConnection());
		PhotonNetwork.offlineMode = OfflineMode;
		// Connect to the main photon server. This is the only IP and port we ever need to set(!)
		if (!PhotonNetwork.connected)
			PhotonNetwork.ConnectUsingSettings("v0.1"); // version of the game/demo. used to separate older clients from newer ones (e.g. if incompatible)

		if (ChatManager.Instance != null && !OfflineMode) {
			yield return StartCoroutine(ChatManager.Instance.Connect());
		}
        UserAPI.Instance.Ready = true;
        if (RoomManager.Instance != null)
        {
            StartCoroutine( RoomManager.Instance.Connect() );
        }

    }

    public IEnumerator CheckForInternetConnection()	{
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
	TourEventHandler _tourEventHandler;
}