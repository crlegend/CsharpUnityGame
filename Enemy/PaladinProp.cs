using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaladinProp : MonoBehaviour {

    public Transform movingAround;
    public Transform target;

    private bool swifted;
	
	void Start () {

        GetComponent<MoveCon>().des = movingAround;
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Baby").transform;
        }
        
		
	}
	
	// Update is called once per frame
	void Update () {

        

        if (transform.parent.parent.childCount == 1 && !swifted)
        {
            GetComponent<MoveCon>().des = target;
            GetComponent<MoveCon>().SpeedModifier(1.5f);
            GetComponent<HealthRecoveryES>().interTurns = 2;
            swifted = true;

        }


		
	}
}
