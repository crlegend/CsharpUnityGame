using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTutorialStep2 : MonoBehaviour {

    public WaterTutorialCon waterTutorialCon;

	void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Baby")
        {
            waterTutorialCon.Step2();
        }
    }
}
