using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellPointCon : MonoBehaviour {

    [System.Serializable]
    public class SpellPos
    {
        public Transform skillPos;
        [Range(0f,1f)]
        public float x;
        [Range(0f, 1f)]
        public float y;
    }

    public SpellPos[] spellPoints1,spellPoints2,spellPoints3,tempPos;
    private SpellPos[] spellPositions;

    void Start()
    {
        spellPositions = spellPoints1;
    }
    

	void Update () {

        for (int i =0; i< spellPositions.Length; i++)
        {
            Vector3 screenPos = new Vector3(Screen.width * spellPositions[i].x, Screen.height * spellPositions[i].y, 0f);            
            spellPositions[i].skillPos.position = Camera.main.ScreenToWorldPoint(screenPos);
            spellPositions[i].skillPos.position = new Vector3(spellPositions[i].skillPos.position.x, 0.5f, spellPositions[i].skillPos.position.z);
        }        
		
	}

    public void SetSpellPoint(SpellPos[] spellPosition)
    {
        spellPositions = spellPosition;

    }
}
