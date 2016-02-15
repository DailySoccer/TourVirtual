using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public enum SelectorPosition {
	TOP,
	RIGHT,
	BOTTOM,
	LEFT
}

public class GuiMapScreen : UIScreen {
	public GameObject Selector;
	RectTransform selectorRT;

	public SelectorPosition selectorPosition;

	public override void Awake () {
		base.Awake ();
	}

	public override void Start() {
		selectorRT = Selector.GetComponent<RectTransform> ();
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
			case "ESTADIO": 
				switch(RoomManager.Instance.GetEntranceDoor()){
				case "PUERTA1":
					button = GameObject.Find ("Map Grada Alta"); 
					break;
				case "PUERTA4":
					button = GameObject.Find ("Map Estadio");
					break;
				}
				break;
			case "ROOM1": button = GameObject.Find ("Map Room1"); break;
			case "ROOM2": button = GameObject.Find ("Map Room2"); break;
			case "ROOM3": button = GameObject.Find ("Map Room3"); break;
			case "ROOM4": button = GameObject.Find ("Map Room4"); break;
			case "ROOM5": button = GameObject.Find ("Map Room5"); break;
			case "ROOM6": button = GameObject.Find ("Map Room6"); break;
			case "ROOM7": button = GameObject.Find ("Map SalaDePrensa"); break;
			}
			
			if (button != null) {
				Vector3 position = Selector.transform.position;
				RectTransform buttonRT = button.GetComponent<RectTransform>();  

				switch(selectorPosition) {
				case SelectorPosition.TOP:
					position.x = button.transform.position.x;
					position.y = button.transform.position.y;
					break;
				case SelectorPosition.RIGHT:
					position.x = button.transform.position.x;
					position.y = button.transform.position.y;			
					break;
				case SelectorPosition.LEFT:
					position.x = button.transform.position.x;
					position.y = button.transform.position.y;						
					break;
				case SelectorPosition.BOTTOM:
					position.x = button.transform.position.x;
					position.y = button.transform.position.y + (buttonRT.rect.height);
					break;				
				}

				Selector.transform.position = position;
			}
		}
	}

	List<Button> _map;
}
