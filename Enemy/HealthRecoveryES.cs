using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class HealthRecoveryES : MonoBehaviour
{

    public int hPoint,selfHPoint;
    public int interTurns;
    //public int keepTurns;
    public GameObject healCaster,healTarget;

    public AudioSource audioSource;
    public AudioClip healMagicSound;


    //public bool casting;

    //private Counter counter;
    //private GameObject[] members;
    private BasicStat[] members;



    //private Common common;
    private int[] fullHP, tempHP;
    private int miniHP;
    //private GameObject miniHPObject;
    private BasicStat miniHPObject;
    private bool casted;
    private AniSwitcher aniSwitcher;
    //private bool counter;
    private Counter counter;
    private int count;
    private bool needCast;
    


    
    void Start()
    {
        counter = new Counter();
        //common = new Common();

        members = transform.parent.parent.GetComponentsInChildren<BasicStat>(true);
        fullHP = new int[members.Length];
        tempHP = new int[members.Length];

        for (int i = 0; i < members.Length; i++)
        {
            fullHP[i] = members[i].hp;
        }


        
        aniSwitcher = transform.parent.GetComponentInChildren<AniSwitcher>();

        

    }

    
    void Update()
    {
        counter.CheckCounter();
        needCast = false;

        for (int i =0; i < members.Length; i++)
        {
            

            if (members[i] == null)
            {
                tempHP[i] = 1000000; // make sure dead object not the minimal
            }
            else
            {
                tempHP[i] = members[i].transform.FindChildWithTag("Enemy").GetComponent<BasicStat>().hp;
            } 
            
            if (tempHP[i] >= fullHP[i] || tempHP[i] <= 0)
            {
                tempHP[i] = 1000000; // make sure the undamaged not the minimal
            }
            else
            {
                needCast = true; // if someone has been damaged then need to cast a magic
            }  

            
        }

        miniHP = Mathf.Min(tempHP);
        miniHPObject = members[System.Array.IndexOf(tempHP, miniHP)]; // find the minimal hp one

        if(needCast)
        {
            if (!casted)
            {
                CastHealthMagic();
                count = counter.Count();

                casted = true;

            }

            if (counter.Count() > count + interTurns)
            {
                casted = false;
            }
        }
        

    }

    void CastHealthMagic()
    {
        if (miniHPObject.gameObject == gameObject)
        {
            miniHPObject.HpModifier(selfHPoint);

        }
        else
        {
            miniHPObject.HpModifier(hPoint);
        }

        audioSource.clip = healMagicSound;
        audioSource.Play();
        Instantiate(healTarget, miniHPObject.transform.parent.GetComponentInChildren<AniSwitcher>().transform);
        Instantiate(healCaster, aniSwitcher.transform);
        GetComponent<MoveCon>().StopMovement(true);
        aniSwitcher.CastMagic(true);
        //casting = true;
        
        
    }
    
}
