using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDifuseByWater : MonoBehaviour {

    public MoveCon moveCon;
    public SpriteCon spriteCon;
    public FireBarCon fireBarCon;
    public BasicStat basicState;
    public int recoveryTurns,stopTurns;
    
    

    IEnumerator OnTriggerEnter(Collider col)
    {
        if (col.name == "WaterPour(Clone)")
        {
            basicState.abFire = false;        
            spriteCon.deBurn = true;
            moveCon.PauseTurns(stopTurns);
            yield return StartCoroutine(fireBarCon.PassTurns(recoveryTurns));            
            spriteCon.deBurn = false;
            basicState.abFire = false;
        }
    }
}
