//#define TRAZAS

using UnityEngine;
using System.Collections.Generic;
using Photon;

public class RoomDefinition {
	public const string GUI_AVATAR = "AVATAR";
	public const string GUI_GAME = "GAME";
    public const string GUI_MINIGAMES = "MINIGAMES";

    public string Id;
	public string SceneName;
	public string Gui;
	public bool PlayerVisible = true;
    public string GamaAction="";
    public byte MaxPlayers = 16;
    public bool HiddenObjects = false;
    public Dictionary<string, object> Doors;
	public Dictionary<string, object> Bundles;
	public Dictionary<string, object> Contents;

	public string _name;
	public string Name {
		get {
			return _name;
		}
		set {
			_name = value;
		}
	}

	public string _pack;
	public string Pack {
		get {
			return _pack;
		}
		set {
			_pack = value;
		}
	}

	public string BundleId {
		get {
			return ExistsBundle("SCENE") ? Bundle ("SCENE") : "";
		}
	}

	public string Door(string key) {
		return Doors[key] as string;
	}

	public string Bundle(string key) {
		return Bundles[key] as string;
	}

	public string Content(string key) {
		return Contents[key] as string;
	}
	
	public bool ExistsBundle(string key) {
        if (Bundles == null) return false;
		return Bundles.ContainsKey(key);
	}

	public bool ExistsDoor(string exitKey) {
		return Doors.ContainsKey(exitKey);
	}

	public string FindDoorTo(string roomId) {
		string door = null;
		foreach(string key in Doors.Keys) {
			if (Doors[key].Equals(roomId)) {
				door = key;
				break;
			}
		}
		return door;
    }
	
	public RoomDefinition(string id, string name, string sceneName, Dictionary<string, object> doors) {
		Id = id;
        Name = name;
		SceneName = sceneName;
		Doors = doors;
	}
	
	static public RoomDefinition LoadFromJSON(Dictionary<string, object> jsonMap) {
		RoomDefinition roomDefinition = new RoomDefinition(
            jsonMap[KEY_ID] as string,
            jsonMap[KEY_NAME] as string,
            jsonMap[KEY_SCENE] as string,
			jsonMap[KEY_DOORS] as Dictionary<string, object>
            );

		if (jsonMap.ContainsKey(KEY_PACK)) {
			roomDefinition.Pack = jsonMap[KEY_PACK] as string;
		}
		if (jsonMap.ContainsKey(KEY_CONTENTS)) {
			roomDefinition.Contents = jsonMap[KEY_CONTENTS] as Dictionary<string, object>;
		}
		if (jsonMap.ContainsKey(KEY_BUNDLES)) {
			roomDefinition.Bundles = jsonMap[KEY_BUNDLES] as Dictionary<string, object>;
		}
		if (jsonMap.ContainsKey(KEY_GUI)) {
			roomDefinition.Gui = jsonMap[KEY_GUI] as string;
		}
        if (jsonMap.ContainsKey(KEY_MAX_PLAYERS)) {
            roomDefinition.MaxPlayers = System.Convert.ToByte(jsonMap[KEY_MAX_PLAYERS]);
        }
        if (jsonMap.ContainsKey(KEY_HIDDEN_OBJECTS))
        {
            roomDefinition.HiddenObjects = System.Convert.ToBoolean(jsonMap[KEY_HIDDEN_OBJECTS]);
        }
        if (jsonMap.ContainsKey(KEY_PLAYER_VISIBLE))
        {
            roomDefinition.PlayerVisible = System.Convert.ToBoolean(jsonMap[KEY_PLAYER_VISIBLE]);
        }
        if (jsonMap.ContainsKey(KEY_GAMA_ACTION))
        {
            roomDefinition.GamaAction = (string)jsonMap[KEY_GAMA_ACTION];
        }
        return roomDefinition;
	}
	
	const string KEY_ID = "id";
	const string KEY_NAME = "name";
	const string KEY_SCENE = "scene";
	const string KEY_GUI = "gui";
	const string KEY_PLAYER_VISIBLE = "player_visible";
    const string KEY_GAMA_ACTION = "gamaction";
    const string KEY_MAX_PLAYERS = "max_players";
    const string KEY_HIDDEN_OBJECTS = "hidden_objects";
    const string KEY_DOORS = "doors";
	const string KEY_BUNDLES = "bundles";
	const string KEY_CONTENTS = "contents";
	const string KEY_PACK = "pack";
}

public class RoomManager : Photon.PunBehaviour {
    public delegate void ChangeEvent();
	public event ChangeEvent OnChange;
	public event ChangeEvent OnSceneChange;
	public event ChangeEvent OnSceneReady;
	public event ChangeEvent OnRoomChange;
	public event ChangeEvent OnPlayerListChange;
	public event ChangeEvent OnPointOfInterestChange;

	public delegate void ActionEvent();
	public event ActionEvent OnJoinRoomAction;
	public event ActionEvent OnLeftRoomAction;

	public RoomDefinition Room;
	public TextAsset Sitemap;
	public string RoomStart;

	public Dictionary<string, object> RoomDefinitions = new Dictionary<string, object>();

	private Transform _pointOfInterest;
	public Transform PointOfInterest {
		get {
			return _pointOfInterest;
		}

		set {
			if (_pointOfInterest != value) {
				_pointOfInterest = value;
				if (OnPointOfInterestChange != null) OnPointOfInterestChange();
			}
		}
	}

	private string IdLastVisitedRoom;
	private string IdLastDoorOfVisitedRoom;

    static RoomManager _instance;
    static public RoomManager Instance {
    get {
            if (_instance == null){
                GameObject roomManagerObj = GameObject.FindGameObjectWithTag("RoomManager");
    _instance = roomManagerObj != null ? roomManagerObj.GetComponent<RoomManager>() : null;
            }
            return _instance;
        }
	}


	void Start () {
		LoadRooms();
    }

    public System.Collections.IEnumerator Connect() {
        RoomDefinition roomLoaded = FindRoomBySceneName(Application.loadedLevelName);
		if (roomLoaded != null) {
            // Shortcut 
            ToRoom (roomLoaded);
		}
		else {
            if ( !string.IsNullOrEmpty(RoomStart) ) {
                string roomKey = GetRoomKey(RoomStart);
                if (RoomDefinitions.ContainsKey(roomKey)) {
                    if(!Authentication.AzureServices.IsDeepLinking && MainManager.VestidorMode != VestidorCanvasController_Lite.VestidorState.SELECT_AVATAR)
                        MainManager.VestidorMode = VestidorCanvasController_Lite.VestidorState.LANDING_PAGE;
                    _doorToEnter = GetDoorKey(RoomStart);
                    ToRoom(RoomDefinitions[roomKey] as RoomDefinition);
                }
            }
		}
		yield return null;
	}
		
	public void GotoPreviousRoom() {

		if (!string.IsNullOrEmpty(IdLastDoorOfVisitedRoom))
			GotoRoomAtDoor (IdLastVisitedRoom + "#" + IdLastDoorOfVisitedRoom);
		else
            if (!string.IsNullOrEmpty(IdLastVisitedRoom))
                ToRoom (RoomDefinitions[IdLastVisitedRoom] as RoomDefinition);
            else
            {
                string roomKey = GetRoomKey(RoomStart);

                RoomDefinition rd = RoomDefinitions[roomKey] as RoomDefinition;
                RoomStart = rd.Door(roomKey);
                roomKey = GetRoomKey(RoomStart);
                _doorToEnter = GetDoorKey(RoomStart);
                ToRoom(RoomDefinitions[roomKey] as RoomDefinition);
            }
	}

	public void GotoRoomAtDoor(string roomGoto) {
        if (RoomManager.Instance.Room != null)
        {
            IdLastVisitedRoom = RoomManager.Instance.Room.Id;
            IdLastDoorOfVisitedRoom = GetEntranceDoor();
        }

		string roomKey = GetRoomKey(roomGoto);

		if (RoomDefinitions.ContainsKey(roomKey)) {
			_doorToEnter = GetDoorKey (roomGoto);
			ToRoom(RoomDefinitions[roomKey] as RoomDefinition);
		}
	}

	public void GotoRoom(string roomKey) {
        if (RoomManager.Instance.Room != null) {
            IdLastVisitedRoom = RoomManager.Instance.Room.Id;
        }
        IdLastDoorOfVisitedRoom = "";

		if (RoomDefinitions.ContainsKey(roomKey)) {
			ToRoom (RoomDefinitions[roomKey] as RoomDefinition);
		}

	}

	public void ToRoom(string exitKey) {
        IdLastVisitedRoom = RoomManager.Instance.Room.Id;
        IdLastDoorOfVisitedRoom = GetEntranceDoor();

        if (Room.ExistsDoor(exitKey)) {
			// La información de la room en la que se entra puede venir en 2 formatos:
			// 1. <id room>
			// 2. <id room>#<door>
			string enterKey = Room.Door(exitKey);

			string roomKey = GetRoomKey (enterKey);
			_doorToEnter = GetDoorKey (enterKey);

			ToRoom (RoomDefinitions[roomKey] as RoomDefinition);
		}
	}

	string GetRoomKey(string enterKey) {
		return enterKey.Contains("#") ? enterKey.Split('#')[0] : enterKey;
	}

	string GetDoorKey(string enterKey) {
		return enterKey.Contains("#") ? enterKey.Split('#')[1] : null;
	}

	public void ToRoom(RoomDefinition roomDefinition) {
        if (!_loadingRoom) StartCoroutine(LoadRoom(roomDefinition));
	}

    System.Collections.IEnumerator LoadRoom(RoomDefinition roomDefinition) {
        _loadingRoom = true;

		RoomDefinition roomOld = Room;
		Room = roomDefinition;

		yield return StartCoroutine(CanvasRootController.Instance.FadeOut(2));
		
		Player player = Player.Instance;
		if (player != null) {
			player.gameObject.SetActive(false);
		}

		if (OnSceneChange != null) OnSceneChange();
		if (Room.SceneName != Application.loadedLevelName) {
            Resources.UnloadUnusedAssets();
            if (DLCManager.Instance != null) {
                //DLCManager.Instance.ClearResources();
#if TRAZAS
                if (Application.CanStreamedLevelBeLoaded(Room.SceneName))
                    Debug.LogError(">>>> Escena precacheada " + Room.SceneName);
#endif
                if (!string.IsNullOrEmpty(Room.BundleId) && !Application.CanStreamedLevelBeLoaded(Room.SceneName) ) {
					yield return StartCoroutine(DLCManager.Instance.LoadResource(Room.BundleId));
				}
            }
            //Application.LoadLevel(Room.SceneName);
            UnityEngine.AsyncOperation ao = Application.LoadLevelAsync(Room.SceneName);
            while (!ao.isDone) yield return null;
            Resources.UnloadUnusedAssets();
        }
        _loadingRoom = false;

		bJustOneTime = false;
		if (PhotonNetwork.connectedAndReady &&  PhotonNetwork.room != null) 
			PhotonNetwork.LeaveRoom();
		else{
			// Esto es solo para la primera conexion.
			bJustOneTime = true;
            JoinToRoom(GetRoomIdById(Room.Id));
		}

        if ( !string.IsNullOrEmpty(Room.GamaAction)){
			Authentication.AzureServices.SendAction("VIRTUALTOUR_ACC_SALA_00",null,(err)=>{ Debug.LogError("ERROr1: "+err);});
			Authentication.AzureServices.SendAction(Room.GamaAction,null,(err)=>{Debug.LogError("ERROr2: "+err);});
        }

		while(!_bJoinedRoom ){ yield return null; }

        yield return StartCoroutine( EnterPlayer(Room, roomOld, player) );
        MyTools.FixLights("Model3D"); // Quita mascara a las luces
        StartCoroutine(CanvasRootController.Instance.FadeIn(1));

		/*
		if (roomDefinition.Id == "ESTADIO")
			InitialTutorial.Instance.SartTutorial();

		if (roomDefinition.Id == "VESTIDORLITE")
			AudioInGameController.Instance.PlayDefinition (SoundDefinitions.VESTIDOR_THEME, true, true);
		else
			AudioInGameController.Instance.PlayDefinition (SoundDefinitions.MAIN_THEME, true, true);

		if (roomDefinition.Id == "MINIBASKET" || roomDefinition.Id == "MINIFOOTBALL" )
			AudioInGameController.Instance.PlayDefinition (SoundDefinitions.MINIGAME_THEME, true, true);
		*/

		switch (roomDefinition.Id) {
		case "ESTADIO":
			if (PlayerPrefs.GetInt ("tutorial_done") == 0)
				InitialTutorial.Instance.SartTutorial();

			if (!HiddenObjects.HiddenObjects.Instance.enabled)
				AudioInGameController.Instance.PlayDefinition (SoundDefinitions.MAIN_THEME, true);
			else
				AudioInGameController.Instance.PlayDefinition (SoundDefinitions.MINIGAME_THEME, true);

			break;

		case "VESTIDORLITE":
			AudioInGameController.Instance.PlayDefinition (SoundDefinitions.VESTIDOR_THEME, true);
			break;

		case "MINIBASKET":
		case "MINIFOOTBALL":
			AudioInGameController.Instance.PlayDefinition (SoundDefinitions.MINIGAME_THEME, true);
			break;
		
		default:
			if (!HiddenObjects.HiddenObjects.Instance.enabled)
				AudioInGameController.Instance.PlayDefinition (SoundDefinitions.MAIN_THEME, true);
			else
				AudioInGameController.Instance.PlayDefinition (SoundDefinitions.MINIGAME_THEME, true);

			break;		
		}

	}

	void Update () {
        UpdatePointOfInterest();
	}

	private void UpdatePointOfInterest() {
		Transform pointOfInterest = null;
		if (ContentManager.Instance.ContentNear != null) {
			pointOfInterest = ContentManager.Instance.ContentNear.PointOfInterest;
		}
		else if (ContentCubeMap.ContentSelected != null) {
			pointOfInterest = ContentCubeMap.ContentSelected.PointOfInterest;
		}
		else if (ContentModels.ContentSelected != null) {
			pointOfInterest = ContentModels.ContentSelected.PointOfInterest;
		}
		else if (ContentVideo.ContentSelected != null) {
			pointOfInterest = ContentVideo.ContentSelected.PointOfInterest;
		}
		else if (ContentInfo.ContentSelected != null) {
			pointOfInterest = ContentInfo.ContentSelected.PointOfInterest;
		}

		PointOfInterest = pointOfInterest;
	}
    public static Transform entrada;

    private System.Collections.IEnumerator EnterPlayer(RoomDefinition roomNew, RoomDefinition roomOld, Player player) {
		Portal portal = null;
        // Esperamos a que se haya inicializado correctamente la escena recien cargada
        // para que podamos encontrar los "portales" (Portal.FindInScene)
        yield return null;

        // Nos han proporcionado la puerta por la que entrar?
        if (!string.IsNullOrEmpty(_doorToEnter)) {
			portal = Portal.FindInScene(_doorToEnter);
		}
		// Venimos de otra habitación?
		else if (roomOld != null) {
			// Encontrar la puerta que conecta con la otra habitación
			portal = Portal.FindInScene(Room.FindDoorTo(roomOld.Id));
		}
		if (portal == null) {
			portal = Portal.First();
#if TRAZAS
			if (portal != null) {
				Debug.Log ("Portal: Default OLD "+ (roomOld != null ? roomOld.Id : "NoOLD") + " NEW "+ (roomNew!=null?roomNew.Id:"NoNEW"));
			}
#endif
		}
        if (portal != null) {
			entrada = portal.transform.FindChild("Point");
			if (entrada != null) {
				if (player != null && player.Avatar!=null) {
                    player.Avatar.transform.position = RoomManager.entrada.position;
                    player.Avatar.transform.rotation = RoomManager.entrada.rotation;
                }

            }            
            else {
				portal = null;
			}
		}
        if (portal == null) {
            if (player != null && player.Avatar != null) {
                // Colocar al player en un lugar de la escena
                player.Avatar.transform.position = Vector3.zero;
                player.Avatar.transform.rotation = Quaternion.identity;
            }
        }
        // Esperamos que el player entre en la nueva Room
        float timeout = Time.realtimeSinceStartup + 2;
		while (!PhotonNetwork.offlineMode && (PhotonNetwork.room == null || !PhotonNetwork.room.name.Contains(Room.Id)) && Time.realtimeSinceStartup<timeout ) {
            yield return null;
		}
        if (player != null) {
            // Hacerlo visible o no...
            player.gameObject.SetActive(Room.PlayerVisible);
		}
        yield return null;
        if (OnChange != null) OnChange();
        if (OnSceneReady != null) OnSceneReady();
    }

	private Portal FindPortalInScene(string portalId) {
		Portal ret = null;
		if (portalId != null) {
			GameObject[] portalesObj = GameObject.FindGameObjectsWithTag("Portal");
			foreach(GameObject portalObj in portalesObj) {
				Portal portal = portalObj.GetComponent<Portal>();
				if (portal.PortalID.Equals(portalId)) {
					ret = portal;
					break;
				}
			}
		}
		return ret;
	}

	private Portal GetPortalFirst() {
		GameObject[] portalesObj = GameObject.FindGameObjectsWithTag("Portal");
		return portalesObj.Length > 0 ? portalesObj[0].GetComponent<Portal>() : null;
	}

	private void JoinToRoom(string roomid ) {
		_bJoinedRoom = false;
#if TRAZAS
        Debug.LogError( ">>> JoinToRoom "+roomid );
#endif
        if (Room.MaxPlayers>1) PhotonNetwork.JoinOrCreateRoom(roomid, new RoomOptions() { maxPlayers = Room.MaxPlayers }, TypedLobby.Default);
		else _bJoinedRoom = true;
	}

	public override void OnConnectedToMaster() {
#if TRAZAS
        Debug.LogError(">>> OnConnectedToMaster");
#endif
        //JoinToRoom();
    }

    public override void OnConnectedToPhoton() {
#if TRAZAS
        Debug.LogError(">>> OnConnectedToPhoton");
#endif
    }

    public override void OnCreatedRoom() {
#if TRAZAS
        Debug.LogError(">>> OnCreatedRoom");
#endif
    }

    public override void OnJoinedRoom() {
		_bJoinedRoom=true;
#if TRAZAS
        Debug.LogError(">>> OnJoinedRoom");
#endif
        if (OnChange != null) OnChange();
		if (OnRoomChange != null) OnRoomChange();
		if (OnJoinRoomAction != null) OnJoinRoomAction();
		if (OnPlayerListChange != null) OnPlayerListChange();
	}

	public override void OnLeftRoom() {
#if TRAZAS
        Debug.LogError(">>> OnLeftRoom");
#endif
        if (OnLeftRoomAction != null) OnLeftRoomAction();
	}

    bool bJustOneTime = false;
	public override void OnJoinedLobby() {
#if TRAZAS
        Debug.LogError(">>> OnJoinedLobby");
#endif
        bJustOneTime = false;
    }

    public override void OnReceivedRoomListUpdate() {
#if TRAZAS
        Debug.LogError(">>> OnReceivedRoomListUpdate _loadingRoom = "+_loadingRoom + " bJustOneTime " +bJustOneTime );
#endif
		if(!_loadingRoom){ // Si está cargando, pospone la conexion con la sala.
        	if (bJustOneTime) return;
        	bJustOneTime = true;
        	if (Room != null) JoinToRoom( GetRoomIdById(Room.Id) );
		}
    }

    string GetRoomIdById(string id, bool forceNew=false) {
        var rooms = PhotonNetwork.GetRoomList();
        if (!forceNew) {
            foreach (var room in rooms) {
                if (room.name.Contains(id)) // Encuentro una sala para esta ID con sitio, pues entro!
                    if (room.playerCount < room.maxPlayers - 2)
                        return room.name;
            }
        }
        // Si no hay sala o no hay hueco... Creo un id nuevo
        do {
            string newid = id + "#" + Random.Range(0, int.MaxValue);
            foreach (var room in rooms) // Compruebo que la mala suerte saque un id igual.
                if (room.name == newid)
                    continue;
            return newid;
        } while (true);
    }

    public override void OnPhotonPlayerConnected(PhotonPlayer newPlayer) {
#if TRAZAS
        Debug.LogError(">>> OnPhotonPlayerConnected");
#endif
        if (OnChange != null) OnChange();
		if (OnPlayerListChange != null) OnPlayerListChange();
	}

	public override void OnPhotonPlayerDisconnected(PhotonPlayer otherPlayer) {
#if TRAZAS
        Debug.LogError(">>> OnPhotonPlayerDisconnected");
#endif
        if (OnChange != null) OnChange();
		if (OnPlayerListChange != null) OnPlayerListChange();
	}

	public override void OnPhotonCreateRoomFailed(object[] codeAndMsg) {
#if TRAZAS
        Debug.LogWarning("OnPhotonCreateRoomFailed");
#endif
    }

    public override void OnPhotonJoinRoomFailed(object[] codeAndMsg) {
#if TRAZAS
        Debug.LogWarning("OnPhotonJoinRoomFailed");
#endif
        // Si hay un error de conexion a la sala, se crea una nueva.
        GetRoomIdById(Room.Id, true);
    }
	
	public override void OnFailedToConnectToPhoton(DisconnectCause cause) {
#if TRAZAS
        Debug.LogError("OnFailedToConnectToPhoton");
#endif
    }

    public override void OnDisconnectedFromPhoton() {
        Debug.LogError("OnDisconnectedFromPhoton");
        if (!PhotonHandler.AppQuits) {
            if (!PhotonNetwork.connected)
                PhotonNetwork.ConnectUsingSettings("v0.1"); // version of the game/demo. used to separate older clients from newer ones (e.g. if incompatible)
        }
    }

    public override void OnConnectionFail(DisconnectCause cause) {
#if TRAZAS
        Debug.LogError("OnConnectionFail "+ cause);
#endif
    }

    public override void OnPhotonMaxCccuReached() {
#if TRAZAS
        Debug.LogError("OnPhotonMaxCccuReached");
#endif
    }

    private List<GameObject> GetRootObjects() {
		List<GameObject> rootObjects = new List<GameObject>();
		foreach (Transform xform in UnityEngine.Object.FindObjectsOfType<Transform>()) {
			if (xform.parent == null) {
				rootObjects.Add(xform.gameObject);
			}
		}
		return rootObjects;
	}
	
	private void LoadRooms() {
		Dictionary<string,object> jsonMap = MiniJSON.Json.Deserialize(Sitemap.text) as Dictionary<string, object>;
		List<object> rooms = jsonMap[KEY_ROOMS] as List<object>;
		foreach (object room in rooms) {
			RoomDefinition roomDefinition = RoomDefinition.LoadFromJSON(room as Dictionary<string, object>);
			RoomDefinitions.Add (roomDefinition.Id, roomDefinition);
		}
	}
	
	public RoomDefinition FindRoomBySceneName(string sceneName) {
		string roomId = null;
		foreach(RoomDefinition room in RoomDefinitions.Values) {
			if (room.SceneName == sceneName) {
				roomId = room.Id;
			}
		}
		return roomId != null ? RoomDefinitions[roomId] as RoomDefinition : null;
	}
	
	string _doorToEnter;
	public string GetEntranceDoor() {
		return _doorToEnter;
	}

	bool _loadingRoom = false;
	bool _bJoinedRoom=false;
	
	const string TAG_DEFAULT = "Default";
	const string TAG_PLAYER = "Player";
	const string KEY_ROOMS = "rooms";
}
