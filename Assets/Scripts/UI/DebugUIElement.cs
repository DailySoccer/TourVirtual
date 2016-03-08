using UnityEngine;
using System.Collections;

//[ExecuteInEditMode]
public class DebugUIElement : MonoBehaviour {
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		//gameObject.SetActive (MainManager.Instance.BuildMode == TourVirtualBuildMode.Debug ? true : false); 
		//enabled = MainManager.Instance.BuildMode == TourVirtualBuildMode.Debug ? true : false; 
		transform.localScale = MainManager.Instance.BuildMode == TourVirtualBuildMode.Debug ? Vector3.one : Vector3.zero;
	}
}
