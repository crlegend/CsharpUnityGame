using UnityEngine;
using System.Collections;

public class WindDotCon : DotCon {

	





    private Common com = new Common();


    protected override void Start () {

        base.Start();


        //detect if fireDot exist in the windswing dot range, then call the closest skillpos with windswing to add fireWind

        if (transform.parent.transform.Find("FireDot(Clone)") != null)
        {
            Transform[] pos = com.CalDistance(transform.position);
            if (pos[0].Find("WindSwing(Clone)") != null)
            {
                pos[0].Find("WindSwing(Clone)").SendMessage("AddFireWind"); 
            }
            else if (pos[1].Find("WindSwing(Clone)") != null)
            {
                pos[1].Find("WindSwing(Clone)").SendMessage("AddFireWind"); 
            }
        }

        if (transform.parent.GetComponent<MisDirection>() != null)
        {
            //Debug.Log("BB");
            transform.parent.GetComponent<MisDirection>().MisDir(true);
        }


    }

    protected override void RecoverConditions()
    {
        if (transform.parent.GetComponent<MisDirection>() != null)
        {
            transform.parent.GetComponent<MisDirection>().MisDir(false);
        }
        base.RecoverConditions();

    }




}

