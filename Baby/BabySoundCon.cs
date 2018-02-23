using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabySoundCon : MonoBehaviour {

    public AudioClip[] babyHappySounds;
    private AudioSource audioSource;
    private bool randomOnOff;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayRandomSound(int i)//1:laugh(happy),2:suprise,3:afraid,4:cry
    {
        if (i == 1)
        {
            audioSource.clip = babyHappySounds[Random.Range(0, babyHappySounds.Length)];
            audioSource.Play();
            //Debug.Log(Random.Range(0, babyHappySounds.Length));

        }
        else if (i == 2)
        {

        }
        else if (i == 3)
        {

        }
        else if (i == 4)
        {

        }
    }

    public void RandomPlayingSounds(int i, float t)
    {
        randomOnOff = true;
        StartCoroutine(RandomSounds(i,t));
    }

    IEnumerator RandomSounds(int i,float t)
    {
        while(randomOnOff)
        {
            PlayRandomSound(i);
            yield return new WaitForSeconds(t);
        }

    }
    
    public void StopRandomSounds()
    {
        StopAllCoroutines();
        randomOnOff = false;
    }

    
}
