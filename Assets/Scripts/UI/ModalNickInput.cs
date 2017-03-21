using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ModalNickInput : MonoBehaviour {
	
	
	public Text TheNick;

	public Button ButtonOK;

	Image buttonOKImage;
	Color buttonOKImageColorActive;
	Color buttonOKImageColorDisabled;

	Text buttonOKText;
	Color buttonOKTextColorActive;
	Color buttonOKTextColorDisabled;

	GUIPopUpScreen thisModal;
	public delegate void callback(string _nick);
	
	public static ModalNickInput Instance { get; private set; }
	
	callback okCallback;
	
	void Awake () {
		Instance = this;
		thisModal = GetComponent<GUIPopUpScreen> ();
		thisModal.IsOpen = false;

		//ButtonOK.gameObject.SetActive(false);

		buttonOKImage 				= ButtonOK.GetComponent<Image>();		
		buttonOKImageColorActive 	= new Color (1f, 1f, 1f, 1f);
		buttonOKImageColorDisabled 	= new Color (0.6f, 0.6f, 0.6f, 0.6f);

		buttonOKText 				= ButtonOK.transform.GetChild(0).GetComponent<Text>();		
		buttonOKTextColorActive 	= new Color (21f/255f, 28f/255f, 43f/255f, 1.0f);
		buttonOKTextColorDisabled 	= new Color (buttonOKTextColorActive.r, buttonOKTextColorActive.g, buttonOKTextColorActive.b, 0.6f);

		Instance.ButtonOK.interactable = true;
	}
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		EvaluateNick();
	}
	
	public void EvaluateNick() {
		buttonOKImage.color = (Instance.TheNick.text.Length >= 3) ? buttonOKImageColorActive : buttonOKImageColorDisabled;
		buttonOKText.color  = (Instance.TheNick.text.Length >= 3) ? buttonOKTextColorActive  : buttonOKTextColorDisabled;
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