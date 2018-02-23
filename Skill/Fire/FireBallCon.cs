using UnityEngine;
using System.Collections;

public class FireBallCon : MonoBehaviour {

    //public GameObject fireWind;
    public GameObject explosion;
    public float speed;
    //public AudioClip[] fireballSounds; //0:woosh, 1:fly, 2:hit


	private Vector3 direction;
    private Rigidbody rig;
    private bool addDot = true;
    private bool halfDamage = false;
    //private AudioSource soundCon;
    

    public GameObject fire, fireDot;


    void Awake()
    {
        rig = GetComponent<Rigidbody>();
        //soundCon = GetComponent<AudioSource>();
    }

    // Use this for initialization

    void Start () {
        
        Physics.IgnoreLayerCollision(12, 13);
        direction = TrailController.endPos - TrailController.startPos;
	    
	}
	
	// Update is called once per frame
	void LateUpdate () 
    {
        

        rig.AddForce((direction) * speed); //move the fire ball with addforce(speedup)


        //float angle = Mathf.Atan2(direction.z, direction.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.AngleAxis(angle, Vector3.right);
        //Debug.Log(angle);
    }

    void OnCollisionEnter(Collision coll)
    {
        
        
        if (coll.gameObject.tag == "Enemy")
        {
           
            if (coll.transform.Find("FireDD(Clone)") != null)
            {
                coll.transform.Find("FireDD(Clone)").SendMessage("DestroySelf");
            }

            GameObject damage = Instantiate(fire, coll.transform.position, Quaternion.identity) as GameObject;

            if (halfDamage == true)
            {
                damage.SendMessage("DamageModifier", 2); //half damage!!
            }

            damage.transform.parent = coll.transform;

            
            if (coll.transform.Find("FireDot(Clone)") != null)
            {
                coll.transform.Find("FireDot(Clone)").SendMessage("DestroySelf");               
                
            }

            if (coll.gameObject.GetComponent<BasicStat>().abFire) // if absorption no dot!
            {
                addDot = false;
            }

            if (addDot == true)
            {
                GameObject dot = Instantiate(fireDot, coll.transform.position, Quaternion.identity) as GameObject;
                dot.transform.parent = coll.transform;

            }
           



            Instantiate (explosion, transform.position, Quaternion.identity);

            Destroy(gameObject, 0.1f);

           

        }

        if (coll.gameObject.tag == "EventObject")
        {
            Instantiate(explosion, transform.position, Quaternion.identity);           
            
            Destroy(gameObject, 0.1f);
        }

    }

    // if touch water, don't add dot , damage half!~
    void OnTriggerEnter(Collider coll)
    {
        if (coll.transform.name == "WaterPour(Clone)")
        {
            addDot = false;


            halfDamage = true;
        }
    }

    /*
    public void PlaySounds(int i)
    {
        soundCon.clip = fireballSounds[i];
        soundCon.Play();
    }*/

   
}
