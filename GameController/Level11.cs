using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level11 : MonoBehaviour {

    public GameObject baby,gameCon,wayPonit1,greenCore,frontPage;
    public Camera mainCam;
    public MoveCon babyMoveCon;
    public Vector3 babyStartPos11;
    public Simple2DFadeIn simple2DFadeIn;
    public Transform route11;

    private int frame = 0;

    

    private Common common = new Common();
    

	void Start () {

        frontPage.SetActive(false);


        common.SwitchCamera(mainCam);
        
        simple2DFadeIn.delay = 0f;
        simple2DFadeIn.speed = 0.01f;

        babyMoveCon.des = route11;
        baby.SetActive(true);
        babyMoveCon.transform.position = babyStartPos11;
        
        //gameCon.SetActive(true);
        //controlUI.SetActive(true);
        //controlUI.transform.Find("Trail").gameObject.SetActive(true);
        wayPonit1.SetActive(true);
        greenCore.SetActive(false);
        



        
        


		
	}
	
	// Update is called once per frame
	void Update () {

        
        if (frame <30)//keep the baby's position
        {
            babyMoveCon.transform.position = babyStartPos11;
            frame++;
        }



        
	}
}
