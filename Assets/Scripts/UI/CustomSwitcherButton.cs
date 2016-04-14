using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CustomSwitcherButton : MonoBehaviour {

	public Sprite imageOn;
	public Sprite imageOff;

	//public bool thridPersonCameraOnly = true;

	[SerializeField]
	private bool isEnabled;

	private Image currentImg;


	//TODO: Controlar el cambio de camara


	void Awake() {
		currentImg = GetComponent<Image>();
		currentImg.sprite = isEnabled ? imageOn : imageOff;
	}

	// Use this for initialization
	void Start () {
#if !LITE_VERSION
		//Player.Instance.cameraStyle = isOn? SyncCameraTransform.CameraStyle.FPS : SyncCameraTransform.CameraStyle.ThirdPerson;
#endif
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ToggleValue( bool value) {
		isEnabled = value;
		currentImg.sprite = isEnabled ? imageOn : imageOff;
	}

	public void setValue(bool value){
		isEnabled = value;
	}
}
