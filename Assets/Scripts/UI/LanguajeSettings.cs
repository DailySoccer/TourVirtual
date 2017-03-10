using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class LanguajeSettings : MonoBehaviour {

	public List<SettingLaguajeSlot> LanguajeSlots;

	public void Refresh() {
		string currentLang = MainManager.Instance.CurrentLanguage;
		foreach ( SettingLaguajeSlot lang in LanguajeSlots) {
			lang.SetActive (lang.name.ToLower() == currentLang.ToLower());
		}
	}

	public void SetLanguage(string val) {
		MainManager.Instance.ChangeLanguage(val);
		Refresh ();
	}

	// Update is called once per frame
	void Update () {	
	}



}
