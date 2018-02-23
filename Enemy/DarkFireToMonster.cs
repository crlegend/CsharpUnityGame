using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkFireToMonster : MonoBehaviour {

    public GameObject[] monsterObjects;




    public void ActivateMonsters()
    {
        for (int i = 0; i<monsterObjects.Length;i++)
        {
            monsterObjects[i].SetActive(true);
        }
        
    }

    public void TurnOffSelf()
    {
        gameObject.SetActive(false);
    }

}
