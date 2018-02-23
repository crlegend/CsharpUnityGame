using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerifyArrows : MonoBehaviour
{

    public bool entered = false;
    
    public VerifyG verifyG;

    
    private bool mouseDown = false;
    
    //private bool recoverArrowed = false;
    

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
            verifyG.VerifyArrowsSeq();  
            entered = true;
            

            Debug.Log("aa");

            
        }
    }

    

}
