using UnityEngine;
using System.Collections;

[System.Serializable]
public class DotCon : MonoBehaviour {


    [Header("Direct Damge")]
    public bool dDamge = false;
    public int dD; //direct damage


    [Header("DoT")]
    public bool dotDamage = false;
    public int dot; // continue damage
    public int dotTurns;


    [Header("Speed(force) regulate")]
    public bool speedReglate = false;
    public float speedRegulator;
    public int speedRegulateTurns;
    public bool stopMovement = false;
    public int stopTurns;


    [Header("Charge Options")]
    public bool deleteCharge = false;
    //public bool resetCharge = false;


    [Header ("Going Down")]
    public bool massLimit = false;
    public int maxMass;


    [Header("Misdirection")]
    public bool misDirection = false;
    public int misDirectionTurns;
   

    [Header("BlowAway")]
    public bool blowAway = false;


    [Header("Exist")]
    public bool baseOnTurns = false;
    public int existTurns;

    bool speedRecover = false;
    protected Counter coun = new Counter();
    protected SpriteRenderer ren;

    int c;

  

	
    protected virtual void Start () {

        c = coun.Count();
        if (transform.parent.GetComponent<BasicStat>() != null)
        {
            if (dDamge)
            {
                transform.parent.SendMessage("HpModifier", -dD);
            }
        }

        if (transform.parent.GetComponentInChildren<MoveCon>() != null) // speed regulate only work with moveable object
        {
            if (speedReglate == true)
            {   
            
                transform.parent.GetComponentInChildren<MoveCon>().SpeedModifier(speedRegulator);
            
            }
        

            if (stopMovement == true) // stop
            {
                transform.parent.SendMessage("StopMovement", true);
            }

           
            if (deleteCharge == true) // charge 
            {

                transform.parent.SendMessage("Chargeable", false);
            }

            if (misDirection == true) // in develop
            {
                transform.parent.SendMessage("MisDirection", misDirectionTurns);
            }


            if (blowAway == true) // in develop
            {
                transform.parent.SendMessage("BlowAway");
            }

        }


       

        if (massLimit == true)
        {
            if (transform.parent.GetComponent<Rigidbody2D>().mass >= maxMass)
            {
                transform.parent.SendMessage("GoDown");
            }
                
        }









	
	}
	
	
    protected virtual void FixedUpdate () {

        coun.CheckCounter();

       
        if (c != coun.Count()) // turn base effect
        {
            if (transform.parent.GetComponent<BasicStat>() != null)
            {
                if (dotDamage == true && c <= dotTurns) //dot damage
                {
                    transform.parent.SendMessage("HpModifier", -dot);

                }
            }

            if (transform.parent.GetComponentInChildren<MoveCon>() != null) // movement related
            {
                if (speedRecover == false && coun.Count() == speedRegulateTurns) // recover speed!
                {
                    transform.parent.GetComponent<MoveCon>().SpeedModifier(1f);
                    speedRecover = true;
                }
                else if (speedReglate == true) // change speed
                {
                    transform.parent.GetComponent<MoveCon>().SpeedModifier(speedRegulator);
                }
                else if (stopMovement == true) // stop every turn
                {
                    if (c != coun.Count())
                    {
                        if (coun.Count() < stopTurns)
                        {
                            transform.parent.SendMessage("StopMovement", true); //stop each turns!
                        }
                        else if (coun.Count() == stopTurns) // recovery
                        {
                            transform.parent.SendMessage("StopMovement", false);
                            stopMovement = false;
                        }
                    }
                }
            }

            c = coun.Count();
        }
	}

    protected virtual void LateUpdate()
    {
        if (coun.Count() == existTurns && baseOnTurns == true) // turn exist
        {
            DestroySelf();
        }

    }

    protected virtual void DestroySelf()
    {
        RecoverConditions();

        Destroy(gameObject);
    }

    protected virtual void RecoverConditions()
    {
        


        if (transform.parent.GetComponentInChildren<MoveCon>() != null)
        {
            transform.parent.SendMessage("StopMovement", false);
            transform.parent.GetComponent<MoveCon>().SpeedModifier(1f);
        }


    }

    protected virtual void AddCombineSkill(string preSkillName, GameObject combineSkill)
    {
        if (transform.parent.Find(preSkillName) != null)
        {
            if (transform.parent.Find(combineSkill.name) != null)
            {
                transform.parent.Find(combineSkill.name).SendMessage("DestroySelf");
            }

            GameObject combSkill = Instantiate(combineSkill, transform.position, Quaternion.identity) as GameObject;
            combSkill.transform.parent = transform.parent;
        }
    }
}
