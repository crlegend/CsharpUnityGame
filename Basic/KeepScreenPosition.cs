using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepScreenPosition : MonoBehaviour {

    public float xRatio = 2, yRatio = 10;
    private Vector3 screenPos;
    
	void Update () {

        screenPos = new Vector3(Screen.width / xRatio, Screen.height / yRatio,Camera.main.nearClipPlane);

        transform.position = Camera.main.ScreenToWorldPoint(screenPos);
        transform.position = new Vector3(transform.position.x, 10f, transform.position.z);

        //Debug.Log(screenPos);

        //Debug.Log(transform.position);

        

		
	}
}
