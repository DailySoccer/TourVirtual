using UnityEngine;
using UnityEngine.Analytics;
using System.Collections;
using System.Collections.Generic;
using System;

public class AnalyticsManager : MonoBehaviour {

	public static RoomVisitData Rooms = new RoomVisitData();
	public static AvatarSelectionData AvatarSelection = new AvatarSelectionData();
	public static DeepLinkingData DeepLinking = new DeepLinkingData();
	public static DresserData Dresser = new DresserData();
	public static CoinsBuyData CoinsBuy = new CoinsBuyData();

	public static AnalyticsManager Instance {get; private set;}

	void Awake() {
		if (Instance == null) {
			Instance = this;
			
			Rooms.OnRoomEvent += (eventSubName, roomData) => _GenerateEvent("Rooms_" + eventSubName, roomData);
			Rooms.OnViewerEvent += (eventSubName, roomData) => _GenerateEvent("Viewer_" + eventSubName, roomData);
			AvatarSelection.OnAvatarEvent += (eventSubName, roomData) => _GenerateEvent("Avatar_" + eventSubName, roomData);
			DeepLinking.OnDeepLinkEvent += (eventSubName, roomData) => _GenerateEvent("Deep_" + eventSubName, roomData);
			//Dresser. += (eventSubName, roomData) => _GenerateEvent("Dresser_" + eventSubName, roomData);
			//CoinsBuy.OnRoomEvent += (eventSubName, roomData) => _GenerateEvent("CoinsBuy_" + eventSubName, roomData);
		}
	}

	private void _GenerateEvent(string eventName, IDictionary<string, object> eventData) {
		// Unity Analytics event
		if(eventData.Count > 10) {
			Debug.LogWarningFormat("Unity analytics event, too many arguments: {0}", eventData.Count);
		}
		Analytics.CustomEvent(eventName, eventData);

		
		// DeltaDNA event
		/*
		// Esto es un copia y pega de la documentacion de deltaDNA, es meramente ilustrativo
		// Build a game event with a couple of event parameters
        GameEvent optionsEvent = new GameEvent (eventName)
			// for each data in eventData
            .AddParam ("option", "Music")
            .AddParam ("action", "Disabled");
 
        // Record the event
        DDNA.Instance.RecordEvent (optionsEvent);
		*/
	}


}
