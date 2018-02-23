using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactiveOriArrow : MonoBehaviour {

    public GameObject arrow,wayPoint1;
    
    public void DestoryArrow()
    {
        Destroy(arrow);
        Destroy(wayPoint1);
        
    }
}
