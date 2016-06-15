using System;
using System.Collections.Generic;
using UnityEngine;

public class SyncCameraTransform : MonoBehaviour {
	
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
				value = Mathf.Clamp(value, PitchDegreesMin, PitchDegreesMax);
				if (Mathf.Approximately(value, _pitchDegrees))
					return;

				Transform.localRotation = Quaternion.Euler(-value, 
					Transform.localRotation.y, Transform.localRotation.z);

				Distance = Radius / Mathf.Cos(Mathf.Deg2Rad * value);

				_pitchDegrees = value;
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
	}

	/// <summary>
	/// 
	/// </summary>
	private void OnDestroy()
	{
		_camera = null;
	}

	/// <summary>
	/// 
	/// </summary>
	private void Start ()
	{
		foreach (CameraAnchor anchor in _anchors) {
			anchor.Init();
			_anchorsByStyle[anchor.Style] = anchor;
		}

		if (_camera == null) 
			_camera = Camera.main;
	}

	

	// Update is called once per frame
	private void LateUpdate ()
	{
		// UNDONE FRS 160614 esto no debería ser necesario
		//if (_camera == null && Camera.main != null) 
		//	_camera = Camera.main;

		if (_camera == null)
			return;

		CameraAnchor anchor = _anchorsByStyle[Player.Instance.cameraStyle];
		anchor.PitchDegrees += Player.Instance.cameraPitch * Time.deltaTime;

		SyncWith(anchor);
	}


	/// <summary>
	/// 
	/// </summary>
	/// <param name="anchor"></param>
	private void SyncWith(CameraAnchor anchor)
	{
		_camera.transform.position = anchor.Transform.position;
		_camera.transform.rotation = anchor.Transform.rotation;

		if (anchor.Radius < WallAvoidanceDistMin)
			return;
/*
		Vector3 nearPos   = anchor.Transform.position + _camera.nearClipPlane*anchor.Transform.forward;

		RaycastHit wallInfo;
		if (Physics.Linecast(nearPos, anchor.Target, out wallInfo, LayerMask.GetMask(_wallLayerName)))
		{
			_camera.transform.position = wallInfo.point
				- WallSafeDistance*_camera.nearClipPlane*anchor.Transform.forward;
		}
		Debug.DrawLine(nearPos, anchor.Target, Color.magenta);
/*/
		RaycastHit wallInfo;
		if (Physics.Raycast(anchor.Target, -anchor.Transform.forward, out wallInfo,
			anchor.Distance - _camera.nearClipPlane, LayerMask.GetMask(_wallLayerName)))
		{
			_camera.transform.position = wallInfo.point
				- WallSafeDistance*_camera.nearClipPlane*anchor.Transform.forward;

			Debug.DrawRay(anchor.Target, -(anchor.Distance - _camera.nearClipPlane) * anchor.Transform.forward, Color.red);
		}
		else
		{
			Debug.DrawRay(anchor.Target, -(anchor.Distance - _camera.nearClipPlane) * anchor.Transform.forward, Color.green);
		}
/**/
	}


	private const float WallSafeDistance = .5f;
	private const float WallAvoidanceDistMin = 1f;

	[SerializeField] private Camera _camera;
	[SerializeField] private CameraAnchor[] _anchors;
	[SerializeField] private string _wallLayerName = "Wall";

	private float _pitch;
	[SerializeField, Range(-90f,  0f)] private float _pitchDegreesMin = -20f;
	[SerializeField, Range(  0f, 90f)] private float _pitchDegreesMax =  20f;

	private Dictionary<CameraStyle, CameraAnchor> _anchorsByStyle;


}