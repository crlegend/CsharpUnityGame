using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyCon : MonoBehaviour {

    public Transform endPoint;
    public Simple2dFade simpleFade;
    

	public void ToEndPoint()
    {
        GetComponent<MoveCon>().des = endPoint;        
        simpleFade.StartFade();

    }

    
}
