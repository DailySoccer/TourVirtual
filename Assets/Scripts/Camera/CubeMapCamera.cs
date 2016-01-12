using UnityEngine;
using System.Collections;

public class CubeMapCamera : MonoBehaviour {

	static CubeMapCamera _instance;
	static Camera _camera;
	static public CubeMapCamera Instance {
		get {
			if (_instance == null) {
				GameObject cubeMapObj = GameObject.FindGameObjectWithTag("CubeMapCamera");
				_instance = cubeMapObj != null ? cubeMapObj.GetComponent<CubeMapCamera>() : null;
				_camera = cubeMapObj != null ? cubeMapObj.GetComponent<Camera>() : null;
			}
			return _instance;
		}
	}

	public float ySpeed = 20.0f;
	public float sensitivity = 0.03f;
	
	public float minimumX = -80f;
	public float maximumX = 80f;

	public float smoothTime	= 0.3f;
	
	Vector3 increment;

	void Start() {
		if (Instance != null) {
			// Instance.gameObject.SetActive(false);
			Deactivate();
		}
	}

	public void Activate() {
		// gameObject.SetActive(true);
		_instance.enabled = true;
		_camera.enabled = true;
	}

	public void Deactivate() {
		// gameObject.SetActive(false);
		_instance.enabled = false;
		_camera.enabled = false;
	}

	public bool AllowUpdate	{
		get { return _allowUpdate; }
		set { 
			if (value) {
				_isDraggingMouse = false;
				_xVelocity = 0;
				_yVelocity = 0;
				_rotationX = transform.rotation.eulerAngles.x;
				_rotationY = transform.rotation.eulerAngles.y;
				_xSmooth = _rotationX;
				_ySmooth = _rotationY;
				// transform.rotation =  Quaternion.Euler(0, 0, 0);
			}
			_allowUpdate = value;
		}
	}

	void Update() {
		if(!_allowUpdate) {
			AllowUpdate = true;
		}

		if(_allowUpdate) {
			GetInputAceleration();
		
			_rotationY += Time.deltaTime * ySpeed * 0.2f;
			_rotationY += -increment.y;

			_rotationX -= increment.x;
			
			_xSmooth = Mathf.SmoothDamp(_xSmooth, _rotationX, ref _xVelocity, smoothTime);
			_ySmooth = Mathf.SmoothDamp(_ySmooth, _rotationY, ref _yVelocity, smoothTime);

			_xSmooth = ClampAngle(_xSmooth, minimumX, maximumX);

			Quaternion rotation = Quaternion.Euler(_xSmooth, _ySmooth, 0);

			transform.rotation = rotation;
		}
	}

	private void GetInputAceleration() { 
		increment = Vector3.zero;
		
		if (Input.touches.Length > 0) {
			Touch touch = Input.GetTouch(0);
			if (touch.phase == TouchPhase.Moved) 
			{
				increment.y = touch.deltaPosition.x * sensitivity;
				increment.x = -touch.deltaPosition.y * sensitivity;
			}
		}
		
		// Control de Ratón
		if (Input.GetMouseButtonDown(0)) {
			_isDraggingMouse = true;
			_dragPosition = Input.mousePosition;
		}
		// Control de Ratón
		if(_isDraggingMouse) 
		{
			increment.y = (Input.mousePosition.x - _dragPosition.x) / Time.deltaTime * sensitivity;
			increment.x = -(Input.mousePosition.y - _dragPosition.y) / Time.deltaTime * sensitivity;
			_dragPosition = Input.mousePosition;					
			
		}				
		if(Input.GetMouseButtonUp(0)) {
			_isDraggingMouse = false;
		}
	}

	private static float ClampAngle (float angle, float min, float max) {
		angle %= 360;
		return Mathf.Clamp (angle, min, max);
	}
		
	private bool _isDraggingMouse;
	private Vector3 _dragPosition;

	private float _xSmooth 	= 0.0f;
	private float _ySmooth 	= 0.0f; 
	private float _xVelocity = 0.0f;
	private float _yVelocity = 0.0f;

	private float _rotationX = 0.0f;
	private float _rotationY = 0.0f;

	private bool _allowUpdate;

}
