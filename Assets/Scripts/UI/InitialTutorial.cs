using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InitialTutorial : MonoBehaviour {

	public static InitialTutorial Instance { private set; get; }

	public List<GameObject> OrderedTutorialScreens = new List<GameObject>();
	Animator _myAnimatorController;
	int tutTimes;

	int _currentScreenId;

	void Awake() {
		Instance = this;
	}

	// Use this for initialization
	void Start () {
		tutTimes = PlayerPrefs.GetInt ("tutorial_done");
	}
	
	// Update is called once per frame
	void Update () {
	}

	void Initialize() {
		if (_myAnimatorController == null)
			_myAnimatorController = GetComponent<Animator> ();

		_myAnimatorController.SetBool ("IsOpen", true);

		foreach (GameObject screen in OrderedTutorialScreens) {
			screen.GetComponent<Animator>().SetBool("IsOpen", false);
		}
		
		_currentScreenId = 0;
	}

	public void SartTutorial() {
		Initialize ();
		StartCoroutine (LaunchTutorial ());
	}

	IEnumerator LaunchTutorial() {
		while (!InOpenState)
			yield return null;

		StartCoroutine (ShowNextScreen ());
	}

	public bool InOpenState {
		get {
			AnimatorStateInfo animStateInfo = _myAnimatorController.GetCurrentAnimatorStateInfo(0);
			return animStateInfo.IsName("Open") && animStateInfo.normalizedTime >= 1f;
		}
	}

	IEnumerator FinishTutorial() {
		yield return new WaitForSeconds (0.5f);
		GameObject lastScreen = OrderedTutorialScreens [_currentScreenId - 1];

		AnimatorStateInfo anim = lastScreen.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0);

		// Esperamos a que se cierre la ultima screen ...
		while (!anim.IsName("Close") && anim.normalizedTime < 1f)
			yield return null;

		// ... cerramos la modal
		_myAnimatorController.SetBool ("IsOpen", false);
		tutTimes += 1;
		PlayerPrefs.SetInt ("tutorial_done", tutTimes);
		PlayerPrefs.Save ();
	}

	IEnumerator ShowNextScreen() {
		GameObject currentScreen = OrderedTutorialScreens [_currentScreenId];

		while (!currentScreen.GetActive())
			yield return null;

		if (_currentScreenId > 0)
			ChangeScreenVisibility (OrderedTutorialScreens [_currentScreenId - 1], false);

		ChangeScreenVisibility (currentScreen, true);

		_currentScreenId++;
	}

	void ChangeScreenVisibility(GameObject sc, bool visible) {
		sc.GetComponent<Animator> ().SetBool ("IsOpen", visible);
	}

	public void OkButton_Click() {
		if (_currentScreenId < OrderedTutorialScreens.Count)
			StartCoroutine (ShowNextScreen ());
		else {
			// Cerramos la ultima screen
			ChangeScreenVisibility (OrderedTutorialScreens [_currentScreenId - 1], false);
			StartCoroutine (FinishTutorial ());
		}
	}

	void ConfigureModal() {
		return;
	}

}
