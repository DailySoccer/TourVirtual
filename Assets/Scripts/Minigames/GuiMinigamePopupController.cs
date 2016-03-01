using UnityEngine;
using System.Collections;

public enum MinigameModalLayout {
	TutorialScreen,
	InitialScreen,
	FinalScreen
}

public class GuiMinigamePopupController : MonoBehaviour {

	public GameObject ModalContentTutorial;
	public GameObject ModalContentInicial;
	public GameObject ModalContentFinal;

	public MinigameCanvasController CanvasRootController;

	public void SetModalLayout (MinigameModalLayout layout) {
		switch (layout) {
		case MinigameModalLayout.TutorialScreen:
			ModalContentTutorial.SetActive(true);
			ModalContentInicial.SetActive(false);
			ModalContentFinal.SetActive(false);
			break;
		case MinigameModalLayout.InitialScreen:
			ModalContentInicial.GetComponent<MinigameModalInitial>().UpdateData();
			ModalContentTutorial.SetActive(false);
			ModalContentInicial.SetActive(true);
			ModalContentFinal.SetActive(false);
			break;
		case MinigameModalLayout.FinalScreen:
			ModalContentFinal.GetComponent<MinigameModalFinal>().UpdateData();
			ModalContentTutorial.SetActive(false);
			ModalContentInicial.SetActive(false);
			ModalContentFinal.SetActive(true);
			break;
		}
	}
}
