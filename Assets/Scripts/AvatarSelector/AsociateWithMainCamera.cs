using UnityEngine;
using System.Collections;

public class AsociateWithMainCamera : MonoBehaviour {

	private Camera _camera;
	public Camera CameraByDefault;

	public void SetCameraToAssociate(Camera cam) {
		_camera = cam;
	}

	// Use this for initialization
	void Start () {
		if (CameraByDefault) {
			_camera = CameraByDefault;
		}
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Canvas>().worldCamera = _camera;
	}
}
