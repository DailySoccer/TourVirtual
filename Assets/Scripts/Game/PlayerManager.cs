using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Photon;

public class PlayerManager : Photon.PunBehaviour {

	static public PlayerManager Instance {
		get {
			GameObject playerManagerObj = GameObject.FindGameObjectWithTag("PlayerManager");
			return playerManagerObj != null ? playerManagerObj.GetComponent<PlayerManager>() : null;
		}
	}

	public AvatarsLibraryPrefabs Library;
	public GameObject playerPrefab;
	public int SelectedModel = -1;

	void Start () {
	}

	void Update () {
	}

	public override void OnLeftRoom() {
	}

	public override void OnJoinedRoom() {
		// PhotonNetwork.Instantiate( "Player Character", Vector3.zero, Quaternion.identity, 0 );
		SpawnPlayer();
	}

	void SpawnPlayer() {
		int viewIdOld = _viewId;

		// Manually allocate PhotonViewID
		_viewId = PhotonNetwork.AllocateViewID();

		/*
		if (viewIdOld != -1 && _viewId != viewIdOld) {
			Debug.Log ("PhotonNetwork.UnAllocateViewID: " + viewIdOld);
			PhotonNetwork.UnAllocateViewID(viewIdOld);
		}
		*/

		Transform playerTransform;
		if (Player.Instance != null) {
			playerTransform = Player.Instance.Avatar.transform;
		}
		else {
			playerTransform = transform;
		}
		photonView.RPC("SpawnOnNetwork", PhotonTargets.AllBuffered, playerTransform.position, playerTransform.rotation, _viewId, PhotonNetwork.player, SelectedModel);
	}

	[PunRPC]
	void SpawnOnNetwork(Vector3 pos, Quaternion rot, int id, PhotonPlayer np, int selectedModel) {
		GameObject thePlayer = null;

		if (np.isLocal && Player.Instance != null) {
			Debug.Log("Instantiate Player");

			thePlayer = Player.Instance.Avatar ?? Player.Instance.gameObject;
			//thePlayer.transform.position = transform.position;
			//thePlayer.transform.rotation = transform.rotation;
			thePlayer.GetComponentsInChildren<Animator>(true)[0].applyRootMotion = true;
			thePlayer.layer = LayerMask.NameToLayer( "Player" );
			// DebugInfo();
		}
		else {
			Debug.Log("SpawnOnNetwork: SelectedModel: " + SelectedModel);

			GameObject prefab = Library.GetRecipe(selectedModel) ?? playerPrefab;
			thePlayer = Instantiate(prefab, pos, rot) as GameObject;

			// Apagamos el componente de desplazamiento
			if (thePlayer.GetComponent<Locomotion>() != null) {
				thePlayer.GetComponent<Locomotion>().enabled = false;
			}

			thePlayer.tag = "AvatarNet";
			thePlayer.layer = LayerMask.NameToLayer( "Net" );
		}

		// Set the PhotonView
		PhotonView[] nViews = thePlayer.GetComponentsInChildren<PhotonView>(true);
		nViews[0].viewID = id;
	}

	void DebugInfo() {
		Debug.Log ("countOfPlayers: " + PhotonNetwork.countOfPlayers);
		Debug.Log ("countOfPlayersInRooms: " + PhotonNetwork.countOfPlayersInRooms);
		Debug.Log ("countOfPlayersOnMaster: " + PhotonNetwork.countOfPlayersOnMaster);
		Debug.Log ("countOfRooms: " + PhotonNetwork.countOfRooms);
	}

	int _viewId = -1;
}
