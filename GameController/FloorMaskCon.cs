using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorMaskCon : MonoBehaviour {

    public Simple2dFade fade;
    public BoxCollider groundBlock;
    public GroundTriggerCon groundTrigger;
    public MonoBehaviour afterAlt;

    //private bool canGoBack = true;

	public void GoAlt()
    {
        StopAllCoroutines();
        StartCoroutine(AltState());
    }

    IEnumerator AltState()
    {
        
        yield return StartCoroutine(fade.FadeIn());
        groundBlock.enabled = false;
        afterAlt.enabled = true;
                
    }

    public void GoBack()
    {
        groundBlock.isTrigger = true;
        groundBlock.enabled = true;
        StartCoroutine(RegularState());
    }

    IEnumerator RegularState()
    {
        while (true)
        {
            yield return new WaitForFixedUpdate();
            if (groundTrigger.canGoBack)
            {
                fade.color = Color.clear;
                groundBlock.isTrigger = false;
                groundBlock.enabled = true;
                yield return StartCoroutine(fade.FadeIn());                
                break;
            }
            else
            {
                yield return new WaitForSeconds(1f); // 1s retest;
                groundTrigger.canGoBack = true;
                groundBlock.enabled = false; // reset trigger to get trigger information 
                yield return new WaitForFixedUpdate();
                groundBlock.enabled = true;
            }
        }
        
        
        

    }    

}
