using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class WaterTutorialStep1 : MonoBehaviour {

    public WaterTutorialCon waterTutorialCon;

	void OnTriggerEnter(Collider col)
    {
        if (col.tag == "WayPosition")
        {
            waterTutorialCon.Step1();
        }
    }

    
}
