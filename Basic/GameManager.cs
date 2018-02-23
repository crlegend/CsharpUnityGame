using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {


    public float length = 100f;
    //private V2toV3 vtv = new V2toV3();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public Vector3 ScreenWorldPosition(Vector3 pos, LayerMask layer, float length)
    {
        Ray camRay = Camera.main.ScreenPointToRay (pos);
        RaycastHit hit;

        if (Physics.Raycast(camRay, out hit, length, layer))
        {
            return(hit.point);
        }
        return (pos);

    }





}
