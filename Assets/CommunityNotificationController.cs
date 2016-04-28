using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CommunityNotificationController : MonoBehaviour {

	public Text TextMessage;
	public float SecondsVisible = 10f;
	
	Animator animator;
	
	// Use this for initialization
	void Awake () {
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void SetMessage(string txt) {
		TextMessage.text = txt.Split('#')[1];
		ShowNotification ();
	}

	void ShowNotification() {
		animator.SetBool("IsOpen", true);
	}

	public void HideNotification() {
		StopCoroutine(Autoclose());
		animator.SetBool ("IsOpen", false);
		TextMessage.text = "";
		StartCoroutine (DisableMe());
	}

	IEnumerator DisableMe() {
		while (animator.GetCurrentAnimatorStateInfo(0).IsName("Open")) {
			yield return null;
		}
		enabled = false;
	}

	public void StartTimerToAutoclose() {
		StartCoroutine ("Autoclose");
	}

	IEnumerator Autoclose() {
		yield return new WaitForSeconds(SecondsVisible);
		HideNotification ();
	}

}
