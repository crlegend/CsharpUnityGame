using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReleaseArrows : MonoBehaviour {

    public Camera cam;

    private Common common;
    private Vector3[] releasePos;
    private int qua;
    //private ArrowGCon arrCon;
    


    void Start () {

        qua = GetComponent<ArrowGCon>().arrowQua;
        releasePos = new Vector3[qua];
        for (int i=0;i<qua;i++)
        {
            releasePos[i] = common.RandomPosition(cam);
        }
		
	}
	
	// Update is called once per frame
	void Update () {


		
	}
}
