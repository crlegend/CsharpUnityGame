using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsTri : MonoBehaviour {

    public Transform tutorialPoint;
    public GameObject tutorial;

    void OnTriggerEnter(Collider col)
    {
        if (col.transform.tag == "Baby" && transform.position == tutorialPoint.position)
        {
            StartTutorial();
        }
    }

    void StartTutorial()
    {
        tutorial.SetActive(true);
    }
}
