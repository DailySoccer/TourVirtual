using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoresResume : MonoBehaviour {

	public Text penaltyScore;
	public Text BasketScore;
	public Text HiddenObjectasScore;
	
	// Use this for initialization
	void Start () {
	
	}

	void OnEnable() {
		penaltyScore.text = 'Not recolected yet';
		BasketScore.text = 'Not recolected yet';
		HiddenObjectasScore.text = 'Not recolected yet';
	}
	
	// Update is called once per frame
	void Update () {
	
	}

}
