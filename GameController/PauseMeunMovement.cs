using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMeunMovement : MonoBehaviour {

	public void PauseMenuIn(bool onOff)
    {
        if (onOff)
        {
            GetComponent<Animator>().SetTrigger("In");
        }
        else
        {
            GetComponent<Animator>().SetTrigger("Out");
        }

    }
}
