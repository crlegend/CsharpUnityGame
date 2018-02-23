using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

    public MainController mController;

	void OnTriggerEnter(Collider col)
    {
        
        if (col.gameObject.tag == "Enemy" || col.gameObject.tag == "Trail")
        {
            ToGameOver();
            //Debug.Log(col.gameObject.tag);
        }
    }

    public void ToGameOver()
    {
        mController.GameOver();
    }

	
}
