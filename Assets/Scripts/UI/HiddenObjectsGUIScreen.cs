using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HiddenObjectsGUIScreen : GUIScreen {

	public MinigameTimerHUD TheTimer;
	public Text TxTScore;

	int maxHiddenObjects;
	int countHiddenObjects;

	public float timeUpdateCicle = 1f;
	float timer;

	void Start () {
		int maxHiddenObjects = HiddenObjects.HiddenObjects.Instance.numHiddenObjects;
		int countHiddenObjects = 0;
		timer = timeUpdateCicle;
		ResetTheTimer();
	}

	public void ResetTheTimer() {
		TheTimer.TimeLeft = 0;
	}

	// Update is called once per frame
	void Update () {
		if (countHiddenObjects != HiddenObjects.HiddenObjects.Instance.numFoundObjects) {
			countHiddenObjects = HiddenObjects.HiddenObjects.Instance.numFoundObjects;
			TxTScore.text = countHiddenObjects + " / " + maxHiddenObjects;
		}
		timer += Time.deltaTime;
		if (timer >= timeUpdateCicle) {
			timer = timer % timeUpdateCicle; 
			TheTimer.TimeLeft = 1 - (HiddenObjects.HiddenObjects.Instance.RemaingTime / HiddenObjects.HiddenObjects.Instance.maxTime);
		}
	}
}
