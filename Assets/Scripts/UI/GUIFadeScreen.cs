using UnityEngine;
using System.Collections;

public class GUIFadeScreen : UIScreen {
	
	public GameObject CircleIn;
	public GameObject CircleOut;
	public float speed = 40f;

	void OnEnable() {
	}

	void Start () {
	}
	
	void Update () {
		if (CircleIn != null && CircleOut != null) {
			CircleIn.transform.Rotate(0, 0, -Time.deltaTime * speed);
			CircleOut.transform.Rotate(0, 0, Time.deltaTime * speed);
		}
	}
}
