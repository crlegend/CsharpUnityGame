using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[System.Serializable]
public class MonstersArray
{
    public GameObject[] monsters;
}

public class Route11Con : MonoBehaviour
{

    public Vector3[] wayPos,camOffSetList; //camOffSetList.y as Zoom offset!
    public MainCamCon mainCamCon;
    public GameObject controlUI, gameCon;
    public SoundEffectCon soundEffectCon;
    public BabyRandomAround babyRandomAround;
    public MoveCon moveCon;
    public SweatRepeatDrop sweatDrop;
    public GeneralSoundCon gSoundCon;
    public AudioClip regularEnemyMusic, normalForestMusic;
    
    //public GameObject enemyGroup;

    public GameObject[] monsterGroup1;
    //public MonstersArray[] monsterGroups;
    public int wayPointNumber;

    public CheckPointCon checkCon;






    private bool touched;
    //private bool switched = false;
    private bool sec1ed,sec2ed;
    private bool clearedGroup1;
    private bool continueGoing;

    // Use this for initialization
    void Start()
    {


        transform.position = wayPos[wayPointNumber];
        


    }

    void FixedUpdate()
    {
        if (wayPointNumber == 0 && touched && !sec1ed)
        {
            Section1();
            sec1ed = true;
        }

        if (Group1Finished() && !sec2ed)
        {
            Section2();
            sec2ed = true;
        }

        if (continueGoing)
        {
            NextPos();
        }

        if (wayPointNumber == wayPos.Length && touched)
        {
            GameObject.FindGameObjectWithTag("Keeps").GetComponent<LevelManager>().NextLevel(1);
            Debug.Log("aa");
        }

        
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
        if (wayPointNumber < wayPos.Length && touched)
        {
            wayPointNumber++;
            transform.position = wayPos[wayPointNumber];
            Debug.Log(wayPointNumber);
        }

    }

    public bool RouteTouched()
    {
        return (touched);
    }

    public void SetCameraOffSet(int j)
    {
        mainCamCon.offsetX = camOffSetList[j].x;
        mainCamCon.offsetZ = camOffSetList[j].z;
        mainCamCon.Zoom(camOffSetList[j].y);
    }

    void Section1()
    {
        SetCameraOffSet(0);
        mainCamCon.enabled = true;
        mainCamCon.Following(true);
        mainCamCon.target = GameObject.FindGameObjectWithTag("Baby").transform;


        StartCoroutine(ActivateMonsterGroup1());
        controlUI.SetActive(true);
        //controlUI.transform.Find("Trail").gameObject.SetActive(true);
        gameCon.SetActive(true);

    }

    IEnumerator ActivateMonsterGroup1()
    {
        yield return new WaitForSeconds(1f);

        gSoundCon.NormalSoundFade(1f, 0f);
        

        sweatDrop.RepeatDrop(true);
        for (int i = 0; i<monsterGroup1.Length;i++)
        {
            monsterGroup1[i].transform.parent.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.5f);
        }


        gSoundCon.aSourceEnemy.clip = regularEnemyMusic;
        gSoundCon.aSourceEnemy.Play();
        gSoundCon.EnemySoundFade(3f, 0.8f);
        



        babyRandomAround.GetComponent<BabyDesCon>().enabled = false;
        babyRandomAround.offsetNX = 0f;
        babyRandomAround.offsetNZ = 0f;        
        babyRandomAround.enabled = true;
        babyRandomAround.RandomMoving(true);
        babyRandomAround.RandomPosReset();
        yield return new WaitForSeconds(0.5f);
        moveCon.des = babyRandomAround.transform; // set baby scare and pull back randomly;

        

        yield return new WaitForSeconds(1f);
        soundEffectCon.playSound("orc", 2);
        yield return new WaitForSeconds(1f);

        for (int i = 0; i < monsterGroup1.Length; i++)
        {
            monsterGroup1[i].GetComponent<NavMeshAgent>().speed = 0.5f;
            //yield return new WaitForSeconds(0.1f);
        }       

    }

    bool Group1Finished()
    {
        clearedGroup1 = true;
        for (int i =0; i<monsterGroup1.Length;i++)
        {
            if (monsterGroup1[i] != null) //check if all monsters has been defeated
            {
                clearedGroup1 = false;
            }
        }
        //Debug.Log(clearedGroup1);
        return (clearedGroup1);
    }

    void Section2()
    {
        //show CutScene;
        sweatDrop.RepeatDrop(false);

        moveCon.des = transform;
        ContinueGoing(true);        
        SetCameraOffSet(1); //change camera range
        //enemyGroup.SetActive(true);
        gSoundCon.aSourceNormal.clip = normalForestMusic;
        gSoundCon.AutoMusic(true);
        
        KeepCon keeps = GameObject.FindGameObjectWithTag("Keeps").GetComponent<KeepCon>();
        keeps.checkNum = 1;

        if (keeps.passed < keeps.checkNum)
        {
            keeps.passed = keeps.checkNum;
        }

        GameObject.FindGameObjectWithTag("MainControl").GetComponent<SaveData>().Save();

    }

    public void ContinueGoing(bool go)
    {
        continueGoing = go;
    }

    public void MoveToNumPos(int num)
    {
        transform.position = wayPos[wayPointNumber];
    }

}
