using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class LanguajeSettings : MonoBehaviour {

	public List<SettingLaguajeSlot> LanguajeSlots;

	// Use this for initialization
	void Start () {
		string currentLang = MainManager.Instance.CurrentLanguage;
		LanguajeSlots.ForEach (leng => leng.SetActive (leng.name == "Languaje Slot:" + currentLang));
		/*
		switch (currentLang) {

			case "es":
				
			break;
			case "en":
			break;
			default:
			break;
		}
	*/
	}
	
	// Update is called once per frame
	void Update () {	
	}



}
