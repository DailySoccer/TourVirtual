using UnityEngine;
using System.Collections;

public class AsociateWithMainCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Camera.main) {
			GetComponent<Canvas>().worldCamera = Camera.main;
		}
	}
}
