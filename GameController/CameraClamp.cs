using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class CameraClamp : MonoBehaviour {

    public Boundary[] boundary;
    public int boundaryNumber;

    private float camX, camZ;
    private Camera cam;
    private float camSize = 0f;

    void Start()
    {
        cam = GetComponent<Camera>();
        
    }


	
	
	// Update is called once per frame
	void LateUpdate () {

        if (camSize != cam.orthographicSize)
        {
            camX = cam.orthographicSize / 2;            
            camZ = (cam.orthographicSize / 2) / cam.aspect;
            camSize = cam.orthographicSize;
        }

        transform.position = new Vector3
            (Mathf.Clamp(transform.position.x, boundary[boundaryNumber].xMin + camX, boundary[boundaryNumber].xMax - camX),
            transform.position.y,
            Mathf.Clamp(transform.position.z, boundary[boundaryNumber].zMin + camZ, boundary[boundaryNumber].zMax - camZ)
            );
    }
}
