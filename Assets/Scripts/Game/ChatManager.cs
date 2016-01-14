using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon.Chat;

public class ChatMessage {
	public string Sender;
	public string Text;
	public bool Readed;

	public ChatMessage(string sender, string text, bool readed) {
		Sender = sender;
		Text = text;
		Readed = readed;
	}
}

public class ChatManager : Photon.PunBehaviour, IChatClientListener {

	static public string CHANNEL_GLOBAL = "Global";

	public delegate void MessagesChangeEvent(string channelName);
	public event MessagesChangeEvent OnMessagesChange;

	static public ChatManager Instance {
		get {
			GameObject chatManagerObj = GameObject.FindGameObjectWithTag("ChatManager");
			return chatManagerObj != null ? chatManagerObj.GetComponent<ChatManager>() : null;
		}
	}

	public string ChatAppId;                    // set in inspector. Your Chat AppId (don't mix it with Realtime/Turnbased Apps).

	public int MessagesFromHistory = -1;

	public string UserName { get; set; }
	public ChatClient ChatClient;

	private string _channelSelected;
	public string ChannelSelectedId {
		get {
			return _channelSelected;
		}

		set {
			_channelSelected = value;
		}
	}

	public string ChannelSelectedName {
		get {
			return GetChannelName(_channelSelected);
		}
	}

	public List<ChatMessage> Messages {
		get {
			return GetMessagesFromChannel(ChannelSelectedId);
		}
	}

	public List<ChatMessage> GetMessagesFromChannel(string channelId) {
		string channelName = GetChannelName(channelId);
		return History.ContainsKey(channelName) ? History[channelName] : new List<ChatMessage>();
	}

	public string GetChannelName(string channelId) {
		return IsPublicChannel(channelId) ? channelId : ChatClient.GetPrivateChannelNameByUser(channelId);
	}

	public Dictionary<string, List<ChatMessage>> History = new Dictionary<string, List<ChatMessage>>();

	void Start () {
	}

	public IEnumerator Connect() {
		if (string.IsNullOrEmpty(this.UserName)) {
			UserName = PhotonNetwork.player.name;
		}
		
		ChatClient = new ChatClient(this);
		ChatClient.Connect(ChatAppId, "1.0", UserName, null);

		while (!ChatClient.CanChat) {
			yield return null;
		}
	}

	/// <summary>To avoid that the Editor becomes unresponsive, disconnect all Photon connections in OnApplicationQuit.</summary>
	public void OnApplicationQuit() {
		if (ChatClient != null) {
			ChatClient.Disconnect();
		}
	}
	
	public void Update() {
		if (ChatClient != null) {
			ChatClient.Service();  // make sure to call this regularly! it limits effort internally, so calling often is ok!
		}
	}

	public void SendMessage(string text) {
		SendMessage(_channelSelected ?? CHANNEL_GLOBAL, text);
	}

	public void SendMessage(string channelName, string text) {
		Debug.Log (string.Format("SendMessage[{0}]: {1}", channelName, text));

		if (IsPublicChannel(channelName)) {
			ChatClient.PublishMessage(channelName, text);
		}
		else {
			ChatClient.SendPrivateMessage(channelName, text);
		}
	}

	public void OnConnected() {
		Debug.Log ("OnConnected");
		// chatClient.Subscribe( new string[] { "channelA", "channelB" } );
		ChatClient.SetOnlineStatus(ChatUserStatus.Online);

		ChatClient.Subscribe( new string[] { CHANNEL_GLOBAL }, 0 );
	}
	
	public void OnDisconnected() {
		Debug.Log ("OnDisconnected");
        if (!PhotonHandler.AppQuits)
            ChatClient.Connect(ChatAppId, "1.0", UserName, null);
		// ChatClient.Unsubscribe( new string[] { CHANNEL_GLOBAL } );
	}
	
	public void OnChatStateChange(ChatState state) {
		Debug.Log ("OnChatStateChange: " + state.ToString());
	}
	
	public void OnSubscribed(string[] channels, bool[] results)	{
		Debug.Log ("OnSubscribed");

		/*
		foreach (string channel in channels) {
			chatClient.PublishMessage(channel, "says 'hi' in OnSubscribed(). " + channel); // you don't HAVE to send a msg on join but you could.
		}
		*/
	}
	
	public void OnUnsubscribed(string[] channels) {
		Debug.Log ("OnUnsubscribed");
	}

	public void OnGetMessages(string channelName, string[] senders, object[] messages) {
		Debug.Log (string.Format ("OnGetMessages [{0}]", channelName));

		if (!History.ContainsKey(channelName)) {
			History.Add(channelName, new List<ChatMessage>());
		}

		for ( int i = 0; i < senders.Length; i++ ) {
			History[channelName].Add(new ChatMessage(senders[i], messages[i] as string, false));
		}

		if (OnMessagesChange != null /*&& channelName.Equals(ChannelSelectedName)*/) {
			OnMessagesChange(channelName);
		}
	}
	
	public void OnPrivateMessage(string sender, object message, string channelName) {
		Debug.Log (string.Format ("OnPrivateMessage [{0}]: {1}: {2}", channelName, sender, message));

		if (!History.ContainsKey(channelName)) {
			History.Add(channelName, new List<ChatMessage>());

			ChatChannel ch = ChatClient.PrivateChannels[ channelName ];
			foreach ( object msg in ch.Messages ) {
				// Debug.Log (string.Format("PrivateMessage: {0} -> {1}: {2}", sender, UserName, msg));
				History[channelName].Add(new ChatMessage(sender, msg as string, false));
			}
		}
		else {
			History[channelName].Add(new ChatMessage(sender, message as string, false));
		}

		if (OnMessagesChange != null /*&& channelName.Equals(ChannelSelectedName)*/) {
			OnMessagesChange(channelName);
		}
	}
	
	public void OnStatusUpdate(string user, int status, bool gotMessage, object message) {
		Debug.Log ("OnStatusUpdate");
	}

	public override void OnJoinedRoom() {
		Debug.Log ("OnJoinedRoom");

		_roomChannel = PhotonNetwork.room.name;

		if (ChatClient != null && ChatClient.CanChat) {
			ChatClient.Subscribe( new string[] { _roomChannel }, MessagesFromHistory );
		}

		ChannelSelectedId = _roomChannel;
	}
	
	public override void OnLeftRoom() {
		if (_roomChannel != null) {
			/*
			if (History.ContainsKey(_channelSubscription)) {
				History[_channelSubscription].Clear();
			}

			if (OnPublicMessagesChange != null) {
				OnPublicMessagesChange();
			}
			*/

			if (ChatClient != null && ChatClient.CanChat) {
				ChatClient.Unsubscribe( new string[] { _roomChannel } );
			}

			_roomChannel = null;
		}
	}

	public bool IsPublicChannel(string channel) {
		return channel.Equals(ChatManager.CHANNEL_GLOBAL) || channel.Equals(_roomChannel);
	}

	private string _roomChannel;
}
