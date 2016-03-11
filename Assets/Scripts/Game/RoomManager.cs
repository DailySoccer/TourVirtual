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
	
	public RoomDefinition(string id, string sceneName, Dictionary<string, object> doors) {
		Id = id;
		SceneName = sceneName;
		Doors = doors;
	}
	
	static public RoomDefinition LoadFromJSON(Dictionary<string, object> jsonMap) {
		RoomDefinition roomDefinition = new RoomDefinition(
			jsonMap[KEY_ID] as string,
			jsonMap[KEY_SCENE] as string,
			jsonMap[KEY_DOORS] as Dictionary<string, object>
            );
		if (jsonMap.ContainsKey(KEY_NAME)) {
			roomDefinition.Name = jsonMap[KEY_NAME] as string;
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
        if (jsonMap.ContainsKey(KEY_PLAYER_VISIBLE)) {
			roomDefinition.PlayerVisible = System.Convert.ToBoolean(jsonMap[KEY_PLAYER_VISIBLE]);
		}
		return roomDefinition;
	}
	
	const string KEY_ID = "id";
	const string KEY_NAME = "name";
	const string KEY_SCENE = "scene";
	const string KEY_GUI = "gui";
	const string KEY_PLAYER_VISIBLE = "player_visible";
	const string KEY_MAX_PLAYERS = "max_players";
    const string KEY_HIDDEN_OBJECTS = "hidden_objects";
    const string KEY_DOORS = "doors";
	const string KEY_BUNDLES = "bundles";
	const string KEY_CONTENTS = "contents";
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

        // Prueba de HiddenObjects
        //HiddenObjects.HiddenObjects.Instance.Play();

        /*
		// Los gameObjects del escenario "inicial" permanecerán
		foreach(GameObject obj in GetRootObjects()) {
			DontDestroyOnLoad(obj);
		}
		*/
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
//                    PlayerManager.Instance.SelectedModel = AvatarDefinition;
                    if ( !string.IsNullOrEmpty(PlayerManager.Instance.SelectedModel) ) {
                        // Sin pasar por seleccion de avatar ya que tiene avatar

                        RoomDefinition rd = RoomDefinitions[roomKey] as RoomDefinition;
                        RoomStart = rd.Door(roomKey);
                        roomKey = GetRoomKey(RoomStart);
                        _doorToEnter = GetDoorKey(RoomStart);

                        StartCoroutine(PlayerManager.Instance.CreateAvatar(PlayerManager.Instance.SelectedModel, (instance) => {
                            Player thePlayer = Player.Instance;
                            instance.layer = LayerMask.NameToLayer("Player");
                            if (thePlayer != null) {
                                thePlayer.Avatar = instance;
                            }
                            if (MainManager.IsDeepLinking) {
                                MainManager.IsDeepLinking = false;
                                GotoRoom("VESTIDOR");
                            }
                            else
                                ToRoom(RoomDefinitions[roomKey] as RoomDefinition);
                        }));
                    }
                    else {
                        _doorToEnter = GetDoorKey(RoomStart);
                        ToRoom(RoomDefinitions[roomKey] as RoomDefinition);
                    }
                }
            }
		}
		yield return null;
	}
		
	public void GotoPreviousRoom() {
		if (IdLastDoorOfVisitedRoom != string.Empty)
			GotoRoomAtDoor (IdLastVisitedRoom + "#" + IdLastDoorOfVisitedRoom);
		else
			ToRoom (RoomDefinitions[IdLastVisitedRoom] as RoomDefinition);
	}

	public void GotoRoomAtDoor(string roomGoto) {
		IdLastVisitedRoom = RoomManager.Instance.Room.Id;
		IdLastDoorOfVisitedRoom = GetEntranceDoor();

		string roomKey = GetRoomKey(roomGoto);

		if (RoomDefinitions.ContainsKey(roomKey)) {
			_doorToEnter = GetDoorKey (roomGoto);
			ToRoom(RoomDefinitions[roomKey] as RoomDefinition);
		}
	}

	public void GotoRoom(string roomKey) {
        Debug.LogError(">>>> GotoRoom " + roomKey);
        if (RoomManager.Instance.Room != null) {
            IdLastVisitedRoom = RoomManager.Instance.Room.Id;
        }
        IdLastDoorOfVisitedRoom = "";

		if (RoomDefinitions.ContainsKey(roomKey)) {
			ToRoom (RoomDefinitions[roomKey] as RoomDefinition);
		}

	}

	public void ToRoom(string exitKey) {
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
#if !LITE_VERSION
		if (PhotonNetwork.connectedAndReady) {
			if (PhotonNetwork.room == null) {
                // Abre la primera pantalla.
                JoinToRoom(Room.Id + "#" + PhotonNetwork.playerName);
            }
            else {
                // Sale de la habitacion actual.
                PhotonNetwork.LeaveRoom();
			}
		}
#endif       
		if (OnSceneChange != null) OnSceneChange();
		
		if (Room.SceneName != Application.loadedLevelName) {
			if (DLCManager.Instance != null) {
				DLCManager.Instance.ClearResources();
                if (!string.IsNullOrEmpty(Room.BundleId)) {
					yield return StartCoroutine(DLCManager.Instance.LoadResource(Room.BundleId));
				}
            }
            Application.LoadLevel(Room.SceneName);
		}
		else {
			Debug.Log("Scene loaded... " + Room.SceneName);
		}
        yield return StartCoroutine(EnterPlayer(roomOld, player));
		StartCoroutine(CanvasRootController.Instance.FadeIn(1));

		_loadingRoom = false;
	}

	void Update () {
        UpdatePointOfInterest();
	}

	private void UpdatePointOfInterest() {
#if !LITE_VERSION
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
#endif
	}
	
	private System.Collections.IEnumerator EnterPlayer(RoomDefinition roomOld, Player player) {
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
			if (portal != null) {
				Debug.Log ("Portal: Default");
			}
		}
		
		if (portal != null) {
			Transform entrada = portal.transform.FindChild("Point");
			if (entrada != null) {
				if (player != null) {
					player.Avatar.transform.position = entrada.position;
					player.Avatar.transform.rotation = entrada.rotation;
				}

				Debug.Log ("Enter: " + Room.Id + " Door: " + portal.PortalID);
			}
			else {
				Debug.LogWarning ("Portal sin Point: " + portal.PortalID);
				portal = null;
			}
		}

		if (portal == null) {
			Debug.Log ("Enter: " + Room.Id + " Door: Default");
			if (player != null) {
				// Colocar al player en un lugar de la escena
				player.Avatar.transform.position = Vector3.zero;
				player.Avatar.transform.rotation = Quaternion.identity;
			}
		}
#if !LITE_VERSION
		// Esperamos que el player entre en la nueva Room
		while (!PhotonNetwork.offlineMode && (PhotonNetwork.room == null || !PhotonNetwork.room.name.Contains(Room.Id))) {
			yield return null;
		}

		Debug.Log ("EnterPlayer: " + PhotonNetwork.player.name);
#endif
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
        PhotonNetwork.JoinOrCreateRoom(roomid, new RoomOptions() { maxPlayers = Room.MaxPlayers }, TypedLobby.Default);
	}

	public override void OnConnectedToMaster() {
		//JoinToRoom();
	}

	public override void OnConnectedToPhoton() {
	}

	public override void OnCreatedRoom() {
    }

	public override void OnJoinedRoom() {
        if (OnChange != null) OnChange();
		if (OnRoomChange != null) OnRoomChange();
		if (OnJoinRoomAction != null) OnJoinRoomAction();
		if (OnPlayerListChange != null) OnPlayerListChange();
	}

	public override void OnLeftRoom() {
		if (OnLeftRoomAction != null) OnLeftRoomAction();
	}

    bool bJustOneTime = false;
	public override void OnJoinedLobby() {
        bJustOneTime = false;
    }

    public override void OnReceivedRoomListUpdate() {
        if (bJustOneTime) return;
        bJustOneTime = true;
        if (Room != null) JoinToRoom(GetRoomIdById(Room.Id));
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
		if (OnChange != null) OnChange();
		if (OnPlayerListChange != null) OnPlayerListChange();
	}

	public override void OnPhotonPlayerDisconnected(PhotonPlayer otherPlayer) {
		if (OnChange != null) OnChange();
		if (OnPlayerListChange != null) OnPlayerListChange();
	}

	public override void OnPhotonCreateRoomFailed(object[] codeAndMsg) {
        //		Debug.LogWarning("OnPhotonCreateRoomFailed");
    }

    public override void OnPhotonJoinRoomFailed(object[] codeAndMsg) {
        //		Debug.LogWarning("OnPhotonJoinRoomFailed");
        // Si hay un error de conexion a la sala, se crea una nueva.
        GetRoomIdById(Room.Id, true);

    }
	
	public override void OnFailedToConnectToPhoton(DisconnectCause cause) {
        //		Debug.LogWarning("OnFailedToConnectToPhoton");
	}
	
	public override void OnDisconnectedFromPhoton() {
        //        Debug.LogWarning("OnDisconnectedFromPhoton");
    }

    public override void OnConnectionFail(DisconnectCause cause) {
        //		Debug.LogWarning("OnConnectionFail");
    }

    public override void OnPhotonMaxCccuReached() {
        //		Debug.LogWarning("OnPhotonMaxCccuReached");
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
		Dictionary<string,object> jsonMap = BestHTTP.JSON.Json.Decode(Sitemap.text) as Dictionary<string, object>;
		List<object> rooms = jsonMap[KEY_ROOMS] as List<object>;
		foreach (object room in rooms) {
			RoomDefinition roomDefinition = RoomDefinition.LoadFromJSON(room as Dictionary<string, object>);
			RoomDefinitions.Add (roomDefinition.Id, roomDefinition);
		}
	}
	
	private RoomDefinition FindRoomBySceneName(string sceneName) {
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
	
	const string TAG_DEFAULT = "Default";
	const string TAG_PLAYER = "Player";
	const string KEY_ROOMS = "rooms";
}
