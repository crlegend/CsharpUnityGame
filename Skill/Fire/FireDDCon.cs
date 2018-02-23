using UnityEngine;
using System.Collections;

public class FireDDCon : MonoBehaviour {

    public GameObject fireWind;
    public int damage;
    int damageTemp;
    bool damaged = false;

    Counter coun = new Counter();

    private Common com = new Common();
    private AniSwitcher ans;
    

    //int c;

       
	void Start () {

        //nav = transform.parent.GetComponent<NavMeshAgent>();

        

        ans = transform.parent.parent.GetComponentInChildren<AniSwitcher>();
        

        if (transform.parent.Find("WindDot(Clone)") != null)
        {
            Transform pos = com.CalShortestDistance(transform.position);
            //Debug.Log(pos.name);

            if (pos.Find("WindSwing(Clone)") != null)
            {
                pos.Find("WindSwing(Clone)").SendMessage("AddFireWind");
            }
        }

        transform.parent.SendMessage("StopMovement", true);

        if (damaged == false)
        {
            if (transform.parent.GetComponent<BasicStat>().abFire) //absorpstion!!!
            {
                transform.parent.SendMessage("HpModifier", damage);
                damaged = true;
            }
            else
            {
                if(ans != null)
                {
                    ans.SetHurt(true);
                }
                
                transform.parent.SendMessage("HpModifier", -damage);
                damaged = true;
            }

        }


        //c = coun.Count();


    }
	
	// Late update the damage, receive damage change before this!!!
	void Update () {

        coun.CheckCounter();

       


                   
        

        if (coun.Count() == 1)
        {
            

            transform.parent.SendMessage("StopMovement", false);
            if (ans != null)
            {
                ans.SetHurt(false);
            }
            
            DestroySelf();

        }      



	
	}





    void DamageModifier(int factor)
    {
        damageTemp = damage;  
        damage = damageTemp / factor;

        //Debug.Log(damage);
    }

   

    void DestroySelf()
    {
        
        Destroy(gameObject);
    }
}
