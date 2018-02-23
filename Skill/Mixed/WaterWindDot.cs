using UnityEngine;
using System.Collections;

public class WaterWindDot : DotCon {

	
    protected override void Start () {
       
            transform.root.BroadcastMessage("Freeze", true);
       
            base.Start();
        
	
	}



    protected override void RecoverConditions()
    {
        
            transform.root.BroadcastMessage("Freeze", false);


        base.RecoverConditions();
    }
	
	
}
