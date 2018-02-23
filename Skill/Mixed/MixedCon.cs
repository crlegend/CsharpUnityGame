using UnityEngine;
using System.Collections;

public class MixedCon : MonoBehaviour {



    public GameObject dotObj;
    public int existTurns;
    public AudioSource freezeSound;

    Counter coun = new Counter();

    void Start () {

    }

    // Update is called once per frame
    void LateUpdate () {

        coun.CheckCounter();
        if (coun.Count() > existTurns)
        {
            Destroy(gameObject);
        }

    }
    void OnTriggerEnter(Collider coll)
    {


        if (coll.transform.tag == "Enemy") //only work on enemy!
        {
            if (coll.transform.Find(dotObj.name+"(Clone)") != null)
            {
                coll.transform.Find(dotObj.name+"(Clone)").SendMessage("DestroySelf");
            }

            GameObject dot = Instantiate(dotObj, coll.transform.position, Quaternion.identity) as GameObject;
            dot.transform.parent = coll.transform;
            if(freezeSound!=null)
            {
                freezeSound.Play();
                Debug.Log("AA");
            }
            

        }

    }

    void DestroySelf()
    {
        Destroy(gameObject);
    }


}
