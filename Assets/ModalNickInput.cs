using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ModalNickInput : MonoBehaviour {


	public Text TheNick;
	public Button ButtonOK;
	GUIPopUpScreen thisModal;
    public delegate void callback();

	public static ModalNickInput Instance { get; private set; }

	void Awake () {
		Instance = this;
		thisModal = GetComponent<GUIPopUpScreen> ();
		thisModal.IsOpen = false;
		ButtonOK.enabled = false;
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {	
	}

    callback okCallback;

	public void EvaluateNick() {
		Instance.ButtonOK.enabled = Instance.TheNick.text.Length > 3;
	}

	public void AcceptNick() {
		//TODO: Guardar los cambios
		Close ();
	}

	public static void AcceptNick_SelfHandled() {
		Close ();
	}

    public static void Show(callback _callback=null) {
        Instance.okCallback = _callback;
		Instance.thisModal.IsOpen = true;
	}

	public static void Close() {
        if (Instance.okCallback != null) Instance.okCallback();
        Instance.thisModal.IsOpen = false;
		Instance.TheNick.text = "";
	}
}
