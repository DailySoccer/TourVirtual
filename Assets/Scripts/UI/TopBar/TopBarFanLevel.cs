using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TopBarFanLevel : MonoBehaviour {

	public Image FillBar;
	public Text CurrentFanLevel;

	void Awake() {
		//Debug.LogError("===> { \n TODO: Necesito la experiencia del 'Fan Level' actual \n  Hay que definirla (quien lo tenga que definir) \n } <==");
	}
	
	void Update () {
		if (CurrentFanLevel != null && UserAPI.Instance != null) {
			CurrentFanLevel.text = UserAPI.Instance.Level.ToString ();
			FillBar.fillAmount = UserAPI.Instance.NextLevel;
		}
	}
}
