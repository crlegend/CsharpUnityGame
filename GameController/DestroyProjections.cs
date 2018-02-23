using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyProjections : MonoBehaviour {

	void OnTriggerEnter(Collider col)
    {
        if(col.tag =="Enemy")
        {
            Destroy(col.gameObject);
            //Debug.Log("DD");
        }
    }
}
