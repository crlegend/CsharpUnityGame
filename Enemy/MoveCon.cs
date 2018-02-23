using UnityEngine;
using System.Collections;

public class MoveCon : MonoBehaviour {

    //public float speed;
    public Transform des;
    public float oriSpeed;
    public Transform randomPos;

    private bool stopIt = false;
    private Vector3 tempPos;
    private UnityEngine.AI.NavMeshAgent nav;
    //private AniSwitcher asw;
    private float tempSpeed;
    //private bool speedControl = false;
    //private bool stoped = false;

    private float spF = 1f;
    private Counter coun = new Counter();
    //private int c;
    private Transform tempDes;
   	
	void Start () {
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        tempSpeed = oriSpeed;
        //c = coun.Count();
        /*if(des != null)
        {

            nav.SetDestination(des.position);
        }*/

        if (des == null)
        {
            des = GameObject.FindGameObjectWithTag("Baby").transform;
        }
        
        
	}
	
	
	void FixedUpdate () {




        if (!stopIt)
        {
            //if (c != coun.Count())
            //{
            if(des != null)
            {
                nav.SetDestination(des.position);
            }
                
            //}
            nav.isStopped = false;

        }
        else            
        {          
            nav.isStopped = true;

        }
        //c = coun.Count();


	}

    

    public void StopMovement(bool stop) // stop or resume movement
    {
        stopIt = stop;

    }



    public void SpeedModifier(float speedFactor) // speed regulator...only apply the biggest speed changes stop > slow
    {
        //speedControl = sC;
        if (!stopIt && nav != null)
        {
            if (speedFactor < spF && speedFactor < 1f)
            {
                spF = speedFactor;
                nav.speed = tempSpeed * speedFactor;

            }
            else if (speedFactor == 1f)
            {
                spF = speedFactor;
                nav.speed = tempSpeed * speedFactor;
                //Debug.Log(nav.speed);

            }
            else if (speedFactor > spF && speedFactor > 1f)
            {
                spF = speedFactor;
                nav.speed = tempSpeed * speedFactor;
            }
            

        }

    }
    

    public void PauseSeconds(float sec) // pause the movement for x seconds
    {
        StartCoroutine(PauseS(sec));
    }

    IEnumerator PauseS(float sec)
    {
        StopMovement(true);
        yield return new WaitForSeconds(sec);
        StopMovement(false);
    }

    public void PauseTurns(int turns)
    {
        StartCoroutine(PauseT(turns));
    }

    public IEnumerator PauseT(int turns)
    {
        coun.CountReset();
        StopMovement(true);
        while(true)
        {
            coun.CheckCounter();            
            if(coun.Count()>turns)
            {
                break;
            }
            yield return new WaitForSeconds(0.033f);
        }
        StopMovement(false);
    }



    public void ToRandom(bool onOff) // need use true first to get response.
    {        
        if (randomPos != null)
        {                           
            if (onOff)
            {
                randomPos.GetComponent<BabyRandomAround>().enabled = true; // remember to reset to position!!!
                randomPos.GetComponent<BabyRandomAround>().RandomPosReset();                
                tempDes = des;
                des = randomPos;
            }
            else
            {
                randomPos.GetComponent<BabyRandomAround>().enabled = false;
                des = tempDes;
            }
        }        
    }





}
