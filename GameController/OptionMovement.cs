using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionMovement : MonoBehaviour {

	public void MoveIn(bool onOff)
    {
        if(onOff)
        {
            GetComponent<Animator>().SetTrigger("In");
        }
        else
        {
            GetComponent<Animator>().SetTrigger("Out");
        }

    }
}
