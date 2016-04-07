using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HiddenObjectsGUIScreen : GUIScreen {

	public MinigameTimerHUD TheTimer;
	public Text TxTScore;


	//Arrastramos aqui el mainmanager
	public  HiddenObjects.HiddenObjects minigameController;
	
	// Use this for initialization
	void Awake () {
	}

	public void SetupTheHUD() {
		//minigameController = MainManager.Instance.GetComponent<HiddenObjects.HiddenObjects> ();
	}

	// Update is called once per frame
	void Update () {
		TxTScore.text = minigameController.numFoundObjects + " / " + minigameController.numHiddenObjects;
		TheTimer.TimeLeft = 1 - (minigameController.RemaingTime / minigameController.maxTime);
	}
}
