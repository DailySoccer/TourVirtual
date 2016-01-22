using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[ExecuteInEditMode]
public class LoadingBar : MonoBehaviour {

	public Image fillBar;
	public Text description;
	public int MaxLoad = 100;
	public int CurrentLoad = 10;

	public void SetValue(int value) { 
		value = Mathf.Clamp (value, 0, MaxLoad);
	}

	public void SetValue(int value, string texto) { 
		SetValue (value);
		description.text = texto;
	}

	// Update is called once per frame
	void Update () {
		if (fillBar != null) {
			fillBar.fillAmount = (float) CurrentLoad / (float) MaxLoad;
		}
	}

}
