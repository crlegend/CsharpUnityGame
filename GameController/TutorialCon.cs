using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCon : MonoBehaviour {

    // Use this for initialization
    
    public GameObject hiddenButton,targetTree;
    public GameObject controlUI;
    //public MagicBoxCon magicBoxCon;
    public ArrowGCon arrowGCon;
    public Camera tutorialCam;
    public AudioSource audioS;
    public AudioClip tutorialMusic;
    public GameObject demoFireBall,demoFireBall2;
    public GameObject iceWallG;
    public GameObject iceWallG2, trail, gameCon;
    


    public bool s1, s2, s3;

    

    private Common common = new Common();
    

    void Start () {

        s1 = true;

        //SetTutorialMusic();

        //common.SwitchCamera(tutorialCam);

        if (s1)
        {
            
            Section1();
        }

        if (s2)
        {
            Section2();
        }

        if (s3)
        {
            
            Section3();
        }
        
		
	}
	
	
    
    
    public void Section1()
    {
        targetTree.SetActive(true);
        arrowGCon.fireBall = demoFireBall;
        //hiddenButton.SetActive(true);
    }
    public void Section2()
    {
        common.SwitchCamera(tutorialCam);
        tutorialCam.transform.position = new Vector3(tutorialCam.transform.position.x, tutorialCam.transform.position.y, 25f);
        tutorialCam.orthographicSize = 10f;
        arrowGCon.fireBall = demoFireBall2; // change to fireBall2(no camera follow and quick
        ArrowGCon.spelled = false;
        StartCoroutine(ActiveSection2());
        
    }

    IEnumerator ActiveSection2()
    {
        
        iceWallG.SetActive(true);
        yield return new WaitForSeconds(3f);
        controlUI.SetActive(true);
        arrowGCon.MoveArrowsBack();
    }

    public void Section3()
    {
        ArrowGCon.spelled = false;
        StartCoroutine(ActivateSection3());
        
        
    }

    IEnumerator ActivateSection3()
    {
        arrowGCon.ReleaseArrows();        
        controlUI.SetActive(false);
        iceWallG2.SetActive(true);
        yield return new WaitForSeconds(3f);
        arrowGCon.gameObject.SetActive(false);
        controlUI.SetActive(true);
        trail.SetActive(true);
        gameCon.SetActive(true);
    }


    
    
}
