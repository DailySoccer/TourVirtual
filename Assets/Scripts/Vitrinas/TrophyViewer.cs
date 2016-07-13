using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TrophyViewer : MonoBehaviour {

	#region Public members
	public float MIN_ZOOM = 0.5f;
	public float MAX_ZOOM = 5;
	public float MAX_PITCH = 30;
	public float MIN_PITCH = -30;
	[Range(0.01f, 1000)]
	public float ZoomDensity = 0.1f;
	[Range(0.01f,1000)]
	public float PitchDensity = 0.02f;
	[Range(0.01f, 1000)]
	public float RollDensity = 0.02f;

	public float DeltaZoom
	{
		get {
			float grow = (_lastClick1 - _lastClick2).sqrMagnitude > ((_lastClick1 + _deltaClick1) - (_lastClick2 + _deltaClick2)).sqrMagnitude ? -1 : 1;
			return _clickCount != 2 ? 0 : Mathf.Max(0, -Mathf.Sign(Vector2.Dot(_deltaClick1, _deltaClick2)) * (_deltaClick2 - _deltaClick1).magnitude) * grow;
		}
	}
	public float DeltaPitch
	{
		get
		{
			return _clickCount != 1 ? 0 : _deltaClick1.y;
		}
	}
	public float DeltaRoll
	{
		get
		{
			return _clickCount != 1 ? 0 : -_deltaClick1.x;
		}
	}
	#endregion

	#region MonoBehaviour methods
	// Use this for initialization
	void Start () {
		PitchDensity *= Screen.dpi;
		RollDensity *= Screen.dpi;
		ZoomDensity *= Screen.dpi;
		_renders = gameObject.GetComponentsInChildren<Renderer>();
		if (_cam == null)
		{
			GameObject camRef = GameObject.Find("ViewerCamera");
			if (camRef != null)
			{
				_cam = camRef.GetComponent<Camera>();
			}
			if (_cam == null)
			{
				_cam = Camera.main;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		UpdateClick();
		UpdateTransform();
	}
	#endregion

	#region Private methods
	private void UpdateBounds()
	{
		foreach (Renderer ren in _renders)
		{
			_minPos = new Vector3(Mathf.Min(_minPos.x, ren.bounds.min.x), Mathf.Min(_minPos.y, ren.bounds.min.y), Mathf.Min(_minPos.z, ren.bounds.min.z));
			_maxPos = new Vector3(Mathf.Max(_maxPos.x, ren.bounds.max.x), Mathf.Max(_maxPos.y, ren.bounds.max.y), Mathf.Max(_maxPos.z, ren.bounds.max.z));
		}
		Vector2 _minScreen = Vector2.zero, _maxScreen = Vector3.zero;
		if (_cam != null)
		{
			_minScreen = _cam.WorldToScreenPoint(_minPos);
			_maxScreen = _cam.WorldToScreenPoint(_maxPos);
		}
		float rangeX, rangeY;
		rangeX = _maxScreen.x - _minScreen.x;
		rangeY = _maxScreen.y - _minScreen.y;
		bool outOfBound = rangeX > Screen.width * 0.8f || rangeY > Screen.height * 0.8f;
		if (outOfBound)
		{
			float scaleCorrection = Mathf.Min((Screen.width * 0.8f) / rangeX, (Screen.height * 0.8f) / rangeY);
			_currentScale *= scaleCorrection;
			_maxInnerScale = _currentScale;
			transform.localScale = Vector3.one * _currentScale;
			_minPos = _maxPos = Vector3.zero;
		}
	}

	private void UpdateClick()
	{
#if UNITY_EDITOR
		if (Input.GetMouseButton(0))
		{
			if (_clickCount == 0)
			{
				_lastClick1 = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
			}
			_clickCount = 1;
			_deltaClick1 = new Vector2(Input.mousePosition.x, Input.mousePosition.y) - _lastClick1;
			_lastClick1 += _deltaClick1;
		}
		else
		{
			_deltaClick1 = Vector2.zero;
			_clickCount = 0;
		}
#else
		int currClickCount = Input.touchCount;
		if (_clickCount == currClickCount)
		{
			switch (_clickCount)
			{
				case 2:
					_deltaClick2 = Input.touches[1].position - _lastClick2;
					_lastClick2 = Input.touches[1].position;
					goto case 1;
				case 1:
					_deltaClick1 = Input.touches[0].position - _lastClick1;
					_lastClick1 = Input.touches[0].position;
					break;
				default:
					_deltaClick1 = _deltaClick2 = Vector2.zero;
					break;
			}
		}
		else
		{
			switch (currClickCount) {
				case 2:
					_lastClick2 = Input.touches[1].position;
					goto case 1;
				case 1:
					_lastClick1 = Input.touches[0].position;
					goto default;
				default:
					_deltaClick1 = _deltaClick2 = Vector2.zero;
					break;
			}
		}
		_clickCount = currClickCount;
#endif
	}

	private void UpdateTransform()
	{
		_currentPitch = Mathf.Clamp(_currentPitch + DeltaPitch / PitchDensity, MIN_PITCH, MAX_PITCH);
		_currentRoll += DeltaRoll / RollDensity;
		_currentScale = Mathf.Clamp(_currentScale + DeltaZoom / ZoomDensity, MIN_ZOOM, _maxInnerScale != 0 ? _maxInnerScale : MAX_ZOOM);
		if (_cam != null)
		{
			transform.rotation = Quaternion.AngleAxis(_currentPitch, _cam.transform.right) * Quaternion.AngleAxis(_currentRoll, _cam.transform.up);
		}
		transform.localScale = Vector3.one * _currentScale;
		UpdateBounds();
	}
#endregion

#region Private members
	private Renderer[] _renders;
	private Vector3 _minPos = Vector3.zero, _maxPos = Vector3.zero;
	private float _currentScale, _currentPitch, _currentRoll;
	private float _maxInnerScale = 0;
	private Vector2 _lastClick1, _lastClick2;
	private Vector2 _deltaClick1, _deltaClick2;
	private int _clickCount;
	private static Camera _cam;
#endregion
}
