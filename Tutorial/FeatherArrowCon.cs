using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeatherArrowCon : MonoBehaviour {

    public float rotateSpeed;
    public float rotateSlowSpeed;
    public float stopTime;
    public float smoothSpeed;

    private float stopVel = 5f;
    private Quaternion oriQuaternion;

	// Use this for initialization
	void Start () {

        oriQuaternion = transform.rotation;
		
	}
	
	// Update is called once per frame
	void Update () {

        if (rotateSpeed > 100f)
        {
            transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed, Space.Self);
            rotateSpeed = Mathf.SmoothDamp(rotateSpeed, rotateSlowSpeed, ref stopVel, stopTime);
        }
        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, oriQuaternion, Time.deltaTime * smoothSpeed);
        }

              


    }
}
