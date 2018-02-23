using UnityEngine;
using System.Collections;

public class RangeSkill : MonoBehaviour {
    public GameObject dots;
    public int existTurns;



    Counter coun = new Counter();
    Common com = new Common();
    int c =0;
	
	




    protected virtual void FixedUpdate () {

        coun.CheckCounter();

        if (c != coun.Count())
        {
            
            c = coun.Count();
        }

        if (coun.Count() > existTurns)
        {
            DestroySelf();
        }

    }

    protected virtual void OnTriggerEnter(Collider coll)
    {


        if (coll.transform.Find(dots.name + "(Clone)") == null && coll.transform.tag == "Enemy") //only add dot on enemy!
        {

            GameObject dot = Instantiate(dots, coll.transform.position, Quaternion.identity) as GameObject;
            dot.transform.parent = coll.transform; 

        }
    }

    protected virtual void OnTriggerExit(Collider coll)
    {
        if (coll.transform.Find(dots.name + "(Clone)") != null)
        {
            coll.transform.Find(dots.name + "(Clone)").SendMessage("DestroySelf");
        }
    }

    protected virtual void DestroySelf()
    {
        com.ReduceRange(transform);
        Destroy(gameObject);
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
