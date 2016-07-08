using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TrophyViewer : MonoBehaviour {

	#region Public members
	public float MIN_ZOOM = 0.5f;
	public float MAX_ZOOM = 2;
	public float MAX_PITCH = 10;
	public float MIN_PITCH = -10;
	[Range(0.01f, 1000)]
	public float ZoomDensity = 25;
	[Range(0.01f,1000)]
	public float PitchDensity = 25;
	[Range(0.01f, 1000)]
	public float RollDensity = 25;

	public float DeltaZoom
	{
		get {
			return _clickCount != 2 ? 0 : Mathf.Max(0, -Mathf.Sign(Vector2.Dot(_deltaClick1, _deltaClick2)) * (_deltaClick2 - _deltaClick1).magnitude);
		}
	}
	public float DeltaPitch
	{
		get
		{
			return _clickCount != 1 ? 0 : -_deltaClick1.y;
		}
	}
	public float DeltaRoll
	{
		get
		{
			return _clickCount != 1 ? 0 : _deltaClick1.x;
		}
	}
	public void SetInteraction(bool activate)
	{
		_interactionActive = activate;
	}
	#endregion

	#region MonoBehaviour methods
	// Use this for initialization
	void Start () {
		_renders = gameObject.GetComponentsInChildren<Renderer>();
		//TODO remove
		_startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		SetInteraction(Time.time - _startTime > 10);
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
			_maxPos = new Vector3(Mathf.Max(_minPos.x, ren.bounds.min.x), Mathf.Max(_minPos.y, ren.bounds.min.y), Mathf.Max(_minPos.z, ren.bounds.min.z));
			//TODO reajustar si el tamaño sobrepasa límites definidos para la pantalla.
			Vector2 _minScreen, _maxScreen;
			_minScreen = Camera.main.WorldToScreenPoint(_minPos);
			_maxScreen = Camera.main.WorldToScreenPoint(_maxPos);
			float rangeX, rangeY;
			rangeX = _maxScreen.x - _minScreen.x;
			rangeY = _maxScreen.y - _minScreen.y;
			bool outOfBound = rangeX > Screen.width * 0.8f || rangeY > Screen.height * 0.8f;
			if (outOfBound)
			{
				float scaleCorrection = Mathf.Min(rangeX / (Screen.width * 0.8f), rangeY / (Screen.height * 0.8f));
				_currentScale *= scaleCorrection;
				transform.localScale = Vector3.one * _currentScale;
			}
		}
	}

	private void UpdateClick()
	{
		_clickCount = Input.touchCount;
		switch(_clickCount)
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
			_lastClick1 = _lastClick2 = _deltaClick1 = _deltaClick2 = Vector2.zero;
				break;
		}
	}

	private void UpdateTransform()
	{
		if (_interactionActive)
		{
			_currentPitch = Mathf.Clamp(_currentPitch + DeltaPitch / PitchDensity, MIN_PITCH, MAX_PITCH);
			_currentRoll += DeltaRoll / RollDensity;
			_currentScale = Mathf.Clamp(_currentScale + DeltaZoom / ZoomDensity, MIN_ZOOM, MAX_ZOOM);
			transform.rotation = Quaternion.AngleAxis(_currentRoll, Vector3.up) * Quaternion.AngleAxis(_currentPitch, Vector3.right);
			transform.localScale = Vector3.one * _currentScale;
			UpdateBounds();
		}
	}
	#endregion

	#region Private members
	private Renderer[] _renders;
	private Vector3 _minPos = Vector3.zero, _maxPos = Vector3.zero;
	private float _currentScale, _currentPitch, _currentRoll;
	private Vector2 _lastClick1, _lastClick2;
	private Vector2 _deltaClick1, _deltaClick2;
	private int _clickCount;
	private bool _interactionActive;

	//TODO remove
	private float _startTime;
	#endregion
}
