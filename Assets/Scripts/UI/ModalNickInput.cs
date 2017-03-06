using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ModalNickInput : MonoBehaviour {
	
	
	public Text TheNick;
	public Button ButtonOK;
	Text ButtonOKText;
	Color ButtonOKTextColor;
	GUIPopUpScreen thisModal;
	public delegate void callback(string _nick);
	
	public static ModalNickInput Instance { get; private set; }
	
	void Awake () {
		Instance = this;
		thisModal = GetComponent<GUIPopUpScreen> ();
		thisModal.IsOpen = false;
		ButtonOK.enabled = false;
		ButtonOKText = ButtonOK.transform.GetChild(0).GetComponent<Text>();
		ButtonOKTextColor = ButtonOKText.color;
		EvaluateNick();
	}
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {	
	}
	
	callback okCallback;
	
	public void EvaluateNick() {
		Instance.ButtonOK.enabled = Instance.TheNick.text.Length >= 3;
		Instance.ButtonOKText.color = Instance.TheNick.text.Length >= 3 ? ButtonOKTextColor : new Color(ButtonOKTextColor.r, ButtonOKTextColor.g, ButtonOKTextColor.b, ButtonOK.colors.disabledColor.a);
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