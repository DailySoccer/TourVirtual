using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof (TouchUnifier))]
public class JoystickMovement : MonoBehaviour {

	public bool isVisibleOnDisuse = false;
	private GameObject _theStick;
	private GameObject _theBase;
	private TouchUnifier touchInput;

	// Use this for initialization
	void Start () {
		_theStick = transform.FindChild("Stick").gameObject;
		_theBase = transform.FindChild("Base").gameObject;
		_theStick.GetComponent<Image>().enabled = isVisibleOnDisuse;
		_theBase.GetComponent<Image>().enabled = isVisibleOnDisuse;
		
		touchInput = GetComponent<TouchUnifier>();
		touchInput.AcceptZone = GetComponent<RectTransform>().rect;
	}
	
	// Update is called once per frame
	void Update () {
//		TouchUnifier.TouchState state = touchInput.State;
		
		
	}
}
