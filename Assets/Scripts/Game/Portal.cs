using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour {

	public string PortalID;


	void Start () {
	}
	
	void Update () {
	}

	void OnTriggerEnter(Collider other) {
        Debug.LogError(">>>>>>>>>>>> " + other.name);
		if (other.tag != Player.TAG_UMA_AVATAR)
			return;
        Debug.LogError(">>>>>>>>>>>> 1 offlineMode " + PhotonNetwork.offlineMode+" room "+ PhotonNetwork.room);
        // Debug.Log ("Enter: Portal: " + PortalID);

//        if (!PhotonNetwork.offlineMode && PhotonNetwork.room == null) return;
        Debug.LogError(">>>>>>>>>>>> 2");

        if (_roomManager == null) {
		 _roomManager = RoomManager.Instance;
		}
        Debug.LogError(">>>>>>>>>>>> 3");

        if (_roomManager != null) {
			_roomManager.ToRoom(PortalID);
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.tag != Player.TAG_UMA_AVATAR)
			return;

		// Debug.Log ("Exit: Portal: " + PortalID );
	}

	static public Portal FindInScene(string portalId) {
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
	
	static public Portal First() {
		GameObject[] portalesObj = GameObject.FindGameObjectsWithTag("Portal");
		return portalesObj.Length > 0 ? portalesObj[0].GetComponent<Portal>() : null;
	}


	RoomManager _roomManager;
}
