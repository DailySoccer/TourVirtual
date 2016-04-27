using UnityEngine;

public class SyncCameraTransform : MonoBehaviour {
	
	public enum CameraStyle {
		FPS,
		ThirdPerson
	}
	
	public GameObject cameraSynced;
	public GameObject fpsPoint;
	public GameObject thirdPersonPoint;
	private float _currentPitch;
   [Range(0, 90)]
	public float MAX_PITCH;
   [Range(-90, 0)]
   public float MIN_PITCH;


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
		}
	}

	private void AddPitch(float amount) {
		_currentPitch = Mathf.Clamp(_currentPitch + amount, MIN_PITCH, MAX_PITCH);
	}
}