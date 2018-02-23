using UnityEngine;
using System.Collections;

public class CharCommon : MonoBehaviour {

    public int fadeSpeed = 5;

    public float hp;


    Color color;
    bool dead = false;
	
	void Start () {

        color = gameObject.GetComponent<SpriteRenderer>().color;
        Physics2D.IgnoreLayerCollision(12, 13);


	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        if (hp <= 0 && dead == false)
        {
            dead = true;
            StartCoroutine(FadeOut());
        }

	
	}

    void HpModifier (int hpChange)
    {        
            hp += hpChange;
            StartCoroutine(Spark());
            Debug.Log(hp);
    }


    void DestroySelf()
    {
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        while (gameObject.GetComponent<SpriteRenderer>().color.a >= 0.05f)
        {
            yield return new WaitForSeconds(0.01f);
            gameObject.GetComponent<SpriteRenderer>().color = Color.Lerp(gameObject.GetComponent<SpriteRenderer>().color, Color.clear, fadeSpeed * Time.deltaTime);

        }
        Destroy(gameObject);
    }

    IEnumerator Spark()
    {
        for (int i = 0; i < 3; i++)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            yield return new WaitForSeconds(0.1f);
            gameObject.GetComponent<SpriteRenderer>().color = color;
            yield return new WaitForSeconds(0.1f);
        }
    }


}
