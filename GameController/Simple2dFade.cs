using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simple2dFade : MonoBehaviour {

    public float delay;
    public float speed;
    public SpriteRenderer sprite;
    public bool repeat;
    public bool needTurnOff;
    public GameObject offObject;
    public Color color;    

    

    public void StartFade()
    {
        
        
        StopAllCoroutines();        
        StartCoroutine(FadeIn());
    }

    public IEnumerator FadeIn()
    {


        yield return new WaitForSeconds(delay);

        while (repeat)
        {
            while (Mathf.Abs(sprite.color.r - color.r) > 0.02 || Mathf.Abs(sprite.color.g - color.g) > 0.02 || Mathf.Abs(sprite.color.b - color.b) > 0.02 || Mathf.Abs(sprite.color.a - color.a) > 0.02)
            {

                sprite.color = Color.Lerp(sprite.color, color, speed * Time.deltaTime);

                yield return new WaitForSeconds(0.033f);

            }
            sprite.color = color;

        }

        while (Mathf.Abs(sprite.color.r - color.r) > 0.02 || Mathf.Abs(sprite.color.g - color.g) > 0.02 || Mathf.Abs(sprite.color.b - color.b) > 0.02 || Mathf.Abs(sprite.color.a - color.a) > 0.02)
        {

            sprite.color = Color.Lerp(sprite.color, color, speed * Time.deltaTime);
            //Debug.Log(sprite.color);
            yield return new WaitForSeconds(0.033f);

        }
        sprite.color = color;

        if (needTurnOff)
        {
            offObject.SetActive(false);
        }

    }

    
}
