using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishCast : MonoBehaviour {

    private AniSwitcher aniSwitcher;
    

	// Use this for initialization
	void Start () {

        aniSwitcher = transform.parent.GetComponent<AniSwitcher>();

		
	}

    public void CastToBack()
    {

        aniSwitcher.CastMagic(false);
        transform.parent.parent.GetComponentInChildren<MoveCon>().StopMovement(false);
        Destroy(gameObject);

    }
	
	
}
