using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using SmartLocalization;

public class ModalHiddenObjectsGameScreen : GUIPopUpScreen {

	public Text ModalText;
	public bool StartGameAfterClose;
	public Button shareToFBButton;
	string currentScore;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Launch_HiddenObjectModal(HiddenObjects.HiddenObjectGameResult modalType, string objetosEncontrados = "10 / 10", bool startGameAfterClose = false) {
		shareToFBButton.gameObject.SetActive (false);
		currentScore = objetosEncontrados;

		switch (modalType) {
		case HiddenObjects.HiddenObjectGameResult.SUCCESS:
			// TODO: establecer mensajes yield sustituciones
			ModalText.text = LanguageManager.Instance.GetTextValue("TVB.Minigame.HiddenSuccess").Replace("@count", objetosEncontrados);
			shareToFBButton.gameObject.SetActive (true);
			break;
		case HiddenObjects.HiddenObjectGameResult.TIME_OUT:
			ModalText.text = LanguageManager.Instance.GetTextValue("TVB.Minigame.HiddenTimeOut");
			//sareToFBButton.gameObject.SetActive (true);
			break;
		case HiddenObjects.HiddenObjectGameResult.TUTORIAL_INICIO:
			ModalText.text = LanguageManager.Instance.GetTextValue("TVB.Minigame.HiddenTutorial");
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
