using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ButterflyTouchCon : MonoBehaviour {
    public RouteCon routeCon;
    public BabySoundCon babySoundCon;
    
    
    
    

	

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Block")
        {
            GetComponent<MoveCon>().StopMovement(true);

        }

        if (col.gameObject.tag == "Baby")
        {
            if(routeCon.RouteTouched())
            {

                routeCon.NextPos();
                babySoundCon.PlayRandomSound(1);
            }
            
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Block")
        {
            GetComponent<MoveCon>().StopMovement(false);
        }
    }
}
