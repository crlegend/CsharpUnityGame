using UnityEngine;
using System.Collections;

public class FollowMoving : MonoBehaviour {
    
    public Transform fol;
    public float xOffset;
    public float zOffset;

    void Start()
    {
        //Renderer ren = GetComponent<Renderer>();
        //Debug.Log(ren.material.name);
    }


    // Update is called once per frame
    void Update () {


        transform.position = new Vector3 (fol.position.x - xOffset, transform.position.y, fol.position.z - zOffset);
	
	}



    


}
