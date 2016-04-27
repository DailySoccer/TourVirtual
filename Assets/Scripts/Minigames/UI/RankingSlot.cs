using UnityEngine;
using UnityEngine.UI;

public class RankingSlot : MonoBehaviour {

	public Text PositionNumber;
	public Text PlayerName;
	public Text PlayerScore;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Setup (string positionNumber, string playerName, string playerscore) {
		PositionNumber.text = positionNumber;
		PlayerName.text = playerName;
		PlayerScore.text = playerscore;
	}
}