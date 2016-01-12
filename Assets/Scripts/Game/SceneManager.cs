using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour {
	public Object MainManagerFrom;

	static public SceneManager Instance {
		get {
			GameObject sceneManagerObj = GameObject.FindGameObjectWithTag("SceneManager");
			return sceneManagerObj != null ? sceneManagerObj.GetComponent<SceneManager>() : null;
		}
	}

	void Start () {
		if (MainManager.Instance == null) {
			Application.LoadLevelAdditive(MainManagerFrom.name);
			Debug.Log ("Loaded " + MainManagerFrom.name + " completed...");
		}
	}
	
	void Update () {
	}
}
