using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTriggerCon : MonoBehaviour {

    public bool canGoBack = true;

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Baby" || col.tag == "Enemy")
        {
            canGoBack = false;

        }


    }
}
