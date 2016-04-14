using UnityEngine;
using System.Collections;

public class AudioSettings : MonoBehaviour {

	public CustomSwitcherButton IconAudio;

	private bool activeSound;

	public void Refresh() {
		activeSound = MainManager.Instance.SoundEnabled;
		IconAudio.setValue (activeSound);
		IconAudio.ToggleValue (activeSound);
	}

	public void ToggleValue() {
		MainManager.Instance.SoundEnabled = !activeSound;
		Refresh ();
	}
}
