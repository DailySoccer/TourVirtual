using UnityEngine;
using System.Collections;

public class HiddenObjectsGameCanvasController : MonoBehaviour {

	//public UIScreen HiddenObjectsMinigameHUD;
	public GUIPopUpScreen ModalHiddenObjectsGameScreen;
	public GameObject TopMenu;

	GameCanvasManager gcm;
	Animator _topMenuAnimator;

	// Use this for initialization
	void OnEnable () {
		gcm = GameObject.FindGameObjectWithTag ("GameCanvasManager").GetComponent<GameCanvasManager> ();
		_topMenuAnimator = TopMenu.GetComponent<Animator> ();
	}

	void Start() {
	}

	void Update () {	
	}

	public void LaunchHiddenObjectMinigameModal() {
		ModalHiddenObjectsGameScreen.IsOpen = true;
	}

	public void StartHiddenObjectsGame() {
		// Cerramos la modal
		ModalHiddenObjectsGameScreen.IsOpen = false;
		// Comienza el juego
		GameObject.FindGameObjectWithTag ("MainManager").GetComponent<HiddenObjects.HiddenObjects>().Play();
		//Activa el hud de hiddenObjects
		IsHiddenObjectHUD_Open = true;
	}

	public void StopHiddenObjectsGame() {
		// Finaliza el juego
		GameObject.FindGameObjectWithTag("MainManager").GetComponent<HiddenObjects.HiddenObjects>().Stop();
		//Desctiva el hud de hiddenObjects
		IsHiddenObjectHUD_Open = false;
	}


	public bool IsHiddenObjectHUD_Open
	{
		get { return Animator.GetBool("IsOpen"); }
		set {
			if (Animator != null) {
				Animator.SetBool("IsOpen", value);
			}
		}
	}

	public Animator Animator {
		get {
			if (_topMenuAnimator == null) {
				_topMenuAnimator = GetComponent<Animator> ();
			}
			return _topMenuAnimator;
		}
	}
}
