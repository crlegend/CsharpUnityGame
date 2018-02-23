using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeesGone : MonoBehaviour {

    private bool triggered = false;
	
	// Update is called once per frame
	void Update () {

        if (GameObject.FindGameObjectsWithTag("BeesGroup").Length == 0)
        {
            
            triggered = true;
        }
        else
        {
            triggered = false;
        }
        
        
		
	}

    public bool NoBees()
    { return triggered; }
}
