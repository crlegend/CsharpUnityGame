using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMagicBox : MonoBehaviour {

    public int zFold = 2;
    //public GameObject magicArrow;
    public MainCamCon camCon;
    public GameObject hiddenButton;

       

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Baby")
        {
            //magicArrow.SetActive(true);
            camCon.Zoom(zFold);
            hiddenButton.SetActive(true);
        }
        
        
        


    }

    


}
