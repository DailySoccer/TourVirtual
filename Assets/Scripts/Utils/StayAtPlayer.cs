using UnityEngine;
using System.Collections;

public class StayAtPlayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
		var avatar = Player.Instance.Avatar;
		if (avatar) {
			transform.position = avatar.transform.position;
			transform.rotation = avatar.transform.rotation;
		}
	}
}
