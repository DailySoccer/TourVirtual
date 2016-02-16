using UnityEngine;
using System.Collections;

public class VestidorCanvasController : MonoBehaviour {

	GameObject PlayerInstance;
	// Use this for initialization
	void Start () {
		StartCoroutine( PlayerManager.Instance.CreateAvatar(PlayerManager.Instance.SelectedModel, (instance)=>{
			
			//Seteamos el Avatar que se muestra en estapantalla
			PlayerInstance = instance;
			PlayerInstance.layer = 5;
			foreach(Transform t in PlayerInstance.transform) {
				t.gameObject.layer = 5;
			}
			PlayerInstance.name = "UI Player Clone for Profile";
			PlayerInstance.GetComponent<Rigidbody>().isKinematic = true;
			PlayerInstance.GetComponent<SynchNet>().enabled = false;
			PlayerInstance.transform.position = new Vector3(0f, 0f, 0f);
			
		}) );
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
