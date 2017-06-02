using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PredefinedMessages : MonoBehaviour {
    const string KEY_DEFAULT = "default";

    public TextAsset JsonMessages;

    // Para cada message-key se asocian messages (para cada idioma)
    private Dictionary<string, object> _messages;

    private string MARK_BEGIN_MESSAGE = "<message>";
    private string MARK_END_MESSAGE = "</message>";

    void Awake () {
        _messages = MiniJSON.Json.Deserialize(JsonMessages.text) as Dictionary<string, object>;
        Debug.Log("JsonMessages: " + JsonMessages.text.ToString());
    }

	void Start () {
	}
	
	void Update () {
	}

    public bool isPredefinidedMessage(string message) {
        return message.StartsWith(MARK_BEGIN_MESSAGE) && message.EndsWith(MARK_END_MESSAGE);
    }

    public Dictionary<string, string> GetMessages() {
        return GetMessages(MainManager.Instance.CurrentLanguage);
    }

    // Lista de key <-> message para un idioma determinado
    public Dictionary<string, string> GetMessages(string language) {
        Dictionary<string, string> result = new Dictionary<string, string>();

        // Buscamos los mensajes predefinidos del idioma actualmente seleccionado
        foreach(var key in _messages.Keys) {
            Dictionary<string, object> data = _messages[key] as Dictionary<string, object>;

            // Si no existe un mensaje asociado en el idioma actual, buscamos en el "default"
            object value;
            if (!data.TryGetValue(language, out value)) {
                data.TryGetValue(KEY_DEFAULT, out value);
            }

            Debug.Assert(value is string, string.Format("PredefinedMessage: {0} NOT is string", key));
            if (value is string) {
                string message = value as string;
                if (message is string && !string.IsNullOrEmpty(message)) {
                    Debug.Log(string.Format("Message: {0} => {1}", key, message));
                    result.Add(key, message);
                }
            }
        }

        return result;
    }

    public string GetTranslatedMessage(string message) {
        return GetTranslatedMessage(MainManager.Instance.CurrentLanguage, message);
    }

    public string GetTranslatedMessage(string language, string message) {
        string result = message;
        if (isPredefinidedMessage(message)) {
            // Extraer la key dentro del formato de "<message>key</message>"
            // TODO: RegEx puede facilitar la tarea y contemplar más casuística
            string key = message.Substring(MARK_BEGIN_MESSAGE.Length, message.Length - MARK_BEGIN_MESSAGE.Length - MARK_END_MESSAGE.Length);
            result = GetMessageFromKey(language, key);
        }
        return result;
    }

    public string GetMessageFromKey(string key) {
        return GetMessageFromKey(MainManager.Instance.CurrentLanguage, key);
    }

    public string GetMessageFromKey(string language, string key) {
        if (!_messages.ContainsKey(key)) {
            Debug.LogErrorFormat("GetMessageFromKey: language={0} key={1} (Invalid Key)", language, key);
            return key;
        }

        Dictionary<string, object> data = _messages[key] as Dictionary<string, object>;
        object value;
        if (!data.TryGetValue(language, out value)) {
            data.TryGetValue(KEY_DEFAULT, out value);
        }

        Debug.Assert(value is string, string.Format("PredefinedMessage: {0} NOT is string", key));
        Debug.Log(string.Format("Message: {0} => {1}", key, value as string));
        return value as string;
    }
}
