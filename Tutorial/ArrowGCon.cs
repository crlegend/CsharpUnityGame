using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowGCon : MonoBehaviour {

    public GameObject arrow;
    public GameObject arrowLight;
    public Vector3 offset;
    public int arrowQua;
    //public float offsetAngle;
    public float interTime;
    public GameObject[] arrows;
    public float castDuration;
    public GameObject fireBall;
    public AudioClip[] doReMi;
    public AudioClip failedSound;
    public AudioClip arrowReleaseSound;
    public Camera cam;
    public static bool spelled;
    public FireBarCon fireBarCon;
    public GameObject mouseDrag;


    private Common common;
    private bool arrowAdded;
    
    private AudioSource soundCon;

    // Use this for initialization


    void Start () {

        StartCoroutine(AddArrow());
        soundCon = GetComponent<AudioSource>();

    }
	
	void Update()
    {
        if (arrowAdded)
        {
            if (arrows[arrows.Length - 1].layer == 17)
            {
                bool pass = true;
                for (int i = 0; i< arrows.Length; i++)
                {
                    if (arrows[i].layer != 17)
                    {
                        pass = false;
                        break;
                    }
                }

                if (pass)
                {
                    CastFireBall();
                }
                else
                {
                    pass = true;
                }
                
                
            }
        }
        
        
        
    }

    IEnumerator AddArrow()
    {
        for(int i =0;i<arrowQua;i++)
        {
            GameObject arrows = Instantiate(arrow, transform.position + i * offset, transform.rotation);
            arrows.transform.parent = gameObject.transform;

            yield return new WaitForSeconds(interTime);
        }
        // get arrows (Clone) number;
        arrows = GameObject.FindGameObjectsWithTag("Arrows");
        arrowLight.SetActive(true);
        
        arrowAdded = true;
        mouseDrag.SetActive(true);


        //just a test of the number!
        /*for (int i = 0; i < arrowQua; i++)
        {
            yield return new WaitForSeconds(1f);
            arrows[i].layer = 17;
        }*/

    }

    public void VerifyArrowsSeq()
    {
        for (int i = 0; i < arrowQua; i++)
        {
            if(arrows[i].GetComponent<ChangeLayer>().entered)
            {
                if (i == 0)
                {
                    StartActive();
                }
                else
                {
                    if(arrows[i-1].layer == 17 && arrows[i].layer == 16) //the arrows layer get BrightLight
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
        if (arrows[arrows.Length-1].layer != 17)
        {
            
            for (int i = 0; i < arrowQua; i++)
            {
                arrows[i].layer = 16;//MagicBox Layer, effect by the magicbox light
                arrows[i].GetComponent<ChangeLayer>().entered = false;
            }
        }

    }

    void FailedActive()
    {
        if (!spelled)
        {
            PlayFailedSound();
        }
            for (int i = 0; i < arrowQua; i++)
            {
                arrows[i].layer = 16;//MagicBox Layer, effect by the magicbox light
                arrows[i].GetComponent<ChangeLayer>().entered = false;
            }
        
    }
    
    void ArrowActive(int i)
    {
        PlaySuccessSounds(i); //play doremi
        arrows[i].layer = 17;
        arrows[i].GetComponent<ChangeLayer>().entered = false;
    }

    void StartActive()
    {
        ClearActived();
        StartCoroutine(StartTimer());
        ArrowActive(0);
    }

    IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(castDuration);
        ClearActived();
    }

    void CastFireBall()
    {
        if(spelled==false)
        {
            GameObject demoFireBall = Instantiate(fireBall, arrows[0].transform.position, Quaternion.identity);
            demoFireBall.transform.position = new Vector3(demoFireBall.transform.position.x, 40f, demoFireBall.transform.position.z);

            ReleaseArrows();
            mouseDrag.SetActive(false);

            if (fireBarCon.transform.parent.gameObject.activeInHierarchy)
            {
                fireBarCon.FireBarUsed();
            }
            ClearActived();

            spelled = true;
        }
    }

    void PlaySuccessSounds(int i)
    {
        soundCon.clip = doReMi[i];
        soundCon.Play();
    }
    void PlayFailedSound()
    {
        soundCon.clip = failedSound;
        soundCon.Play();
    }

    public void MoveArrowsBack() //move arrows back to position
    {
        for (int i=0;i<arrowQua;i++)
        {
            arrows[i].GetComponent<ArrowRandomLerp>().MoveBack();
            arrows[i].layer = 16;//MagicBox Layer, effect by the magicbox light
            arrows[i].GetComponent<ChangeLayer>().entered = false;            
        }
        
        
    }

    

    public void ReleaseArrows()
    {
        soundCon.clip = arrowReleaseSound;
        soundCon.Play();
        for (int i = 0; i < arrowQua; i++) // release arrows outside view
        {
            arrows[i].GetComponent<ArrowRandomLerp>().Release();

        }
    }

    public bool ArrowAdded()
    {
        return (arrowAdded);
    }

       
}
