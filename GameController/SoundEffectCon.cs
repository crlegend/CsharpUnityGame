using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectCon : MonoBehaviour {

    public AudioClip[] orc,dead;
    private AudioSource audioSource;

	
	void Start () {

        audioSource = GetComponent<AudioSource>();
		
	}
	
	public void playSound(string name, int i)
    {
        switch(name)
        {
            case "orc":  //ocr: 0--hurt, 1--dead, 2--howl
                audioSource.clip = orc[i];
                break;
            case "dead":
                audioSource.clip = dead[i];
                break;
            
          

        }

        audioSource.Play();
    }
}
