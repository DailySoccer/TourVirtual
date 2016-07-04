using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TrophyViewer : MonoBehaviour {

	#region Public members
	public float MIN_ZOOM = 0.5f;
	public float MAX_ZOOM = 2;
	public float MAX_PITCH = 10;
	public float MIN_PITCH = -10;
	public float PitchSpeed = 5;
	public float RollSpeed = 20;
	#endregion

	#region MonoBehaviour methods
	// Use this for initialization
	void Start () {
		renders = gameObject.GetComponentsInChildren<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
		UpdateBounds();
		
	}
	#endregion

	#region Private methods
	void UpdateBounds()
	{
		foreach (Renderer ren in renders)
		{
			minPos = new Vector3(Mathf.Min(minPos.x, ren.bounds.min.x), Mathf.Min(minPos.y, ren.bounds.min.y), Mathf.Min(minPos.z, ren.bounds.min.z));
			maxPos = new Vector3(Mathf.Max(minPos.x, ren.bounds.min.x), Mathf.Max(minPos.y, ren.bounds.min.y), Mathf.Max(minPos.z, ren.bounds.min.z));
		}
	}


	#endregion

	#region Private members
	private Renderer[] renders;
	private Vector3 minPos = Vector3.zero, maxPos = Vector3.zero;
	private float currentscale, currentPitch, current;
	private Vector3 lastClick1, lastClick2;
	#endregion
}
