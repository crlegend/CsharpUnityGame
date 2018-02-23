using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyTrigger : MonoBehaviour
{

    //public Transform target;
    //public float activateDistance;
    public EnemyTrigger nextTrigger;
    public SpellPointCon spellPointCon;
    public MonsterWaves[] mWaves; // from DDAForMonsterGroups
    //public Route11Con route11;
    public RouteBase route;
    [HideInInspector]public bool camActivated = false;

    public GeneralSoundCon gSoundCon; //
    public AudioClip newEnemyMusic;


    private float distance;

    private bool activated;
    private Vector3 tempOffset;
    private MainCamCon mainCamCon;

    private float tempSize;
    private bool first = true; //means first camera parament!!!

    private bool activatedWave;
    



    void Start()
    {

        mainCamCon = Camera.main.GetComponent<MainCamCon>();



    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Baby" &&!activated)
        {
            if (newEnemyMusic != null)
            {
                NewMusic();
            }

            //ForBossStart();
            StartCoroutine(ActivateMonsterGroups());
            activated = true;
        }
    }

    void NewMusic()
    {
        gSoundCon.SetEnemyMusicClip(newEnemyMusic);
    }


    void Update()
    {



        /*distance = Vector2.Distance(new Vector2(transform.position.x, transform.position.z),
                                    new Vector2(target.position.x, target.position.z));

        if (distance < activateDistance && !activated)
        {
            
            
            //gSoundCon.EnemyMusicFadeIn();
            
        }*/

        if (transform.childCount == 0)
        {
            if (!first) // if first has been used then need to reset camera
            {
                if (nextTrigger != null)
                {
                    if (!nextTrigger.camActivated)
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

            //ForBossEnd();
            
            //Destroy(gameObject, 2.2f);//Unstable!!!
        }

    }

    IEnumerator ActivateMonsterGroups()
    {
        for (int i = 0; i < mWaves.Length; i++)
        {
            yield return new WaitForSeconds(mWaves[i].delayTime);

            activatedWave = false;

            for (int j = 0; j < mWaves[i].groups.Length; j++)
            {
                mWaves[i].groups[j].SetActive(true);
            }

            activatedWave = true;

            if (mWaves[i].needAdjust)
            {

                CameraAdjust(mWaves[i].camOff, mWaves[i].zoom, mWaves[i].needAdjust);
                camActivated = true;
            }

            if (mWaves[i].skillPosition == MonsterWaves.SkillPosition.Up)
            {
                spellPointCon.SetSpellPoint(spellPointCon.spellPoints1);
            }
            else if (mWaves[i].skillPosition == MonsterWaves.SkillPosition.Middle)
            {
                spellPointCon.SetSpellPoint(spellPointCon.spellPoints2);
            }
            else if (mWaves[i].skillPosition == MonsterWaves.SkillPosition.Down)
            {
                spellPointCon.SetSpellPoint(spellPointCon.spellPoints3);
            }
            else if (mWaves[i].skillPosition == MonsterWaves.SkillPosition.Temp)
            {
                spellPointCon.SetSpellPoint(spellPointCon.tempPos);
            }

            

        }
    }

    public void CameraAdjust(Vector3 offSet, float zSize, bool need)
    {

        if (mainCamCon != null)
        {
            if (need && first) // only set the first as original to be reset
            {
               
                if (route != null)
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
        yield return new WaitForSeconds(2.1f); //notice here, a unstable argument!
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

    /*public virtual void ForBossStart()
    {

    }

    public virtual void ForBossEnd()
    {

    }*/

}
