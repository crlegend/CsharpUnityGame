using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpinAwayByWind : MonoBehaviour {

    
    

    

	void OnTriggerEnter(Collider col)
    {
        if(col.name == "WindSwing(Clone)")
        {
            SpinAway();
        }

        if(col.tag == "Baby")
        {
            GetComponent<MoveCon>().StopMovement(true);
        }
    }

    public void SpinAway()
    {
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<MoveCon>().enabled = false;
        transform.parent = null;

        GetComponent<SimpleRotate>().enabled = true;
        GetComponent<SimpleRelease>().enabled = true;
        Destroy(gameObject, 2f);
        
    }
}
