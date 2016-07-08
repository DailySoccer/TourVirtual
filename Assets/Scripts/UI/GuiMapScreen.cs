using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GuiMapScreen : UIScreen {
	public GameCanvasManager TheGameCanvasManager;

	public GameObject Selector;

	string currentLocation;

	RectTransform selectorRT;

	public override void Awake () {
		base.Awake ();
	}

	public bool Opened;

	public override void Start() {
		selectorRT = Selector.GetComponent<RectTransform> ();
	}

	public void HandleRoom(string roomGoto) {
		string[] placeToGo= roomGoto.Split ('#');
		string room = placeToGo [0];
		string door = placeToGo.Length > 1 ? placeToGo [1] : "";

		if (room == RoomManager.Instance.Room.Id) {
			if (door != "") {
				if ( door == RoomManager.Instance.GetEntranceDoor()){
					TheGameCanvasManager.ShowMainGameScreen ();
					return;
				}
			}
			else
			{
				TheGameCanvasManager.ShowMainGameScreen ();
				return;
			}
		}

		RoomManager.Instance.GotoRoomAtDoor(roomGoto);
	}
	public override void UpdateTitle(){
		Opened = true;
		base.UpdateTitle ();
	}

	public override void Update () {
		base.Update ();

		if (Opened) {
			string newLocation = RoomManager.Instance.Room.Id + "#" + RoomManager.Instance.GetEntranceDoor ();
			if (currentLocation != newLocation) {

				if (Selector != null && RoomManager.Instance != null && RoomManager.Instance.Room != null) {
					GameObject button = null;
			
					switch (RoomManager.Instance.Room.Id) {
						case "ESTADIO": 
							switch (RoomManager.Instance.GetEntranceDoor ()) {
								case "PUERTA1":
								case "PUERTA2":
									button = GameObject.Find ("Map Grada Alta"); 
									break;
								case "PUERTA3":
								case "PUERTA4":
								case "PUERTA5":
									button = GameObject.Find ("Map Estadio");
									break;
							}
							break;
						case "ROOM1":
							button = GameObject.Find ("Map Room1");
							break;
						case "ROOM2":
							button = GameObject.Find ("Map Room2");
							break;
						case "ROOM3":
							button = GameObject.Find ("Map Room3");
							break;
						case "ROOM4":
							button = GameObject.Find ("Map Room4");
							break;
						case "ROOM5":
							button = GameObject.Find ("Map Room5");
							break;
						case "ROOM6":
							button = GameObject.Find ("Map Room6");
							break;
						case "ROOM7":
							button = GameObject.Find ("Map SalaDePrensa");
							break;

						case "ROOM8":
							button = GameObject.Find ("Map Room8");
							break;
					
						case "ROOM9":
							button = GameObject.Find ("Map Room9");
						break;
					
						case "ROOM10":
							button = GameObject.Find ("Map Room10");
						break;
					}

					if (button == null) {
						Debug.LogErrorFormat("No se ha encontrado el borón: {0}", RoomManager.Instance.Room.Id);
					}

					Selector.transform.SetParent ( button.transform.parent);
					Selector.transform.position = new Vector3(button.transform.position.x, button.transform.position.y, 0);
					currentLocation = RoomManager.Instance.Room.Id + "#" + RoomManager.Instance.GetEntranceDoor ();
				}
			}
			Opened = true;
		}
	}

	public void CloseMap() {
		Opened = false;
	}

	List<Button> _map;
}
