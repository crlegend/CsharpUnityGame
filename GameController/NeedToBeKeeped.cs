using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedToBeKeeped : MonoBehaviour {

	
	void Start () {

        transform.parent = null;
        transform.parent = GameObject.FindGameObjectWithTag("Keeps").transform;
	}
	
	
}
