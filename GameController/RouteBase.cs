using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class RouteBase : MonoBehaviour
{

    public Vector3[] camOffSetList; //camOffSetList.y as Zoom offset!    
    public GameObject[] wayPositions;
    public int wayPointNumber = 0;
    //public CheckPointCon checkCon;
    public bool continueGoing;


    private bool touched;
   
    

    // Use this for initialization
    public virtual void Start()
    {
        
           
        transform.position = wayPositions[wayPointNumber].transform.position;
        
    }

    void FixedUpdate()
    {        

        if (continueGoing)
        {
            NextPos();
        }

        /*if (wayPointNumber == wayPositions.Length && touched)
        {
            //GameObject.FindGameObjectWithTag("Keeps").GetComponent<LevelManager>().NextLevel(1);
            Debug.Log("aa");
        }*/


    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Baby")
        {
            touched = true;
        }

    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Baby")
        {
            touched = false;
        }

    }

    void NextPos()
    {
        if (wayPointNumber < wayPositions.Length && touched)
        {
            
            transform.position = wayPositions[wayPointNumber].transform.position;
            wayPointNumber++;
            Debug.Log(wayPointNumber);
        }

    }

    public bool RouteTouched()
    {
        return (touched);
    }

    public void SetCameraOffSet(int j)
    {
        MainCamCon mainCamCon = Camera.main.GetComponent<MainCamCon>();
        mainCamCon.offsetX = camOffSetList[j].x;
        mainCamCon.offsetZ = camOffSetList[j].z;
        mainCamCon.Zoom(camOffSetList[j].y);
    }

    

    
    public void ContinueGoing(bool go)
    {
        continueGoing = go;
    }

    public void MoveToNumPos(int num)
    {
        transform.position = wayPositions[wayPointNumber].transform.position;
    }

}
