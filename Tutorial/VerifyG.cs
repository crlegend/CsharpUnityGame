using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerifyG : MonoBehaviour {

    public float activateDuration;
    public Transform castPostion;
    public GameObject spell;
    public AudioClip activatingSound, failedSound, releaseSound;
    public Color activeColor = Color.green;

    private AudioSource audioSource;
    private GameObject[] arrows;
    private ColorLerp[] colorLerp;
    private bool spelled = false;
    private VerifyArrows[] verifyArrows;
    public GameObject group1, group2, group3;

    // Use this for initialization
    void Start () {

        arrows = GetComponent<FeatherArrowGCon>().featherArrows;

        colorLerp = new ColorLerp[arrows.Length];
        verifyArrows = new VerifyArrows[arrows.Length];
        audioSource = GetComponent<AudioSource>();

        for(int i = 0; i< arrows.Length; i++)
        {
            colorLerp[i] = arrows[i].GetComponent<ColorLerp>();
            verifyArrows[i] = arrows[i].GetComponentInChildren<VerifyArrows>();
        }


	}

    void FixedUpdate()
    {
        if (colorLerp[colorLerp.Length - 1].oriColor == Color.green)
        {
            bool pass = true;
            for (int i = 0; i < arrows.Length; i++)
            {
                if (colorLerp[i].oriColor != Color.green)
                {
                    pass = false;
                    break;
                }
            }

            if (pass)
            {
                CastSkill();
            }
            else
            {
                pass = true;
            }


        }
        



    }

    
    public void VerifyArrowsSeq()
    {
        for (int i = 0; i < arrows.Length; i++)
        {
            if (verifyArrows[i].entered)
            {
                if (i == 0)
                {
                    PlaySuccessSounds();
                    StartActive();
                }
                else
                {
                    if (colorLerp[i - 1].oriColor == Color.green && colorLerp[i].oriColor == Color.white) //the arrows oriColor get BrightLight
                    {
                        ArrowActive(i);
                    }
                    else
                    {
                        FailedActive();
                    }
                }
            }
        }
    }

    void ClearActived()
    {
        if (colorLerp[colorLerp.Length - 1].oriColor != Color.green)
        {

            for (int i = 0; i < arrows.Length; i++)
            {
                colorLerp[i].oriColor = Color.white;//MagicBox oriColor, effect by the magicbox light
                verifyArrows[i].entered = false;
            }
        }

    }

    void FailedActive()
    {
        if (!spelled)
        {
            PlayFailedSound();
        }


        for (int i = 0; i < arrows.Length; i++)
        {
            colorLerp[i].oriColor = Color.white;//MagicBox oriColor, effect by the magicbox light
            verifyArrows[i].entered = false;
        }

    }

    void ArrowActive(int i)
    {
        Debug.Log("AA");
        
        colorLerp[i].oriColor = Color.green;
        verifyArrows[i].entered = false;
    }

    void StartActive()
    {
        ClearActived();
        StartCoroutine(StartTimer());
        ArrowActive(0);
    }

    IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(activateDuration);
        ClearActived();
    }

    protected void CastSkill()
    {
        if (!spelled)
        {
            Instantiate(spell, castPostion);           

            spelled = true;
        }
    }

    void PlaySuccessSounds()
    {
        audioSource.clip = activatingSound;
        audioSource.Play();
    }
    void PlayFailedSound()
    {
        audioSource.clip = failedSound;
        audioSource.Play();
    }

    
    public void MoveArrowsBack() //move arrows back to position
    {
        for (int i = 0; i < arrows.Length; i++)
        {
            arrows[i].GetComponent<ArrowRandomLerp>().MoveBack();
            colorLerp[i].oriColor = Color.white;//MagicBox oriColor, effect by the magicbox light
            verifyArrows[i].entered = false;
        }
    }

    public void ReleaseArrows()
    {
        audioSource.clip = releaseSound;
        audioSource.Play();
        for (int i = 0; i < arrows.Length; i++) // release arrows outside view
        {
            arrows[i].GetComponent<ArrowRandomLerp>().Release();
        }
    }
}


