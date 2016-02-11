using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TopBarVirtualCoins : MonoBehaviour {

	public Text CurrentVirtualCoins;

	void Awake() {
		Debug.LogError("===> { \n TODO:  UserAPI.Instance.Points son los escudos (virtual coins) ? \n } <==");
	}

	void Update () {
		CurrentVirtualCoins.text = UserAPI.Instance.Points.ToString ();
	}
}
