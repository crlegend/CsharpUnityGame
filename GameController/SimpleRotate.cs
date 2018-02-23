using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleRotate : MonoBehaviour {

    public bool rotate;
    public Vector3 rotateAngle;
    public float speed;	
	
	void Update () {

        if(rotate)
        {
            transform.Rotate(rotateAngle*Time.deltaTime*speed);
        }
        
		
	}
}
