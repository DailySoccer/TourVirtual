using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[ExecuteInEditMode]
public class TopBarFanLevel : MonoBehaviour {

	public Image FillBar;
	public Text CurrentFanLevel;

	void Awake() {
		Debug.LogError("===> { \n TODO: Necesito la experiencia del 'Fan Level' actual \n  Hay que definirla (quien lo tenga que definir) \n } <==");
	}
	
	void Update () {
		if (FillBar != null)
			//TODO: cuando tenga el level actual quitar el deltaTime y poner el currentLevelExp.
			FillBar.fillAmount = Mathf.Clamp (Time.deltaTime, 0, 1);

		if (CurrentFanLevel != null && UserAPI.Instance != null)
			CurrentFanLevel.text = UserAPI.Instance.Level.ToString ();
	}
}
