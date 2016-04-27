using UnityEngine;
using System.Collections;

public class GUIChatScreen : UIScreen 
{

	public delegate void ScreenOpenEvent(string screenName);
	public event ScreenOpenEvent OnMessagesChange;

	public string screenName = ""; 

	Animator _theAnimator;
	CanvasGroup cg;
	[SerializeField]
	private string currentState = "";

	public override void Awake ()
	{
		_theAnimator = GetComponent<Animator>();
		cg = GetComponent<CanvasGroup>();
		base.Awake ();
	}
	
	public override void Update ()
	{
		base.Update ();
	}

	public void OnScreenOpen() {

		if (_theAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime == -1) {
			currentState = "";
		}
		else {
			currentState = "Open";
		}
		Debug.Log("normalized time: " + _theAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime);
		if (OnMessagesChange != null) {
			OnMessagesChange(screenName);
			currentState = "Open";
		}
	}

}
