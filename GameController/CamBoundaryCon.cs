using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamBoundaryCon : MonoBehaviour {

    public Camera cam;
    public float saveRange;
    private float camSize = 0f;
    private float camX, camZ;
    private BoxCollider box;

    // Use this for initialization
    void Start () {

        box = GetComponent<BoxCollider>();
		
	}
	
	// Update is called once per frame
	void LateUpdate () {

        //transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
        

        if (camSize != cam.orthographicSize)
        {
            camX = cam.orthographicSize + saveRange;
            camZ = (cam.orthographicSize / cam.aspect) + saveRange;
            box.size = new Vector3(camX, camZ, 50f);
            camSize = cam.orthographicSize;
        }

    }

    protected virtual void OnTriggerExit(Collider col)
    {
        if(col.tag == "Skill" || col.name =="Bee")
        {
            Destroy(col.gameObject);
        }


    }

    

    
}
