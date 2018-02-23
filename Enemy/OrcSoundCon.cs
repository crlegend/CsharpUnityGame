using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcSoundCon : MonoBehaviour {

    private AudioSource orcAudioSource;
    public AudioClip[] orcSounds; //0--hurt, 1--die, 2--showUp

    void Start()
    {
        orcAudioSource = GetComponent<AudioSource>();
    }
    public void PlayOrcSounds(int i)
    {
        orcAudioSource.clip = orcSounds[i];
        orcAudioSource.Play();
    }
}
