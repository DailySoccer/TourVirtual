using UnityEngine;
using System.Collections;

public class ClickOnThirdPlayers : MonoBehaviour {
	int layerMask;
	GameCanvasManager gcm;
	// Use this for initialization
	void Start () {
		layerMask = LayerMask.GetMask("Net");
		gcm = GameObject.FindGameObjectWithTag ("GameCanvasManager").GetComponent<GameCanvasManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(Camera.main==null) return;
		
		if (gcm.currentGUIPopUpScreen == null && !gcm.ModalScreen.IsOpen) {
			// Moviles
			if (Input.touchCount != 0) {
				Touch touch = Input.touches [0];
				Ray ray = Camera.main.ScreenPointToRay (touch.position);
				RaycastHit hit;
			
				if (Physics.Raycast (ray, out hit, 20.0f, layerMask)) {
					if (hit.collider.gameObject.name.Contains ("base"))
						hit.collider.gameObject.GetComponent<RemotePlayerHUD> ().RemotePlayerHUD_ClickHandle ();
				}
			}
			// Editor Unity
			if ( Input.GetMouseButtonDown(0)) {
				RaycastHit hit;
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				if ( Physics.Raycast(ray, out hit, 20.0f, layerMask) ){
					//if (hit.collider.gameObject.name.Contains("clone"))
						hit.collider.gameObject.GetComponentInChildren<RemotePlayerHUD>().RemotePlayerHUD_ClickHandle();
				}
			}
		}

	}
}
