using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour {

    public float checkTime;

    private bool startQuit = false;
    private bool check = false;
	
	void Update () {

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(!startQuit)
            {
                StartTimer();
                startQuit = true;
            }         
            
        }

        CheckQuit(check);

    }

    void StartTimer()
    {
        //Debug.Log("ee");
        StartCoroutine(Check());
        
    }

    IEnumerator Check()
    {
        yield return new WaitForSeconds(0.033f);
        check = true;
        yield return new WaitForSeconds(checkTime);
        check = false;
        startQuit = false;
    }

    void CheckQuit(bool check)
    {
        if (check)
        {
            //Debug.Log("qq");
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                //Debug.Log("tt");
                Application.Quit();
            }
        }
        
    }
}
