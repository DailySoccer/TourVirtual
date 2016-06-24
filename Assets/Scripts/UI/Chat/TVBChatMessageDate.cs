using System;
using UnityEngine;
using UnityEngine.UI;
using SmartLocalization;

public class TVBChatMessageDate : MonoBehaviour {
	public Text TextComponent;	

	public string TheDate {
		get {return _theDateString;}
		set {
			_theDateString = value;
			TextComponent.text = _theDateString == MyTools.ToShortDateString( DateTime.Now ) ? LanguageManager.Instance.GetTextValue("TVB.Chat.Today") : value;
		}
	}

	string _theDateString;
}