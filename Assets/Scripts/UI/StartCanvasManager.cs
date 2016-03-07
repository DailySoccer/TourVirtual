using UnityEngine;
using UnityEngine.UI;
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
        if (MainManager.Instance.Ready)
        {
            if (!enterButton.gameObject.activeSelf)
            {
                bttEffects = enterButton.gameObject.GetComponents<IAnimated>().ToList();
                enterButton.gameObject.SetActive(true);
                foreach( var c in bttEffects)
                    c.Open(1f);
            }

            if (!_initialized)
            {
                if (Input.anyKey/*GetMouseButton(0)*/ || Input.touchCount > 0)
                {
                    if (RoomManager.Instance != null)
                    {
                        _initialized = true;
                        if (startSound != null) startSound.Play();
                        // Inicia la conexion con el servidor PUN.
                        StartCoroutine(RoomManager.Instance.Connect());
                    }
                }
            }
        }
	}

	private bool _initialized = false;
}
