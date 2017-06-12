using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Soomla;

public class InitialTutorial : MonoBehaviour {

	public static InitialTutorial Instance { private set; get; }

	public event Action TutorialFinish;

	public List<GameObject> OrderedTutorialScreens = new List<GameObject>();
	Animator _myAnimatorController;
	int tutTimes;

	int _currentScreenId;

	void Awake() {
		Instance = this;
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update ()
	{
	}

	void ResetTutorial()
	{
		_currentScreenId = 0;
		if (_myAnimatorController == null)
			_myAnimatorController = GetComponent<Animator> ();

		_myAnimatorController.SetBool ("IsOpen", true);

		foreach (GameObject screen in OrderedTutorialScreens) {
			screen.GetComponent<Animator>().SetBool("IsOpen", false);
		}

		foreach (GameObject screen in OrderedTutorialScreens) {
			screen.SetActive(false);
		}
	}

	public void StartTutorial()
	{
		ResetTutorial ();
		StartCoroutine (LaunchTutorial ());

        AnalyticsManager.Instance.OpenHelp();
	}

	IEnumerator LaunchTutorial()
	{
		while (!InOpenState)
			yield return null;

		StartCoroutine (ShowNextScreen ());
	}

	public bool InOpenState
	{
		get
		{
			if (_myAnimatorController == null)
				return false;
			AnimatorStateInfo animStateInfo = _myAnimatorController.GetCurrentAnimatorStateInfo(0);
			return animStateInfo.IsName("Open") && animStateInfo.normalizedTime >= 1f;
		}
	}

	IEnumerator FinishTutorial()
	{
		yield return new WaitForSeconds (0.5f);
		GameObject lastScreen = OrderedTutorialScreens [_currentScreenId - 1];

		AnimatorStateInfo anim = lastScreen.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0);

		// Esperamos a que se cierre la ultima screen ...
		while (!anim.IsName("Close") && anim.normalizedTime < 1f)
			yield return null;

		// ... cerramos la modal
		_myAnimatorController.SetBool ("IsOpen", false);

		PlayerPrefs.SetInt ("tutorial_done", PlayerPrefs.GetInt ("tutorial_done") + 1);
		PlayerPrefs.Save ();

		OnTutorialFinish();
	}

	


	private IEnumerator ShowNextScreen() {
		GameObject currentScreen = OrderedTutorialScreens [_currentScreenId];
		currentScreen.SetActive (true);
		while (!currentScreen.GetActive()) {
			yield return null;
		}

		if (_currentScreenId > 0)
			ChangeScreenVisibility (OrderedTutorialScreens [_currentScreenId - 1], false);

		ChangeScreenVisibility (currentScreen, true);
		_currentScreenId++;
	}

	private void ChangeScreenVisibility(GameObject sc, bool visible)
	{
		sc.GetComponent<Animator>().SetBool ("IsOpen", visible);
	}

	public void OkButton_Click()
	{
		if (_currentScreenId < OrderedTutorialScreens.Count)
			StartCoroutine (ShowNextScreen ());
		else {
			// Cerramos la ultima screen
			ChangeScreenVisibility (OrderedTutorialScreens [_currentScreenId - 1], false);
			StartCoroutine (FinishTutorial ());
		}
	}

	private void ConfigureModal()
	{
		return;
	}


	protected void OnTutorialFinish()
	{
		var e = TutorialFinish;
		if (e != null)
			e();

        AnalyticsManager.Instance.CloseHelp();
	}

	
}
