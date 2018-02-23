using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTriggered : MonoBehaviour {

    public WaterTutorialCon waterTutorialCon;

	void OnTriggerEnter(Collider col)
    {
        if (col.name == "WaterPour(Clone)")
        {
            waterTutorialCon.Step3();
        }
    }
}
