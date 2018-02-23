using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroCon : MonoBehaviour {

    public GameObject introCamera, frontPage, baby,field,wayPoint1;

    public AudioSource introMusic;
    public Camera introCam;
    public EndIntroData endIntroData;
    public GameObject magicArrow;

    
    void Awake()
    {
        SetFrontPage();
    }

    void Start () {

        SetCamera();
        //SetFrontPage();
        SetBaby();
        //SetField();
        //SetWayPoint1();
        //SetMagicBox();
        endIntroData = new EndIntroData(baby.transform.position, introCam.transform.position);
        introMusic.Play();
        magicArrow.SetActive(true);
        //hiddenButton.SetActive(true);
        
		
	}
	
	void SetCamera()
    {
        introCamera.SetActive(true);

    }
    void SetFrontPage()
    {
        frontPage.SetActive(true);
    }
    void SetBaby()
    {
        baby.SetActive(true);
    }
    void SetField()
    {
        field.SetActive(true);
    }

    void SetWayPoint1()
    {
        wayPoint1.SetActive(true);
    }
    
    
    public void MusicCon(bool onOff)
    {

        if (onOff)
        {
            introMusic.Play();
        }
        else
        {
            introMusic.Stop();
        }

    }

    public void StopCamera(bool onOff)
    {
        introCam.enabled = onOff;
    }

    public void EndIntro()
    {
        endIntroData.babyPos = baby.transform.position;
        endIntroData.camPos = introCam.transform.position;
        //hiddenButton.SetActive(true);
        //introMusic.GetComponent<GeneralSoundCon>().NormalSoundFade(0.5f, 0.2f);
    }

    public class EndIntroData
    {
        public Vector3 babyPos, camPos;

        public EndIntroData(Vector3 baby, Vector3 cam)
        {
            babyPos = baby;
            camPos = cam;
        }

    }
}
