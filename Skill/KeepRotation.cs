using UnityEngine;
using System.Collections;

public class KeepRotation : MonoBehaviour {

    private Quaternion rotation;

    void Start()
    {
        rotation = transform.rotation;
    }
	// Update is called once per frame
	void LateUpdate () {

        transform.rotation = rotation;
	
	}
}
