using UnityEngine;
using System.Collections;

public class VestidorCanvasController : MonoBehaviour {

	public Transform PlayerPosition;

	GameObject PlayerInstance;

	Vector3 worldPos = Vector3.zero;


	// Use this for initialization
	void Start () {


		StartCoroutine( PlayerManager.Instance.CreateAvatar(PlayerManager.Instance.SelectedModel, (instance)=>{

			//Seteamos el Avatar que se muestra en estapantalla
			PlayerInstance = instance;
			PlayerInstance.GetComponent<Rigidbody>().isKinematic = true;
			PlayerInstance.GetComponent<SynchNet>().enabled = false;

			PlayerInstance.transform.localScale = Vector3.one * 10;

			
		}) );
	}
	
	// Update is called once per frame
	void Update () {	
		if (PlayerInstance)
			PlayerInstance.transform.position = PlayerPosition.position;

	}
}
