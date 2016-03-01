using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MinigameCanvasController : MonoBehaviour {

	public GuiMinigameScreen MainGUIScreen;
	private bool isMainGUIScreenOpen;

	public GUIPopUpScreen ModalPopUpScreen;
	private bool isModalGUIScreenOpen;
	bool isShowingTut;

	public GuiMinigamePopupController GuiMinigameScreenPopupManager;

	public UserAPI.MiniGame MinigameType = UserAPI.MiniGame.FreeShoots;

	public int RecordScore { get; set;}

	// Use this for initialization
	void Awake () {
		if ( UserAPI.Instance == null) {
			RecordScore = 0;
			Debug.LogError("[MinigameCanvasController in " + name + "]: No se ha iniciado el UserAPI. El record será 0");
		} else {		         
			RecordScore = UserAPI.Instance.GetScore(MinigameType);
		}

		// Mostramos la ventana popup con el ranking y el botón de jugar
		HideAllScreens ();
		ShowInitialScreen ();
	}

	IEnumerator ShowModalScreen(MinigameModalLayout layout) {
		if (ModalPopUpScreen != null) {
			if (isModalGUIScreenOpen) {
				ModalPopUpScreen.IsOpen = false;
				while(!ModalPopUpScreen.Animator.GetCurrentAnimatorStateInfo(0).IsName("Close")) {
					Debug.Log ("Esperando a que se cierre la modal actual");
					yield return null;
				}
			}
			GuiMinigameScreenPopupManager.SetModalLayout(layout);
			ModalPopUpScreen.IsOpen = true;
		
		} else {
			Debug.LogError("[MinigameCanvasController in " + name + " ]: La ModalPopUpScreen es null. Quizás no se ha establecido en el inspector.");
		}
	}

	void CloseModalScreen() {
		if (ModalPopUpScreen != null) {
			if (!isModalGUIScreenOpen) {
				ModalPopUpScreen.IsOpen = false;
			}
		} else {
			Debug.LogError("[MinigameCanvasController in " + name + " ]: La ModalPopUpScreen es null. Quizás no se ha establecido en el inspector.");
		}
	}

	public void ToggleMainHUD(bool visible) {
		if (MainGUIScreen != null) {
			isMainGUIScreenOpen = visible;
			MainGUIScreen.IsOpen = visible;
			MainGUIScreen.GetComponent<CanvasGroup>().interactable = visible;		
		} else {
			Debug.LogError("[MinigameCanvasController in " + name + " ]: La MainGUIScreen es null. Quizás no se ha establecido en el inspector.");
		}
	}

	public void StartGame() {
		// Si no hemos hecho puntos aún... es que nunca hemos jugado y mostramos el tutorial
		if (RecordScore == 0 && !isShowingTut) {
			StartCoroutine (ShowModalScreen (MinigameModalLayout.TutorialScreen));
			isShowingTut = true;
			return;
		}
		// Cerramos la modal abierta
		CloseModalScreen ();
		// Mostramos el hud
		ToggleMainHUD (true);
		GameObject.Find("Shooter").SendMessage("OnRetry");
	}

	void HideAllScreens() {
		if (isMainGUIScreenOpen) {
			ToggleMainHUD(false);
		}
		CloseModalScreen ();
	}
	public void ShowInitialScreen() {
		StartCoroutine (ShowModalScreen (MinigameModalLayout.InitialScreen));
	}

	public void ShowEndScreen() {
		StartCoroutine (ShowModalScreen (MinigameModalLayout.FinalScreen));
	}

	public void BackToRoom() {
		HideAllScreens ();
		RoomManager.Instance.GotoPreviousRoom ();
	}
}
