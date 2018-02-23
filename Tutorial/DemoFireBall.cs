using UnityEngine;
using System.Collections;

public class DemoFireBall : MonoBehaviour
{

    //public GameObject fireWind;
    public GameObject explosion;
    public float speed;
    public GameObject firballImage;

    private GameObject followCam;
    public AudioClip[] fireballSounds; //0:woosh, 1:fly, 2:hit
    
    



    private Vector3 direction;
    private Rigidbody rig;
    private AudioSource soundCon;








    void Awake()
    {
        rig = GetComponent<Rigidbody>();
        soundCon = GetComponent<AudioSource>();
        

    }

    // Use this for initialization

    void Start()
    {
        Physics.IgnoreLayerCollision(12, 13);

        followCam = GameObject.Find("FollowCamera");

        followCam.GetComponent<FollowCamCon>().ActiveFollowCamera();
        followCam.GetComponent<FollowCamCon>().target = gameObject.transform;

        direction = new Vector3(0, 0, 1);
        StartCoroutine(MoveFireBall());

    }

    // Update is called once per frame
   

        
         //move the fire ball with addforce(speedup)


        //float angle = Mathf.Atan2(direction.z, direction.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.AngleAxis(angle, Vector3.right);
        //Debug.Log(angle);
    

    IEnumerator MoveFireBall()
    {
        PlaySounds(0);
        yield return new WaitForSeconds(2f);
        PlaySounds(1);
        while(true)
        {
            yield return new WaitForSeconds(0.03f);
            rig.AddForce((direction) * speed);
        }
        
    }
    void OnCollisionEnter(Collision coll)
    {


        if (coll.gameObject.tag == "Enemy")
        {
            PlaySounds(2);
            GameObject fireballExplosion = Instantiate(explosion, transform.position, Quaternion.identity) as GameObject;
            fireballExplosion.transform.parent = transform;

            firballImage.SetActive(false);

            
            Destroy(gameObject, 5f);



        }

    }

    public void PlaySounds(int i)
    {
        soundCon.clip = fireballSounds[i];
        soundCon.Play();
    }




}
