using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerDestroy : MonoBehaviour {

    public string triggersName;

    void OnTriggerEnter(Collider col)
    {
        if (col.name == triggersName)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        
    }


}
