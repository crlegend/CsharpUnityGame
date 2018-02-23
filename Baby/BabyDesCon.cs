using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyDesCon : MonoBehaviour {

    public Transform route;
    public SpriteRenderer babySpr;
    public MoveCon moveCon;

    private bool layerChanged = false;
	
	void Start () {

        GetComponent<BabyRandomAround>().RandomMoving(false);

        if (!layerChanged)
        {
            StartCoroutine(ChangeLayer());
            layerChanged = true;
        }
		
	}
	

    IEnumerator ChangeLayer()
    {
        yield return new WaitForSeconds(4f);
        babySpr.sortingLayerName = "Baby";
        babySpr.sortingOrder = 0;
        moveCon.des = route; // switch to butterfly as des

    }
	
}
