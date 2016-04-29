using UnityEngine;
using System.Collections;

public class CheckHiddenObjectHUDActive : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void OnEnable() {
		if (HiddenObjects.HiddenObjects.Instance != null)
			GetComponent<Animator>().SetBool("IsOpen", HiddenObjects.HiddenObjects.Instance.enabled);
	}

	// Update is called once per frame
	void Update () {
	
	}


}
