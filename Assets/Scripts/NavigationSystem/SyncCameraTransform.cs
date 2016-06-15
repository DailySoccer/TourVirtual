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
	private struct CameraAnchor
	{
		public static float PitchDegreesMin;
		public static float PitchDegreesMax;

		public CameraStyle Style;
		public Transform Transform;

		[HideInInspector] public float Radius;
		[HideInInspector] public Vector3 Target;

		private float _pitchDegrees;
		public float PitchDegrees
		{
			get { return _pitchDegrees; }
			set
			{
				_pitchDegrees = Mathf.Clamp(value, PitchDegreesMin, PitchDegreesMax);
				Transform.Rotate(Vector3.right, -_pitchDegrees);

				Target = Transform.position + Transform.forward *
					+ Radius / Mathf.Cos(_pitchDegrees);
			}
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
		foreach (CameraAnchor anchor in _anchors)
			ProcessAnchor(anchor);

		if (_camera == null) 
			_camera = Camera.main;
	}

	private void ProcessAnchor(CameraAnchor anchor)
	{
		Vector3 horizontalPos = anchor.Transform.position;
		horizontalPos.y = 0f;

		anchor.Radius = horizontalPos.magnitude;
		anchor.PitchDegrees = -anchor.Transform.rotation.x;

		_anchorsByStyle[anchor.Style] = anchor;
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

		if (anchor.Radius > WallAvoidanceDistMin)
		{
			Vector3 nearPos   = anchor.Transform.position + _camera.nearClipPlane*anchor.Transform.forward;
			
			RaycastHit wallInfo;
			if (Physics.Linecast(nearPos, anchor.Target, out wallInfo, LayerMask.GetMask(_wallLayerName)))
			{
				_camera.transform.position = wallInfo.point
					- WallSafeDistance*_camera.nearClipPlane*anchor.Transform.forward;
			}
		}

		_camera.transform.rotation = anchor.Transform.rotation;
	}


	private const float WallSafeDistance = .95f;
	private const float WallAvoidanceDistMin = 1f;

	[SerializeField] private Camera _camera;
	[SerializeField] private CameraAnchor[] _anchors;
	[SerializeField] private string _wallLayerName = "Wall";

	private float _pitch;
	[SerializeField, Range(-90f,  0f)] private float _pitchDegreesMin = -20f;
	[SerializeField, Range(  0f, 90f)] private float _pitchDegreesMax =  20f;

	private Dictionary<CameraStyle, CameraAnchor> _anchorsByStyle;


}