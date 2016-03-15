using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ModalTextOnly : MonoBehaviour {
	public static ModalTextOnly Instance { get; private set; }

	public Text TheText;
	public GUIPopUpScreen thisModal;
    public delegate void callback();

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

    callback okCallback;


    public void ShowText(string text, callback _callback=null) {
        okCallback = _callback;
        TheText.text = text;
		thisModal.IsOpen = true;
	}

	public void CloseModal() {
        if (okCallback == null) okCallback();
        thisModal.IsOpen = false;
	}


}
