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
		ButtonOK.gameObject.SetActive(false);
		//buttonOKText = ButtonOK.transform.GetChild(0).GetComponent<Text>();		
		//buttonOKTextColor = buttonOKText.color;
		//colorDisabled = new Color (buttonOKTextColor.r, buttonOKTextColor.g, buttonOKTextColor.b, ButtonOK.colors.disabledColor.a);
	}
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		//buttonOKText.color =  colorDisabled;
		//ButtonOK.image.color = colorDisabled;
	}
	
	public void EvaluateNick() {
		//Instance.ButtonOK.interactable = Instance.TheNick.text.Length >= 3;
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