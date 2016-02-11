using UnityEngine;
using System.Collections;

public class MainGameAutocloseLevelName : MonoBehaviour {

	public float SecondsVisible = 10f;

	Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StartTimerToAutoclose() {
		//if (titleObj.GetComponent<Animator>().GetBool("IsOpen"))
		StartCoroutine ("Autoclose");
	}

	IEnumerator Autoclose() {
		 yield return new WaitForSeconds(SecondsVisible);
		animator.SetBool ("IsOpen", false);
	}
}
