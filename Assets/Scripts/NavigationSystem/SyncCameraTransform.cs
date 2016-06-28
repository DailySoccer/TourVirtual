using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class SyncCameraTransform : MonoBehaviour
{
	
	public enum CameraStyle
	{
		Default = 0,
		Fps     = 1,
		Tps     = 2,
	}

	[Serializable]
	private class CameraAnchor
	{
		public static float PitchDegreesMin;
		public static float PitchDegreesMax;

		[SerializeField] private CameraStyle _style;
		public CameraStyle Style { get { return _style; } }

		[SerializeField] private Transform _transform;
		public Transform Transform { get { return _transform; } }

		public float Radius   { get; private set; }
		public float Distance { get; private set; }
		public Vector3 Target {
			get { return Transform.position + Distance*Transform.forward; }
		}

		private float _pitchDegrees;
		public float PitchDegrees
		{
			get { return _pitchDegrees; }
			set
			{
				if(float.IsNaN(value)) {
					Debug.LogError("SyncCameraTransform::PitchDegrees>> Rotation NaN!!");
					value = 0f;
				}

				value = Mathf.Clamp(value, PitchDegreesMin, PitchDegreesMax);
				if (Mathf.Approximately(value, _pitchDegrees))	
					return;

				_pitchDegrees = value;

				Transform.localRotation = Quaternion.AngleAxis(value, -Vector3.right);
				Distance = Radius / Mathf.Cos(Mathf.Deg2Rad * value);
			}
		}

		public void Init()
		{
			Vector3 horizontalPos = Transform.localPosition;
			horizontalPos.y = 0f;

			Radius = horizontalPos.magnitude;
			PitchDegrees = -Transform.eulerAngles.x;
		}
	}


	/// <summary>
	/// 
	/// </summary>
	private void Awake()
	{
		CameraAnchor.PitchDegreesMin = _pitchDegreesMin;
		CameraAnchor.PitchDegreesMax = _pitchDegreesMax;

		_anchorsByStyle = new Dictionary<CameraStyle, CameraAnchor>();

		foreach (CameraAnchor anchor in _anchors) {
			_anchorsByStyle[anchor.Style] = anchor;
			anchor.Init();
		}

		_camera = Camera.main;
	}

	

	/// <summary>
	/// 
	/// </summary>
	private void OnDestroy()
	{
		_camera = null;
		_anchors = null;
	}


	/// <summary>
	/// 
	/// </summary>
	private void LateUpdate ()
	{
		// UNDONE FRS 160614 esto no debería ser necesario
		//if (_camera == null && Camera.main != null) 
		//	_camera = Camera.main;

		if ( _camera == null)
			return;
		
		CameraAnchor anchor = _anchorsByStyle[Player.Instance.cameraStyle];

		if(float.IsNaN(anchor.PitchDegrees)) {
			Debug.LogError("SyncCameraTransform::PitchDegrees>> Rotation NaN!!");
			anchor.PitchDegrees = 0f;
		}

		anchor.PitchDegrees += Player.Instance.cameraPitch * Time.deltaTime;

		SyncWith(anchor);
	}


	/// <summary>
	/// 
	/// </summary>
	/// <param name="anchor"></param>
	/// <param name="smoothTransition"></param>
	private void SyncWith(CameraAnchor anchor)
	{
		_camera.transform.rotation = anchor.Transform.rotation;
		
/*
		Vector3 nearPos   = anchor.Transform.position + _camera.nearClipPlane*anchor.Transform.forward;

		RaycastHit wallInfo;
		if (Physics.Linecast(nearPos, anchor.Target, out wallInfo, LayerMask.GetMask(_wallLayerName)))
		{
			_camera.transform.position = wallInfo.point
				- _wallSafeDistance*_camera.nearClipPlane*anchor.Transform.forward;
		}
		Debug.DrawLine(nearPos, anchor.Target, Color.magenta);
/*/
		

		RaycastHit wallInfo = new RaycastHit();
		IsCollidingWithWall = anchor.Radius > _wallCollisionDistMin &&
			Physics.SphereCast(anchor.Target, _wallCollisionRadiusMin, -anchor.Transform.forward, 
				out wallInfo, anchor.Distance - _camera.nearClipPlane, LayerMask.GetMask(_wallLayerName));

		Vector3 targetPosition;
		if (!IsCollidingWithWall)
		{
			targetPosition = anchor.Transform.position;
			if (_smoothSecs > 0f)
				_smoothSecs -= Time.deltaTime*_smoothStopSecs;

			Debug.DrawRay(anchor.Target, -(anchor.Distance - _camera.nearClipPlane) * anchor.Transform.forward, Color.green);
		}
		else
		{
			targetPosition = wallInfo.point
				- _wallSafeDistance * _camera.nearClipPlane * anchor.Transform.forward;
			_smoothSecs = _smoothSecsMax;

			Debug.DrawRay(anchor.Target, wallInfo.point  - anchor.Target, Color.red);
		}

/**/

		if(_smoothSecs > 0f)
			_camera.transform.position = Vector3.SmoothDamp(
				_camera.transform.position, targetPosition, ref _smoothVelo, _smoothSecs);
		else
			_camera.transform.position = targetPosition;
	}



	//=================================================

	

	/// <summary>
	/// 
	/// </summary>
	private bool IsCollidingWithWall
	{
		get { return _isCollidingWithWall; }
		set
		{
			if (value == _isCollidingWithWall)
				return;
			_isCollidingWithWall = value;
		}
	}

	[SerializeField] private Camera _camera;
	[SerializeField] private CameraAnchor[] _anchors;

	private float _pitch;
	[SerializeField, Range(-90f, 0f)]
	private float _pitchDegreesMin = -20f;
	[SerializeField, Range(0f, 90f)]
	private float _pitchDegreesMax = 20f;

	[SerializeField] private string _wallLayerName = "Wall";
	[SerializeField, Range(-5f, 5f)]
	private float _wallSafeDistance = 0f;
	[SerializeField, Range(0f, 5f)]
	private float _wallCollisionDistMin = 1f;
	[SerializeField, Range(0f, 5f)]
	private float _wallCollisionRadiusMin = .2f;
	
	[SerializeField, Range(0f, 5f)]
	private float _smoothSecsMax = 0.1f;
	[SerializeField, Range(0f, 1f)]
	private float _smoothStopSecs;


	private Dictionary<CameraStyle, CameraAnchor> _anchorsByStyle;
	private Vector3 _smoothVelo = Vector3.zero;
	private bool _isCollidingWithWall;
	private float _smoothSecs; 
	
}