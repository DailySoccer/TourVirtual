
namespace SmartLocalization.Editor
{
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent (typeof (Text))]
public class LocalizedText : MonoBehaviour 
{
	public string localizedKey = "INSERT_KEY_HERE";
	public void SetLocalizedTextKey(string val) {
		localizedKey = val;
		OnChangeLanguage(LanguageManager.Instance);
	}
	Text textObject;
	
	void Awake() {
		textObject = this.GetComponent<Text>();
	}

	void Start () {
		LanguageManager.Instance.OnChangeLanguage += OnChangeLanguage;
		
		//Run the method one first time
		OnChangeLanguage(LanguageManager.Instance);
	}
	
	void OnDestroy()
	{
		if(LanguageManager.HasInstance)
		{
			LanguageManager.Instance.OnChangeLanguage -= OnChangeLanguage;
		}
	}
	
	void OnChangeLanguage(LanguageManager languageManager)
	{
		if (textObject != null) 
			textObject.text = languageManager.GetTextValue(localizedKey) ?? localizedKey;
	}
}
}
