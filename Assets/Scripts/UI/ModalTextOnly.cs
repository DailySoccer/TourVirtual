using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ModalTextOnly : MonoBehaviour {


	public Text TheText;
	public GUIPopUpScreen thisModal;
    public delegate void callback();

	public static ModalTextOnly Instance { get; private set; }

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
