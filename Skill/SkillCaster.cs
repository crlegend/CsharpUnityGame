using UnityEngine;
using System.Collections;

public class SkillCaster : MonoBehaviour {

    private Counter coun = new Counter();
    public Common com = new Common();

    public GameObject fireBall;
    public GameObject waterPour;
    public GameObject earthWall;
    public GameObject windSwing;
    public GameObject thunderStrike;
    public Transform castPos;
    public AudioClip rangeSkillError;

    public FireBarCon fireBarCon;

    public bool fireOn, waterOn, earthOn, windOn, thunderOn;

    public static bool readable = true;
    private int c = 0;
    private string gotSkill;
    private bool casted = false; // only cast once;
    //private GameManager gam;

    

    // Use this for initialization
    void Start () {

        fireOn = true;
        
	
	}
	
	// Update is called once per frame
	void LateUpdate () {

        coun.CheckCounter();
        if (c != coun.Count())
        {
            
            //CastSkill(gotSkill);
            Reset();
            
        }

        else
        {
            if (readable)
            {
            
                DetectSkill();
            }
            
        }
        
	
	}

    void Reset()
    {
        if (!Input.GetMouseButton(1)) // the tricky part, in case hold the mouse pass turns
        {            
            readable = true;
            c = coun.Count();      


        }
        gotSkill = null;
        casted = false;
       

               
        

    }

    void CastSkill(string skill)
    {
        if (!casted)
        {
            if (fireOn)
            {
                if (skill == "line" || skill == "line2")
                {
                    CastFire();
                    AfterCast();
                }
            }

            if (waterOn)
            {
                if (skill == "circle" || skill == "circle2")
                {
                    CastWater();
                    AfterCast();
                }
            }

            if (windOn)
            {
                if (skill == "triangle" || skill == "triangle2")
                {
                    CastWind();
                    AfterCast();
                }
            }

            if (earthOn)
            {
                if (skill == "square" || skill == "square2")
                {
                    CastEarth();
                    AfterCast();
                }
            }

            if (thunderOn)
            {
                if (skill == "z" || skill == "z2")
                {
                    CastThunder();
                    AfterCast();
                }
            }

            
            
        }
    }

    void AfterCast()
    {
        readable = false; //each turn one gesture read only, right after the first gesture set, close the reading
        casted = true;
        fireBarCon.FireBarUsed();
    }

    void DetectSkill()
    {

        if (InputManager.MTRightButtonUp())//only on mouse up, read gesture "string"
        {

            gotSkill = Gesture.sendGesture;
            CastSkill(gotSkill);
           
        }
    }

    public void CastFire()
    {

        //Debug.Log(TrailController.startPos-TrailController.endPos);


        Instantiate(fireBall, TrailController.startPos, Quaternion.identity);

    }

    void CastEarth()
    {
        Transform skp;

        skp = Instantiate(castPos, com.CalShortestDistance(Gesture.cen));
        skp.parent = skp.parent.parent;
        //skp = CalShortestDistance(Camera.main.ScreenToWorldPoint(InputManager.MTPosition()));//For test using
        if (skp.Find("EarthWall(Clone)") != null)
        {
            skp.Find("EarthWall(Clone)").SendMessage("DestroySelf");
        }

        GameObject earth = Instantiate(earthWall, skp.position, Quaternion.identity) as GameObject;
        earth.transform.parent = skp;





    }

    void CastThunder()
    {

        GameObject Thunder;
        if (GameObject.FindGameObjectsWithTag("Enemy").Length != 0)
        {
            Transform e = com.CalDistanceImproved(Gesture.cen);
            if (e.Find("Thunder(Clone)") != null)
            {
                e.Find("Thunder(Clone)").SendMessage("DestroySelf");
            }
            Thunder = Instantiate(thunderStrike, e.position, Quaternion.identity) as GameObject;
            Thunder.transform.parent = e;

        }
        else
        {
            Thunder = Instantiate(thunderStrike, Gesture.cen, Quaternion.identity) as GameObject;
        }
    }

    void CastWater()
    {
        /*Transform skp;
        skp = com.CalShortestDistance(Gesture.cen);
        //skp = CalShortestDistance(Camera.main.ScreenToWorldPoint(InputManager.MTPosition()));//For test using
        if (skp.Find("WaterPour(Clone)") != null)
        {
            skp.Find("WaterPour(Clone)").SendMessage("DestroySelf");
        }

        GameObject water = Instantiate(waterPour, skp.position, Quaternion.identity) as GameObject;
        water.transform.parent = skp;*/
        CastRangeSpell(waterPour,"WaterPour(Clone)");


    }

    void CastWind()
    {

        CastRangeSpell(windSwing,"WindSwing(Clone)");

    }

    public bool SkillCasted()
    {
        return(casted);
    }

    
    void CastRangeSpell(GameObject skill,string spellName)
    {

        
        Transform skp, closest;
        closest = com.CalShortestDistance(Gesture.cen);

        if(closest.parent.FindTranformsWithName(spellName).Length < 2)
        {
            if (closest.childCount == 0)
            {
                skp = Instantiate(castPos, closest.position, closest.rotation);
                skp.parent = closest.parent;

            }
            else
            {
                skp = closest;
            }

            //skp = CalShortestDistance(Camera.main.ScreenToWorldPoint(InputManager.MTPosition()));//For test using
            if (skp.Find(spellName) != null)
            {
                skp.Find(spellName).SendMessage("DestroySelf");
            }

            GameObject rSkill = Instantiate(skill, skp.position, Quaternion.identity) as GameObject;
            rSkill.transform.parent = skp;
            
        }
        else
        {
            AudioSource audioSouce = GetComponent<AudioSource>();
            audioSouce.clip = rangeSkillError;
            audioSouce.Play();
        }
        

        

        
    }


}
