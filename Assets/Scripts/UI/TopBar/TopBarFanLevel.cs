#if !LITE_VERSION

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TopBarFanLevel : MonoBehaviour {

	public Image FillBar;
	public Text CurrentFanLevel;

	void Awake() {
		//Debug.LogError("===> { \n TODO: Necesito la experiencia del 'Fan Level' actual \n  Hay que definirla (quien lo tenga que definir) \n } <==");
	}
    float oldNextLevel = -1;
    int oldLevel = -1;
    void Update () {
		if (CurrentFanLevel != null && UserAPI.Instance != null && 
            (oldNextLevel!= UserAPI.Instance.NextLevel || oldLevel!= UserAPI.Instance.Level)) {
            oldNextLevel = UserAPI.Instance.NextLevel;
            oldLevel = UserAPI.Instance.Level;
            CurrentFanLevel.text = UserAPI.Instance.Level.ToString ();
			FillBar.fillAmount = UserAPI.Instance.NextLevel;
		}
	}
}
#endif