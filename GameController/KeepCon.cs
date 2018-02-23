using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class KeepCon : MonoBehaviour {

    public int scene;

    public int checkNum;

    public int passed;

    void Update()
    {
        if (Screen.fullScreen)
        {
            Screen.fullScreen = false;
        }
    }
    
    
    

	
}
