using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowRandomLerp : MonoBehaviour {

    

    private Common common;
    private Vector3 endPos,temPos;
    private bool triggered = false;
    private Camera cam;
    private bool moveBack = false;
    private bool released = false;


    public AudioClip releaseSound;
    public float speed;
    
    

    void Awake()
    {
        common = new Common();
        //cam = GameObject.Find("TutorialCamera").GetComponent<Camera>();        
        cam = Camera.main;

    }

    void Start () {
        endPos = temPos = transform.position;
        transform.position = common.RandomPosition(cam);
        
        
    }
	
	// Update is called once per frame
	void Update () {


        transform.position = Vector3.Lerp(transform.position, endPos, Time.deltaTime * speed);
        if (Mathf.Abs(transform.position.z-endPos.z)<0.05 && triggered == false)
        {
            GetComponent<AudioSource>().Play();
            transform.Find("Sparks").gameObject.SetActive(true);
            //Debug.Log(Mathf.Abs(transform.position.z - endPos.z));
            triggered = true;
        }

        if (released)
        {
            endPos = common.RandomPositionOutside(cam);
            
            released = false;
            
        }

        if (moveBack)
        {
            endPos = temPos;
            moveBack = false;
        }
		
	}

    public void MoveBack()
    {
        moveBack = true;
    }

    public void Release()
    {
        released = true;
    }

    
}
