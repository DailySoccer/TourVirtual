using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HiddenObjectsGUIScreen : GUIScreen {

	public MinigameTimerHUD TheTimer;
	public Text TxTScore;

	void Awake () {
	}
	
	// Update is called once per frame
	void Update () {
		TxTScore.text = HiddenObjects.HiddenObjects.Instance.numFoundObjects + " / " + HiddenObjects.HiddenObjects.Instance.numHiddenObjects;
		TheTimer.TimeLeft = 1 - (HiddenObjects.HiddenObjects.Instance.RemaingTime / HiddenObjects.HiddenObjects.Instance.maxTime);
	}
}
