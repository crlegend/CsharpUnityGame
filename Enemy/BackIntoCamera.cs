using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackIntoCamera : MonoBehaviour {

    private bool outOfCam;
    private float tempRange;
    private Transform tempDes;

    void OnTriggerExit(Collider col)
    {
        if (col.name == "SmallBoundary")
        {
            outOfCam = true;
            GoBackToCamera();
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (outOfCam)
        {
            if(col.name == "SmallBoundary")
            {
                outOfCam = false;
                InCamera();
            }
        }
    }

    void GoBackToCamera()
    {
        tempRange = GetComponent<FireProjectionCon>().shootRange;
        GetComponent<FireProjectionCon>().shootRange = 0.1f; // turn off the shoot
        tempDes = GetComponent<MoveCon>().des;
        GetComponent<MoveCon>().des = GameObject.FindGameObjectWithTag("Baby").transform;
    }

    void InCamera()
    {
        GetComponent<FireProjectionCon>().shootRange = tempRange;
        GetComponent<MoveCon>().des = tempDes;
    }
	
}
