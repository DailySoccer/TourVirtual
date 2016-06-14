using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InitialTutorial : MonoBehaviour {

	public static InitialTutorial Instance { private set; get; }

	public List<GameObject> OrderedTutorialScreens = new List<GameObject>();
	Animator _myAnimatorController;

	int _currentScreenId;

	void Awake() {
		Instance = this;
	}

	// Use this for initialization
	void Start () {
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
		if (PlayerPrefs.GetInt ("tutorial_done") > 0)
			return;

		Initialize ();
		StartCoroutine (LaunchTutorial ());
	}

	IEnumerator LaunchTutorial() {
		while (!InOpenState)
			yield return null;

		ShowNextScreen ();
	}

	public bool InOpenState {
		get {
			return _myAnimatorController.GetCurrentAnimatorStateInfo(0).IsName("Open");
		}
	}

	void FinishTutorial() {
		_myAnimatorController.SetBool ("IsOpen", false);
		PlayerPrefs.SetInt ("tutorial_done", 1);
	}

	void ShowNextScreen() {
		if (_currentScreenId > 0)
			ChangeScreenVisibility (OrderedTutorialScreens [_currentScreenId - 1], false);

		ChangeScreenVisibility (OrderedTutorialScreens [_currentScreenId], true);

		_currentScreenId++;
	}

	void ChangeScreenVisibility(GameObject sc, bool visible) {
		sc.GetComponent<Animator> ().SetBool ("IsOpen", visible);
	}

	public void OkButton_Click() {
		if (_currentScreenId < OrderedTutorialScreens.Count )
			ShowNextScreen ();
		else
			FinishTutorial ();
	}

	void ConfigureModal() {
		return;
	}

}
