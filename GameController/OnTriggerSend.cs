using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerSend : MonoBehaviour {

    public string targetName;
    public GameObject targetObject;
    
        
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == targetName)
        {
            SendItOut();
        }
    }

    protected virtual void SendItOut()
    {
        targetObject.GetComponent<WinTutorialCon>().CleanByWind();
        gameObject.SetActive(false);
    }
}
