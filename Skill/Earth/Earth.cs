using UnityEngine;
using System.Collections;

public class Earth : RangeSkill {

    public GameObject watEarth;
    public GameObject winEarth;

	// Use this for initialization
	void Start () {

        AddCombineSkill("WaterPour(Clone)", watEarth);
        AddCombineSkill("WindSwing(Clone)", winEarth);
        	
	}
	
}
