using UnityEngine;
using System.Collections;

public class ContentCubeMap : MonoBehaviour {

	public GameObject Cubemap;

	static public ContentCubeMap ContentSelected;

	public Transform PointOfInterest {
		get {
			Transform point = transform.FindChild("Point");
			return point ?? transform;
		}
	}

	public GameObject GetInstance() {
		if (_instance == null) {
			_instance = GameObject.Instantiate(Cubemap);
		}
		return _instance;
	}
	
	void Start () {
	}
	
	void Update () {
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag != Player.TAG_UMA_AVATAR)
			return;

		// Debug.Log ("Enter: Cubemap: " + gameObject.name);
		
		ContentSelected = this;
	}
	
	void OnTriggerExit(Collider other) {
		if (other.tag != Player.TAG_UMA_AVATAR)
			return;

		// Debug.Log ("Exit: Cubemap: " + gameObject.name);
		
		if (ContentSelected == this) {
			ContentSelected = null;
		}
	}

	GameObject _instance;
}
