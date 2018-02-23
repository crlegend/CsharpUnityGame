using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateFollowArrows : MonoBehaviour {

    public GameObject nextGroup;

    private ColorLerp[] groupChild;
    private bool passed;

    void Start()
    {
        groupChild = GetComponentsInChildren<ColorLerp>();
    }

	void Update () {

        passed = true;
        for (int i=0; i<groupChild.Length; i++)
        {
            if (groupChild[i].oriColor != Color.green)
                passed = false;
        }

        if (passed)
        {
            nextGroup.GetComponent<ActivateFollowArrows>().enableBoxCollider(true);
            enableBoxCollider(false);
        }
		
	}

    public void enableBoxCollider(bool onOff)
    {
        for (int i = 0; i< groupChild.Length; i++)
        {
            groupChild[i].GetComponent<BoxCollider>().enabled = onOff;
        }
    }
}
