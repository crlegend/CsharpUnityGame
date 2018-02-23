using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterArrowGCon : MonoBehaviour {

    public float radius;
    public float interval;
    public float rotateAngle;
    public GameObject waterArrow;

    private GameObject[] arrows;

    // Use this for initialization
    void Start () {

        StartCoroutine(SetArrows());
        
        Debug.Log(Mathf.Sin(15f));
        Debug.Log(Mathf.Sin(30f));

    }
	
	// Update is called once per frame
	void Update () {

        transform.Rotate(new Vector3(0f, 0f, rotateAngle));

    }

    IEnumerator SetArrows()
    {
        Vector3[] positions = new Vector3[24];
        arrows = new GameObject[positions.Length];
        

        for (int i =0; i<positions.Length;i++)
        {
            arrows[i] = Instantiate(waterArrow, transform) as GameObject;

            float cornerAngle = -15f*i*(Mathf.PI/180) ;

            positions[i] = new Vector3(Mathf.Cos(cornerAngle) * radius, Mathf.Sin(cornerAngle) * radius, 0f);
            arrows[i].transform.localPosition = positions[i];
            arrows[i].transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, -180-15f*i));

            yield return new WaitForSeconds(interval);
            //Debug.Log(Mathf.Sin(15f));
            //Debug.Log(Mathf.Cos(i * 15f));

        }       
    }

    
}
