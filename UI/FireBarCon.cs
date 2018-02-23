using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireBarCon : MonoBehaviour {

    private Scrollbar scr;
    public bool casted;

    public float turnSpeed;
    public static bool counter = false;
    public Image handleImage;
    public GameObject spark;
    public ArrowGCon arrowGCon;
    public SkillCaster skillCaster;
    public static int count;


    // Use this for initialization
    void Awake()
    {

        scr = GetComponent<Scrollbar>();

    }

    private void Start()
    {
        
    }

    
    void Update()
    {
        
        if (scr.size < 1f)
        {
            scr.size = scr.size + turnSpeed;
        }

        else
        {            
            counter = !counter;
            count += 1;
            scr.size = 0f;
			FireBarRecovery();
            
            

        }

		if (scr.size > 0.990 && scr.size < 0.999)
		{
            if (arrowGCon != null)
            {
                casted = ArrowGCon.spelled;
            }
			
			if (skillCaster.gameObject.activeInHierarchy)
			{
				casted = skillCaster.SkillCasted();
			}
		}

    }

	

    

    public void NextStep()
    {
        FireBarRecovery();
        GetComponent<AudioSource>().Play();
        if (spark)
        {
            spark.SetActive(true);
        }
        
    }

    public void FireBarUsed()
    {
        GetComponent<Animator>().SetTrigger("Pressed");
        
        handleImage.color = Color.gray;
    }

    public void FireBarRecovery()
    {
        if (arrowGCon != null)
        {
            if (arrowGCon.ArrowAdded()) //only effect after all arrows was in!
            {
                arrowGCon.MoveArrowsBack();
            }

            ArrowGCon.spelled = false;
        }
        
        
        GetComponent<Animator>().SetTrigger("Normal");
        handleImage.color = Color.red;

    }

    public IEnumerator PassTurns(int turns)
    {
        int tempTurns = count;
        while(true)
        {
            yield return new WaitForSeconds(0.033f);
            if (count > tempTurns + turns)
                break;
        }
    }

    
}
