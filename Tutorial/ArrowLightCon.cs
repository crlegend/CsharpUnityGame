using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowLightCon : MonoBehaviour {

    public float speed;
    //public GameObject endPos;
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

	
	// Update is called once per frame
	void FixedUpdate () {
        
        transform.Translate(Vector3.up * Time.deltaTime * speed);
	}

    public void Reset()
    {
        transform.position = startPos;
    }
}
