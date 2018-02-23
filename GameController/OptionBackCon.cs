using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionBackCon : MonoBehaviour {

    public PauseMeunMovement pause;
    public StartMenuCon start;

	public void Save()
    {
        GameObject.FindGameObjectWithTag("MainControl").GetComponent<SaveData>().Save();
    }

    public void BackFromPause()
    {
        if (pause.gameObject.activeInHierarchy)
        {
            pause.PauseMenuIn(true);
        }
        else if (start.gameObject.activeInHierarchy)
        {
            start.StartMenuIn(true);
        }
        
    }
}
