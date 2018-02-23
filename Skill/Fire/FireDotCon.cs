using UnityEngine;
using System.Collections;

public class FireDotCon : MonoBehaviour {



    public int fireDotDamage;
    Counter coun;//turn counter;
    int c;//temp number
	

    //CommonCon comm = new CommonCon();

	void Start () {

        


        coun = new Counter();
        c = 0;
        

	}
	
	// Update is called once per frame
	void LateUpdate () {

        coun.CheckCounter();

        if (transform.parent.GetComponent<BasicStat>().abFire)
        {
            Destroy(gameObject);
        }
        else
        {
            if (c != coun.Count() && coun.Count() < 3)
            {
                transform.parent.SendMessage("HpModifier", -fireDotDamage);

                c = coun.Count();


            }
            else if (coun.Count() == 3)
            {
                transform.parent.SendMessage("HpModifier", -fireDotDamage);
                //SendMessageUpwards("EffModifier", "Fire");
                //SpeedEffect(3); // speed recover
                //transform.parent.GetComponent<MoveCon>().SpeedModifier(1f, false);
                Destroy(gameObject);
            }
        }

        
	
	}

    /*void SpeedEffect(float i)
    {
        
    }*/

    void RemoveFireDot()
    {
        
        Destroy(gameObject);
    }
}
