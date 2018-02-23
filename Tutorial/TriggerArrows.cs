using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerArrows : MonoBehaviour {


    public GameObject arrowGroup;
    public Transform arrow1;
    public Camera followCam;
    public FollowCamCon followCamCon;
    public TutorialCon tutorialCon;
    public IntroCon introCon;
    public GameObject baby;
    public MainCamCon mainCamCon;
    public GameObject magicArrow, wayPoint1;

    private Common common = new Common();

    void OnMouseDown()
    {
        tutorialCon.enabled = true;
        introCon.enabled = false;
        arrowGroup.SetActive(true);
        mainCamCon.enabled = false;
        common.SwitchCamera(followCam);
        followCamCon.target = arrow1;
        baby.SetActive(false);
        magicArrow.SetActive(false);
        wayPoint1.SetActive(false);
    }
}
