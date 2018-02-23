using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TurnsCon : MonoBehaviour {
    private Scrollbar scr;
    public float turnSpeed;
    public static bool counter = false;
	// Use this for initialization
	void Awake () {

        scr = GetComponent<Scrollbar>();
	    
	}
	
	// Update is called once per frame
	void LateUpdate () {

        if (scr.value < 1)
        {
            scr.value = scr.value + turnSpeed;
        }
        else
        {            
            scr.value = 0f;
            if (scr.value == 0f)
            {
                counter = !counter;
            }
        }
	
	}
}
