using UnityEngine;
using System.Collections;

public class ThuAniCon : MonoBehaviour {
    private Animator ani;
    private float y;
    Transform targetSpr;
	// Use this for initialization
	void Start () {
        if (transform.parent.parent != null)
        {
            ani = GetComponent<Animator>();
            StartCoroutine(SmallDot());
            targetSpr = transform.parent.parent.parent.FindChildWithTag("EnemySprite");

            //Debug.Log(targetSpr.GetComponent<SpriteRenderer>().sprite.textureRect.height);
            //Debug.Log(GetComponent<SpriteRenderer>().sprite.textureRect.height);
        }



	}

    IEnumerator SmallDot()
    {
        yield return new WaitForSeconds(ani.GetCurrentAnimatorStateInfo(0).length);

        float y = targetSpr.GetComponent<SpriteRenderer>().sprite.textureRect.height / GetComponent<SpriteRenderer>().sprite.textureRect.height;
        

        transform.localScale = new Vector3(0.2f, transform.localScale.y*y, 1f);

        transform.position = targetSpr.position;
    }
	
	
}
