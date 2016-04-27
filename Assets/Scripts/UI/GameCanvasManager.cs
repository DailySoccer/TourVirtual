using UnityEngine;

public class GameCanvasManager : CanvasManager 
{
	private MainManager _mainManagerInstance;

	private UnityEngine.UI.Toggle _soundsToggle;
	private UnityEngine.UI.Toggle _musicToggle;

	void Awake() {
		_mainManagerInstance = MainManager.Instance;
		
		// Get Language Settings
		switch (_mainManagerInstance.CurrentLanguage) {
		case "es":
			GameObject toggleSpanish = GameObject.Find("Toggle Spanish");
			if (toggleSpanish != null){
				toggleSpanish.GetComponent<UnityEngine.UI.Toggle>().isOn = true;
			}
			break;
		case "en":
			GameObject toggleEnglish = GameObject.Find("Toggle English");
			if (toggleEnglish != null){
				GameObject.Find("Toggle English").GetComponent<UnityEngine.UI.Toggle>().isOn = true;
			}
			break;
		}
		_mainManagerInstance.OnMessagesUnreadedEvent += OnUnreadedMessages;
	}

	void OnEnable() {
		ShowScreen(currentGUIScreen);
	}
	private void OnUnreadedMessages(int counter) {
		GameObject.FindGameObjectWithTag("ChatUIButton").GetComponent<BadgeAlert>().Count = counter;
	}
}