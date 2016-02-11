using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TopBarEnergy : MonoBehaviour {

	public Image FillBar;
	Text currentEnergy;
	public Text CurrentEnergy;
	public int MaxEnergy = 10;

	void Awake() {
		Debug.LogError("===> { \n TODO: Necesito la 'Energía' que tiene el usuario \n  Hay que definir como se gasta (quien lo tenga que definir) \n } <==");
	}
	
	void Update () {
		if (FillBar != null)
			//TODO: cuando tenga la energía actual quitar el deltaTime y poner el currentEnergy.
			FillBar.fillAmount = Time.deltaTime * 10;// / (float) MaxEnergy;

		if (CurrentEnergy != null && UserAPI.Instance != null)
			CurrentEnergy.text  = string.Format("{0}/{1}", "<color=#ade332>" + (int)(Mathf.Clamp (Time.deltaTime, 0f, 1f)*100) + "</color>", MaxEnergy);

	}

}
