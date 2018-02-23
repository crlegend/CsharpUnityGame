using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simple2DFadeIn : MonoBehaviour {

    public float delay;
    public float speed;
    public SpriteRenderer sprite;
    public bool repeat;

    private Color color;
    
	
	void Start () {



        StopAllCoroutines();
        color = new Color(255f, 255f, 255f, 255f);        
        sprite = GetComponent<SpriteRenderer>();
        sprite.color = Color.clear;
        StartCoroutine(FadeIn());



    }
	
    IEnumerator FadeIn()
    {


        yield return new WaitForSeconds(delay);

        while (repeat)
        {
            while (sprite.color.a < 0.98f)
            {

                sprite.color = Color.Lerp(sprite.color, color, speed * Time.deltaTime);

                yield return new WaitForSeconds(0.033f);

            }
            sprite.color = Color.clear;            
            
        }

        while (sprite.color.a < 0.98f)
        {

            sprite.color = Color.Lerp(sprite.color, color, speed * Time.deltaTime);

            yield return new WaitForSeconds(0.033f);

        }
        
    }    
}
