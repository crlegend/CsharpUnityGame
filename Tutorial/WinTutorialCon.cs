using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class WinTutorialCon : MonoBehaviour {

    [Header("ObjectNeedToOpen")]
    public GameObject[] needToOpens;

    [Header("ObjectNeedToClose")]
    public GameObject[] needToClosed;

    [Header("OtherOptions")]
    public Transform castPoint;
    public Transform butterFlyEndPoint;
    public GameObject babyG;
    public float camOffsetX, camOffsetZ, camZoom;
    public float particleSlowSpeed;
    public ParticleSystem cloudParticle;
    public float beesDelay = 5f;
    public SkillCaster skillCaster;
    public float waitBees;

    [Header("AfterTutorial")]
    public GameObject beesForTutorial;
    //public CheckPointCon checkPoint;
    public GameObject inGameMenu;
    public KeepCon keepCon;
    public MainController mainController;
    
    


    private MainCamCon mainCamCon;
    

	// Use this for initialization
	void Start () {

        
        mainCamCon = Camera.main.GetComponent<MainCamCon>();
        mainCamCon.target = castPoint;
        mainCamCon.offsetX = camOffsetX;
        mainCamCon.offsetZ = camOffsetZ;
        mainCamCon.Zoom(camZoom);

        for (int i =0;i< needToOpens.Length;i++)
        {
            needToOpens[i].SetActive(true);
        }

        for (int i=0;i<needToClosed.Length;i++)
        {
            needToClosed[i].SetActive(false);
        }

        butterFlyEndPoint.transform.parent.GetComponentInChildren<MoveCon>().des = butterFlyEndPoint;
        babyG.GetComponent<GroupCon>().OnOffGroup(false);
        

    }
	
	void PlayParticle(bool onOff)
    {
        if(onOff)
        {
            cloudParticle.Play();
        }
        else
        {
            cloudParticle.Stop();
        }        
    }

    public void CleanByWind()
    {
        GetComponentInChildren<FeatherArrowGCon>().ReleaseAllArrows();

        skillCaster.windOn = false;

        StartCoroutine(CleanCloud());
        
    }

    IEnumerator CleanCloud()
    {
        
        

        var em = cloudParticle.emission;
        float num = 15f;
        
        while (num > 0.5f)
        {
            num = Mathf.Lerp(num, 0f, Time.deltaTime * particleSlowSpeed);
            em.rateOverTime = num;
            yield return new WaitForSeconds(0.033f);
        }


        PlayParticle(false);

        yield return new WaitForSeconds(beesDelay);
        AddBees();// next stage!

    }

    void AddBees()
    {
        beesForTutorial.SetActive(true);
        babyG.GetComponent<GroupCon>().OnOffGroup(true);
        StartCoroutine(SetSkillController());

    }

    IEnumerator SetSkillController()
    {
        yield return new WaitForSeconds(waitBees);
        skillCaster.windOn = true;
    }

    void Update()
    {
        if(beesForTutorial.GetComponent<BeesGone>().NoBees())
        {
            NextStep();
        }
    }

    void NextStep()
    {
        
        //checkPoint.checkPointNum = 1;
        inGameMenu.SetActive(true);
        keepCon.checkNum = 3;
        if (keepCon.passed < keepCon.checkNum)
        {
            //Debug.Log(keepCon.passed);
            keepCon.passed = keepCon.checkNum;
            
            //Debug.Log(keepCon.passed);
        }
        GameObject.FindGameObjectWithTag("MainControl").GetComponent<SaveData>().Save();//SavePoint
        mainCamCon.target = babyG.GetComponentInChildren<MoveCon>().transform;
        mainCamCon.offsetZ = 7;
        mainCamCon.Zoom(10f);
        mainController.menuOn = true;

        gameObject.SetActive(false);
        
        
    }

   
}

