using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MainCamCon : MonoBehaviour {



    

    public Transform target;
    public float offsetX, offsetZ;
    public float smoothSpeed = 0.01f;
    public float zoomSpeed;

    private Vector3 camTarget;
    private Camera cam;
    public bool following = true;



	void Awake () {

        cam = GetComponent<Camera>();
        cam.orthographicSize = (Screen.height / 100f) / 1f; //very important!!! and smart


    }
	
	// Update is called once per frame
	void Update () {

         
        if (following)
        {

            camTarget = new Vector3(target.position.x + offsetX, 50f, target.position.z + offsetZ);


            transform.position = Vector3.Lerp(transform.position, camTarget, smoothSpeed * Time.deltaTime);
            
        }
        
        

	}

    /*public void OffSet(float offX, float offZ)
    {
        StartCoroutine(CamOffSet(offX,offZ));
    }

    IEnumerator CamOffSet(float offX, float offZ)
    {
        camTarget = new Vector3(target.position.x, 50f, target.position.z);
        while (Mathf.Abs(camTarget.x - (target.position.x + offX)) >0.001 && Mathf.Abs(camTarget.z - (target.position.z + offZ))>0.001)
        {
            camTarget = Vector3.Lerp(camTarget, new Vector3(target.position.x + offX, 50f, target.position.z + offZ), Time.deltaTime * smoothSpeed);
            yield return new WaitForSeconds(0.03f);
        }
    }*/

    public void Zoom(float size)
    {

        StopAllCoroutines();
        StartCoroutine(ZoomC(size));
    }

    IEnumerator ZoomC(float z)
    {
        while (Mathf.Abs(cam.orthographicSize - z) > 0.01)
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, z, Time.deltaTime * zoomSpeed);
            yield return new WaitForSeconds(0.03f);
        }
        cam.orthographicSize = z;
       
    }

    public void Following(bool follow)
    {
        following = follow;
    }

    public void MoveTo(Transform tar, float speed)
    {
        target = tar;
        smoothSpeed = speed;
    }

}
