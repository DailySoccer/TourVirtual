using UnityEngine;
using UnityEngine.UI;

using System;
using System.Collections;

public class SendDirectChatMessage : MonoBehaviour {

	public Text TitleWithUserName;
	public Button TheButton;
	public InputField TheInput;

	// Use this for initialization
	void OnEnable () {
		TheInput.gameObject.SetActive (false);
		TheButton.onClick.AddListener (Button_Click);
		TheInput.onEndEdit.AddListener (delegate {Input_EndEdit();});
	}

	void OnDisable() {
		TheButton.onClick.RemoveListener (Button_Click);
		ResetTheInputField ();
	}

	void Button_Click() {
		TheInput.gameObject.SetActive (true);
		TheInput.ActivateInputField ();

		ChatManager.Instance.SelectedChannelId = TitleWithUserName.text;
	}

	void Input_EndEdit() {

		if (TheInput.text.Trim() == string.Empty) {
			#if UNITY_EDITOR
				Debug.LogError("[SendChatMessage] in <" + this.name + ">: Intentaste mandar un mensaje vacío.");
			#endif
			return;
		}
		
		string messageToSend = DateTime.UtcNow + "#" + TheInput.text;
		#if UNITY_EDITOR
			Debug.LogError("[SendChatMessage] in <" + this.name + ">: Trying to send message: \"" + messageToSend );
		#endif
		
		ChatManager.Instance.SendMessage(messageToSend);

		
		TheInput.onEndEdit.RemoveListener (delegate {Input_EndEdit();});
		ResetTheInputField ();
	}

	void ResetTheInputField() {
		TheInput.text = "";
		TheInput.gameObject.SetActive (false);
	}
	// Update is called once per frame
	void Update () {}
}
