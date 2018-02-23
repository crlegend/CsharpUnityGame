using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteXswitch : MonoBehaviour {

    private Vector3 lastPos;
    
	// Use this for initialization
	void Start () {

        lastPos = transform.position;
        GetComponent<SpriteRenderer>().flipX = false;
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        if (transform.position.x - lastPos.x >0)
        {
            GetComponent<SpriteRenderer>().flipX = false; // just flip the sprite, works great!!

        }
        else if (transform.position.x - lastPos.x <0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }

        lastPos = transform.position;

        

    }
}
