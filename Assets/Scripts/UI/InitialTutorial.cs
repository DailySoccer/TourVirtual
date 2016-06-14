using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InitialTutorial : MonoBehaviour {

	public static InitialTutorial Instance { private set; get; }

	public List<GameObject> OrderedTutorialScreens = new List<GameObject>();
	Animator _myAnimatorController;

	int _currentScreenId;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	void Initialize() {
		if (_myAnimatorController != null)
			_myAnimatorController = GetComponent<Animator> ();

		_myAnimatorController.SetBool ("IsOpen", true);

		foreach (GameObject screen in OrderedTutorialScreens) {
			screen.GetComponent<Animator>().SetBool("IsOpen", false);
		}
		
		_currentScreenId = 0;
	}

	void ShowTutorial() {
		Initialize ();
		ShowNextScreen ();
	}

	void FinishTutorial() {
		_myAnimatorController.SetBool ("IsOpen", false);
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
}
