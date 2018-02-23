using UnityEngine;
using System.Collections;

public class WaterDotCon : DotCon {

	// Use this for initialization
    [Header("Combination")]
    public GameObject fireWaterDot;


    protected override void Start () {

        base.Start();
        AddCombineSkill("FireDot(Clone)", fireWaterDot);
       

	
	}
	
	


}
