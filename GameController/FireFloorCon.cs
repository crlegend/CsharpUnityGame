using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFloorCon : MonoBehaviour {

    public float fireFloorRecoveryInterval;
    public FloorMaskCon floorMaskCon;

	IEnumerator OnTriggerEnter(Collider col)
    {
        
        if (col.name == "WaterPour(Clone)" || col.name == "WaterWind(Clone)")
        {
            floorMaskCon.GoAlt();
            yield return new WaitForSeconds(fireFloorRecoveryInterval);
            floorMaskCon.GoBack();
        }

        

        
    }
}
