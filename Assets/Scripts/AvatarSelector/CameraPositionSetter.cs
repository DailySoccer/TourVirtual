using UnityEngine;
using System.Collections;

public class CameraPositionSetter : MonoBehaviour {

	private Camera asociatedCamera;

	// Use this for initialization
	void Start () {
		asociatedCamera = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
		if (!asociatedCamera) {
			asociatedCamera = Camera.main;
		}
		
		if (asociatedCamera) {
			asociatedCamera.gameObject.transform.position = transform.position;
			asociatedCamera.gameObject.transform.rotation = transform.rotation;
		}
	}
	
	
}
