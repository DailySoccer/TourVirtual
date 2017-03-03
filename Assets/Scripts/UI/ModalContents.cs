using UnityEngine;
using System.Collections;

public class ModalContents : MonoBehaviour {

	public static ModalContents Instance{ get; private set;}
	public GUIPopUpScreen ModalScreen;
	// Use this for initialization

	void Awake(){
		Instance = this;
	}

	public void ShowModalScreen(int newModalLayout)
	{

		if (ModalScreen == null) {
//			Debug.LogError("[CanvasManager in " + name + "]: La guiModalScreen es null. Quizás no has establecido la primera desde el inspector.");
			return;
		}

		// Lanzamos la modal, solo si está cerrada previamente.
		HideModalScreen ();
		if(((ModalLayout) newModalLayout!=ModalLayout.SETTINGS && (ModalLayout)newModalLayout!=ModalLayout.BLANK))
			if( Authentication.Instance.CheckOffline()) 
				return;

		StartCoroutine (ModalCloseBeforeOpenAgain(newModalLayout));
	}

	IEnumerator ModalCloseBeforeOpenAgain(int newModalLayout) {

		while (ModalScreen.InOpenState) {
			yield return null;
		}

		ModalScreen.IsOpen = true;
		ModalScreen.GetComponent<CanvasGroup>().interactable = true;
		
		PopUpWindow modalPopUpWindow = ModalScreen.GetComponent<PopUpWindow> ();
		modalPopUpWindow.CurrentModalLayout = (ModalLayout)newModalLayout;
	}

	public void HideModalScreen() {
		//if (ModalScreen != null) {
		ModalScreen.IsOpen = false;
		ModalScreen.GetComponent<CanvasGroup> ().interactable = false;
		ModalScreen.GetComponent<PopUpWindow>().SetState(ModalLayout.BLANK);
		//}
	}

	public void OpenOptions(){
		ModalContents.Instance.ShowModalScreen(10);
	}
	
}
