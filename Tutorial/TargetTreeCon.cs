using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetTreeCon : MonoBehaviour {

    public Sprite burnedTree;
    public TutorialCon tutorialCon;
    public BoxCollider topTree;

    //private Common common = new Common();
    private Transform fire;
    private bool burned;
    
    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Skill")
        {
            if(!burned)
            {
                fire = transform.Find("FireDotSprite");
                fire.gameObject.SetActive(true);
                StartCoroutine(BurnTheTree());
                GetComponent<AudioSource>().Play();
                
                burned = true;
            }
            
        }
        
        
    }

    IEnumerator BurnTheTree()
    {
        yield return new WaitForSeconds(5f);
        GetComponent<SpriteRenderer>().sprite = burnedTree;
        yield return new WaitForSeconds(1f);
        fire.gameObject.SetActive(false);
        transform.position = new Vector3(transform.position.x, 1f, transform.position.z);
        yield return new WaitForSeconds(2f);
        topTree.enabled = false;
        gameObject.tag = "Untagged";
        tutorialCon.Section2();

        //GameObject.Find("Tutorial").GetComponent<TutorialCon>().section2 = true;
        


    }
}
