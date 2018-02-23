using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTutorialCon : MonoBehaviour {

    public ButterflyCon butterflyCon;
    public GameObject waterTutorialArrows;
    public GameObject fireFloor1Mask;
    public GameObject controlUI;
    public SkillCaster skillCaster;
    public SpellPointCon spellPos;
    public float fadeInterval;
    public float beforeGoDark;
    
    

    private MoveCon babyMoveCon;
    
     


    void Start()
    {
        babyMoveCon = GameObject.FindGameObjectWithTag("Baby").GetComponent<MoveCon>();
        
    }

	public void Step1() //go to butterfly point
    {
        babyMoveCon.ToRandom(false); //make sure in random state
    }

    public void Step2() // initiate waterArrows, butterfly fly away, open water spell,stop baby,set camera
    {        
        waterTutorialArrows.SetActive(true);
        controlUI.SetActive(true);
        spellPos.SetSpellPoint(spellPos.tempPos);
        Camera.main.GetComponent<MainCamCon>().target = waterTutorialArrows.transform;
        Camera.main.GetComponent<MainCamCon>().Zoom(10f);
        babyMoveCon.StopMovement(true);
        skillCaster.waterOn = true;
        butterflyCon.ToEndPoint();
    }

    public void Step3() // successfully casted water spell, waterArrow fade, burn ground to dark 
    {
        StartCoroutine(WaterArrowFade());
        StartCoroutine(BurnGroundDark());
    }

    IEnumerator WaterArrowFade()
    {
        Simple2dFade[] arrowsFade = waterTutorialArrows.GetComponentsInChildren<Simple2dFade>();
        for (int i = 0;i<arrowsFade.Length;i++)
        {
            arrowsFade[i].GetComponent<Animator>().enabled = false;
            arrowsFade[i].StartFade();
            yield return new WaitForSeconds(fadeInterval);
        }
        waterTutorialArrows.SetActive(false);
    }

    IEnumerator BurnGroundDark()
    {
        yield return new WaitForSeconds(beforeGoDark);
        fireFloor1Mask.SetActive(true);       
    }

    public void Step4() //baby continue move, camera back
    {
        Camera.main.GetComponent<MainCamCon>().target = babyMoveCon.transform;
        babyMoveCon.StopMovement(false);
    }

    
}
