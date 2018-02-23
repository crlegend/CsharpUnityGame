using UnityEngine;
using System.Collections;

public class GroupCon : MonoBehaviour {

    
	
    public void DestroySelf(float delay)
    {
        Destroy(gameObject, delay);        
    }

    public virtual void OnOffGroup(bool onOff)
    {
        if(onOff)
        {
            gameObject.SetActive(true);
            GetComponent<Simple2dFade>().color = Color.white;
            GetComponent<Simple2dFade>().needTurnOff = false;
            GetComponentInChildren<MoveCon>().StopMovement(false);
            GetComponent<Simple2dFade>().StartFade();
            
        }
        else
        {
            GetComponent<Simple2dFade>().color = Color.clear;
            GetComponent<Simple2dFade>().needTurnOff = true;
            GetComponentInChildren<MoveCon>().StopMovement(true);
            GetComponent<Simple2dFade>().StartFade();
            
        }
        
    }


}
