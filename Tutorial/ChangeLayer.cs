using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLayer : MonoBehaviour {

	public bool entered = false;
    private bool mouseDown = false;

    void Update()
    {
        if (InputManager.MTRightButtonDown())
        {
            mouseDown = true;
        }
        if (InputManager.MTRightButtonUp())
        {
            mouseDown = false;
        }        

    }

    void OnMouseEnter()
    {
        if (mouseDown)
        {
            //Debug.Log("AA");
            entered = true;
            gameObject.SendMessageUpwards("VerifyArrowsSeq");
        }

            
    }
}
