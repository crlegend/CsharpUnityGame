using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamCon : MonoBehaviour
{


    public Transform target;
    public float offsetX, offsetZ;
    public float smoothSpeed = 0.01f;
    public float zoomSpeed;

    private Camera cam;
    private Camera[] cams;

    void Awake()
    {

        cam = GetComponent<Camera>();
        cam.orthographicSize = (Screen.height / 100f) / 1f; //very important!!! and smart


    }

    

    // Update is called once per frame
    void Update()
    {

        if(target)
        {
            transform.position = Vector3.Lerp(transform.position, target.position, smoothSpeed * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, 50f, transform.position.z);

        }


    }

    //zoom control size is the size of camera;
    public void Zoom(float size)
    {


        StartCoroutine(ZoomC(size));
    }

    IEnumerator ZoomC(float z)
    {
        while (Mathf.Abs(cam.orthographicSize - z) > 0.01)
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, z, Time.deltaTime * zoomSpeed);
            yield return new WaitForSeconds(0.03f);
        }

    }

    public void ActiveFollowCamera()
    {
        cams = Camera.allCameras;
        for (int i = 0; i < cams.Length; i++)
        {
            cams[i].enabled = false;
        }

        GetComponent<Camera>().enabled = true;


    }

    public void RecoverCameras()
    {
        for (int i = 0; i < cams.Length; i++)
        {
            cams[i].enabled = true;
        }

        GetComponent<Camera>().enabled = false;
        gameObject.SetActive(false);

    }
}
