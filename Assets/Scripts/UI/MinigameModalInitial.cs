using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using SmartLocalization;

public class MinigameModalInitial : MonoBehaviour {

	public Text UserMaxScore;
	public GameObject RankingParentList;
	public GameObject RankingSlotElement;

	public UserAPI.MiniGame MinigameType = UserAPI.MiniGame.FreeShoots;

	public int MAX_RANKING_COUNT = 6;

	List<GameObject> rankingSlots = new List<GameObject>();



	// Use this for initialization
	void Start () {
		UpdateData ();
	}

	void CleanRanking() { 
		foreach (GameObject go in rankingSlots) {
			DestroyImmediate(go);
		}
	}
	public void UpdateData() {
		string MaxScoreText;
		if (UserAPI.Instance == null) {
			MaxScoreText = string.Format("{0} \n <size=86>{1}</size>", LanguageManager.Instance.GetTextValue("TVB.Minigame.BestScore"), 0);
			Debug.LogError("[MinigameModalInitial in " + name + "]: No se ha iniciado el UserAPI. El MaxScore será 0");
		} else {
			MaxScoreText = string.Format("{0} \n <size=86>{1}</size>", LanguageManager.Instance.GetTextValue("TVB.Minigame.BestScore") ,UserAPI.Instance.GetScore(MinigameType));
		}
		UserMaxScore.text = MaxScoreText;

		UserAPI.Instance.GetRanking( MinigameType, RankingDataCallBack);
	}

	public void RankingDataCallBack() {
		UserAPI.ScoreEntry[] ranking;
		CleanRanking ();

		if (UserAPI.Instance == null) {
			ranking = new UserAPI.ScoreEntry[MAX_RANKING_COUNT];
			for (int i = 0; i < ranking.Length; i++ ) {
				ranking[i].Nick = "Noname-" + i.ToString();
				ranking[i].Score = 10 - i;
			}
			Debug.LogError("[MinigameModalInitial in " + name + "]: No se ha iniciado el UserAPI. El Ranking estará vacío");
			//return;
		} else {
			ranking = UserAPI.Instance.GetHighScore (MinigameType);
		}
		if (ranking != null)
		{
			int numSlots = ranking.Length < MAX_RANKING_COUNT ? ranking.Length : MAX_RANKING_COUNT;
			
			for (int i = 0; i < numSlots; i++)
			{
				GameObject r = Instantiate(RankingSlotElement);
				r.GetComponent<RankingSlot>().Setup((i + 1).ToString(), ranking[i].Nick, ranking[i].Score.ToString());
				r.transform.SetParent(RankingParentList.transform);
				r.transform.localScale = Vector3.one;
				r.name = "RankingPos_" + i.ToString();
				rankingSlots.Add(r);
			}
		}
	}
}
