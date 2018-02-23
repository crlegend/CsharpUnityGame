using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyRandomAround : MonoBehaviour {

    public Transform baby;
    public float offsetX,offsetNX;
    public float offsetZ,offsetNZ;
    public float changeRate;
    public bool runAway;
    public bool randowSuckIn = false;
    

    private Vector3 startPos;
    private float maxX;
    private float minX;
    private float maxZ;
    private float minZ;

    private bool rand = true;
    //private float tempRate;

     
	
	
	
	void OnEnable () {

        RandomPosReset();


    }




    IEnumerator ChangePosition()
    {
        
        while (rand)
        {
            if (runAway)
            {
                OneSide(true); //set only run to the oppsite direction
                SetPostion();//reset start position everytime to run away
                //changeRate = tempRate / 2;
                
            }

            if (randowSuckIn)
            {
                OneSide(true);
                SetPostion();
            }

            //random set the postion of des

            transform.position = new Vector3(Random.Range(minX, maxX), transform.position.y, Random.Range(minZ,maxZ));
            yield return new WaitForSeconds(changeRate);

        }
    }

    public void RandomMoving(bool random)
    {
        rand = random;
    }

    public void RandomPosReset()
    {
        StopAllCoroutines();
        SetPostion();
        runAway = false;
        //randowSuckIn = false;
        //tempRate = changeRate;
        StartCoroutine(ChangePosition());

    }

    

    void SetPostion()
    {
        
        startPos = baby.position;
        transform.position = baby.position;
        maxX = startPos.x + offsetX;
        minX = startPos.x - offsetNX;
        maxZ = startPos.z + offsetZ;
        minZ = startPos.z - offsetNZ;
    }

    void SetSuckDirection()
    {
        
    }

    public void OneSide(bool onOff)
    {
        if(onOff)
        {
             offsetNX = 0f;
             offsetNZ = 0f;

        }
        else
        {
            offsetNX = offsetX;
            offsetNZ = offsetZ;
        }
    }


}
