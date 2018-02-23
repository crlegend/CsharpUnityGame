using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[System.Serializable]
public class CheckPointData
{
    public enum Des { Random, Route};

    [Header("Level")]
    public GameObject level;

    [Header("Baby")]
    public GameObject babyG;
    public GameObject baby;
    public Vector3 babyPos;
    
    [Header("Camera")]
    public GameObject aliveCamera;
    public int boundaryNum;
    public float size, offsetX, offsetZ;
    [Header("Route")]
    public Des des;
    public GameObject route;
    public int routeNum;
    public RouteBase routeCon;

    [Header("Music")]
    public AudioClip defaultMusic;
    public bool autoMusic;

    [Header("NeedToBeOn")]
    public GameObject[] controllers;
    
    [Header("NeedToBeOff")]
    public GameObject[] objects;

    [Header("MonsterGroups")]
    public GameObject[] monsterGroups;

    [Header("Others")]
    public bool menuOnOff;
    




}

public class CheckPointCon : MonoBehaviour {

    public CheckPointData[] checkPointData;
    public GeneralSoundCon gSoundCon;
    public MainController mainController;
    
    

    //public int checkPointIndex;
    public int checkPointNum = 0;

    private int frame;

    void Awake()
    {
        //checkPointNum = checkPointIndex;
        checkPointNum = GameObject.FindGameObjectWithTag("Keeps").GetComponent<KeepCon>().checkNum;
        checkPointData[checkPointNum].level.SetActive(true);

    }

	void Start () {

        

        for (int i =0; i < checkPointData[checkPointNum].objects.Length; i++)
        {
            checkPointData[checkPointNum].objects[i].SetActive(false);
            //Debug.Log("aa");
        }
        

        checkPointData[checkPointNum].babyG.SetActive(true);
        checkPointData[checkPointNum].baby.GetComponent<MoveCon>().enabled = false;
        checkPointData[checkPointNum].baby.GetComponent<MoveCon>().des = checkPointData[checkPointNum].route.transform;
        checkPointData[checkPointNum].baby.GetComponent<NavMeshAgent>().enabled = false;
        checkPointData[checkPointNum].baby.transform.position = checkPointData[checkPointNum].babyPos;
        checkPointData[checkPointNum].baby.GetComponent<NavMeshAgent>().enabled = true;
        checkPointData[checkPointNum].baby.GetComponent<MoveCon>().enabled = true;
        checkPointData[checkPointNum].route.SetActive(true);


        checkPointData[checkPointNum].aliveCamera.SetActive(true);
        checkPointData[checkPointNum].aliveCamera.GetComponent<CameraClamp>().boundaryNumber = checkPointData[checkPointNum].boundaryNum;
        checkPointData[checkPointNum].aliveCamera.transform.position = new Vector3 (
            checkPointData[checkPointNum].babyPos.x, 50f, checkPointData[checkPointNum].babyPos.z);
        checkPointData[checkPointNum].aliveCamera.GetComponent<Camera>().orthographicSize = checkPointData[checkPointNum].size;
        checkPointData[checkPointNum].aliveCamera.GetComponent<MainCamCon>().offsetX = checkPointData[checkPointNum].offsetX;
        checkPointData[checkPointNum].aliveCamera.GetComponent<MainCamCon>().offsetZ = checkPointData[checkPointNum].offsetZ;

        if (checkPointData[checkPointNum].des == CheckPointData.Des.Route)
        {
            SetRoute();
        }
        


        for (int i = 0; i< checkPointData[checkPointNum].controllers.Length;i++)
        {
            checkPointData[checkPointNum].controllers[i].SetActive(true);
        }        

        for (int i = 0; i < checkPointData[checkPointNum].monsterGroups.Length; i++)
        {
            checkPointData[checkPointNum].monsterGroups[i].SetActive(true);
        }

        gSoundCon.aSourceNormal.clip = checkPointData[checkPointNum].defaultMusic;
        gSoundCon.AutoMusic(checkPointData[checkPointNum].autoMusic);
        mainController.menuOn = checkPointData[checkPointNum].menuOnOff;
    }

    

    

    public virtual void SetRoute()
    {
        if (checkPointData[checkPointNum].route.GetComponent<Route11Con>()!= null)
        {
            checkPointData[checkPointNum].route.GetComponent<Route11Con>().wayPointNumber = checkPointData[checkPointNum].routeNum;
            checkPointData[checkPointNum].route.GetComponent<Route11Con>().ContinueGoing(true);
            checkPointData[checkPointNum].route.GetComponent<Route11Con>().MoveToNumPos(checkPointData[checkPointNum].routeNum);
        }
        if (checkPointData[checkPointNum].routeCon!=null)
        {
            checkPointData[checkPointNum].routeCon.wayPointNumber = checkPointData[checkPointNum].routeNum;
            checkPointData[checkPointNum].routeCon.ContinueGoing(true);
            checkPointData[checkPointNum].routeCon.MoveToNumPos(checkPointData[checkPointNum].routeNum);
        }

        
    }
	
	
}
