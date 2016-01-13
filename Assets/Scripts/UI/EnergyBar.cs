using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[ExecuteInEditMode]
public class EnergyBar : MonoBehaviour {

	public Image fillBar;
	public Text currentEnergy;
	public int MaxEnergy = 10;
	public int currentValue = 10;

	public void addValue(float value) { 
		value = Mathf.Clamp (value + value, 0f, 1f);
	}

	// Update is called once per frame
	void Update () {
		if (fillBar != null) {
			fillBar.fillAmount = currentValue / (float) MaxEnergy;
			currentEnergy.text  = string.Format("{0}/{1}", "<color=#ade332>" + currentValue + "</color>", MaxEnergy);
		}
	}

}
