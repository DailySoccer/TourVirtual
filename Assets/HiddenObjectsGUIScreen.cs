using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HiddenObjectsGUIScreen : GUIScreen {

	public MinigameTimerHUD TheTimer;
	public Text TxTScore;
	//Arrastramos aqui el Main Manager
	//public  HiddenObjects.HiddenObjects minigameController;
	
	// Use this for initialization
	void Awake () {
	}
	
	// Update is called once per frame
	void Update () {
		TxTScore.text = HiddenObjects.HiddenObjects.Instance.numFoundObjects + " / " + HiddenObjects.HiddenObjects.Instance.numHiddenObjects;
		TheTimer.TimeLeft = 1 - (HiddenObjects.HiddenObjects.Instance.RemaingTime / HiddenObjects.HiddenObjects.Instance.maxTime);
		/*Debug.Log(string.Format("[HiddenObjectsGUIScreen] in {0}: HiddenObjectsMinigame[ RemaingTime: {1}  +++ maxTime: {2}]", 
		                        name, HiddenObjects.HiddenObjects.Instance.RemaingTime, HiddenObjects.HiddenObjects.Instance.maxTime));*/
	}
}
