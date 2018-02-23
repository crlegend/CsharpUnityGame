using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterGroupGon : MonoBehaviour {

    public bool showUp;
    public GameObject darkFire;
    public GameObject[] monsterObjects;
	public Transform rangeTarget;
	public float shiftRange;
	public float moveRange;

    void Awake()
    {
        rangeTarget = GameObject.Find("Baby").transform;
        if (shiftRange == 0f)
        {
            shiftRange = 3f;
            moveRange = 3f;
        }
        
    }

    
	void Start () {

		while (!RangePassed ()) {
		};




        if (showUp)
        {
            for (int i = 0; i < monsterObjects.Length; i++)
            {
                monsterObjects[i].SetActive(false);
            }
            darkFire.SetActive(true);
            GetComponent<AudioSource>().Play();


        }


    }

	bool RangePassed()
	{
		bool pass = false;

		float distance;

		distance = Vector2.Distance(new Vector2(transform.position.x, transform.position.z),
			new Vector2(rangeTarget.position.x, rangeTarget.position.z));
		


		if (distance < shiftRange) 
		{
			ShiftPosition ();

		} 
		else 
		{
			pass = true;
		}


		return(pass);

	}

	void ShiftPosition()
	{
		bool inMesh = false;
		NavMeshHit hit = new NavMeshHit();
		while (!inMesh)
		{
			inMesh = NavMesh.SamplePosition(RandomInCircle(transform.position, moveRange), out hit, 1f, NavMesh.AllAreas);
		}

		transform.position = hit.position;
	}

	Vector3 RandomInCircle(Vector3 oriPos, float rad)//get a random point around the original position
	{
		return new Vector3(oriPos.x + Random.insideUnitCircle.x * rad, oriPos.y, oriPos.z + Random.insideUnitCircle.y * rad);
	}




    void OnTriggerEnter(Collider col)
    {
        Debug.Log(col.gameObject.tag);   
        if (col.gameObject.tag == "CamBoundary")
        {
            darkFire.SetActive(true);
        }
    }


    public void DestroySelf(float delay)
    {
        Destroy(gameObject, delay);
    }
}
