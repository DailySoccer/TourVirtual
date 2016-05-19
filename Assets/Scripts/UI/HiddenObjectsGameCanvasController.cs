using UnityEngine;
using System.Collections;

public class HiddenObjectsGameCanvasController : MonoBehaviour {

	//public UIScreen HiddenObjectsMinigameHUD;
	public ModalHiddenObjectsGameScreen ModalHiddenObjectsGameScreen;
	public GameObject TopMenu;

	GameCanvasManager gcm;
	Animator _topMenuAnimator;

	HiddenObjects.HiddenObjects hiddenObjs;

	// Use this for initialization
	void Awake () {
		gcm = GameObject.FindGameObjectWithTag ("GameCanvasManager").GetComponent<GameCanvasManager> ();
		_topMenuAnimator = TopMenu.GetComponent<Animator> ();

		hiddenObjs = HiddenObjects.HiddenObjects.Instance;//GameObject.FindGameObjectWithTag ("MainManager").GetComponent<HiddenObjects.HiddenObjects> ();
	}

	void OnEnable() {
		GetComponent<HiddenObjectsGameCanvasController>().IsHiddenObjectHUD_Open = HiddenObjects.HiddenObjects.Instance.enabled;
	}

	void OnDisable() {
		hiddenObjs.OnGameSuccess -= HandleOnGameSuccess;
		hiddenObjs.OnGameFail -= HandleOnGameFail;
	}

	void Start() {
	}
	
	void Update () {	
	}

	void HandleOnGameSuccess ()
	{
		HiddenObjectsGameOver();
	}

	void HandleOnGameFail ()
	{
		HiddenObjectsGameOver ();
	}

	void HiddenObjectsGameOver() {
		hiddenObjs.OnGameSuccess -= HandleOnGameSuccess;
		hiddenObjs.OnGameFail -= HandleOnGameFail;
		IsHiddenObjectHUD_Open = false;
	}

	public void LaunchHiddenObjectMinigameModal() {
		ModalHiddenObjectsGameScreen.Launch_HiddenObjectModal (HiddenObjects.HiddenObjectGameResult.TUTORIAL_INICIO, "", true);
	}


	public void StartHiddenObjectsGame() {
		hiddenObjs.OnGameSuccess += HandleOnGameSuccess;
		hiddenObjs.OnGameFail += HandleOnGameFail;

		// Cerramos la modal
		ModalHiddenObjectsGameScreen.IsOpen = false;

		if (ModalHiddenObjectsGameScreen.StartGameAfterClose) {
			// Comienza el juego
			hiddenObjs.Play (ModalHiddenObjectsGameScreen);
			//Activa el hud de hiddenObjects
			IsHiddenObjectHUD_Open = true;
		}
	}

	public void ForceStopHiddenObjectsGame() {
		// Finaliza el juego
		hiddenObjs.Stop();
		//Desctiva el hud de hiddenObjects
		HiddenObjectsGameOver ();
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
