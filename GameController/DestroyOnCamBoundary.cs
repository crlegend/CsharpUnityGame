using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCamBoundary : MonoBehaviour {

    
	void OnTriggerExit(Collider col)
    {
        if (col.tag == "CamBoundary")
        {
            Debug.Log("CC");
            Destroy(gameObject);
            
        }
    }
}
