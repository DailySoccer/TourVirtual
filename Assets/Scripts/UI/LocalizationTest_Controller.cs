using UnityEngine;
using System.Collections;
using SmartLocalization;

public class LocalizationTest_Controller : MonoBehaviour {

	private LanguageManager _languageManager;

	// Use this for initialization
	void Start () {
		_languageManager = LanguageManager.Instance;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetLanguajeEnglish() {
		ChangeLanguage("en");
	}

	public void SetLanguajeSpanish() {
		ChangeLanguage("es");
	}

	private void ChangeLanguage(string locale) {
		if (_languageManager.IsLanguageSupported(locale)) {
			_languageManager.ChangeLanguage(locale);
		}
	}
}
