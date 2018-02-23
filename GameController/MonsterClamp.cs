using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterClamp : MonoBehaviour {

    private float camX, camZ;    
    private float camSize = 0f;
    
	
	// Update is called once per frame
	void LateUpdate () {

        if (camSize != Camera.main.orthographicSize)
        {
            camX = Camera.main.orthographicSize / 2;
            camZ = (Camera.main.orthographicSize / 2) / Camera.main.aspect;
            camSize = Camera.main.orthographicSize;
            
        }

        transform.position = new Vector3
            (Mathf.Clamp(transform.position.x, Camera.main.transform.position.x + camX, Camera.main.transform.position.x - camX),
            transform.position.y,
            Mathf.Clamp(transform.position.z, Camera.main.transform.position.z + camZ, Camera.main.transform.position.z - camZ)
            );

        Debug.Log(Camera.main.transform.position.x + camX);
        Debug.Log(Camera.main.transform.position.x - camX);
        Debug.Log(camX);
    }

}

