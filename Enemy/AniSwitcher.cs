using UnityEngine;
using System.Collections;

public class AniSwitcher : MonoBehaviour {

    public Transform target;

    private Animator ani;
    //private MoveCon moveCon;
    
     

    
    //private Common com = new Common();
    private Vector3 lasPos;
    private float degree;
    private Vector3 tempDir;
    //private bool setted = false;
    private bool hurted = false;
    private bool casting = false;

    void Awake()
    {
        ani = GetComponent<Animator>();
        //moveCon = transform.parent.GetComponentInChildren<MoveCon>();
        
    }

    void Start () {

        lasPos = transform.position;
        target = GameObject.FindGameObjectWithTag("Baby").transform;
           
	
	}

	
   

	void Update () {


        if(target != null)
        {
            Vector3 targetDirection = (target.position - transform.position).normalized;
            ani.SetFloat("TargetX", targetDirection.x);
            ani.SetFloat("TargetZ", targetDirection.z);
        }


        //degree = com.CalDegree(lasPos,transform.position);
        //Debug.Log(degree);
        //ani.SetFloat("Angle",degree);

       
        Vector3 dir = (transform.position - lasPos).normalized;// get direction
        //Debug.Log(Mathf.Abs(dir.x) + Mathf.Abs(dir.z));

        if (Mathf.Abs(dir.x) + Mathf.Abs(dir.z) > 0) // if object moving
        {
           
            ani.SetFloat("x", dir.x);
            ani.SetFloat("z", dir.z);
            lasPos = transform.position;                    
            tempDir = dir; // store the last non-zero value for the stop direction.
            if (hurted) // hurted show hurted animation
            {
                ani.SetBool("Hurt", true);
                ani.SetBool("Cast", false);

            }
            else if (casting)
            {
                ani.SetBool("Cast", true);
                ani.SetBool("Hurt", false);
                
            }
            else // change back to walking
            {
                ani.SetBool("Cast", false);
                ani.SetBool("Hurt", false);
                if (!ani.GetBool("IsWalking"))
                {
                    ani.SetBool("IsWalking", true);
                }
                
                
                
            }
                
                    
        }

        else // object not moving
        {
            
            ani.SetFloat("x", tempDir.x); //all base on the direction before stop
            ani.SetFloat("z", tempDir.z);

            if (hurted) 
            {
                ani.SetBool("Hurt", true);
                ani.SetBool("Cast", false);

            }
            else if (casting)
            {
                ani.SetBool("Cast", true);
                ani.SetBool("Hurt", false);
            }
            else
            {
                ani.SetBool("Cast", false);
                ani.SetBool("Hurt", false);
                ani.SetBool("IsWalking", false);
            }
                
                    
                
                    
           

        }
    }


	

	
    public void SetHurt(bool hur)
    {
        hurted = hur;
    }

    public void CastMagic(bool cast)
    {
        casting = cast;
    }

    public bool Casting()
    {
        return casting;
    }

    /*public void StopAniAtFirstFrame()
    {
        
        ani.Play(ani.GetCurrentAnimatorStateInfo(0).shortNameHash, -1, 0f);
        ani.speed = 0f;
    }

    public void UnStopAni()
    {
        ani.speed = 1f;
    }*/
    

}
