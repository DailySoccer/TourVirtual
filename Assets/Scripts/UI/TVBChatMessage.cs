using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TVBChatMessage : MonoBehaviour {

	/// <summary>
	/// NickName del usuario que ha escrito el mensaje
	/// </summary>
	public Text owner;

	/// <summary>
	/// NickName del usuario que ha escrito el mensaje
	/// </summary>
	public Text date;

	/// <summary>
	/// El texto del mensaeje.
	/// </summary>
	public Text message;

	/// <summary>
	/// Gets or sets the owner.
	/// </summary>
	/// <value>The owner.</value>
	public string theOwner {
		get{return _theOwner;} 
		set{_theOwner = value;}
	}

	/// <summary>
	/// Gets or sets the date.
	/// </summary>
	/// <value>The date.</value>
	public string theDate {
		get{return _theDate;} 
		set{_theDate = value;}
	}

	/// <summary>
	/// Gets or sets the time.
	/// </summary>
	/// <value>The time.</value>
	public string theTime {
		get{return _theTime;} 
		set{_theTime = value;}
	}

	/// <summary>
	/// Gets or sets the text.
	/// </summary>
	/// <value>The text.</value>
	public string theText {
		get{return _theText;} 
		set{_theText = value;}
	}

	public ChatMessage ChatMessageInstance {
		set {
			_theOwner = ChatManager.Instance.UserName == value.Sender ? "" : value.Sender;
			_theText = value.Text.Substring(value.getDateTextSeparatorIndex() + 1);
			_theDate = value.GetMessageDate().ToLocalTime().ToShortDateString();
			_theTime = value.GetMessageDate().ToLocalTime().ToShortTimeString();

			if (owner != null) {
				owner.text = value.Sender;
			}
			if (date != null) {
				date.text = _theTime;
			}

			message.text = _theText;

			_chatMessageInstance = value;
		}

		get{ return _chatMessageInstance;}
	}

	public bool IsTheSameMessage(ChatMessage comparer) {
		return _chatMessageInstance.Sender == comparer.Sender && _chatMessageInstance.Text == comparer.Text;
	}

	private ChatMessage _chatMessageInstance;
	private string _theOwner;
	private string _theDate;
	private string _theTime;
	private string _theText;

}
