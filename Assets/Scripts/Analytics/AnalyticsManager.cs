// #define ENABLE_ANALYTICS

using UnityEngine;
using UnityEngine.Analytics;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

public class AnalyticsManager : MonoBehaviour {

    private event Action<string, IDictionary<string, object>> OnAvatarEvent;
    private event Action<string, IDictionary<string, object>> OnRoomEvent;
    private event Action<string, IDictionary<string, object>> OnViewerEvent;
    private event Action<string, IDictionary<string, object>> OnDresserEvent;
    private event Action<string, IDictionary<string, object>> OnBuyCoinsEvent;
    private event Action<string, IDictionary<string, object>> OnPurchaseEvent;
    private event Action<string, IDictionary<string, object>> OnDeepLinkEvent;
    private event Action<string, IDictionary<string, object>> OnChatsEvent;
    private event Action<string, IDictionary<string, object>> OnHiddenObjectsEvent;
    private event Action<string, IDictionary<string, object>> OnBasketEvent;
    private event Action<string, IDictionary<string, object>> OnFootballEvent;
    private event Action<string, IDictionary<string, object>> OnHelpEvent;
    private event Action<string, IDictionary<string, object>> OnOtherUserProfileEvent;

	private static RoomVisitData Rooms = new RoomVisitData();
    private static ViewerData Viewer = new ViewerData();
    private static AvatarSelectionData AvatarSelection = new AvatarSelectionData();
    private static DresserData Dresser = new DresserData();
    private static CoinsBuyData CoinsBuy = new CoinsBuyData();
    private static DeepLinkingData DeepLinking = new DeepLinkingData();
    private static ChatsData Chats = new ChatsData();
    private static HiddenObjectsData HiddenObjects = new HiddenObjectsData();
    private static BasketGameData Basket = new BasketGameData();
    private static FootballGameData Football = new FootballGameData();
    private static HelpData Help = new HelpData();
    private static OtherUserProfileData OtherUserProfile = new OtherUserProfileData();

	public static AnalyticsManager Instance {get; private set;}

	void Awake() {
		if (Instance == null) {
			Instance = this;
			
            OnAvatarEvent += (eventSubName, roomData) => _GenerateEvent("Avatar_" + eventSubName, roomData);
			OnRoomEvent += (eventSubName, roomData) => _GenerateEvent("Rooms_" + eventSubName, roomData);
			OnViewerEvent += (eventSubName, roomData) => _GenerateEvent("Viewer_" + eventSubName, roomData);
            OnDresserEvent += (eventSubName, roomData) => _GenerateEvent("Dresser_" + eventSubName, roomData);
            OnBuyCoinsEvent += (eventSubName, roomData) => _GenerateEvent("Coins_" + eventSubName, roomData);
            OnPurchaseEvent += (eventSubName, roomData) => _GenerateEvent("Purchase_" + eventSubName, roomData);
            OnDeepLinkEvent += (eventSubName, roomData) => _GenerateEvent("Deep_" + eventSubName, roomData);
            OnChatsEvent += (eventSubName, roomData) => _GenerateEvent("Chat_" + eventSubName, roomData);
            OnHiddenObjectsEvent += (eventSubName, roomData) => _GenerateEvent("HiddenObjects_" + eventSubName, roomData);
            OnBasketEvent += (eventSubName, roomData) => _GenerateEvent("Basket_" + eventSubName, roomData);
            OnFootballEvent += (eventSubName, roomData) => _GenerateEvent("Football_" + eventSubName, roomData);
            OnHelpEvent += (eventSubName, roomData) => _GenerateEvent("Help_" + eventSubName, roomData);
            OnOtherUserProfileEvent += (eventSubName, roomData) => _GenerateEvent("OtherUserProfile_" + eventSubName, roomData);
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
        OnAvatarEvent("Enter", new Dictionary<string, object>() {
        });

        AvatarSelection.Enter();
    }

    public void ShownAvatarModel(AvatarAPI descriptor) {
        AvatarSelection.ShowModel(descriptor);
    }

    public void SelectAvatarModel(AvatarAPI descriptor) {
        OnAvatarEvent("SelectAvatar", new Dictionary<string, object>() {
            { "modelsViewed", AvatarSelection.CountModelsViewed },
            { "selectedModelId", descriptor.Head },
            { "gender", descriptor.Gender },
            { "totalTime", AvatarSelection.TotalTimeInSeconds }
        });

        #if ENABLE_ANALYTICS

        // Registramos el género del usuario (esperando que sea igual al de su avatar)
        Analytics.SetUserGender( descriptor.isMan ? Gender.Male : Gender.Female );

        #endif
    }

    // DEEP LINKING

    public void DeepLinkingEnter() {
        OnDeepLinkEvent("Enter", new Dictionary<string, object>() {
        });
    }

    public void DeepLinkingOtherUser() {
        OnDeepLinkEvent("OtherUser", new Dictionary<string, object>() {
        });
    }

    // ROOM

    public void SelectRoomUsingMap() {
        Rooms.SetFromMenu();
    }

    public void EnterRoom(string roomId) {
        Rooms.Enter(roomId);
        Viewer.Reset();
        Chats.Reset();
        HiddenObjects.EnterRoom(roomId);

        OnRoomEvent(Rooms.FromMenu ? "EnterFromMenu" : "EnterFromPortal", new Dictionary<string, object>() {
            { "enteringRoomId", roomId },
            { "leavingRoomId", Rooms.LastRoomId }
        });
    }

    public void LeaveRoom(string roomId) {
        OnRoomEvent("Leave", new Dictionary<string, object>() {
            { "roomId", Rooms.CurrentRoomId },
            { "usersInRoom", PlayerManager.Instance.CountPlayersInRoom },
            { "viewersOpened", Viewer.ViewersOpened },
            { "viewersOpenedList", Viewer.ViewersOpenedListToString() },
            { "viewersSteped", Viewer.ViewersStepedList.Count },
            { "fromMenu", Rooms.FromMenu },
            { "totalTime", Rooms.TotalTimeInSeconds }
        });

        ChatsInfo();
    }

    // VITRINAS

    public void StepOnViewer(string viewerId) {
        Viewer.StepOnViewer(viewerId);
    }

    public void OpenViewer(string viewerId) {
        Viewer.OpenViewer(viewerId);

        OnViewerEvent("Open", new Dictionary<string, object>() {
            { "viewerId", viewerId },
            { "roomId", Rooms.CurrentRoomId }
        });
    }

    public void ViewerBuySuccess(string contentName, float coinsNeeded) {
        OnViewerEvent("BuySuccess", new Dictionary<string, object>() {
            { "viewerId", Viewer.LastOpenViewerId },
            { "roomId", Rooms.CurrentRoomId },
            { "contentName", contentName },
            { "coinsNeeded", coinsNeeded },
            { "totalTime", Viewer.TotalTimeInSeconds }
        });
    }

    public void ViewerBuyCancel(string contentName, float coinsNeeded) {
        OnViewerEvent("BuyCancel", new Dictionary<string, object>() {
            { "viewerId", Viewer.LastOpenViewerId },
            { "roomId", Rooms.CurrentRoomId },
            { "contentName", contentName },
            { "coinsNeeded", coinsNeeded },
            { "totalTime", Viewer.TotalTimeInSeconds }
        });
    }

    public void ViewerRequestBuyAllContent() {
        OnViewerEvent("RequestBuyAllContent", new Dictionary<string, object>() {
            { "viewerId", Viewer.LastOpenViewerId },
            { "roomId", Rooms.CurrentRoomId },
            { "totalTime", Viewer.TotalTimeInSeconds }
        });
    }

    public void ViewerBuyAllContent() {
        OnViewerEvent("BuyAllContent", new Dictionary<string, object>() {
            { "viewerId", Viewer.LastOpenViewerId },
            { "roomId", Rooms.CurrentRoomId },
            { "totalTime", Viewer.TotalTimeInSeconds }
        });
    }

    // VESTIDOR

    public void EnterDresser() {
        Dresser.Enter();

        OnDresserEvent("Enter", new Dictionary<string, object>() {
            { "roomId", Rooms.CurrentRoomId }
        });
    }

    public void SelectCloth(VirtualGoodsAPI.VirtualGood dress) {
        Dresser.SelectCloth(dress);
    }

    public void ChangeAvatarModel(AvatarAPI descriptor) {
        Dresser.CloseAccept();
        CloseAvatarModel("CloseAccept");
    }

    public void CancelAvatarModel() {
        Dresser.CloseCancel();
        CloseAvatarModel("CloseCancel");
    }

    private void CloseAvatarModel(string eventName) {
        IDictionary<string, object> data = new Dictionary<string, object>() {
            { "deeplinking", DeepLinkingManager.IsEditAvatar },
            { "totalTime", Dresser.TotalTimeInSeconds }
        };
        foreach (string productTypeName in Enum.GetNames(typeof(ProductType))) {
            ProductType productType = (ProductType) Enum.Parse(typeof(ProductType), productTypeName);
            int count = Dresser.CountViewedClothes(productType);
            if (count > 0) {
                data.Add(string.Format("{0}.mostViewed", productTypeName), Dresser.MostViewedCloth(productType));
                data.Add(string.Format("{0}.countViewed", productTypeName), count);
            }
        }
        OnDresserEvent(eventName, data);
    }

    public void OpenBuyInDresser(VirtualGoodsAPI.VirtualGood virtualGood) {
        Dresser.OpenBuy(virtualGood);

        OnDresserEvent("Open", new Dictionary<string, object>() {
        });
    }

    public void BuyInDresser(bool success) {
        if (success) {
            Dresser.BuySuccess();
        }
        else {
            Dresser.BuyCancel();
        }
    }

    public void CloseBuyInDresser() {
        OnDresserEvent( Dresser.BuyResult ? "BuySuccess" : "BuyCancel", new Dictionary<string, object>() {
            { "virtualGoodId", Dresser.VirtualGoodToBuy.GUID },
            { "productType", ClothesListController.Instance.GetTVGType(Dresser.VirtualGoodToBuy.IdSubType) },
            { "coinsNeeded", Dresser.VirtualGoodToBuy.Price },
            { "totalTime", Dresser.TotalBuyTimeInSeconds }
        });
    }

    // MONEDAS

    public void OpenBuyCoins() {
        CoinsBuy.Enter();

        OnBuyCoinsEvent("Open", new Dictionary<string, object>() {
            { "roomId", Rooms.CurrentRoomId },
            { "currentCoins", UserAPI.Instance.Points },
        });
    }

    public void CancelBuyCoins() {
        OnBuyCoinsEvent("BuyCancel", new Dictionary<string, object>() {
            { "roomId", Rooms.CurrentRoomId },
            { "currentCoins", UserAPI.Instance.Points },
            { "totalTime", CoinsBuy.TotalTimeInSeconds }
        });
    }

    public void BuyCoins(string productId) {
        OnBuyCoinsEvent("BuySuccess", new Dictionary<string, object>() {
            { "roomId", Rooms.CurrentRoomId },
            { "productId", productId },
            { "currentCoins", UserAPI.Instance.Points },
            { "totalTime", CoinsBuy.TotalTimeInSeconds }
        });
    }

    // PURCHASE

    public void PurchaseSuccess(string itemId) {
        OnPurchaseEvent("Success", new Dictionary<string, object>() {
            { "roomId", Rooms.CurrentRoomId },
            { "ItemId", itemId },
            { "currentCoins", UserAPI.Instance.Points }
        });
    }

    public void PurchaseError(string itemId) {
        OnPurchaseEvent("Error", new Dictionary<string, object>() {
            { "roomId", Rooms.CurrentRoomId },
            { "ItemId", itemId },
            { "currentCoins", UserAPI.Instance.Points }
        });
    }

    // CHAT

    public void ChatsInfo() {
        if (ChatManager.Instance != null && !string.IsNullOrEmpty(ChatManager.Instance.RoomId)) {
            OnChatsEvent("Info", new Dictionary<string, object>() {
                { "roomId", Rooms.CurrentRoomId },
                { "usersInRoom", PlayerManager.Instance.CountPlayersInRoom },
                { "totalPrivateMessages", Chats.TotalPrivateMessages },
                { "usersPrivateMessages", Chats.TotalUsers },
                // { "messagesInRoom", ChatManager.Instance.CountMessagesFromChannel(ChatManager.Instance.RoomId) }
            });
        }
    }

    public void ChatsPrivateMessage(string userId) {
        Chats.PrivateMessage(userId);
    }

    // MINIJUEGO OBJETOS ESCONDIDOS

    public void HiddenObjectsStart() {
        HiddenObjects.Start();

        OnHiddenObjectsEvent("Start", new Dictionary<string, object>() {
        });
    }

    public void HiddenObjectPickup() {
        HiddenObjects.TotalFindedObjects++;
    }

    public void HiddenObjectsStop() {
        HiddenObjects.Stop();

        OnHiddenObjectsEvent("Stop", new Dictionary<string, object>() {
            { "visitedRooms", HiddenObjects.TotalVisitedRooms },
            { "differentRooms", HiddenObjects.TotalDifferentRooms },
            { "findedObjects", HiddenObjects.TotalFindedObjects },
            { "totalTime", HiddenObjects.TotalTimeInSeconds }
        });
    }

    // MINIJUEGO BASKET

    public void BasketStart() {
        Basket.Start();

        OnBasketEvent("Start", new Dictionary<string, object>() {
        });
    }

    public void BasketResult(int score, int round, int record) {
        Basket.Stop();

        OnBasketEvent("Result", new Dictionary<string, object>() {
            { "score", score },
            { "round", round },
            { "record", record },
            { "totalTime", Basket.TotalTimeInSeconds }
        });
    }

    // MINIJUEGO FOOTBALL

    public void FootballStart() {
        Football.Start();

        OnFootballEvent("Start", new Dictionary<string, object>() {
        });
    }

    public void FootballResult(int score, int round, int record) {
        Football.Stop();

        OnFootballEvent("Result", new Dictionary<string, object>() {
            { "score", score },
            { "round", round },
            { "record", record },
            { "totalTime", Football.TotalTimeInSeconds }
        });
    }

    // HELP

    public void OpenHelp() {
        Help.Enter();
    }

    public void CloseHelp() {
        OnHelpEvent("Close", new Dictionary<string, object>() {
            { "roomId", Rooms.CurrentRoomId },
            { "totalTime", Help.TotalTimeInSeconds }
        });
    }

    // OTHER USER PROFILE

    public void OpenOtherUserProfile(string[] dataModel) {
        OtherUserProfile.Enter(dataModel);

        OnOtherUserProfileEvent("Open", new Dictionary<string, object>() {
            { "roomId", Rooms.CurrentRoomId },
            { "gender", UserAPI.AvatarDesciptor.Gender },
            { "otherGender", OtherUserProfile.Gender }
        });
    }


    public void CloseOtherUserProfile() {
        OnOtherUserProfileEvent("Close", new Dictionary<string, object>() {
            { "roomId", Rooms.CurrentRoomId },
            { "gender", UserAPI.AvatarDesciptor.Gender },
            { "otherGender", OtherUserProfile.Gender },
            { "totalTime", OtherUserProfile.TotalTimeInSeconds }
        });
    }
}
