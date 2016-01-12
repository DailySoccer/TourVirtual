using UnityEngine;
using System.Collections;

public class AnimationEffectsInfo : MonoBehaviour {


	public bool bloomEnabled = true;
	public bool fadeEnabled = true;
	public bool slideEnabled = true;
	public Vector2 initialPivot;

	// Use this for initialization
	void Awake () {
		var piv = (transform as RectTransform).pivot;
		initialPivot = new Vector2(piv.x, piv.y);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
