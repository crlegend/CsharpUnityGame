using UnityEngine;
using System.Collections;

public class Water : RangeSkill {

	// Use this for initialization
    public GameObject earthWater;
    public GameObject windWater;
	
	// Update is called once per frame
    void Start() {

        AddCombineSkill("EarthWall(Clone)", earthWater);
        AddCombineSkill("WindSwing(Clone)", windWater);	
	}
}
