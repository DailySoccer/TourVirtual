using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using SmartLocalization;

public class MinigameModalFinal : MonoBehaviour {

	public Text BestScore;
	public Text LastScore;
	public GameObject ShareButton;

	public UserAPI.MiniGame MinigameType = UserAPI.MiniGame.FreeShoots;

	// Use this for initialization
	void Start () {
		#if !(UNITY_EDITOR || UNITY_IOS || UNITY_ANDROID)
			ShareButton.SetActive (false);
		#endif
	}

	/*
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
	*/
	public void UpdateData () {
		BestScore.text = "-";
		LastScore.text = "-";

		if (UserAPI.Instance == null)
			BestScore.text = string.Format("{0} \n <size=86>{1}</size>", LanguageManager.Instance.GetTextValue("TVB.Minigame.BestScore"), "0");
		else
			BestScore.text = string.Format("{0} \n <size=86>{1}</size>", LanguageManager.Instance.GetTextValue("TVB.Minigame.BestScore"), UserAPI.Instance.GetScore (MinigameType).ToString());
		
		if (MinigameType == UserAPI.MiniGame.FreeShoots) {
			LastScore.text = string.Format("{0} \n <size=86>{1}</size>", LanguageManager.Instance.GetTextValue("TVB.Minigame.YourScore"), GameObject.Find("Shooter").GetComponent<Basket.Shooter>().score);
		} else {
			LastScore.text = string.Format("{0} \n <size=86>{1}</size>", LanguageManager.Instance.GetTextValue("TVB.Minigame.YourScore"), GameObject.Find("Shooter").GetComponent<Football.Shooter>().score);
		}
	}
}