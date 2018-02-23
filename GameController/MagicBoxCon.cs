using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBoxCon : MonoBehaviour {

    public float RotateSpeed;
    public float zoomSpeed;
    public Vector3 boxScale;
    public float changeSpeed;

	// Use this for initialization
	void Start () {

        StartCoroutine(ZoomOut());
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.Rotate(Vector3.forward * Time.deltaTime *RotateSpeed);
		
	}

    IEnumerator ZoomOut()
    {
        while (transform.localScale.z <= 5.9f)
        {
            yield return new WaitForSeconds(0.03f);
            transform.localScale = Vector3.Lerp(transform.localScale, boxScale, Time.deltaTime * zoomSpeed);
        }
    }

    public void RotateTo(float degree)
    {
        StartCoroutine(RotateDegree(degree));
    }

    IEnumerator RotateDegree(float degree)
    {
        while (Mathf.Abs(transform.eulerAngles.z - degree) > 0.01)
        {
            yield return new WaitForSeconds(0.03f);
            transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, new Vector3(0f, 0f, degree), Time.deltaTime * changeSpeed);
        }
        
    }
}
