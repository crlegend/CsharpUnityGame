using UnityEngine;
using System.Collections;

public class TheWallCon : MonoBehaviour {

	// Use this for initialization
    public int hp = 50;
    // Use this for initialization
    void Start () {

        Physics2D.IgnoreLayerCollision(12, 12);
        //Debug.Log(Camera.main.WorldToScreenPoint(transform.position));

    }
}
