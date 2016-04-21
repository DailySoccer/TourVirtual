using UnityEngine;
using System.Collections;

public class ClcikOnThirdPlayers : MonoBehaviour {
	int layerMask;
	// Use this for initialization
	void Start () {
		layerMask = LayerMask.GetMask("Net");
	}
	
	// Update is called once per frame
	void Update () {
	

		if ( Input.touchCount != 0 ) {
			Touch touch = Input.touches[0];
			Ray ray = Camera.main.ScreenPointToRay(touch.position);
			RaycastHit hit;
			
			if ( Physics.Raycast(ray, out hit, 20.0f, layerMask) ){
				if (hit.collider.gameObject.name.Contains("base"))
					hit.collider.gameObject.GetComponent<RemotePlayerHUD>().RemotePlayerHUD_ClickHandle();
			}
		}
		
		if ( Input.GetMouseButtonDown(0) ) {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if ( Physics.Raycast(ray, out hit, 20.0f, layerMask) ){
				//if (hit.collider.gameObject.name.Contains("clone"))
					hit.collider.gameObject.GetComponentInChildren<RemotePlayerHUD>().RemotePlayerHUD_ClickHandle();
			}
		}

	}
}
