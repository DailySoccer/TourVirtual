using System;
using UnityEngine;
using UnityEngine.UI;


public class TVBChatMessageDate : MonoBehaviour {
	public Text TextComponent;	

	public string TheDate {
		get {return _theDateString;}
		set {
			_theDateString = value;
			TextComponent.text = _theDateString == DateTime.Now.ToShortDateString() ? "Today" : value;
		}
	}

	string _theDateString;
}
