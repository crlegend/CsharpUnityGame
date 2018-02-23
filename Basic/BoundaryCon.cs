using UnityEngine;
using System.Collections;

public class BoundaryCon : MonoBehaviour {

    


    void Update()
    {
        transform.position = Camera.main.transform.position;
        transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
    }
		
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.name == "Fireball(Clone)")
        {
            Destroy(col.gameObject);
        }
    }

    
}
