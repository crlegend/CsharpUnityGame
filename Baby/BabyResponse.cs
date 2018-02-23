using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BabyResponse : MonoBehaviour {

    public float alertRange,dangerRange,ZoomSize;
    public BabyRandomAround babyRandomAround;
    public SweatRepeatDrop sweatDrop;
    


    private Transform babyOriDes;
    private GameObject[] monsters, activateMonsters;
    private Transform tempDes;
    private int j;
    private float[] distance;
    private Vector2 direction;
    private bool switched,camSwitched;

    private MainCamCon mainCamCon;

    private float camOffSetX, camOffSetZ, camZoomSize;
    private int tempID;
    private bool needChange;


	
	
	// Update is called once per frame
	void Update () {
                
        monsters = GameObject.FindGameObjectsWithTag("Enemy");
        

        distance = new float[monsters.Length];

        if(distance.Length != 0)
        {
            //setup a temp destination for baby moving recovery. stable!
            if (!switched)
            {
                tempDes = GetComponent<MoveCon>().des;
            }

            //setup a temp camera propotity for camera recovery.
            if (!camSwitched)
            {
                mainCamCon = Camera.main.GetComponent<MainCamCon>();
                if (mainCamCon != null)
                {
                    camOffSetX = mainCamCon.offsetX;
                    camOffSetZ = mainCamCon.offsetZ;
                    camZoomSize = mainCamCon.GetComponent<Camera>().orthographicSize;
                }
                
            }


            for (int i = 0; i < monsters.Length; i++)
            {
                distance[i] = Vector2.Distance(new Vector2(transform.position.x, transform.position.z), new Vector2(monsters[i].transform.position.x, monsters[i].transform.position.z));

            }

            Transform closestMonster;
            float minDistance;

            

            minDistance = Mathf.Min(distance);// closest distance

            if(tempID != System.Array.IndexOf(distance, minDistance))//in case found closer enemy!
            {
                needChange = true;
            }
            
            closestMonster = monsters[System.Array.IndexOf(distance, minDistance)].transform; // the closest monster!!
            tempID = System.Array.IndexOf(distance, minDistance);
            direction = new Vector2(transform.position.x - closestMonster.position.x, transform.position.z - closestMonster.position.z);

            if (minDistance < alertRange)
            {
                if (!switched || needChange)
                {
                    
                    direction = direction.normalized; // got a nomralized direction for baby alert moving
                                                      //switch mode
                    babyRandomAround.runAway = true;
                    babyRandomAround.offsetX = direction.x;
                    babyRandomAround.offsetZ = direction.y;
                    babyRandomAround.enabled = true;
                    GetComponent<MoveCon>().des = babyRandomAround.transform;// set baby's moving directon to random(alert mode)
                    sweatDrop.RepeatDrop(true);
                    switched = true;
                    needChange = false;
                    
                }

                
            }

            else if (minDistance > alertRange+1)
            {
                if (switched)
                {
                    GetComponent<MoveCon>().des = tempDes; // if no close monster then nothing happened
                    sweatDrop.RepeatDrop(false);
                    babyRandomAround.enabled = false;
                    switched = false;
                    
                }
                
                
            }

            //zoom camera when the enemy is close.

            if (minDistance < dangerRange)
            {
                if(!camSwitched)
                {
                    //set camera position
                    mainCamCon.offsetX = -direction.x/2;
                    mainCamCon.offsetZ = -direction.y/2;// only vector2 y=z
                    //zoom in

                    mainCamCon.Zoom(ZoomSize);
                    
                       
                    camSwitched = true;

                    //Debug.Log(camZoomSize);
                }
            }
            else if (minDistance > (dangerRange + 0.5f) || closestMonster == null)
            {
                if(camSwitched)
                {
                    
                    mainCamCon.offsetX = camOffSetX;
                    mainCamCon.offsetZ = camOffSetZ;
                    mainCamCon.Zoom(camZoomSize);
                    //Debug.Log(camZoomSize);
                    camSwitched = false;
                }
            }




            
        }

        

        
        
		
	}

    

    
}
