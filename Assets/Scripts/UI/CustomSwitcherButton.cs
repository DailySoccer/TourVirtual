using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CustomSwitcherButton : MonoBehaviour {

	public Sprite imageOn;
	public Sprite imageOff;

	//public bool thridPersonCameraOnly = true;

	[SerializeField]
	private bool isEnabled;

	private Image currentImg;


	//TODO: Controlar el cambio de camara


	void Awake() {

	}

	public void ToggleValue( bool value) {
		isEnabled = value;
		if (currentImg == null) {
			currentImg = GetComponent<Image> ();
		}
		currentImg.sprite = isEnabled ? imageOn : imageOff;
	}

	public void setValue(bool value){
		isEnabled = value;
	}
}
