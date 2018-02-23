using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupEnemyCon : MonoBehaviour {
    
	void Update () 
    {
        if (transform.GetComponentsInChildren<BasicStat>().Length == 0)
        {
            Destroy(gameObject);
        }
    }
       
}
