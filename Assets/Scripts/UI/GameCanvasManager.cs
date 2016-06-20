using UnityEngine;
using UnityEngine.UI;

public class GameCanvasManager : CanvasManager 
{
	private MainManager _mainManagerInstance;

	private Toggle _soundsToggle;
	private Toggle _musicToggle;


	private BadgeAlert badgeAlert;

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
		badgeAlert = GameObject.FindGameObjectWithTag("ChatUIButton").GetComponent<BadgeAlert>();

		_mainManagerInstance.OnMessagesUnreadedEvent += OnUnreadedMessages;
	}

	void OnEnable() {
		ShowScreen(currentGUIScreen);
	}
	private void OnUnreadedMessages(int counter) {
		badgeAlert.Count = counter;
	}
}