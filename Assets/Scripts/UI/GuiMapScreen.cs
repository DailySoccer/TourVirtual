using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GuiMapScreen : GUIPopUpScreen {
	public Button MapRoomIcon;
	public GameObject Selector;

	public override void Awake () {
		base.Awake ();
	}

	public override void Start() {
		/*
		if (_map == null) {
			_map = new List<Button>();

			int X = 100;
			int Y = Screen.height - 200;

			foreach(string roomDefinitionKey in RoomManager.Instance.RoomDefinitions.Keys) {
				RoomDefinition roomDefinition = RoomManager.Instance.RoomDefinitions[roomDefinitionKey] as RoomDefinition;

				Button roomBtn = GameObject.Instantiate(MapRoomIcon);
				roomBtn.GetComponentInChildren<Text>().text = roomDefinition.Name;

				string roomKey = roomDefinitionKey;
				roomBtn.onClick.AddListener(() => HandleRoom(roomKey));
				
				roomBtn.transform.position = new Vector3(X, Y, 0);
				roomBtn.transform.SetParent(transform);
				
				_map.Add(roomBtn);

				X += 150;
				if (X + (MapRoomIcon.GetComponent<RectTransform>().rect.xMax / 2) > Screen.width) {
					Y -= 150;
					X = 100;
				}
			}
		}
		*/

	}

	public void HandleRoom(string roomGoto) {
		Debug.LogWarning("HandleRoom: " + roomGoto);
		RoomManager.Instance.GotoRoomAtDoor(roomGoto);
	}

	public override void Update () {
		base.Update ();

		if (Selector != null && RoomManager.Instance != null && RoomManager.Instance.Room != null) {
			GameObject button = null;
			
			switch(RoomManager.Instance.Room.Id) {
			case "ESTADIO": button = GameObject.Find ("Map Grada Alta"); break;
			case "ROOM1": button = GameObject.Find ("Map Room1"); break;
			case "ROOM2": button = GameObject.Find ("Map Room2"); break;
			case "ROOM3": button = GameObject.Find ("Map Room3"); break;
			case "ROOM4": button = GameObject.Find ("Map Room4"); break;
			case "ROOM5": button = GameObject.Find ("Map Room5"); break;
			case "ROOM6": button = GameObject.Find ("Map Room6"); break;
			}
			
			if (button != null) {
				Vector3 position = Selector.transform.position;
				position.y = button.transform.position.y;
				Selector.transform.position = position;
			}
		}
	}

	List<Button> _map;
}
