using UnityEngine;
using System.Collections;

public class SyncCameraTransform : MonoBehaviour {
	
	public enum CameraStyle {
		FPS,
		ThirdPerson
	}
	
	public GameObject cameraSynced;
	public GameObject fpsPoint;
	public GameObject thirdPersonPoint;
	private float _currentPitch;
	public const int MAX_PITCH = 35;
	public const int MIN_PITCH = -35;


	// Use this for initialization
	void Start () {
		if (cameraSynced == null && Camera.main != null) {
			cameraSynced = Camera.main.gameObject;
		}
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (cameraSynced == null && Camera.main != null) {
			cameraSynced = Camera.main.gameObject;
		}
		if (cameraSynced != null) {
			GameObject point = thirdPersonPoint;
			switch (Player.Instance.cameraStyle) {
				case CameraStyle.FPS: point = fpsPoint; break;
				case CameraStyle.ThirdPerson: point = thirdPersonPoint; break;
			}

			cameraSynced.transform.position = point.transform.position;
			cameraSynced.transform.rotation = point.transform.rotation;
			AddPitch(Player.Instance.cameraPitch * Time.deltaTime);
			cameraSynced.transform.Rotate(Vector3.right, -_currentPitch);
			/*transform.localEulerAngles = new Vector3(
					Mathf.Clamp(transform.localEulerAngles.x, MIN_PITCH, MAX_PITCH),
					transform.localEulerAngles.y,
					transform.localEulerAngles.z);*/

		}
	}

	private void AddPitch(float amount) {
		_currentPitch = Mathf.Clamp(_currentPitch + amount, MIN_PITCH, MAX_PITCH);
	}
}
