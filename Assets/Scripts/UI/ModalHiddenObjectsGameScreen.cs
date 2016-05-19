using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using SmartLocalization;

public class ModalHiddenObjectsGameScreen : GUIPopUpScreen {

	public Text ModalText;
	public bool StartGameAfterClose;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Launch_HiddenObjectModal(HiddenObjects.HiddenObjectGameResult modalType, string objetosEncontrados = "10 / 10", bool startGameAfterClose = false) {
	
		switch (modalType) {
		case HiddenObjects.HiddenObjectGameResult.SUCCESS:
			// TODO: establecer mensajes yield sustituciones
			ModalText.text = LanguageManager.Instance.GetTextValue("TVB.Minigame.HiddenSuccess").Replace("@count", objetosEncontrados);
			break;
		case HiddenObjects.HiddenObjectGameResult.TIME_OUT:
			ModalText.text = LanguageManager.Instance.GetTextValue("TVB.Minigame.HiddenTimeOut");
			break;
		case HiddenObjects.HiddenObjectGameResult.TUTORIAL_INICIO:
			ModalText.text = LanguageManager.Instance.GetTextValue("TVB.Minigame.HiddenTutorial");
			break;		
		}
		IsOpen = true;
		StartGameAfterClose = startGameAfterClose;
	}
}
