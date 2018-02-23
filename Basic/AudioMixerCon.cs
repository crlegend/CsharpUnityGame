using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class AudioMixerCon : MonoBehaviour {

    public AudioMixer mixer;

    public void SetMusic(float musicVol)
    {
        mixer.SetFloat("MusicVol", musicVol);
    }

    public void SetSound(float soundVol)
    {
        mixer.SetFloat("SoundVol", soundVol);
    }

    public void SetMaster(float masterVol)
    {
        mixer.SetFloat("MasterVol", masterVol);
    }
	
}
