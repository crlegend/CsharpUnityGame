using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCameraTutorial : MonoBehaviour {

    public Camera tutorialCam;
    public GameObject arrowsG;
    private Common common = new Common();


    public void SwitchCameraBackToTutorial()
    {
        common.SwitchCamera(tutorialCam);
    }

    void ActiveArrowsG()
    {
        arrowsG.SetActive(true);
        Destroy(gameObject); // delete self
    }
    
}
