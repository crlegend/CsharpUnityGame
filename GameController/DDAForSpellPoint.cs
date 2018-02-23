using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDAForSpellPoint : MonoBehaviour {

    private Transform[] spellPos;
    private float[] distance;
    private Transform closest;

	// Use this for initialization
	void Awake () {
        GameObject gameCon = GameObject.Find("GameCon");

        spellPos = gameCon.transform.FindTransformsWithTag("SkillPos");
        
        distance = new float[spellPos.Length];
        
        
	}

    
	
	// Update is called once per frame
	void Update () {

        for (int i = 0; i< spellPos.Length; i++)
        {
            if(spellPos[i] != null)
            {
                distance[i] = Vector3.Distance(transform.position, spellPos[i].transform.position);
                if (!spellPos[i].gameObject.activeInHierarchy)
                    spellPos[i].gameObject.SetActive(true);
            }
            else
            {
                distance[i] = 1000f;//unstable!!
            }
            
        }

        

        closest = spellPos[System.Array.IndexOf(distance, Mathf.Min(distance))].transform;
        if (closest.gameObject.activeInHierarchy)
        {
            //Debug.Log(closest.name);
            closest.gameObject.SetActive(false);
        }

        if (transform.childCount == 0)
        {
            for (int i = 0; i < spellPos.Length; i++)
            {
                if(spellPos[i] != null)
                {
                    if (!spellPos[i].gameObject.activeInHierarchy)
                        spellPos[i].gameObject.SetActive(true);
                }
                
            }

            Destroy(gameObject);

        }

    }
}
