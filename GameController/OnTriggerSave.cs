using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerSave : MonoBehaviour {

    public int level;

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Baby")
        {
            Save(level);            
        }
    }

	public static void Save(int lvl)
    {
        KeepCon keepCon = GameObject.FindGameObjectWithTag("Keeps").GetComponent<KeepCon>();
        keepCon.checkNum = lvl;
        if (keepCon.passed < keepCon.checkNum)
        {
            //Debug.Log(keepCon.passed);
            keepCon.passed = keepCon.checkNum;

            //Debug.Log(keepCon.passed);
        }
        GameObject.FindGameObjectWithTag("MainControl").GetComponent<SaveData>().Save();
    }
}
