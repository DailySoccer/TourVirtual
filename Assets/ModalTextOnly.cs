using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ModalTextOnly : MonoBehaviour {
	public static ModalTextOnly Instance { get; private set; }

	public Text TheText;
	public GUIPopUpScreen thisModal;

	void Awake () {
		Instance = this;
		thisModal.IsOpen = false;
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ShowText(string text) {
		TheText.text = text;
		thisModal.IsOpen = true;
	}

	public void CloseModal() {
		thisModal.IsOpen = false;
	}


}
