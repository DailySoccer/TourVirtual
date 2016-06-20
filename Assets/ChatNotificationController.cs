using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChatNotificationController : MonoBehaviour
{
	public Text TextMessage;
	public float SecondsVisible = 10f;
	
	private Animator _animator;
	
	//============================================================

	private void Awake ()
	{
		_animator = GetComponent<Animator> ();
	}

	private void OnDestroy()
	{
		_animator = null;
	}
	
	//==============================================================================

	public void ShowMessage(string txt)
	{
		TextMessage.text = txt.Split('#')[1];
		ShowNotification ();
	}

	public void ShowNotification()
	{
		_animator.SetBool("IsOpen", true);
	}

	public void HideNotification()
	{
		StopCoroutine(Autoclose());
		_animator.SetBool ("IsOpen", false);
		TextMessage.text = "";
		StartCoroutine (DisableMe());
	}

	public void StartTimerToAutoclose()
	{
		StartCoroutine(Autoclose());
	}

	private IEnumerator DisableMe()
	{
		while (_animator.GetCurrentAnimatorStateInfo(0).IsName("Open")) 
			yield return null;

		enabled = false;
	}

	private IEnumerator Autoclose()
	{
		yield return new WaitForSeconds(SecondsVisible);
		HideNotification();
	}

	
}
