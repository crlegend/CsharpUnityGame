using UnityEngine;
using System.Collections;

public class TurnBase : MonoBehaviour {

    protected Counter coun = new Counter();
    protected int tempTurns;

    protected virtual void Start()
    {
        tempTurns = coun.Count();
        StartSomeThing();
    }


    protected virtual void FixedUpdate () {

        coun.CheckCounter();

        if (tempTurns != coun.Count())
        {
            DoSomeThing();
            tempTurns = coun.Count();


        }
	
	}

    protected virtual void DoSomeThing()
    {
        
    }

    protected virtual void StartSomeThing()
    {
        
    }

}
