using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class StartCanvasManager : CanvasManager {

	public Button enterButton;
	public AudioSource startSound;

	private List<IAnimated> bttEffects;

	void OnEnable() {
		enterButton.gameObject.SetActive(false);
		ShowScreen(currentGUIScreen);
	}
	
	void Start () {
	}
	
	void Update () {
		if (MainManager.Instance.Ready) {
			if (!enterButton.gameObject.activeSelf) {
				bttEffects = enterButton.gameObject.GetComponents<IAnimated>().ToList();
				enterButton.gameObject.SetActive(true);
				bttEffects.ForEach(c => c.Open(1f));
			}

			if (!_initialized) {
				if (Input.anyKey/*GetMouseButton(0)*/ || Input.touchCount > 0) {
					if (RoomManager.Instance != null) {
						_initialized = true;

						if (startSound != null) {
							startSound.Play();
						}
						StartCoroutine(RoomManager.Instance.Connect());
					}
				}
			}
		}
	}

	private bool _initialized = false;
}
