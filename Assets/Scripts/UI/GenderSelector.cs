using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

//[ExecuteInEditMode]
public class GenderSelector : MonoBehaviour {

	private List<ButtonCheckable> Buttons;

	private string CurrentGender = "";

	void Awake() {
		Buttons = gameObject.GetComponentsInChildren<ButtonCheckable>(true).ToList();
		SelectGender (Buttons [0].gameObject);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {	
	}

	public void SelectGender(GameObject ObjectToCheck) {
		if (CurrentGender != ObjectToCheck.name) {
			DeselectAll ();
			Buttons.Find (b => b.gameObject.name == ObjectToCheck.name).IsTabActive = true;
			CurrentGender = ObjectToCheck.name;
		}
	}

	void DeselectAll() {
        foreach( var b in Buttons)
			b.IsTabActive = false;		
	}
}
