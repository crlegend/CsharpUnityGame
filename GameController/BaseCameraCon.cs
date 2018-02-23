using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCameraCon : MonoBehaviour {

    
    public float zoomSpeed;
    private Camera cam;

    void Awake()
    {

        cam = GetComponent<Camera>();
        //cam.orthographicSize = (Screen.height / 100f) / 1f; //very important!!! and smart


    }

   

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
}
