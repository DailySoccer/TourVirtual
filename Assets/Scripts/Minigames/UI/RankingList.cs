#if !LITE_VERSION
using UnityEngine;
using System.Collections;

public class RankingList : MonoBehaviour {

	public GameObject RankingSlotPrefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void AddRankingSlot (string positionNumber, string playerName, string playerscore) {
		GameObject slot = Instantiate (RankingSlotPrefab);
		slot.transform.parent = transform;
		slot.transform.localScale = Vector3.one;
		slot.GetComponent<RankingSlot> ().Setup (positionNumber, playerName, playerscore);
	}
}
#endif