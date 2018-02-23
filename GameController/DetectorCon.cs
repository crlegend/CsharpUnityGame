using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorCon : MonoBehaviour {

    

	void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            Camera.main.GetComponent<MainCamCon>().Zoom(7f);
        }
    }
}
