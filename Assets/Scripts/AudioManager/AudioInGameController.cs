using System;
using UnityEngine;
using System.Collections;

namespace FootballStar.Audio {
	
	public class AudioInGameController : MonoBehaviour 
	{
		void Awake () { 
		}
		
		void Start() {
			if (mAudioManager == null) // Esta comprobacion es necesaria cuando rulamos la escena "jugadas01"
				mAudioManager = GetComponent<AudioMaster>();
		}

		//  Metodos //
		public void PlayDefinition(SoundDefinitions soundDef)
		{

            PlayDefinition(soundDef, false);
		}
		public void PlayDefinition(SoundDefinitions soundDef, bool loop)
		{
            if (loop)
				mAudioManager.PlayMusic(soundDef);
			else
				mAudioManager.Play(soundDef);
		}

		public void CustomPlay(SoundDefinitions soundDef, float volume, float pitch)
		{
			mAudioManager.CustomPlay(soundDef, volume, pitch);
		}



		// --> Menu SFX		
		public void PlayButtonTick()
		{
			PlayDefinition(SoundDefinitions.BUTTON_TICK);
		}
		public void PlayButtonForward()
		{
			PlayDefinition(SoundDefinitions.BUTTON_FORWARD);
		}
		public void PlayButtonBackward()
		{
			PlayDefinition(SoundDefinitions.BUTTON_BACKWARD);
		}
		public void PlayButtonAccept()
		{
			PlayDefinition(SoundDefinitions.BUTTON_ACCEPT);
		}
		/*
		public void PlayMenuButtonSound()
		{
			PlayDefinition(SoundDefinitions.BUTTON_MENU);
		}
		
		public void PlayGoBackButtonSound()
		{
			PlayDefinition(SoundDefinitions.BUTTON_BACK);
		}
		
		public void PlayStartMatchSound()
		{
			PlayDefinition(SoundDefinitions.BUTTON_STARTPLAYING);
		}
		
		public void PlayReplayButtonSound()
		{
			PlayDefinition(SoundDefinitions.BUTTON_REPLAY);
		}
		
		public void PlayContinueButtonSound()
		{	
			PlayDefinition(SoundDefinitions.BUTTON_CONTINUE);
		}
		
		public void PlaySelectorSound()
		{
			PlayDefinition(SoundDefinitions.BUTTON_SELECTOR);
		}		
		
		public void PlayItemLockedSound()
		{
			PlayDefinition(SoundDefinitions.LOCKED_ITEM);
		}

		public void PlayBoughtSound()
		{
			PlayDefinition(SoundDefinitions.CASHREGISTER);
		}
		
		public void PlayMatchStartSound()
		{
			PlayDefinition(SoundDefinitions.BUTTON_PLAY);
		}		
		// <-- Menu SFX	
		*/

		public void StopAllActiveAudios(bool fadingSound)
		{
			mAudioManager.StopAll(fadingSound);
		}

		private AudioMaster mAudioManager;
		private bool mIsFirstPlay = true;
		
		private float mScorePerInteraction;      	// puntuacion que recibimos por cada interaccion satisfactoria
		private float mMatchScorePercentage = 0f;	// porcentaje de puntuacion que tenemos acumulado durante el partido
	}
}