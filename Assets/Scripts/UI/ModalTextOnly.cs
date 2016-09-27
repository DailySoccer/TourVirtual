using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ModalTextOnly : MonoBehaviour {

	public static ModalTextOnly Instance { get; private set; }
	public GUIPopUpScreen thisModal;
	public GUIPopUpScreen thisModal2;
    public delegate void callback(bool mode);
	private callback okCallback;

	public Text TheText;
	public Text TheText2;

	void Awake () {
		Instance = this;
		thisModal.IsOpen = false;
		thisModal2.IsOpen = false;
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

	public static void ShowTextGuestMode(string text, callback _callback=null) {
        Instance.okCallback = _callback;
        Instance.TheText2.text = text;
		Instance.thisModal2.IsOpen = true;
	}

	public static void CloseModal(bool mode) {
        if (Instance.okCallback != null) Instance.okCallback(mode);
        Instance.thisModal.IsOpen = false;
		Instance.thisModal2.IsOpen = false;
	}


}
