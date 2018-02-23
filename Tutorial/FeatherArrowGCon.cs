using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeatherArrowGCon : MonoBehaviour {

    public GameObject[] featherArrows;
    public float interTime;
    public float colorShiftTime;
    public AudioSource audioSource;
    public AudioClip enterSound,releaseSound;
    public float releaseSpeed;

    //private bool triggered = false;
    private bool runColor = true;
    

    void Awake()
    {
        for (int i = 0; i < featherArrows.Length; i++)
        {
            featherArrows[i].SetActive(false);
        }
    }

	void Start()
    {
        
        StartCoroutine(AddFeatherArrows());
        audioSource.clip = enterSound;
        audioSource.loop = true;
        audioSource.Play();

        
    }

	IEnumerator AddFeatherArrows()
    {
        
        for (int i = 0; i< featherArrows.Length; i++)
        {
            featherArrows[i].SetActive(true);
            yield return new WaitForSeconds(interTime);
        }


        RunColorAround();

    }

    public void RunColorAround()
    {
        StartCoroutine(RunColor());
    }

    IEnumerator RunColor()
    {
        while (runColor)
        {
            
            for (int i = 0; i < featherArrows.Length; i++)
            {
                featherArrows[i].GetComponent<ColorLerp>().ColorLerpAround();
                yield return new WaitForSeconds(colorShiftTime);
            }
        }
        
    }



    public void ReleaseAllArrows()
    {
        PlayReleaseSound();
        SimpleRelease[] simpleRelease = GetComponentsInChildren<SimpleRelease>();
        for (int i = 0; i< simpleRelease.Length;i++)
        {
            simpleRelease[i].speed = releaseSpeed;
            simpleRelease[i].release = true;
            
        }
    }


    void PlayReleaseSound()
    {
        audioSource.loop = false;
        audioSource.clip = releaseSound;
        audioSource.Play();
        
        
    }




}
