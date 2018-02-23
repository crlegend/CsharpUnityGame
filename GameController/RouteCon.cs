using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouteCon : MonoBehaviour {

    public Vector3[] wayPos;
    public MoveCon moveCon;
    public Transform wayPoint1;
    public MainCamCon mainCamCon;
    public AudioSource backMusic,babySound;
    public AudioClip babySuprise;
    


    private BoxCollider coll;
    private int i = 0;
    private bool touched;
    private bool switched = false;

	// Use this for initialization
	void Start () {

        
        transform.position = wayPos[i];
		
	}

    void LateUpdate()
    {
        if (i == (wayPos.Length - 1) && !switched)//baby des to WayPoint1 no longer follow butterfly
        {
            moveCon.transform.parent.GetComponentInChildren<BabyDesCon>().enabled = false;
            moveCon.des = wayPoint1;
            mainCamCon.MoveTo(wayPoint1, 10f); // move camera to maigic arrows, with speedUp
            backMusic.GetComponent<GeneralSoundCon>().NormalSoundFade(0.8f, 0.2f);
            babySound.clip = babySuprise; // play baby suprise sound
            babySound.Play();
            moveCon.PauseSeconds(3f);
            switched = true;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        touched = true;

        if (i == (wayPos.Length - 1)) // destory butterfly/route after the last point
        {
            Destroy(col.transform.parent.gameObject);
            Destroy(gameObject);
        }
    }

    void OnTriggerExit(Collider col)
    {
        touched = false;
    }
    // Update is called once per frame
    public void NextPos()
    {
        if (i < wayPos.Length && touched)
        {
            i++;
            transform.position = wayPos[i];
        }
        
    }

    public bool RouteTouched()
    {
        return (touched);
    }

    



}
