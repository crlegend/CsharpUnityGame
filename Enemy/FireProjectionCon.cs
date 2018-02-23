using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectionCon : MonoBehaviour {

    public Transform target,arrowStartPoint;
    public GameObject projection;
    public int errorRate;
    public Transform finalTarget;
    public MoveCon moveCon;
    public AniSwitcher ani;
    
    
    public float maxErrorRange,minErrorRange;
    //public float chargeTime;
    public float shootRange;
    public float farFactor = 1000; //for the targetTransform get faraway.

    [HideInInspector]public bool shooted;

    private bool hurting;


    /// <summary>
    /// basicly animation controlled fire arrow!!!
    /// </summary>
    
    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Baby").transform;
    }

    void FixedUpdate()
    {
        if(!shooted)
        {
            if (Mathf.Abs(Vector3.Distance(transform.position, target.position)) < shootRange)
            {
                Shoot();
                shooted = true;
            }
        }
        else
        {
            if(ani.GetComponent<Animator>().GetBool("Hurt") &&!hurting) // crazy logic!!! to turn back from hurt
            {
                hurting = true;
            }

            if (hurting)
            {
                if(!ani.GetComponent<Animator>().GetBool("Hurt"))
                {
                    shooted = false;
                    hurting = false;
                }
            }
        }

        
        
    }

    void Shoot()
    {
        //moveCon.des = target;
        //moveCon.StopMovement(true);
        moveCon.StopMovement(true);
        ani.CastMagic(true);
        //Debug.Log("AA");
    }

	public void Fire()
    {
        if (arrowStartPoint.childCount == 0)
        {
            FireProjection(CalculatePosition());
        }
        
    }

    public Transform CalculatePosition()
    {
        Vector3[] possiblePositions = new Vector3[errorRate];
        for (int i =1;i<possiblePositions.Length;i++)
        {
            possiblePositions[i] = target.position;
            possiblePositions[i] = possiblePositions[i] + RandomVector3(maxErrorRange,minErrorRange);
            possiblePositions[i] = new Vector3(possiblePositions[i].x, 0f, possiblePositions[i].z);
        }
        possiblePositions[0] = target.position;

        //Instantiate(finalTarget,transform);

        //finalTarget.position = Vector3.Normalize(possiblePositions[Random.Range(0, possiblePositions.Length)]) * farFactor;
        finalTarget.localPosition = Vector3.Normalize(transform.InverseTransformPoint(possiblePositions[Random.Range(0, possiblePositions.Length)]))*farFactor;
        finalTarget.position = new Vector3(finalTarget.position.x, 0f, finalTarget.position.z);
        

        
        return finalTarget;

    }

    void FireProjection(Transform shootPoint)
    {
        GameObject projector = Instantiate(projection, arrowStartPoint) as GameObject;
        projector.GetComponent<MoveCon>().des = shootPoint;
        //Debug.Log("CC");     

    }

    public Vector3 RandomVector3(float error, float minError)
    {        
        Vector3 randomV3 = new Vector3();
        while (true)
        {
            randomV3 = new Vector3(Random.Range(-error, error), 0f, Random.Range(-error, error));
            if (Mathf.Abs(randomV3.x) > minError && Mathf.Abs(randomV3.z) > minError)
            {
                break;
            }
        }
        
        return randomV3;

    }

}
