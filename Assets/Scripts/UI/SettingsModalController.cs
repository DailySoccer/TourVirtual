using UnityEngine;
using System.Collections;

public class SettingsModalController : MonoBehaviour {

	public LanguajeSettings Languajes;
	public AudioGameSettings Audio;

	// Use this for initialization
	void OnEnable () {
		Languajes.Refresh ();
		Audio.Refresh ();
		transform.Find("VR Option").gameObject.SetActive(Application.loadedLevelName!="VestidorLite");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
