using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RanToButterfly : MonoBehaviour {

    private MoveCon babyMoveCon;
    public Transform butterFly;
    public float waitForButterflyTime;
    public RouteBase route13;
    public GameObject controlUI;

    private bool triggered; // in case it triggered again!!!

	void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Baby" && !triggered) 
        {
            babyMoveCon = col.GetComponent<MoveCon>();
            StartCoroutine(StartWaterTutorial()); 
        }
    }

    IEnumerator StartWaterTutorial()
    {
        triggered = true; 
        babyMoveCon.ToRandom(true);
        controlUI.SetActive(false);
        route13.MoveToNumPos(2);
        yield return new WaitForSeconds(waitForButterflyTime);

        butterFly.parent.gameObject.SetActive(true); // butterfly in

        MainCamCon mainCamCon; // set camera
        mainCamCon = Camera.main.GetComponent<MainCamCon>();
        mainCamCon.target = butterFly;
        mainCamCon.offsetX = 0f;
        mainCamCon.offsetZ = 0f;
        mainCamCon.Zoom(6f);
        
    }
}
