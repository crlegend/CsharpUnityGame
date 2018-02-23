using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowEndPosCon : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        
        other.transform.GetComponent<ArrowLightCon>().Reset();
    }
}
