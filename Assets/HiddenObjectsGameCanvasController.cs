using UnityEngine;
using System.Collections;

public class HiddenObjectsGameCanvasController : MonoBehaviour {

	public GuiMinigameScreen HiddenObjectsMinigameHUD;
	
	public GUIPopUpScreen ModalHiddenObjectsGameScreen;

	GameCanvasManager gcm;

	// Use this for initialization
	void Awake () {
		gcm = GameObject.FindGameObjectWithTag ("GameCanvasManager").GetComponent<GameCanvasManager> ();
	}
	
	// Update is called once per frame
	void Update () {	
	}

	public void StartHiddenObjectsGame() {
		gcm.ShowScreen (HiddenObjectsMinigameHUD);
		ModalHiddenObjectsGameScreen.IsOpen = true;
	}
}
