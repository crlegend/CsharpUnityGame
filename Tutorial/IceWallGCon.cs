using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceWallGCon : MonoBehaviour {

    public IceWallCon iceWallCon1, iceWallCon2, iceWallCon3;
    public FireBarCon fireBarCon;
    public TutorialCon tutorialCon;

    private bool step2ed, step3ed;
    private int count = 0;
    //private int hit = 0;

    private bool setted = false;
    private bool actived;
    //private bool nexted;
    private Counter counter;

    private void Start()
    {
        counter = new Counter();
        StartCoroutine(InitiateIceWall());
        ResetAll();
    }

    IEnumerator InitiateIceWall()
    {
        //yield return new WaitForSeconds(1f);
        iceWallCon1.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        iceWallCon2.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        iceWallCon3.gameObject.SetActive(true);

        actived = true;
    }

    void Update()
    {
        counter.CheckCounter();
    }

    void LateUpdate () {

       

        if (actived)
        {
			if (fireBarCon.casted && !setted)
            {
                count = counter.Count();

                
                
                setted = true;

            }

            if(setted)
            {
                if (counter.Count() - count == 2 && !step2ed)
                {
                    
					if (!fireBarCon.casted) //base on if the fireball casted successful or not
                    {

                        iceWallCon1.IceWallRecovery();
                        ResetAll();
                    }
                    step2ed = true; // make sure count =2 only run once!




                }

                if (counter.Count() - count == 3 && !step3ed)
                {
                    

					if (!fireBarCon.casted)
                    {

                        ResetIceWalls();
                        ResetAll();
                    }
                    else
                    {
                        
                        NextStep();          

                         
                        step3ed = true;

                    }

                }
            }

            
        }
       

       

        
		
	}

    public void ResetAll()
    {
        setted = false;
        count = 0;
        step2ed = false;
        step3ed = false;
		fireBarCon.casted = false;
        //nexted = false;
        //hit = 0;
    }

    protected virtual void NextStep()
    {
        tutorialCon.Section3();
        Destroy(gameObject, 2f);
    }

    public void ResetIceWalls()
    {
        iceWallCon1.IceWallRecovery();
        iceWallCon2.IceWallRecovery();
        iceWallCon3.IceWallRecovery();
    }
}
