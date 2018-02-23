using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherSoundCon : MonoBehaviour {

    public AudioSource audioSource;
    public AudioClip chargeBow, fireBow;
	
	public void ChargeBow()
    {
        audioSource.clip = chargeBow;
        audioSource.Play();
    }

    public void FireBow()
    {
        audioSource.clip = fireBow;
        audioSource.Play();
    }
}
