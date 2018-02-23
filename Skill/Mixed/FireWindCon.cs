using UnityEngine;
using System.Collections;

public class FireWindCon : MonoBehaviour {

	//only exist 1 turn, so doesn't need to be removed here
    public GameObject fireWindDot;

    public int existTurns;



    Counter coun = new Counter();

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        coun.CheckCounter();

        if (coun.Count() == existTurns)
        {
            DestroySelf();
        }
	
	}

    void OnTriggerEnter2D(Collider2D coll)
    {


        if (coll.transform.Find("FireWindDot(Clone)") == null && coll.transform.tag == "Enemy") //only exist 1 turn, so doesn't need to be removed here
        {

            GameObject dot = Instantiate(fireWindDot, coll.transform.position, Quaternion.identity) as GameObject;
            dot.transform.parent = coll.transform; 

        }




    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.transform.Find("FireWindDot(Clone)") != null)
        {
            coll.transform.Find("FireWindDot(Clone)").SendMessage("DestroySelf");
        }
    }



    void DestroySelf()
    {
        
        Destroy(gameObject);
    }
}
