using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CustomSwitcherButton : MonoBehaviour {

	public Sprite imageOn;
	public Sprite imageOff;

	public bool thridPersonCameraOnly = true;

	[SerializeField]
	private bool isOn;

	private Image currentImg;


	//TODO: Controlar el cambio de camara


	void Awake() {
		currentImg = GetComponent<Image>();
		currentImg.sprite = isOn ? imageOn : imageOff;
	}

	// Use this for initialization
	void Start () {
		Player.Instance.cameraStyle = isOn? SyncCameraTransform.CameraStyle.FPS : SyncCameraTransform.CameraStyle.ThirdPerson;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ChangeState() {
		if (!thridPersonCameraOnly) {
			currentImg.sprite = isOn ? imageOn : imageOff;
			isOn = !isOn;
			Player.Instance.cameraStyle = isOn? SyncCameraTransform.CameraStyle.FPS : SyncCameraTransform.CameraStyle.ThirdPerson;
		}
	}
}
