using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsCon : MonoBehaviour {

    private FadeLevelOut[] fadeLevels;

    public LevelManager levelManager;


    void Start()
    {
        levelManager = GameObject.Find("KeepThings").GetComponent<LevelManager>();

        if (levelManager.resetLevel)
        {
            fadeLevels = GetComponentsInChildren<FadeLevelOut>(true);
            for (int i = 0; i < fadeLevels.Length; i++)
            {
                fadeLevels[i].gameObject.SetActive(false);
                
            }

            for (int i = 0; i < fadeLevels.Length; i++)
            {
                fadeLevels[i].gameObject.SetActive(levelManager.level[i].onOff);
                
            }

            levelManager.resetLevel = false;
        }
        
    }
}
