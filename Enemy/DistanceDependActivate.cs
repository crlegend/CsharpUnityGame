using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DistanceDependActivate : MonoBehaviour {

    public Transform target;
    public float activateDistance;
    public Vector3 cameraOffset;
    public float zoomSize;
    public Route11Con route11;
    //public GeneralSoundCon gSoundCon;
    //public AudioClip regularEnemyMusic, normalForestMusic;




    private float distance;
    private GameObject[] members;
    private bool activated;
    private Vector3 tempOffset;
    private MainCamCon mainCamCon;
    private bool needAdjust;
    private float tempSize;
	
	
    

    void Start()
    {
             
        mainCamCon = Camera.main.GetComponent<MainCamCon>();
        members = new GameObject[transform.childCount]; // get all children
        for (int i = 0; i< transform.childCount;i++)
        {
            members[i] = transform.GetChild(i).gameObject;
        }

        if (cameraOffset.x == 0f && cameraOffset.z == 0f && cameraOffset.y == 0f) // 0,0,0 means no need to adjust
        {
            needAdjust = false;

        }
        else
        {
            needAdjust = true;
        }
    }

	void Update () {

        

        distance = Vector2.Distance(new Vector2(transform.position.x, transform.position.z),
                                    new Vector2(target.position.x, target.position.z));

        if (distance < activateDistance && !activated)
        {
            for(int i = 0; i < members.Length; i++)
            {
                members[i].SetActive(true);
            }

            if (needAdjust)
            {
                CameraAdjust();
            }

            //gSoundCon.EnemyMusicFadeIn();
            

            activated = true;
        }

        if (transform.childCount == 0)
        {
            if(needAdjust)
            {
                ResetCamera();
                needAdjust = false;
            }


            //gSoundCon.NormalMusicFadeIn();
            

            Destroy(gameObject,2.2f);            
        }
		
	}


    public void CameraAdjust()
    {        
        
        if (mainCamCon != null)
        {
            tempOffset = new Vector3(route11.camOffSetList[route11.camOffSetList.Length-1].x, 0f, route11.camOffSetList[route11.camOffSetList.Length - 1].z);
            tempSize = mainCamCon.GetComponent<Camera>().orthographicSize;
            mainCamCon.offsetX = cameraOffset.x;
            mainCamCon.offsetZ = cameraOffset.z;
            if (zoomSize != 0)
            {
                mainCamCon.Zoom(zoomSize);
            }
                        
        }

    }

    public void ResetCamera()
    {
        StartCoroutine(DelayReset());
    }

    IEnumerator DelayReset()
    {
        yield return new WaitForSeconds(2.1f);
        if (mainCamCon != null)
        {
            mainCamCon.Zoom(tempSize);

            //Debug.Log(tempSize);
            mainCamCon.offsetX = tempOffset.x;
            mainCamCon.offsetZ = tempOffset.z;

        }
    }


}
