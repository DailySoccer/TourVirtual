using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TopBarVirtualCoins : MonoBehaviour {

	public Text CurrentVirtualCoins;

	void Awake() {
	}

	void Update () {
		if (UserAPI.Instance != null)
			CurrentVirtualCoins.text = UserAPI.Instance.Points.ToString ();
	}
}
