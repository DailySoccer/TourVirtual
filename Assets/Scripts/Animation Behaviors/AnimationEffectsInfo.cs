using UnityEngine;
using System.Collections;

public class AnimationEffectsInfo : MonoBehaviour {


	public bool bloomEnabled = true;
	public bool fadeEnabled = true;
	public bool slideEnabled = true;
	public Vector2 initialPivot;

	// Use this for initialization
	void Awake () {
		initialPivot = (transform as RectTransform).pivot;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
