using UnityEngine;
using System.Collections;

public class GUIPopUpScreen : UIScreen 
{
	public override void Awake ()
	{
		base.Awake ();
	}
	
	public override void Update ()
	{
		base.Update ();
	}

	void AnimEvent_PrepareModal() {
		return;//SetState(CurrentModalLayout);
	}
}
