#if !LITE_VERSION
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[ExecuteInEditMode]
public class MinigameTimerHUD : MonoBehaviour {

	public Image Clock;
	public float TimeLeft;

	// Use this for initialization
	void Start () {
		if (TimeLeft == null) {
			Debug.LogError("[MinigameTimerHUD] in" + name + ": MinigameTimerHUD: No hay ningun grafico que con 'ImageType: filled -> Radial360' asignado en este script" );
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (TimeLeft != null) {
			Clock.fillAmount = TimeLeft;
		}

		TimeLeft = Mathf.Clamp (TimeLeft, 0f, 1f);
	}
}
#endif