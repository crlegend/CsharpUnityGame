using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateMonster : MonoBehaviour {

    public GameObject[] members;

    private bool activated;

	public void ActivateSelf()
    {
        for(int i=0;i<members.Length; i++)
        {
            members[i].SetActive(true);
        }

        GetComponent<MoveCon>().enabled = true;
        GetComponent<BasicStat>().enabled = true;
        GetComponent<SpecialCondition>().enabled = true;
        GetComponent<KeepRotation>().enabled = true;
        //GetComponent<MonsterClamp>().enabled = true;

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "CamBoundary" && !activated)
        {
            ActivateSelf();
            activated = true;
        }
    }
}
