using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MinigameModalInitial : MonoBehaviour {

	public Text UserMaxScore;
	public GameObject RankingParentList;
	public GameObject RankingSlotElement;

	public UserAPI.MiniGame MinigameType = UserAPI.MiniGame.FreeShoots;

	List<GameObject> rankingSlots = new List<GameObject>();


	// Use this for initialization
	void Start () {
		UpdateData ();
	}

	void CleanRanking() { 
		foreach (GameObject go in rankingSlots) {
			Destroy(go);
		}
	}
	public void UpdateData() {
		CleanRanking ();

		string MaxScoreText;
		if (UserAPI.Instance == null) {
			MaxScoreText = string.Format("TU MEJOR PUNTUACIÓN \n <size=86>{0}</size>" , 0);
			Debug.LogError("[MinigameModalInitial in " + name + "]: No se ha iniciado el UserAPI. El MaxScore será 0");
		} else {
			MaxScoreText = string.Format("TU MEJOR PUNTUACIÓN \n <size=86>{0}</size>" ,UserAPI.Instance.GetScore(MinigameType));
		}
		UserMaxScore.text = MaxScoreText;

		UserAPI.ScoreEntry[] ranking;
		if (UserAPI.Instance == null) {
			ranking = new UserAPI.ScoreEntry[0];
			Debug.LogError("[MinigameModalInitial in " + name + "]: No se ha iniciado el UserAPI. El Ranking estará vacío");
			//return;
		} else {
			ranking = UserAPI.Instance.GetHighScore (MinigameType);
		}
		/*
		for(int i = 0; i < ranking.Length || i < 10; i++) {
			GameObject r = Instantiate(RankingSlotElement);
			r.GetComponent<RankingSlot>().Setup(i.ToString(), ranking[i].Nick, ranking[i].Score.ToString()); 
			rankingSlots.Add(r);
		}*/
	}
}
