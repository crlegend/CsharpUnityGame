using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MonsterWaves
{
    public GameObject[] groups;
    public float delayTime;
    public enum SkillPosition { Up, Middle, Down,Temp}
    public SkillPosition skillPosition;
    public bool needAdjust;
    public Vector3 camOff;
    public float zoom;
    
}

public class DDAForMonsterGroup : MonoBehaviour
{

    public Transform target;
    public float activateDistance;
    public DDAForMonsterGroup nextDDA; 
    
    public MonsterWaves[] mWaves;
    public Route11Con route11;
    public RouteBase route;
    public bool camActivated = false;

    //public GeneralSoundCon gSoundCon;


    private float distance;
   
    private bool activated;
    private Vector3 tempOffset;
    private MainCamCon mainCamCon;
    
    private float tempSize;
    private bool first = true;

    private bool activatedWave;




    void Start()
    {

        mainCamCon = Camera.main.GetComponent<MainCamCon>();
        

        
    }

    void Update()
    {



        distance = Vector2.Distance(new Vector2(transform.position.x, transform.position.z),
                                    new Vector2(target.position.x, target.position.z));

        if (distance < activateDistance && !activated)
        {
            ForBossStart();
            StartCoroutine(ActivateMonsterGroups());
            //gSoundCon.EnemyMusicFadeIn();
            activated = true;
        }

        if (transform.childCount == 0)
        {
            if (!first) // if first has been used then need to reset camera
            {
                if(nextDDA != null)
                {
                    if (!nextDDA.camActivated)
                    {
                        ResetCamera();
                    }
                }
                else
                {
                    ResetCamera();
                }
                
                
                first = true; // only once
            }

            ForBossEnd();
            //gSoundCon.NormalMusicFadeIn();
            Destroy(gameObject, 2.2f);
        }

    }

    IEnumerator ActivateMonsterGroups()
    {
        for (int i =0;i<mWaves.Length;i++)
        {
            yield return new WaitForSeconds(mWaves[i].delayTime);

            activatedWave = false;

            for (int j = 0; j<mWaves[i].groups.Length;j++)
            {
                mWaves[i].groups[j].SetActive(true);
            }

            activatedWave = true;

            if (mWaves[i].needAdjust)
            {
                
                CameraAdjust(mWaves[i].camOff, mWaves[i].zoom, mWaves[i].needAdjust);
                camActivated = true;
            }         
            
        }
    }

    public void CameraAdjust(Vector3 offSet, float zSize, bool need)
    {
        
        if (mainCamCon != null)
        {
            if (need && first) // only set the first as original to be reset
            {
                if (route11!=null)
                {
                    tempOffset = new Vector3(route11.camOffSetList[route11.camOffSetList.Length - 1].x, 0f, route11.camOffSetList[route11.camOffSetList.Length - 1].z);
                }

                if (route !=null)
                {
                    tempOffset = new Vector3(route.camOffSetList[route.camOffSetList.Length - 1].x, 0f, route.camOffSetList[route.camOffSetList.Length - 1].z);
                }
                
                tempSize = mainCamCon.GetComponent<Camera>().orthographicSize;
                first = false;
            }
            
            mainCamCon.offsetX = offSet.x;
            mainCamCon.offsetZ = offSet.z;
            if (zSize != 0)
            {
                mainCamCon.Zoom(zSize);
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

    public bool ActivateWave()
    {
        return activatedWave;
    }

    public virtual void ForBossStart()
    {

    }

    public virtual void ForBossEnd()
    {

    }

}
