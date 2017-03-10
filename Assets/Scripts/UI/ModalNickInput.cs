using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ModalNickInput : MonoBehaviour {


	public Text TheNick;
	public Button ButtonOK;
	Text buttonOKText;
	Color buttonOKTextColor;
	Color colorDisabled;
	GUIPopUpScreen thisModal;
	public delegate void callback(string _nick);

	public static ModalNickInput Instance { get; private set; }

	callback okCallback;

	void Awake () {
		Instance = this;
		thisModal = GetComponent<GUIPopUpScreen> ();
		thisModal.IsOpen = false;
		ButtonOK.interactable = false;
		buttonOKText = ButtonOK.transform.GetChild(0).GetComponent<Text>();
		buttonOKTextColor = buttonOKText.color;
		colorDisabled = new Color (buttonOKTextColor.r, buttonOKTextColor.g, buttonOKTextColor.b, ButtonOK.colors.disabledColor.a);
		EvaluateNick();
	}

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {	
	}

	public void EvaluateNick() {
		Instance.ButtonOK.interactable = Instance.TheNick.text.Length >= 3;
		if (Instance.TheNick.text.Length >= 3) {
			Instance.buttonOKText.color =  buttonOKTextColor;
		} else {
			Instance.buttonOKText.color =  colorDisabled;
		}
	}

	public void AcceptNick() {
		if (Instance.okCallback != null) Instance.okCallback(Instance.TheNick.text);
	}

	public void SelfClose() {
		if (Instance.okCallback != null) Instance.okCallback("<EMPTY>");
		Close ();
	}

	public static void Show(callback _callback=null) {
		Instance.TheNick.text = UserAPI.Instance.Nick;
		Instance.TheNick.transform.parent.GetComponent<InputField>().text =Instance.TheNick.text; 
		Instance.okCallback = _callback;
		Instance.thisModal.IsOpen = true;
	}

	public static void Close() {
		Instance.thisModal.IsOpen = false;
	}
}