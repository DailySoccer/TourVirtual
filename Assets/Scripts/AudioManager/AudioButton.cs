using UnityEngine;
using System.Collections;
using FootballStar.Audio;

public class AudioButton : MonoBehaviour {
	
	public SoundDefinitions SoundDefinition = SoundDefinitions.BUTTON_TICK;
 	
	void Start()
	{
		mAudioGameController = GameObject.FindGameObjectWithTag("GameModel").GetComponent<AudioInGameController>();
	}

	void OnClick()
	{
		switch (SoundDefinition) 
		{
			case SoundDefinitions.BUTTON_TICK:
				mAudioGameController.PlayButtonTick();
			break;
			case SoundDefinitions.BUTTON_FORWARD:
				mAudioGameController.PlayButtonForward();
			break;
			case SoundDefinitions.BUTTON_BACKWARD:
				mAudioGameController.PlayButtonBackward();
			break;
			case SoundDefinitions.BUTTON_ACCEPT:
				mAudioGameController.PlayButtonAccept();
			break;
		}
	}

	private AudioInGameController mAudioGameController;
}
