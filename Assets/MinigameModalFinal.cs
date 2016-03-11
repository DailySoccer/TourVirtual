#if !LITE_VERSION

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MinigameModalFinal : MonoBehaviour {

	public Text BestScore;
	public Text LastScore;

	public UserAPI.MiniGame MinigameType = UserAPI.MiniGame.FreeShoots;

	// Use this for initialization
	void Start () {
	
	}

	public void UpdateData () {
		if (UserAPI.Instance == null)
			BestScore.text = string.Format("TU MEJOR PUNTUACIÓN \n <size=86>{0}</size>", "0");
		else
			BestScore.text = string.Format("TU MEJOR PUNTUACIÓN \n <size=86>{0}</size>", UserAPI.Instance.GetScore (MinigameType).ToString());

		if (MinigameType == UserAPI.MiniGame.FreeShoots) {
			LastScore.text = string.Format("PUNTOS CONSEGUIDOS \n <size=86>{0}</size>", GameObject.Find("Shooter").GetComponent<Basket.Shooter>().score);
		} else {
			LastScore.text = string.Format("PUNTOS CONSEGUIDOS \n <size=86>{0}</size>", GameObject.Find("Shooter").GetComponent<Football.Shooter>().score);
		}
	}
}
#endif