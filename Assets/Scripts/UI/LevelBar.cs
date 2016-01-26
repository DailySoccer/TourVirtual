using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[ExecuteInEditMode]
public class LevelBar : MonoBehaviour {

    public Image fillBar;
	public float Current = 0;
	
	public void SetValue(float value) {
        Current = Mathf.Clamp (value, 0, 1);
	}

	// Update is called once per frame
	void Update () {
		if (fillBar != null) {
			fillBar.fillAmount = Current;
		}
	}
}
