using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepRotationNew : MonoBehaviour {

    public Vector3 fixRotation;
    public bool keepX, keepY, keepZ;
	
	
	// Update is called once per frame
	void LateUpdate () {

        if(keepX)
        {
            transform.rotation = Quaternion.Euler(fixRotation.x, transform.rotation.y, transform.rotation.z);
        }
        if(keepY)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, fixRotation.y, transform.rotation.z);
        }
        if(keepZ)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, fixRotation.z);
        }

		
	}
}
