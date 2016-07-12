using UnityEngine;
using System.Collections;

public class ChatScreenGUI : UIScreen {

	public TVBChatController TheChatController;

	public override void Awake () {
		base.Awake ();
	}
	
	public override void Start () {
	}

	public override void UpdateTitle ()
	{
		TheChatController.GoToChannelsScreen ();
		base.UpdateTitle ();
	}

	public override void Update ()
	{
		base.Update ();
	}
}
