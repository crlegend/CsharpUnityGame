using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjByAnimation : MonoBehaviour {

    public FireProjectionCon firePorjection;
    public AniSwitcher ani;
    public MoveCon moveCon;
    public Transform randomPos;
    public Transform arrowStartPoint;

    public void FireIt() //need to be used in animation!!
    {
        firePorjection.Fire();
    }

    public void CastFinished() //need to be used in animation!!!
    {
        if (arrowStartPoint.childCount>0)
        {
            arrowStartPoint.GetChild(0).parent = null;
        }
        
        ani.CastMagic(false);
        firePorjection.shooted = false;
        moveCon.StopMovement(false);
        //moveCon.enabled = true;
        moveCon.des = randomPos;       
        //Debug.Log("aa");

    }
}
