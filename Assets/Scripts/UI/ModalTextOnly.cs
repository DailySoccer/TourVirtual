using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ModalTextOnly : MonoBehaviour {

	public static ModalTextOnly Instance { get; private set; }
	public GUIPopUpScreen thisModal;
    public delegate void callback();
	private callback okCallback;

	public Text TheText;



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
	
    public static void ShowText(string text, callback _callback=null) {
        Instance.okCallback = _callback;
        Instance.TheText.text = text;
		Instance.thisModal.IsOpen = true;
	}

	public static void CloseModal() {
        if (Instance.okCallback != null) Instance.okCallback();
        Instance.thisModal.IsOpen = false;
	}


}
