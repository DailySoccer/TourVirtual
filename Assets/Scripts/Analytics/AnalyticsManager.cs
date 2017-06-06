// #define ENABLE_ANALYTICS

using UnityEngine;
using UnityEngine.Analytics;
using System.Collections;
using System.Collections.Generic;
using System;

public class AnalyticsManager : MonoBehaviour {

	private static RoomVisitData Rooms = new RoomVisitData();
    private static AvatarSelectionData AvatarSelection = new AvatarSelectionData();
    private static DeepLinkingData DeepLinking = new DeepLinkingData();
    private static DresserData Dresser = new DresserData();
    private static CoinsBuyData CoinsBuy = new CoinsBuyData();

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

		_PrintEvent(eventName, eventData);

		// Unity Analytics event
		if(eventData.Count > 10) {
			Debug.LogWarningFormat("Unity analytics event, too many arguments: {0}", eventData.Count);
		}

        #if ENABLE_ANALYTICS

    		Analytics.CustomEvent(eventName, eventData);

        #endif

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

	private void _PrintEvent(string eventName, IDictionary<string, object> eventData) {
        Debug.LogFormat("Analytics Event: {0} Data: {1}", eventName, MiniJSON.Json.Serialize(eventData));
	}

    /*
     * EVENTOS
     */

    // AVATAR SELECTION

    public void OpenAvatarSelection() {
        AvatarSelection.Enter();
    }

    public void ShownAvatarModel(AvatarAPI descriptor) {
        AvatarSelection.ShowModel(descriptor);
    }

    public void SelectAvatarModel(AvatarAPI descriptor) {
        AvatarSelection.SelectModel(descriptor);

        #if ENABLE_ANALYTICS

        // Registramos el género del usuario (esperando que sea igual al de su avatar)
        Analytics.SetUserGender( descriptor.isMan ? Gender.Male : Gender.Female );

        #endif
    }

    // ROOM

    public void EnterRoom(string roomId) {
        Rooms.Enter(roomId);
    }

    public void LeaveRoom(string roomId) {
        Rooms.Leave();
    }

    public void StepOnViewer(string viewerId) {
        Rooms.StepOnViewer(viewerId);
    }

    public void OpenViewer(string viewerId) {
        Rooms.OpenViewer(viewerId);
    }

    public void GotoUsingMap() {
        Rooms.SetFromMenu();
    }

    // VESTIDOR

    public void EnterDresser() {
        Dresser.Enter();
    }

    public void ChangeAvatarModel(AvatarAPI descriptor) {
        Dresser.CloseAccept();
    }

    public void CancelAvatarModel() {
        Dresser.CloseCancel();
    }

    public void OpenBuyInDresser() {
        Dresser.OpenBuy();
    }

    public void BuyInDresser(VirtualGoodsAPI.VirtualGood virtualGood, bool success) {
        if (success) {
            Dresser.BuySuccess(virtualGood);
        }
        else {
            Dresser.BuyCancel(virtualGood);
        }
    }
}
