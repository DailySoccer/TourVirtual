using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;
using System.Collections.Generic;
using SmartLocalization;

public class TVBChatController : MonoBehaviour
{
	public GameObject channelSlotPrefab;

	public GameObject messageDatePrefab;
	public GameObject messageOwnPrefab;
	public GameObject messageOtherPrefab;

	public GUIChatScreen channelsScreen;
	public GUIChatScreen messagesScreen;

	public Text currentChannelUILabel;
	public GameObject ChannelInputBar;


	//public InputField channelsInputField;
	public InputField messageInputField;

	public Button messageSendButton;

    public Animator chatAnimator;
	Animator newMsgAnimator;
	/// <summary>
	/// El objeto padre de la lista de canales para que los canales generados
	/// tengan este objeto como padre.
	/// </summary>
	public GameObject channelsListParent;

	/// <summary>
	/// El objeto padre de la lista de canales para que los canales generados
	/// tengan este objeto como padre.
	/// </summary>
	public GameObject messagesListParent;


	[SerializeField][ReadOnly]

	private GUIChatScreen _currentGUIChatScreen;

	/// <summary>
	/// Los Slots de la lista de canales
	/// </summary>
	private List<GameObject> _channelsGameObjects = new List<GameObject>();

	/// <summary>
	/// Los GameObjects messages del canal.
	/// </summary>
	private List<GameObject> _messagesGameObjects = new List<GameObject>();
	
	private Dictionary<string, List<object>> _friendChats = new Dictionary<string, List<object>>();

	private string currentChannelName = "";
	private string currentChannelFriendlyName = "";

    void OnEnable() {
        if (RoomManager.Instance.Room != null) {
            StartChatController();
        }
    }

    void Start () {
		ChatManager.Instance.OnMessagesChange += Messages_OnChangeHandle;
	}

	public void StartChatController() {
		//Nos aseguramos de que el botón de envio de mensaje está desactivado
		messageSendButton.interactable = false;
		//channelsInputField.text = "";
		messageInputField.text = "";
		GoToChannelsScreen();
		CleanMessagesList();
	}

	public void GoToChannelsScreen() {
		RoomManager.Instance.OnPlayerListChange -= ChannelList_OnChangeHanlde;
		SetCurrentChannel("");
		ShowChatScreen(channelsScreen);
		if (newMsgAnimator == null)
			newMsgAnimator = GameObject.FindGameObjectWithTag("NewMessageButton").GetComponent<Animator>();

		newMsgAnimator.SetBool("IsOpen", false);
		CleanChannelSlotsList();
		PopulateChannelsList();
	}
	
	void GotoChatScreen() {
		ShowChatScreen(messagesScreen);
		CleanMessagesList();
		PopulateChannelMessages();
	}

    /// <summary>
    /// Populates the Chat Channels list.
    /// </summary>
    void PopulateChannelsList() {
		//CleanPlayerSlotList();

		//AddChannelSlot("Global");
		AddChannelSlot(ChatManager.CHANNEL_COMMUNITYMANAGER);
		AddChannelSlot(ChatManager.Instance.RoomId);

		foreach (string channel in _friendChats.Keys) 
			AddChannelSlot(channel);
	}

	void PopulateChannelsListWithUsers()
	{
		//CleanPlayerSlotList();

		List<string> connectedUsers = PhotonNetwork.otherPlayers.Select(p => p.name).ToList();

		foreach (string privateChannel in connectedUsers) 
			AddChannelSlot(privateChannel);
	}

	/// <summary>
	/// Añade un GameObject a la lista Padre de canales del chat.
	/// </summary>
	/// <param name="name">Name.</param>
	private void AddChannelSlot(string id)
	{
		if(id == ChatManager.Instance.RoomId)
			foreach(GameObject channel in _channelsGameObjects)
				if(ChatManager.Instance.IsRoom(channel.name))
					channel.SetActive(channel.name == id);
		
		if (_channelsGameObjects.Any(c => c.name == id))
			UpdateChannelSlot(id);
		else
			GenerateChannelSlot(id);
	}

	


	private void UpdateChannelSlot(string chnName)
	{
		GameObject userSlot = _channelsGameObjects.FirstOrDefault(c => c.name == chnName);
		SetChannelSlotValues(userSlot, chnName);
	}

	private void GenerateChannelSlot(string chnName)
	{
		GameObject userSlot = Instantiate(channelSlotPrefab);
		userSlot.name = chnName;
		
		userSlot.transform.SetParent(channelsListParent.transform);
		userSlot.transform.localScale = Vector3.one;

		SetChannelSlotValues(userSlot, chnName);			

		Button btn = userSlot.GetComponent<Button>();
		btn.onClick.AddListener( () => ChatChannel_OnClickHandle(userSlot.GetComponent<TVBChatChannel>()) );

		_channelsGameObjects.Add(userSlot);
	}

	private void SetChannelSlotValues(GameObject userSlot, string channelName)
	{
		TVBChatChannel channel = userSlot.GetComponent<TVBChatChannel>();
        string friendlyName = GetChannelName(channelName);
       
		channel.realName = channelName;
		channel.friendlyName = friendlyName;

		channel.channelType = ChatManager.Instance.IsPublicChannel (channelName) ? 
			( channelName.ToLower().Contains ("community") ? ChatChannelType.Community : ChatChannelType.General ) : 
			ChatChannelType.Private;
		channel.setup ();

		List<object> chat;
		if (!_friendChats.TryGetValue(channelName, out chat) || chat.Count == 0)
		{
			channel.lastUpdateDate.text = "";
			channel.GetComponentInChildren<BadgeAlert>().Count = 0;
		}
		else
		{
			var msg = chat.Last() as Dictionary<string, object>;
			DateTime lastMessageDateTime = msg.toChatMessage().GetMessageDate();//Fecha/hora de ultima actualizacion 

			if (MyTools.ToShortDateString(lastMessageDateTime.AddDays(1)) == MyTools.ToShortDateString(DateTime.Now))
			{
				// Si el mensaje es de ayer ==> "AYER"
				channel.lastUpdateDate.text = LanguageManager.Instance.GetTextValue("TVB.Chat.Yesterday").ToUpper();
			}
			else if (MyTools.ToShortDateString(lastMessageDateTime) == MyTools.ToShortDateString(DateTime.Now))
			{
				// Si el mensaje es de hoy   ==> La Hora
				channel.lastUpdateDate.text = MyTools.ToShortTimeString(lastMessageDateTime);
			}
			else
			{
				// Resto de mensajes  ==> La Fecha
				channel.lastUpdateDate.text = MyTools.ToShortDateString(lastMessageDateTime);
			}

			//Mensajes no leidos:
			int unreadedCount = (from Dictionary<string, object> hash in _friendChats[channelName]
				where (bool) hash["readed"] == false
				select hash).Count();

			var badgeAlert = channel.GetComponentInChildren<BadgeAlert>();
			if(badgeAlert != null)
				badgeAlert.Count = unreadedCount;
		}

#if UNITY_EDITOR
		Debug.LogError("[" + this.name + "] >>> Creado slot de chat: " + channelName + " A.K.A. >>>" + friendlyName + "<<<");
#endif
	}

	/// <summary>
	/// Cleans the Chat Channel slot list.
	/// </summary>
	void CleanChannelSlotsList() {
		foreach(GameObject go in _channelsGameObjects) {
			Button btn = go.GetComponent<Button>();
			// Desuscribimos el evento de click
			btn.onClick.RemoveListener( () => ChatChannel_OnClickHandle(go.GetComponent<TVBChatChannel>()) );
			Destroy(go);
		}
		_channelsGameObjects.Clear();
	}
	/*
	public void SearchButton_OnClickHandle() {

		Animator chnlScrnAnimator = GameObject.FindGameObjectWithTag("ChatSearchBar").GetComponent<Animator>();
		if (!chnlScrnAnimator.GetBool("IsOpen")) {
			chnlScrnAnimator.SetBool("IsOpen", true);
		}
		else {
			HideSearchBar();
		}
	}
	*/
	public void NewMessageButton_OnClickHandle() {
		if (newMsgAnimator == null)
			newMsgAnimator = GameObject.FindGameObjectWithTag("NewMessageButton").GetComponent<Animator>();

		CleanChannelSlotsList();
		if (!newMsgAnimator.GetBool("IsOpen")) {
			newMsgAnimator.SetBool("IsOpen", true);
			PopulateChannelsListWithUsers();
			RoomManager.Instance.OnPlayerListChange += ChannelList_OnChangeHanlde;
		}
		else {
			RoomManager.Instance.OnPlayerListChange -= ChannelList_OnChangeHanlde;
			newMsgAnimator.SetBool("IsOpen", false);
			HideSearchBar();
			PopulateChannelsList();
		}
	}
	
	void ChatChannel_OnClickHandle(TVBChatChannel chn) {

		SetCurrentChannel(chn.realName);

		HideSearchBar();
		ChatManager.Instance.SelectedChannelId = chn.realName;
#if UNITY_EDITOR
		Debug.LogFormat("[TVBChatController]: Entrando en el canal [{0}]", chn.realName);
#endif

		GotoChatScreen();
	}

	public void ChannelList_OnChangeHanlde ()
	{
		PopulateChannelsListWithUsers();
	}	


	private void Messages_OnChangeHandle(string channelId)
	{
#if UNITY_EDITOR
		Debug.LogFormat(" ~ ~ ~ [TVBChatController] Nuevos mensajes en el canal [{0}] [<{1}>]", channelId, ChatManager.Instance.IsPublicChannel(channelId)? "Público" : "Privado");
#endif
		// Guardamos en el disco lo no oúblicos
		if (!ChatManager.Instance.IsPublicChannel(channelId)) {
			SaveMessagesInLocal(channelId, GetNewRemoteMessages(channelId));
			//Debug.LogFormat("[TVBChatController]: Guardados en local", channelId);
		}

		if (currentChannelName == "") {
			PopulateChannelsList();
		}
		else {
			PopulateChannelMessages();
		}

		CheckUnreadMessages();
	}

	private void CheckUnreadMessages() {
		//TODO: Cuenta los mensajes sin leer y notifica al MainManager.
		int counter = 0;

		foreach(string key in _friendChats.Keys) {
			foreach (Dictionary<string, object> hash in _friendChats[key]) {
				if ((bool)hash["readed"] == false) {
					counter++;
				}
			}
		}
		MainManager.Instance.UnreadedChatMessages = counter;
		//Debug.LogFormat("[TVBChatController]: Existen un total de {0} mensajes sin leer", counter);
	}
	
	public void SetCurrentChannel(string theName) {
		currentChannelName = theName;
		currentChannelFriendlyName = GetChannelName(theName);
		currentChannelUILabel.text = currentChannelFriendlyName;
	}


	private static string GetChannelName(string channelId)
	{
		if(channelId == ChatManager.CHANNEL_COMMUNITYMANAGER)
			return channelId;

		if (ChatManager.Instance.IsRoom(channelId))
			return ChatManager.ROOM_CHANNEL_NAME;

		if (ChatManager.Instance.UserName != null)
		{
			int userNameIndex = channelId.IndexOf(ChatManager.Instance.UserName, StringComparison.Ordinal);
			if (userNameIndex > 0)
				return channelId.Remove(userNameIndex, ChatManager.Instance.UserName.Length).Trim(':');
		}

		return channelId;
	}

	
	private void CleanMessagesList()
	{
		//Debug.Log ("[TVBChatController]: Cleaning...");
		foreach(GameObject go in _messagesGameObjects) 
			DestroyImmediate(go);
		
		_messagesGameObjects.Clear();
	}

	private List<ChatMessage> GetPreviousMessages(string channelName)
	{
		// Si es un canal publico, no tenemos guardado ningún mensaje.
		if (ChatManager.Instance.IsPublicChannel(channelName)) {
			return new List<ChatMessage>();
		}

		List<ChatMessage> channelMessages = new List<ChatMessage>();

		if ( _friendChats.ContainsKey(channelName) ) {
			foreach (Dictionary<string, object> line in _friendChats[channelName]) {
				channelMessages.Add(line.toChatMessage());
			}
		}
		//else {
			//Debug.LogFormat("[TVBChatController]: El canal actual [{0}] No tiene mensajes guardados", channelName);
		//}

		//Debug.LogFormat("[TVBChatController]: El canal actual [{0}] tiene [{1}] mensajes guardados", channelName, channelMessages.Count);

		return channelMessages;
	}

	private List<ChatMessage> GetNewRemoteMessages(string channelId)
	{
		List<ChatMessage> channelMessages = new List<ChatMessage>();

		//Si son publicos.
		if (ChatManager.Instance.IsPublicChannel(channelId)) {
			//Debug.LogFormat("[TVBChatController]: Hay {0} nuevos mensajes en el canal [{1}] que es Público", channelId, ChatManager.Instance.Messages.Count().ToString());
			return ChatManager.Instance.Messages;
		}
		//Si son privados.
		List<ChatMessage> messages = ChatManager.Instance.GetMessagesFromChannel(channelId);
		if (!_friendChats.ContainsKey(channelId)) {
			//Debug.LogFormat("[TVBChatController]: Hay {0} mensajes en el canal [{1}] que es Privado. (Aún no se habían guardado en local)", messages.Count().ToString(), channelId);

			return messages;
		}
		// Descartamos los que ya estan en local
		foreach(ChatMessage cht in messages) {
			bool messageAlreadyInLocal = (	from Dictionary<string, object> hash in _friendChats[channelId]
											where (string)hash["sender"] == cht.Sender
							                   && (string)hash["text"] == cht.Text
											select hash
							       		 ).Count() > 0;

			if (!messageAlreadyInLocal) {
				channelMessages.Add(cht);
			}
		}
		//Debug.LogFormat("[TVBChatController]: El canal {0} tiene [{1}] mensajes nuevos.", channelId, messages.Count().ToString());
		return channelMessages;
	}

	private void PopulateChannelMessages()
	{
		List<ChatMessage> theMessages = new List<ChatMessage>();
		theMessages.AddRange(GetPreviousMessages(currentChannelName));
		theMessages.AddRange(GetNewRemoteMessages(currentChannelName));

		AddMessageSlots(theMessages);
	}

	private void SaveMessagesInLocal(string channel, List<ChatMessage> messages)
	{
		List<object> chats;
		if (!_friendChats.TryGetValue(channel, out chats)) {
			chats = new List<object>();
			_friendChats.Add(channel, chats);
		}

		foreach (ChatMessage m in messages) {
			m.Readed = m.Sender == ChatManager.Instance.UserName;
			if (!chats.Contains(m)) 
				chats.Add( m.toHashTable() );
		}

		SerializeAndSaveChats();
	}

	void SetMessagesAsReaded(string currentChannelName)
	{
		foreach (Dictionary<string, object> hash in _friendChats[currentChannelName]) 
			hash["readed"] = true;
	}
	
	void SerializeAndSaveChats()
	{
		var data = new Dictionary<string, object>();
		foreach (var pair in _friendChats)
			data.Add(pair.Key, pair.Value);

		string friend_chats = MiniJSON.Json.Serialize(data);
		
		PlayerPrefs.SetString("friend_chats", friend_chats);
		PlayerPrefs.Save();
	}
	
	void DeserializeAndLoadChats() {
		string jsonString = PlayerPrefs.GetString("friend_chats");
        Dictionary<string, object> data = MiniJSON.Json.Deserialize(jsonString) as Dictionary<string, object>;
		
		
		_friendChats.Clear();
		foreach(string key in data.Keys) {
			if (!_friendChats.ContainsKey(key)) {
				_friendChats.Add(key, new List<object>());
			}
			foreach(Dictionary<string, object> message in data[key] as List<object>) {
				_friendChats[key].Add(message);
			}
		}
	}

	private void AddMessageSlots( List<ChatMessage> messages) {
		List<String> datesProcessed = new List<String>();

		foreach( ChatMessage msg in messages) {

			string msgDate = MyTools.ToShortDateString( msg.GetMessageDate().ToLocalTime() );

			if (!datesProcessed.Contains(msgDate)) {
				datesProcessed.Add(msgDate);

				if (_messagesGameObjects.Where(m => {
												TVBChatMessageDate chatDate = m.GetComponent<TVBChatMessageDate>();
												
												if (chatDate == null) {
													return false;
												}
												return chatDate.TheDate == msgDate;
											}).Count() == 0) {
					_messagesGameObjects.Add(GenerateDateObject(msgDate));
				}
			}

			// Comprobamos que este mensaje no esté ya en la lista
			if (_messagesGameObjects.Where(m => {
											TVBChatMessage chatmsg = m.GetComponent<TVBChatMessage>();

											if (chatmsg == null) {
												return false;
											}

											return chatmsg.IsTheSameMessage(msg);
										}).Count() == 0)
			{
				_messagesGameObjects.Add(GenerateMessageObject(msg));
			}
		}

		if (!ChatManager.Instance.IsPublicChannel(currentChannelName)) {
			if (_friendChats.ContainsKey(currentChannelName)) {
				SetMessagesAsReaded(currentChannelName);
				CheckUnreadMessages();
			}
		}
	}

	private GameObject GenerateDateObject(string msgDate) {
		GameObject goMsgDate = Instantiate(messageDatePrefab);
		goMsgDate.transform.SetParent(messagesListParent.transform);
		goMsgDate.transform.localScale = Vector3.one;

		TVBChatMessageDate chatMsgDate =  goMsgDate.GetComponent<TVBChatMessageDate>();
		chatMsgDate.TheDate = msgDate;

		return goMsgDate;
	}

	private GameObject GenerateMessageObject(ChatMessage msg) {
		GameObject goMsg;
		
		if (msg.Sender == ChatManager.Instance.UserName) {
			goMsg = Instantiate(messageOwnPrefab);
		}
		else {
			goMsg = Instantiate(messageOtherPrefab);
		}
		
		goMsg.transform.SetParent(messagesListParent.transform);
		goMsg.transform.localScale = Vector3.one;
		
		TVBChatMessage chatMsg = goMsg.GetComponent<TVBChatMessage>();
		chatMsg.ChatMessageInstance = msg;

		return goMsg;
	}

	/// <summary>
	/// Muestra la pantalla de chat que nos pasan 
	/// </summary>
	/// <param name="guiScreen">GUI screen.</param>
	public void ShowChatScreen(GUIChatScreen guiScreen) {
		if (_currentGUIChatScreen != null)
		{
			_currentGUIChatScreen.IsOpen = false;
		}
		
		_currentGUIChatScreen = guiScreen;

		if (_currentGUIChatScreen != null)
		{
			_currentGUIChatScreen.IsOpen = true;
		}
	}

	public void MessageTextChange() {
		messageSendButton.interactable = messageInputField.text.Trim().Length > 0;
	}

	public void SendChatMessage() {
		if (messageInputField.text.Trim() == string.Empty) {
#if UNITY_EDITOR
			Debug.LogError("[SendChatMessage] in <" + this.name + ">: Intentaste mandar un mensaje vacío.");
#endif
			return;
		}

		string messageToSend = DateTime.UtcNow + "#" + messageInputField.text;
#if UNITY_EDITOR
		Debug.LogError("[SendChatMessage] in <" + this.name + ">: Trying to send message: \"" + messageToSend );
#endif

		ChatManager.Instance.SendMessage(messageToSend);

		messageInputField.text = "";
	}

	public void HideSearchBar() {
        foreach (var obj in _channelsGameObjects)
            obj.SetActive(true);
		//channelsInputField.text = "";
		//Animator chnlScrnAnimator = GameObject.FindGameObjectWithTag("ChatSearchBar").GetComponent<Animator>();
		//chnlScrnAnimator.SetBool("IsOpen", false);
		//PopulateChannelsList();
	}
	/*
	public void FilterChannelList() {
        foreach( var obj in _channelsGameObjects)
		    obj.SetActive( obj.GetComponent<TVBChatChannel>().realName.ToLower().Contains(channelsInputField.text.ToLower()));
	}
	*/
	public void ClearPlayerPrefs() {
		PlayerPrefs.DeleteAll();
		_friendChats.Clear();

		CleanChannelSlotsList();

		PopulateChannelsList();
	}


}