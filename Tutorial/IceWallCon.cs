using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceWallCon : MonoBehaviour {

    private bool broken;
    private AudioSource audioSource;

    public IceWallGCon iceWallGCon;
    public AudioClip iceWallFreeze, iceWallBreak;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
       if (collision.gameObject.tag == "Skill")
        {
            IceWallBreak();           

        }
    }

    



    public void IceWallBreak()
    {
        audioSource.clip = iceWallBreak;
        audioSource.Play();
        GetComponent<Animator>().SetTrigger("Break");
        GetComponent<BoxCollider>().enabled = false;
        broken = true;

    }

    public void IceWallRecovery()
    {
        audioSource.clip = iceWallFreeze;
        audioSource.Play();
        GetComponent<Animator>().SetTrigger("Recovery");
        GetComponent<BoxCollider>().enabled = true;
        broken = false;
        
    }

    public bool IceWallBroken()
    {
        return (broken);
    }
	
	
}
