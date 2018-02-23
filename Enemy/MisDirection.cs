using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;



public class MisDirection : MonoBehaviour {

    public Transform freeEnemies, oriDes, group;
    public MoveCon targetMoveCon;
    public BabyRandomAround randomAround;
    public float misMovementSpeed;
    public float suckInSpeed;
    

    private bool triggered = false;
    
    void Start()
    {
        if(group.parent.parent !=null) //unstable!!!
        {
            freeEnemies = group.parent.parent; 
        }

        oriDes = GameObject.FindGameObjectWithTag("Baby").transform;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Skill")
        {
            Vector3 direction = Vector3.Normalize(col.transform.position - transform.position);
            randomAround.offsetX = direction.x/suckInSpeed;
            randomAround.offsetZ = direction.z/suckInSpeed;
        }
    }

    public void MisDir(bool onOff)
    {
        NavMeshAgent nav = targetMoveCon.GetComponent<NavMeshAgent>();
        float oriSpeed = nav.speed;
        if (!triggered)
        {
            
            group.parent = freeEnemies;
            targetMoveCon.enabled = true;
            nav.enabled = true;
            triggered = true;
        }

        

        if (onOff)
        {
            randomAround.randowSuckIn = true;
            randomAround.gameObject.SetActive(true);            
            targetMoveCon.des = randomAround.transform;
            nav.speed = misMovementSpeed;
        }
        else
        {
            randomAround.randowSuckIn = false;
            randomAround.gameObject.SetActive(false);
            targetMoveCon.des = oriDes;
            nav.speed = oriSpeed;
        }
        
    }

    
}
