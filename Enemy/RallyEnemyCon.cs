using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RallyEnemyCon : MonoBehaviour {
    
    
    public Transform rallyPoint;
    private bool reached = false; 
   

    void OnTriggerEnter(Collider col)
    {
        if(col.name == rallyPoint.name)
        {
            reached = true;
        }
    }

    public bool Reached()
    {
        return reached;
    }
}
