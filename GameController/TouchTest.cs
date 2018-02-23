using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TouchTest : MonoBehaviour {

    public GameObject block;
    public NavMeshSurface nav;
    private bool onOff;
	
    public void Rebake()
    {
        block.SetActive(onOff);
        onOff = !onOff;
        nav.BuildNavMesh();
        
    }
	
	
}
