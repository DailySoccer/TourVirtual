using UnityEngine;
using System.Collections;

public class SettingsModalController : MonoBehaviour {

	public LanguajeSettings Languajes;
	public AudioSettings Audio;

	// Use this for initialization
	void OnEnable () {
		Languajes.Refresh ();
		Audio.Refresh ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
