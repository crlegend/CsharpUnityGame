using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadData : MonoBehaviour {

	void Start()
    {

        GameObject.FindGameObjectWithTag("MainControl").GetComponent<SaveData>().Load();
    }
}
