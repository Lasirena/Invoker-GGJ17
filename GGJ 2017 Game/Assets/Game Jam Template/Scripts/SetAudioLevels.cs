using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetAudioLevels : MonoBehaviour {

	public AudioMixer mainMixer;					//Used to hold a reference to the AudioMixer mainMixer


	//Call this function and pass in the float parameter musicLvl to set the volume of the AudioMixerGroup Music in mainMixer
	public void SetMusicLevel(float musicLvl)
	{
		mainMixer.SetFloat("volume_Music", musicLvl);
	}

	//Call this function and pass in the float parameter sfxLevel to set the volume of the AudioMixerGroup SoundFx in mainMixer
	public void SetSpellSFXLevel(float sfxLevel)
	{
		mainMixer.SetFloat("volume_FX_Spells", sfxLevel);
	}

	public void SetMonsterSFXLevel(float sfxLevel)
	{
		mainMixer.SetFloat("volume_FX_Monsters", sfxLevel);
	}
}