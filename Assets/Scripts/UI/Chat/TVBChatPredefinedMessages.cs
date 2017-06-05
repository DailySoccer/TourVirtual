using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class TVBChatPredefinedMessages : MonoBehaviour {
    public TVBChatController chatController;
    public GameObject messagesListParent;
    public GameObject predefinedMessagePrefab;

    bool _initialized = false;

	void Awake () {
	}

    void Start() {
        if (!_initialized) {
            Init();
        }
    }

    void Init() {
        Debug.Log("TVBChatPredefinedMessages Init");
        Dictionary<string, string> lMessages = ChatManager.Instance.GetPredefinedMessages();
        foreach(string key in lMessages.Keys) {
            GenerateMessage(key, lMessages[key]);
        }

        _initialized = true;
    }

    void GenerateMessage(string key, string message) {
        GameObject goMsg = Instantiate(predefinedMessagePrefab);

        goMsg.transform.SetParent(messagesListParent.transform);
        goMsg.transform.localScale = Vector3.one;

        TVBChatPredefinedMessage chatMsg = goMsg.GetComponent<TVBChatPredefinedMessage>();
        chatMsg.SetMessage(this, key, message);
    }

    public void SendChatMessage(string key) {
        chatController.SendChatPredefinedMessage(key);
    }

	void Update() {
	}
}
