using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour {

    public static DontDestroy dontD;

	void Awake()
    {
        if (dontD == null)
        {
            DontDestroyOnLoad(gameObject);
            dontD = this;
        }
        else if (dontD == this)
        {
            Destroy(gameObject);
        }
        
    }
}
