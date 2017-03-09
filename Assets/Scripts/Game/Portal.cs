using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour {

	public string PortalID;
	private bool isAvailable = true;

	void Start () {
		if (PortalID == "PUERTA3" || PortalID == "PUERTA5") {
			MainManager.Instance.OnVRModeSwitch -= OnVRSwitch;
			MainManager.Instance.OnVRModeSwitch += OnVRSwitch;
			OnVRSwitch();
		}
	}
	
	void Update () {
	}

	private void OnVRSwitch()
	{	
		if (PortalID == "PUERTA3" || PortalID == "PUERTA5") {
			isAvailable = !MainManager.Instance.IsVrModeEnabled;
		}
	}

	void OnTriggerEnter(Collider other) {
		if (!isAvailable)
			return;

		if (other.tag != Player.TagUmaAvatar)
			return;
        // Debug.Log ("Enter: Portal: " + PortalID);

//        if (!PhotonNetwork.offlineMode && PhotonNetwork.room == null) return;
        if (_roomManager == null) {
		 _roomManager = RoomManager.Instance;
		}

        if (_roomManager != null) {
			_roomManager.ToRoom(PortalID);
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.tag != Player.TagUmaAvatar)
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
