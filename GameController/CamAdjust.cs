using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamAdjust : MonoBehaviour {

    public RouteBase route;
    public int offListNum;

    

	void OnTriggerEnter(Collider col)
    {
        if (col.tag =="Baby")
        {
            route.SetCameraOffSet(offListNum);
        }
    }
}
