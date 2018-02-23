using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RallyGroupCon : MonoBehaviour
{

    public RallyEnemyCon[] groupMember;
    public SimpleMovementNew[] rallyPoints;
    public float reachTime;

    private bool allReached, moved, timeUp;


    void Start()
    {
        StartCoroutine(Timer());
    }


    void Update()
    {
        if(!moved)
        {
            allReached = true;
            for (int i = 0; i < groupMember.Length; i++)
            {
                if (!groupMember[i].Reached())
                    allReached = false;
            }

            if (allReached || timeUp)
            {
                for(int i =0; i<rallyPoints.Length;i++)
                {
                    rallyPoints[i].StartMove(true);                    
                }
                moved = true;
            }
        }

    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(reachTime);
        timeUp = true;
    }
}
