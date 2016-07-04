using UnityEngine;
using System.Collections;

public class ClickOnThirdPlayers : MonoBehaviour {
	int layerMask;
	GameCanvasManager gcm;

    bool itsOk = false;
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
			if (Input.touchCount != 0 ) {
				Touch touch = Input.touches [0];
                if (touch.phase == TouchPhase.Began) itsOk = true;
                else if (touch.phase == TouchPhase.Moved)  itsOk = false;
                else if (touch.phase == TouchPhase.Ended ) {
                    if (itsOk) {
                        itsOk = false;
                        Ray ray = Camera.main.ScreenPointToRay(touch.position);
                        RaycastHit hit;
                        if (Physics.Raycast(ray, out hit, 20.0f, layerMask))
                        {
                            RemotePlayerHUD hud = hit.collider.gameObject.GetComponentInChildren<RemotePlayerHUD>();
                            //if (hit.collider.gameObject.name.Contains("base"))
                            if (hud != null) hud.RemotePlayerHUD_ClickHandle();
                        }
                    }
                }
            }
#if UNITY_EDITOR
            // Editor Unity
            if ( Input.GetMouseButtonDown(0)) {
				RaycastHit hit;
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				if ( Physics.Raycast(ray, out hit, 20.0f, layerMask) ){
					//if (hit.collider.gameObject.name.Contains("clone"))
					RemotePlayerHUD rph = hit.collider.gameObject.GetComponentInChildren<RemotePlayerHUD>();
					if (rph != null)
						hit.collider.gameObject.GetComponentInChildren<RemotePlayerHUD>().RemotePlayerHUD_ClickHandle();
				}
			}
#endif
        }

	}
}
