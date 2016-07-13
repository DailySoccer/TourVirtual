using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using SmartLocalization;

public class ModalHiddenObjectsGameScreen : GUIPopUpScreen {

	public Text ModalText;
	public bool StartGameAfterClose;
	public Button shareToFBButton;
	string currentScore;

	public bool IsGameFinished;

	// Use this for initialization
	void Start () {
		#if !(UNITY_EDITOR || UNITY_IOS || UNITY_ANDROID)
			shareToFBButton.gameObject.SetActive (false);
		#endif
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void Launch_HiddenObjectModal(HiddenObjects.HiddenObjectGameResult modalType, string objetosEncontrados = "10 / 10", bool startGameAfterClose = false) {
		shareToFBButton.gameObject.SetActive (false);
		currentScore = objetosEncontrados;

		switch (modalType) {
			case HiddenObjects.HiddenObjectGameResult.SUCCESS:
			IsGameFinished = true;
				// TODO: establecer mensajes yield sustituciones
				ModalText.text = LanguageManager.Instance.GetTextValue("TVB.Minigame.HiddenSuccess").Replace("@count", objetosEncontrados);
				shareToFBButton.gameObject.SetActive (true);
			break;
			case HiddenObjects.HiddenObjectGameResult.TIME_OUT:
			IsGameFinished = true;
				ModalText.text = LanguageManager.Instance.GetTextValue("TVB.Minigame.HiddenTimeOut");
				shareToFBButton.gameObject.SetActive (false);
			break;
			case HiddenObjects.HiddenObjectGameResult.TUTORIAL_INICIO:
			IsGameFinished = false;
				ModalText.text = LanguageManager.Instance.GetTextValue("TVB.Minigame.HiddenTutorial");
				shareToFBButton.gameObject.SetActive (false);
			break;		
		}
		IsOpen = true;
		StartGameAfterClose = startGameAfterClose;
	}

	public void ShareScoreWithFB() {
		#if UNITY_EDITOR
		Debug.LogErrorFormat("Trying to share score with Facebook: points {0} -> Record<{1}>", currentScore, "false");
		#endif
		
		FacebookManager.Instance.ShareToFacebook(FacebookLink.PointsShare(false, currentScore, FacebookLink.GameType.TESORO));
	}
}
