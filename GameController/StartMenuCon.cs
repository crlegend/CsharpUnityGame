using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuCon : MonoBehaviour {

    public Animator startMenuAni,levelSelectorAni;

    void Awake()
    {
        //GetComponent<Canvas>().sortingLayerName = "UI";
    }

	public void StartMenuIn(bool onOff)
    {
        if (onOff)
        {
            startMenuAni.SetTrigger("In");
            
        }
        else
        {
            startMenuAni.SetTrigger("Out");
            
        }
        
    }

    public void LevelSelectorIn(bool onOff)
    {
        if(onOff)
        {
            levelSelectorAni.SetTrigger("In");
        }
        else
        {
            levelSelectorAni.SetTrigger("Out");
        }
    }

    

}
