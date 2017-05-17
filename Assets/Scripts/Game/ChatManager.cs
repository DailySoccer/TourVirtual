using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon;
using ExitGames.Client.Photon.Chat;
using SmartLocalization;

public class ChatMessage
{
	public string Sender;
	public string Text;
	public bool Readed;

	public ChatMessage(string sender, string text, bool readed) {
		Sender = sender;
		Text = text;
		Readed = readed;
	}
}

public class ChatManager : Photon.PunBehaviour, IChatClientListener
{
	static public string CHANNEL_COMMUNITYMANAGER = "Community Manager";
	static public string ROOM_CHANNEL_NAME {
		get{
			return LanguageManager.Instance.GetTextValue("TVB.Chat.RoomChannelName");
		}
	}

	public delegate void MessagesChangeEvent(string channelId);
	public event MessagesChangeEvent OnMessagesChange;

	static public ChatManager Instance {
		get {
			GameObject chatManagerObj = GameObject.FindGameObjectWithTag("ChatManager");
			return chatManagerObj != null ? chatManagerObj.GetComponent<ChatManager>() : null;
		}
	}

	public string RoomId { get; private set; }

	public string ChatAppId;                    // set in inspector. Your Chat AppId (don't mix it with Realtime/Turnbased Apps).

	public int MessagesFromHistory = -1;

	public string UserName { get; set; }
	public ChatClient ChatClient;

	public string SelectedChannelId { get; set; }

	public Dictionary<string, List<ChatMessage>> History = new Dictionary<string, List<ChatMessage>>();
	

	public List<ChatMessage> Messages {
		get {
			return GetMessagesFromChannel(SelectedChannelId);
		}
	}

	public List<ChatMessage> GetMessagesFromChannel(string channelId)
	{
		List<ChatMessage> msgs;
		return History.TryGetValue(channelId, out msgs) ? msgs : new List<ChatMessage>();
	}

	private HashSet<string> _roomIds;


	//==============================================================================================

	private void Awake()
	{
		_roomIds = new HashSet<string>();
	}
	
	void Start ()
	{
		foreach(KeyValuePair<string, object> pair in RoomManager.Instance.RoomDefinitions)
			_roomIds.Add(pair.Key);
	}


	/// <summary>To avoid that the Editor becomes unresponsive, disconnect all Photon connections in OnApplicationQuit.</summary>
	public void OnApplicationQuit()
	{
		if (ChatClient != null) 
			ChatClient.Disconnect();
		
	}
	
	public void Update()
	{
		if (ChatClient != null) 
			ChatClient.Service();  // make sure to call this regularly! it limits effort internally, so calling often is ok!
	}

	public void SendMessage(string text)
	{
		string chn =  SelectedChannelId ?? CHANNEL_COMMUNITYMANAGER;
#if UNITY_EDITOR
		Debug.LogError("[SendMessage] in <" + name + ">: Se enviará al canal: " + chn);
#endif
		SendMessage(chn, text);
	}

	public void SendMessage(string channelName, string text) {
		if (IsPublicChannel(channelName)) {
            ChatClient.PublishMessage(channelName, text);
		}
		else {
            ChatClient.SendPrivateMessage(channelName, text);
		}
	}

	public void OnConnected() {
		//Debug.Log (">>> Chat OnConnected");
		ChatClient.SetOnlineStatus(ChatUserStatus.Online);
		ChatClient.Subscribe( new string[] { CHANNEL_COMMUNITYMANAGER }, 0 );

		if( !string.IsNullOrEmpty(RoomId) ){
			if (ChatClient != null && ChatClient.CanChat) {
				ChatClient.Subscribe( new [] { RoomId }, MessagesFromHistory );
			}
		}
		
	}

	// TODO
	public void DebugReturn(DebugLevel level, string message) {
#if UNITY_EDITOR
		switch(level) {
		case DebugLevel.ERROR: Debug.LogError(message); break;
		case DebugLevel.WARNING: Debug.LogWarning(message); break;
		default: Debug.Log(message); break;
		}
#endif
		throw new System.NotImplementedException();
	}

	public void OnDisconnected() {
		//Debug.Log (">>> Chat OnDisconnected");
        if (!PhotonHandler.AppQuits && !MainManager.Instance.OfflineMode)
			ChatClient.Connect(ChatAppId, "1.0", new ExitGames.Client.Photon.Chat.AuthenticationValues(UserName));
	}
	
	public void OnChatStateChange(ChatState state) {
		//Debug.Log (">>> Chat OnChatStateChange: " + state.ToString());
	}
	
	public void OnSubscribed(string[] channels, bool[] results)	{
		//Debug.LogError (">>> Chat OnSubscribed to: " + channels.stringArrayToString());
	}
	public void OnUnsubscribed(string[] channels) {
		//Debug.Log (">>> Chat OnUnsubscribed to: " + channels.stringArrayToString());
	}

    public override void OnDisconnectedFromPhoton()
    {
        OnDisconnected();
    }

    public void OnGetMessages(string channelId, string[] senders, object[] messages)
	{
		// Debug.Log (string.Format ("OnGetMessages [{0}]", channelId));
	    List<ChatMessage> channelHistory;
	    if (!History.TryGetValue(channelId, out channelHistory)) {
		    channelHistory = new List<ChatMessage>();
			History.Add(channelId, channelHistory);
	    }

	    for(int i = 0; i < senders.Length; ++i ) 
			channelHistory.Add(new ChatMessage(senders[i], messages[i] as string, false));
		
		if (OnMessagesChange != null /*&& channelId.Equals(SelectedChannelId)*/) 
			OnMessagesChange(channelId);
	}
	
	public void OnPrivateMessage(string sender, object message, string channelName) {
//		Debug.Log (string.Format ("OnPrivateMessage [{0}]: {1}: {2}", channelId, sender, message));
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

		if (OnMessagesChange != null /*&& channelId.Equals(SelectedChannelId)*/) {
			OnMessagesChange(channelName);
		}
	}
	
	public void OnStatusUpdate(string user, int status, bool gotMessage, object message) {
//		Debug.Log ("OnStatusUpdate");
	}

	public override void OnJoinedRoom()
	{
		RoomId = PhotonNetwork.room.name.Split('#')[0];
		_roomIds.Add(RoomId);

		#if UNITY_EDITOR
			//Debug.Log ("OnJoinedRoom");
			//Debug.LogError (">>> JOINED THE ROOM: " + RoomId);
		#endif

        if (ChatClient != null && ChatClient.CanChat) {
			ChatClient.Subscribe( new [] { RoomId }, MessagesFromHistory );
		}

		SelectedChannelId = RoomId;
	}
	
	public override void OnLeftRoom()
	{
		if (RoomId != null) {
			/*
			if (History.ContainsKey(_channelSubscription)) {
				History[_channelSubscription].Clear();
			}

			if (OnPublicMessagesChange != null) {
				OnPublicMessagesChange();
			}
			*/

			if (ChatClient != null && ChatClient.CanChat) {
				ChatClient.Unsubscribe( new string[] { RoomId } );
			}
			//_roomChannel = null;
		}
	}

	public bool IsPublicChannel(string id)
	{
		return IsRoom(id) || (
			   id == ChatManager.CHANNEL_COMMUNITYMANAGER 
			&& UserName == ChatManager.CHANNEL_COMMUNITYMANAGER);
	}

	public bool IsRoom(string channelId)
	{
		return _roomIds.Contains(channelId);
	}

	public IEnumerator Connect()
	{
		if (string.IsNullOrEmpty(this.UserName))
		{
			UserName = PhotonNetwork.player.name;
		}

		ChatClient = new ChatClient(this);
		ChatClient.Connect(ChatAppId, "1.0", new ExitGames.Client.Photon.Chat.AuthenticationValues(UserName));

		while (!ChatClient.CanChat)
		{
			yield return null;
		}
	}

	public void MyDisconnect(){
		ChatClient.Disconnect();
	}
	
}
