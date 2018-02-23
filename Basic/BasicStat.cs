using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class BasicStat : MonoBehaviour {


    public int hp = 50;
    public float fadeSpeed;
    public GameObject monsterSprite;
    public SoundEffectCon soundEffectCon;
    public string deadSoundName;
    public int deadSoundNumber;

    public bool healtable = true;
    

    private SpriteRenderer spr;
    private Animator ani;

    private bool dead = false;



    private Color col;
    private int fullHP;

    [Header("Absorption")]
    public bool abFire;
    public bool abWind;
    public bool abWater;







    void Awake () {

        spr = monsterSprite.GetComponent<SpriteRenderer>();
        ani = monsterSprite.GetComponent<Animator>();
        soundEffectCon = transform.root.GetComponentInChildren<SoundEffectCon>();

        Physics.IgnoreLayerCollision(11, 11);
        col = spr.color;
	
	}

    void Start()
    {
        fullHP = hp;
    }
	
	// Update is called once per frame
	void LateUpdate () {

        if (hp <= 0)
        {
            GetComponent<MoveCon>().StopMovement(true);

            if (dead == false)
            {   
                dead = true;
                Dead();
            }
        }
        else if (hp > fullHP)
        {
            hp = fullHP;
        }

        

        
	
	}

    public void HpModifier(int hpChange)
    {
        hp = hp + hpChange;
        StartCoroutine(Spark());
    }




    void Dead()
    {
        if (transform.parent.parent != null) //??????
        {
            //transform.parent.parent = null;
            GetComponent<MoveCon>().enabled = true;
            GetComponent<NavMeshAgent>().enabled = true;
            
        }

        if (soundEffectCon != null)
        {
            soundEffectCon.playSound(deadSoundName, deadSoundNumber);
        }
        


        ani.SetBool("Hurt", true);
        GetComponent<Collider>().enabled = false;
        gameObject.tag = "Untagged";
        transform.parent.BroadcastMessage("FadeOut");
        transform.parent.SendMessage("DestroySelf", 2f);



    }

    /*IEnumerator FadeOut()
    {



        while (spr.color.a >= 0.05f)
        {
            
            spr.color = Color.Lerp(spr.color, Color.clear, fadeSpeed * Time.deltaTime);
            yield return new WaitForSeconds(0.033f);
            Debug.Log(spr.color.a);

        }




    }*/

    //maybe good enough!
    IEnumerator Spark()
    {

        for (int i = 0; i < 3; i++)
        {
            spr.color = Color.red;
            yield return new WaitForSeconds(0.1f);
            spr.color = col;
            yield return new WaitForSeconds(0.1f);
        }
    }

    /*void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Block")
        {
            stopIt = true;
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.transform.tag == "Block")
        {
            stopIt = false;
        }
    }*/

}
