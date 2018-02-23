using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;



public class Test : MonoBehaviour {

    public Vector3 big, small;

    public void NorTest()
    {
        Debug.Log(Vector3.Normalize(big));
        Debug.Log(Vector3.Normalize(small));
    }



   
}
