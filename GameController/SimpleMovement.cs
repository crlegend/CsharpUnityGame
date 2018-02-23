using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement : MonoBehaviour {

    public float delay, speed;
    public Vector3 direction;
    public bool move = false;

	// Use this for initialization
	void Start () {

        StartCoroutine(MoveTo());
		
	}

    IEnumerator MoveTo()
    {
        yield return new WaitForSeconds(delay);
        while(move)
        {
            transform.Translate(direction * speed * Time.deltaTime);
            yield return new WaitForSeconds(0.033f);
        }
    }
	
	
}
