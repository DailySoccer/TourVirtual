using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RoomControllerUI : Photon.PunBehaviour {
	public Text RoomName;
	public Button Left;
	public Button Up;
	public Button Right;
	public Button Down;

	void Start () {
		_roomManager = RoomManager.Instance;
	}

	public override void OnJoinedRoom() {
		RoomDefinition room = _roomManager.Room;
		RoomName.gameObject.SetActive(true);
		RoomName.text = room.Name;
		Left.gameObject.SetActive(room.ExistsDoor("LEFT"));
		Up.gameObject.SetActive(room.ExistsDoor("UP"));
		Right.gameObject.SetActive(room.ExistsDoor("RIGHT"));
		Down.gameObject.SetActive(room.ExistsDoor("DOWN"));
	}

	void Update () {
	}

	public RoomManager _roomManager;
}
