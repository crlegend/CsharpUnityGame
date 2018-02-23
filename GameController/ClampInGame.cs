using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClampInGame : MonoBehaviour {

    public Boundary boundary = new Boundary();
	
	// Update is called once per frame
	void Update () {
		
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, boundary.xMin, boundary.xMax),
            transform.position.y,
            Mathf.Clamp(transform.position.z, boundary.zMin, boundary.zMax));
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.name == "Arrow(Clone)")
        {
            Destroy(col.gameObject);
        }
    }
}
