using UnityEngine;
using System.Collections;

public class AudioSettings : MonoBehaviour {

	public CustomSwitcherButton IconAudio;

	private bool activeSound;
	// Use this for initialization
	void Start () {
		activeSound = MainManager.Instance.SoundEnabled;
		IconAudio.setValue (activeSound);
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void ToggleValue() {
		IconAudio.ToggleValue ();
		activeSound = !activeSound;
		MainManager.Instance.SoundEnabled = activeSound;
	}
}
