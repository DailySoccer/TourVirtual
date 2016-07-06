using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class SyncCameraTransform : MonoBehaviour
{
	/// <summary>
	/// 
	/// </summary>
	private void Awake()
	{
		_anchorsByType = new Dictionary<CameraAnchor.Type, CameraAnchor>();

		CameraAnchor.PitchDegreesMin = _pitchDegreesMin;
		CameraAnchor.PitchDegreesMax = _pitchDegreesMax;
		
		_camera = Camera.main;

		RoomManager.Instance.OnSceneReady += OnSceneReady;
		enabled = false;
	}

	/// <summary>
	/// 
	/// </summary>
	private void OnDestroy()
	{
		_camera = null;
		_anchorsByType = null;
	}



	/// <summary>
	/// 
	/// </summary>
	private void LateUpdate ()
	{
		Assert.IsNotNull(_camera);
		Assert.IsNotNull(_anchorsByType);

		CameraAnchor anchor;
		if (!_anchorsByType.TryGetValue(Player.Instance.CameraType, out anchor))
			anchor = _anchorsByType[_defaultAnchorType];

		if (!Mathf.Approximately(Player.Instance.cameraPitch, 0f))
			anchor.PitchDegrees += Player.Instance.cameraPitch * Time.deltaTime;
		else if(!Mathf.Approximately(Player.Instance.cameraRotation, 0f))
			anchor.PitchDegrees -= anchor.PitchDegrees * _pitchRecoveryForce * Time.deltaTime;

		SyncWith(anchor);
	}

	//======================================================================================

	/// <summary>
	/// 
	/// </summary>
	/// <param name="anchor"></param>
	/// <param name="smoothTransition"></param>
	private void SyncWith(CameraAnchor anchor)
	{
		_camera.transform.rotation = anchor.transform.rotation;
		
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
		bool isCollidingWithWall = anchor.Radius > _wallCollisionDistMin &&
			Physics.SphereCast(anchor.Target, _wallCollisionRadiusMin, -anchor.transform.forward, 
				out wallInfo, anchor.Distance - _camera.nearClipPlane, LayerMask.GetMask(_wallLayerName));

		Vector3 targetPosition;
		if (!isCollidingWithWall)
		{
			targetPosition = anchor.transform.position;
			if (_smoothSecs > 0f)
				_smoothSecs -= Time.deltaTime*_smoothStopSecs;

			Debug.DrawRay(anchor.Target, -(anchor.Distance - _camera.nearClipPlane) * anchor.transform.forward, Color.green);
		}
		else
		{
			targetPosition = wallInfo.point
				- _wallSafeDistance * _camera.nearClipPlane * anchor.transform.forward;
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


	//-------------------------------------------

	/// <summary>
	/// 
	/// </summary>
	private void OnSceneReady()
	{
		foreach (CameraAnchor anchor in
			Player.Instance.GetComponentsInChildren<CameraAnchor>(true))
		{
			anchor.transform.parent = transform;
			_anchorsByType[anchor.AnchorType] = anchor;
		}

		if (_anchorsByType.Count > 0)
		{
			RoomManager.Instance.OnSceneReady -= OnSceneReady;
			enabled = true;
		}
	}

	

	//=================================================



	

	[SerializeField] private Camera _camera;
	[SerializeField] private CameraAnchor.Type _defaultAnchorType = CameraAnchor.Type.ThirdPerson;

	private float _pitch;
	[SerializeField, Range(-90f, 0f)]
	private float _pitchDegreesMin = -20f;
	[SerializeField, Range(0f, 90f)]
	private float _pitchDegreesMax = 20f;
	[SerializeField, Range(0f, 5f)]
	private float _pitchRecoveryForce = 1f;

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
	
	private Dictionary<CameraAnchor.Type, CameraAnchor> _anchorsByType;
	private Vector3 _smoothVelo = Vector3.zero;
	private float _smoothSecs;
	
}