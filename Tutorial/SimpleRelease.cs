using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleRelease : MonoBehaviour {

    private Common common;
    private Vector3 endPos;
    //private bool triggered = false;    
    //private bool moveBack = false;

    public bool release = false;
    
    public float speed;

    void Start () {

        common = new Common();
        //temPos = transform.position;
        endPos = common.RandomPositionOutside(Camera.main);


    }

    // Update is called once per frame
    void Update () {

        if(release)
        {
            LerpToPosition();
           
        }

        
		
	}

    protected void LerpToPosition()
    {
        transform.position = Vector3.Lerp(transform.position, endPos, Time.deltaTime * speed);
    }

    

    

    
}
