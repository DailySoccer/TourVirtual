using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ContentModel3DController : MonoBehaviour {
	const float DISTANCE_NEXT_OBJECT = 10f;
	const float TIME_CHANGE_OBJECT = 1f;
	
	const float PITCH_THRESHOLD = 35;

	private float _horizontalRotation;
	private float _verticalRotation;
	
	Vector3 HIDE_TO_LEFT = new Vector3(0,0,DISTANCE_NEXT_OBJECT);
	Vector3 HIDE_TO_RIGHT = new Vector3(0,0,DISTANCE_NEXT_OBJECT);
	Vector3 SHOW_TO_LEFT = new Vector3(0,0,DISTANCE_NEXT_OBJECT);
	Vector3 SHOW_TO_RIGHT = new Vector3(0,0,DISTANCE_NEXT_OBJECT);
	
	public GameObject Model3D;
	public Text Description;
	public int Index = 0;

	public Camera CameraModel;

	public Transform PointOfInterest {
		get {
			return CurrentContent.PointOfInterest;
		}
	}
	
	public bool Empty {
		get {
			return CurrentContent.Count == 0;
		}
	}
	
	public bool IsFirst {
		get {
			return (CurrentContent.Count > 0) && (Index == 0);
		}
	}
	
	public bool IsLast {
		get {
			return (CurrentContent.Count > 0) && (Index == CurrentContent.Count - 1);
		}
	}
	
	public ContentModels CurrentContent {
		get {
			return ContentModels.ContentSelected;
		}
	}

	public bool IsRunning {
		get {
			return _hiding || _showing;
		}
	}
	
	public void Next() {
		if (!IsRunning && CurrentContent.Count > 0) {
			HideModel(HIDE_TO_RIGHT);
			if (++Index > CurrentContent.Count - 1) {
				Index = CurrentContent.Count - 1;
			}
			ShowModel(SHOW_TO_RIGHT);
		}
	}
	
	public void Prev() {
		if (!IsRunning && CurrentContent.Count > 0) {
			HideModel(HIDE_TO_LEFT);
			if (--Index < 0) {
				Index = 0;
			}
			ShowModel(SHOW_TO_LEFT);
		}
	}
	
	void Start () {
	}
	
	void Update () {
		if (_currentModel3D != null && _currentModel3D.activeSelf && !(Lean.LeanTouch.PinchScale < 1f)) {
			DragModel (_currentModel3D);
		}

		_currentModel3D.transform.localScale *= Lean.LeanTouch.PinchScale;

		float min = 0.6f;
		float max = 2f;

		if (_currentModel3D.transform.localScale.x < min) {
			_currentModel3D.transform.localScale = new Vector3(min, min, min);
		}
		else if (_currentModel3D.transform.localScale.x > max) {
			_currentModel3D.transform.localScale = new Vector3(max, max, max);
		}
	}
	
	public IEnumerator ShowContents() {
		ContentManager.Instance.Model3DView.SetActive(true);
		gameObject.SetActive(true);

		MainManager.Instance.GameInputEnabled = false;

		/*
		_cameraMain = GameObject.FindGameObjectWithTag("MainCamera");
		_cameraMain.SetActive(false);
		*/
		
		if (CameraModel == null) {
			CameraModel = ContentManager.Instance.ModelViewCamera;
		}
		CameraModel.enabled = true;

		Index = 0;
		ShowModel (new Vector3(0,0,DISTANCE_NEXT_OBJECT));
		
		yield return null;
	}
	
	public IEnumerator HideContents() {
		ContentManager.Instance.Model3DView.SetActive(false);
		gameObject.SetActive(false);

		MainManager.Instance.GameInputEnabled = true;
		
		HideModel ();
		
		// _cameraMain.SetActive(true);
		CameraModel.enabled = false;
		
		yield return null;
	}
	
	private void ShowModel(Vector3 desp) {
		_currentModel3D = CurrentContent.GetInstance(Index);
		_currentModel3D.layer = LayerMask.NameToLayer("Model3D");
		_currentModel3D.transform.position = CameraModel.transform.FindChild("Point").position - (_currentModel3D.GetComponent<Renderer>().bounds.center - _currentModel3D.transform.position);

		_currentModel3D.SetActive(true);
		StartCoroutine(MoveToShow(_currentModel3D, desp, 1));

		_theSpeed = _avgSpeed = Vector3.zero;
		
		ContentDescription contentDescription = _currentModel3D.GetComponent<ContentDescription>();
		Description.text = (contentDescription != null) ? contentDescription.Description : "";
	}

	private void HideModel(Vector3 desp) {
		if (_currentModel3D != null) {
			StartCoroutine(MoveToHide(_currentModel3D, desp, 1));
		}
	}
	
	private void HideModel() {
		if (_currentModel3D != null) {
			_currentModel3D.SetActive(false);
		}
	}
	
	private IEnumerator MoveToHide(GameObject obj, Vector3 desp, float time) {
		_hiding = true;
		if (obj != null) {
			Vector3 position = obj.transform.position;
			Go.to (obj.transform, TIME_CHANGE_OBJECT, new GoTweenConfig()
			       .position(obj.transform.position + desp));
			yield return new WaitForSeconds(time);
			
			if (_currentModel3D != obj) {
				obj.SetActive(false);
				obj.transform.position = position;
			}
		}
		_hiding = false;
	}
	
	private IEnumerator MoveToShow(GameObject obj, Vector3 desp, float time) {
		_showing = true;
		if (obj != null) {
			obj.SetActive(true);
			Go.from (obj.transform, TIME_CHANGE_OBJECT, new GoTweenConfig()
			       .position(obj.transform.position + desp)
			       .setEaseType(GoEaseType.ExpoOut)
			);

			yield return new WaitForSeconds(time);
		}
		_showing = false;
	}

	void DragModel(GameObject model) {
		if (Input.GetMouseButton(0) || Input.touchCount > 0) {
			Vector2 movement = (Input.touchCount > 0)
				? new Vector2 (Input.touches[0].deltaPosition.x, Input.touches[0].deltaPosition.y)
					: new Vector2 (Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
			_theSpeed = new Vector3(-movement.x, movement.y, 0.0F);
			_avgSpeed = Vector3.Lerp(_avgSpeed, _theSpeed, Time.deltaTime * 5);
			
			_isDragging = true;
		} else {
			if (_isDragging) {
				_theSpeed = _avgSpeed;
				_isDragging = false;
			}
			_theSpeed = Vector3.Lerp(_theSpeed, Vector3.zero, Time.deltaTime * _lerpSpeed);
		}

		if (Mathf.Abs(_theSpeed.x) > Mathf.Abs(_theSpeed.y)) {
			_theSpeed.y /= 10;
		} else {
			_theSpeed.x /= 10;
		}

		_horizontalRotation -= _theSpeed.x * _rotationSpeed;
		_verticalRotation = Mathf.Clamp(_verticalRotation + _theSpeed.y * _rotationSpeed, -PITCH_THRESHOLD,  PITCH_THRESHOLD);

		
		//model.transform.rotation = Quaternion.Euler(270 + _verticalRotation, _horizontalRotation, 0f);
		model.transform.rotation = Quaternion.identity;
		model.transform.Rotate(model.transform.right * -90f);
		model.transform.Rotate(CameraModel.transform.up * -_horizontalRotation, Space.World);
		model.transform.Rotate(CameraModel.transform.right * _verticalRotation, Space.World);
		/*
		model.transform.Rotate(model.transform.up *  _horizontalRotation);
		model.transform.Rotate(model.transform.right * _verticalRotation);*/
	}

	bool _hiding = false;
	bool _showing = false;
	
	GameObject _cameraMain;
	GameObject _currentModel3D;

	#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_WEBPLAYER
	const float _rotationSpeed = 1.0F;
	#else	
	const float _rotationSpeed = 0.1F;
	#endif
	private float _lerpSpeed = 1.0F;
	
	private Vector3 _theSpeed = Vector3.zero;
	private Vector3 _avgSpeed = Vector3.zero;
	private bool _isDragging = false;
}
