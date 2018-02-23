using UnityEngine;
using System.Collections;

public class FireThunderCon : MonoBehaviour {

    //just addition damage, and a explosion effect!! (may be add physics later)

    public float fireThunderDamage;
    public GameObject explosion;
    //public int fearTurns;

   

	// Use this for initialization
	void Start () {

        Instantiate (explosion, transform.position, Quaternion.identity);

        SendMessageUpwards("HpModifier", -fireThunderDamage);

        //SendMessageUpwards("Fear", fearTurns);
	
	}
	
	
	
}
