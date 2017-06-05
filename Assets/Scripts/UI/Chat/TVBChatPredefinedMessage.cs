using UnityEngine;
using UnityEngine.UI;

public class TVBChatPredefinedMessage : MonoBehaviour {
    public Text TextComponent;

    private TVBChatPredefinedMessages _controller;
    private string _messageKey;

    public void SetMessage(TVBChatPredefinedMessages controller, string key, string message) {
        _controller = controller;
        _messageKey = key;
        TextComponent.text = message;
    }

    public void SendChatMessage() {
        _controller.SendChatMessage(_messageKey);
    }
}
