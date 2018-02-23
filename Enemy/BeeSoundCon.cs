using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeSoundCon : MonoBehaviour {

    public BeesGone beesGone;
    public AudioSource audioSource;
    

    private bool onOff = false;

	
	void Update () {

        if (GameObject.FindGameObjectsWithTag("BeesGroup").Length == 0)
        {
            if(onOff)
            {                
                audioSource.Stop();
                onOff = false;
            }
        }
        else
        {
            if (!onOff)
            {
                audioSource.Play();
                onOff = true;
            }
        }
		
	}
}
