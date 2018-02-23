using UnityEngine;
using System.Collections;

public class ThunderWaterCon : MonoBehaviour {

	// Use this for initialization
    //need to add dot to every enemy, and trigger(of cause)!

    public GameObject waterThunderDot;
    public int existTurns;

    Counter coun = new Counter();

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        coun.CheckCounter();
        if (coun.Count() == existTurns)
        {
            Destroy(gameObject);
        }
	
	}
    void OnTriggerEnter2D(Collider2D coll)
    {


        if (coll.transform.Find("ThunderWaterDot(Clone)") == null && coll.transform.tag == "Enemy") //only work on enemy!
        {

            GameObject dot = Instantiate(waterThunderDot, coll.transform.position, Quaternion.identity) as GameObject;
            dot.transform.parent = coll.transform; 

        }

    }


}
