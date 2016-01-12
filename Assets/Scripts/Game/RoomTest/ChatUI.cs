using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ChatUI : MonoBehaviour {
	public Text Messages;
	public InputField InputText;

	void Start () {
		_chatManager = ChatManager.Instance;
		_chatManager.OnMessagesChange += HandleOnMessagesChangeEvent;
	}

	void Update () {
	}

	void HandleOnMessagesChangeEvent(string channelName) {
		string msg = "";
		foreach(ChatMessage message in _chatManager.Messages) {
			if (message.Sender == _chatManager.UserName) {
				msg += "<color=green>" + message.Sender + "</color>" + "> " + message.Text + "\n";
			}
			else {
				msg += message.Sender + "> " + message.Text + "\n";
			}
		}
		Messages.text = msg;
	}

	public void SendChatMessage() {
		_chatManager.ChannelSelectedId = ChatManager.CHANNEL_GLOBAL;
		_chatManager.SendMessage(InputText.text);
		InputText.text = "";
	}

	public ChatManager _chatManager;
}
