using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TopBar : MonoBehaviour {

	public Text UserName;
	
	void Awake () {
		UserName.text = UserAPI.Instance.Nick;
	}
}
