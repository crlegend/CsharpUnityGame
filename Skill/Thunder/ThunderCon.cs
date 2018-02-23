using UnityEngine;
using System.Collections;

public class ThunderCon : MonoBehaviour {

    public float thunderDamage;
    public int stopTurns;

    Common com = new Common();//need for cal-distance

    public GameObject fireThunder;
    public GameObject thunderWater;



    Counter coun = new Counter();
    int c;

	//cause single damage
    void Start()
    {
        c = coun.Count();
        if (transform.parent != null)
        {
            if (transform.parent.transform.Find("FireDot(Clone)") != null) //combine with fire
            {
                GameObject ft = Instantiate(fireThunder, transform.position, Quaternion.identity) as GameObject;
                ft.transform.parent = transform.parent.transform;
            }

           

            Transform[] pos = com.CalDistance(transform.position);

            if (pos[0].Find("WaterPour(Clone)") != null)
            {
                GameObject wt = Instantiate(thunderWater, pos[0].position, Quaternion.identity) as GameObject;
                wt.transform.parent = pos[0];                   
            }
            else if (pos[1].Find("WaterPour(Clone)") != null)
            {
                GameObject wt = Instantiate(thunderWater, pos[1].position, Quaternion.identity) as GameObject;
                wt.transform.parent = pos[1];
            }
                    

            transform.parent.SendMessage("HpModifier", -thunderDamage);
            transform.parent.SendMessage("Chargeable");
            transform.parent.SendMessage("StopMovement", true);
        }
        else
        {
            Destroy(gameObject, 1f);
        }
    }

    void FixedUpdate()
    {
        coun.CheckCounter();
        if (transform.parent != null)
        {
            if (coun.Count() > stopTurns)
            {
                if (transform.parent != null)
                {
                    transform.parent.SendMessage("StopMovement", false);
                }
                Destroy(gameObject);
            }
            else
            {
                if (c != coun.Count())
                {
                    transform.parent.SendMessage("StopMovement", true); // regulate movement each turn.
                }
            }
        }
    }

    void DestroySelf()
    {
        Destroy(gameObject);
    }
}
