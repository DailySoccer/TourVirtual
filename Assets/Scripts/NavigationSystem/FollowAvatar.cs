using UnityEngine;


public class FollowAvatar : MonoBehaviour
{

	public enum FollowStyle {
		RigidStickAndFaceOnStop,
		RigidStickAndFaceAlways
	}

	public float DegreesSoftThreshold = 0.1f;
	public float DegreesHardThreshold = 0.6f;
	public float RotationSpeed = 0.8f;
	public float DistanceThreshold = 0.5f;
	public float TranslateSpeed = 1f;
	
	public float TIME_STOP_TO_FACE_CAMERA = 0.5f;
	public float TIME_TO_FACE_CAMERA_AFTER_ROTATION = 1f;
	public float TIME_WALKING_TO_FACE_CAMERA = 1f;	
	public float ANGLE_TO_FACE_CAMERA_WALKING = 15f;
	
	//private bool isRotating = false;
	[SerializeField]
	private float timeNotMoving = 0f;
	[SerializeField]
	private float timeWalking = 0f;
	
	[SerializeField]
	private bool isMoving = false;
	[SerializeField]
	private bool isRotating = false;
	
	private Transform _followedAvatar;
	private Transform _followingCamera;
	[SerializeField]
	private Transform _thePointOfInterest;
	
	void Start() {
	}

	void Init() {
		RoomManager.Instance.OnSceneReady += HandleOnSceneReady;
		RoomManager.Instance.OnPointOfInterestChange += HandlePointOfInterest;
		_followingCamera = GetComponentInChildren<SyncCameraTransform>().transform;
	}

	void OnDestroy() {
		if (RoomManager.Instance != null) {
			RoomManager.Instance.OnSceneReady -= HandleOnSceneReady;
			RoomManager.Instance.OnPointOfInterestChange -= HandlePointOfInterest;
		}
	}

	void HandleOnSceneReady ()	{
		_followedAvatar = null;
	}
	
	void HandlePointOfInterest() {
		_thePointOfInterest = RoomManager.Instance.PointOfInterest;
		
		/*// MOCK UP
		
		if (_thePointOfInterest == null) {
			_thePointOfInterest = GameObject.Find("laLiga2003").transform;
		} else {
			_thePointOfInterest = null;
		}
		
		
		Debug.Log("!!!! POINT OF INTEREST REACHED !!!!");*/
	}
	
	private void Update ()
	{


		if (!_initialized) {
			Init ();
			_initialized = true;
		}
		
		if (_followedAvatar == null)
        {// || _playerLocomotion == null) {
			GameObject thePlayer = Player.Instance.Avatar;
			if (thePlayer != null) {
				_followedAvatar = thePlayer.transform;
				transform.position = _followedAvatar.position;
				transform.rotation =  _followedAvatar.rotation;
				//_playerLocomotion = Player.Instance.Locomotion;

			}
		}
		
		if (_followedAvatar != null )
		{
			
			// MOVIMIENTO
			
			switch (Player.Instance.FollowStyle)
			{
				case FollowStyle.RigidStickAndFaceAlways:
					RigidStick();
					FaceCamera();
					break;

				case FollowStyle.RigidStickAndFaceOnStop:
					RigidStick();
					FaceCameraOnStop();
					break;
			}
		}

		
	}
	
	private void LateUpdate()
	{
		//STABILIZE X AND Z
		transform.rotation = new Quaternion(0f, transform.rotation.y, 0f, transform.rotation.w);
		
	}


	private void LookAtPointOfInterest()
	{
		Quaternion current = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w);
		transform.LookAt(_thePointOfInterest);
		transform.rotation = new Quaternion(current.x, transform.rotation.y, current.z, transform.rotation.w);
		transform.rotation = Quaternion.Lerp(current, transform.rotation, RotationSpeed * Time.deltaTime);
	}
	
	void RigidStick() {
		//isMoving = _playerLocomotion.Movement != 0;
		transform.position = _followedAvatar.position;
	}
	
	private void FaceCameraOnStop()
	{
		Transform camTransf = _followingCamera.transform;
		
		Vector2 camForward2d = new Vector2(camTransf.forward.x, camTransf.forward.z).normalized;
		Vector2 camRight2d = new Vector2(camTransf.right.x, camTransf.right.z).normalized;
		
		Vector2 playerForward = new Vector2(_followedAvatar.forward.x, _followedAvatar.forward.z).normalized;
		
		// -1 Movimiento del Avatar hacia la izquierda, 1 hacia la derecha. 0 en la direccion en la que está o en la contraria.
		float relPlayerCam = Vector2.Dot(camForward2d, playerForward);
		// positivo hacia delante, negativo hacia atras
		float relForwardPlayerCam = Vector2.Dot(camRight2d, playerForward);
		
		const float toDegree = 180f / Mathf.PI;
		float angleForwardPlayerCam = Mathf.Abs(Mathf.Atan2(relForwardPlayerCam, relPlayerCam) * toDegree);
		
		
		
		if (!isMoving && Player.Instance.CameraRotation == 0) {
			timeNotMoving += Time.deltaTime;
		} else {
			if (Player.Instance.CameraRotation != 0) {
				timeNotMoving = -TIME_TO_FACE_CAMERA_AFTER_ROTATION;
			}
			timeNotMoving = Mathf.Min(0f, timeNotMoving);
		}
		
		if (isMoving && angleForwardPlayerCam < ANGLE_TO_FACE_CAMERA_WALKING && Player.Instance.CameraRotation == 0) {
			timeWalking += Time.deltaTime;
		} else {
			if (Player.Instance.CameraRotation != 0) {
				timeWalking = -TIME_TO_FACE_CAMERA_AFTER_ROTATION;
			}
			timeWalking = isMoving? 0 : Mathf.Min(0f, timeWalking);
		}
		
		transform.Rotate(Vector3.up, Player.Instance.CameraRotation * Time.deltaTime);
		
		if (timeNotMoving > TIME_STOP_TO_FACE_CAMERA)
		{
			if (_thePointOfInterest == null)
			{
				transform.rotation = Quaternion.Lerp(transform.rotation, _followedAvatar.rotation, RotationSpeed * Time.deltaTime);
			}
			else
			{
				LookAtPointOfInterest();
			}
		}
		
		if (timeWalking > TIME_WALKING_TO_FACE_CAMERA)
		{	
			transform.rotation = Quaternion.Lerp(transform.rotation, _followedAvatar.rotation, RotationSpeed * Time.deltaTime);
		}

		
	}


	void FaceCamera()
	{
		Transform camTransf = _followingCamera.transform;
		
		Vector2 camForward2d = new Vector2(camTransf.forward.x, camTransf.forward.z).normalized;
		Vector2 camRight2d = new Vector2(camTransf.right.x, camTransf.right.z).normalized;
		
		Vector2 playerForward = new Vector2(_followedAvatar.forward.x, _followedAvatar.forward.z).normalized;
		
		// -1 Movimiento del Avatar hacia la izquierda, 1 hacia la derecha. 0 en la direccion en la que está o en la contraria.
		float relPlayerCam = Vector2.Dot(camForward2d, playerForward);
		// positivo hacia delante, negativo hacia atras
		float relForwardPlayerCam = Vector2.Dot(camRight2d, playerForward);
		
		const float TO_DEGREE = 180 / Mathf.PI;
		float angleForwardPlayerCam = Mathf.Abs(Mathf.Atan2(relForwardPlayerCam, relPlayerCam) * TO_DEGREE);
		
		if (isMoving)
		{
			transform.rotation = Quaternion.Lerp(transform.rotation, _followedAvatar.rotation, RotationSpeed * Time.deltaTime);// RotationSpeed * Time.deltaTime);
			isRotating = true;
		}
		else
		{
			transform.Rotate(Vector3.up, Player.Instance.CameraRotation * Time.deltaTime);
		}

		
		/*
		if (!isMoving || Mathf.Abs(angleForwardPlayerCam) < 3) {
			isRotating = false;
		}
		*/
		/*
		
		
		if (!isMoving && Player.Instance.CameraRotation == 0) {
			timeNotMoving += Time.deltaTime;
		} else {
			if (Player.Instance.CameraRotation != 0) {
				timeNotMoving = -TIME_TO_FACE_CAMERA_AFTER_ROTATION;
			}
			timeNotMoving = Mathf.Min(0f, timeNotMoving);
		}
		
		if (isMoving && angleForwardPlayerCam < ANGLE_TO_FACE_CAMERA_WALKING && Player.Instance.CameraRotation == 0) {
			timeWalking += Time.deltaTime;
		} else {
			if (Player.Instance.CameraRotation != 0) {
				timeWalking = -TIME_TO_FACE_CAMERA_AFTER_ROTATION;
			}
			timeWalking = isMoving? 0 : Mathf.Min(0f, timeWalking);
		}
		
		
		transform.Rotate(Vector3.up, Player.Instance.CameraRotation * Time.deltaTime);
		
		if (timeNotMoving > TIME_STOP_TO_FACE_CAMERA) {
			if (_thePointOfInterest == null) {
				transform.Rotation = Quaternion.Lerp(transform.Rotation, _followedAvatar.Rotation, RotationSpeed * Time.deltaTime);
			} else {
				LookAtPointOfInterest();
			}
		}
		
		if (timeWalking > TIME_WALKING_TO_FACE_CAMERA) {
			transform.Rotation = Quaternion.Lerp(transform.Rotation, _followedAvatar.Rotation, RotationSpeed * Time.deltaTime);
		}*/
	}




	private bool _initialized = false;
	
}
