using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Assertions;

[RequireComponent(typeof(Animator))]
public class ChatNotificationController : MonoBehaviour
{

	[SerializeField, Range(0f, 50f)] private float _secondsVisible = 10f;
	[SerializeField] private Animator _animator;
	[SerializeField]
	private Text _text;
	private string Text {
		get { return _text.text; }
		set { _text.text = value; }
	}


	//============================================================

	private void Awake ()
	{
		_animator = GetComponent<Animator> ();
	}

	private void OnDestroy()
	{
		_text = null;
		_animator = null;
	}

	private void Start()
	{
		Assert.IsNotNull(_text, "ChatNotificationController::Start>> Text not defined!!");
	}
	
	//==============================================================================

	public void ShowMessage(string txt)
	{
		Text = txt.Split('#')[1];
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
		Text = "";
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
		yield return new WaitForSeconds(_secondsVisible);
		HideNotification();
	}
}
