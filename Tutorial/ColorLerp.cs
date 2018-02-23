using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorLerp : MonoBehaviour {

    public Color targetColor;
    public float toSpeed, backSpeed;
    public Color oriColor;
    private SpriteRenderer spriteRender;

    void Start()
    {
        spriteRender = GetComponent<SpriteRenderer>();

        oriColor = Color.white;


    }

    public void LerpToTargetColor()
    {
        
        StartCoroutine(LerpTo());
    }

    IEnumerator LerpTo()
    {
        
        while(Mathf.Abs(targetColor.r - spriteRender.color.r) > 0.1f)
        {
            yield return new WaitForSeconds(0.0333f);
            spriteRender.color = Color.Lerp(spriteRender.color, targetColor, toSpeed * Time.deltaTime);
            //Debug.Log(targetColor.r - spriteRender.color.r);
        }
        spriteRender.color = targetColor;
        

    }

    void LerpColorBack()
    {
        StartCoroutine(LerpBack());
    }

    IEnumerator LerpBack()
    {
        while (Mathf.Abs(oriColor.r - spriteRender.color.r) > 0.1f)
        {
            yield return new WaitForSeconds(0.0333f);
            spriteRender.color = Color.Lerp(spriteRender.color, oriColor, backSpeed * Time.deltaTime);
        }
        spriteRender.color = oriColor;

    }

    public void ColorLerpAround()
    {
        StartCoroutine(LerpAround());
    }

    IEnumerator LerpAround()
    {
        yield return StartCoroutine(LerpTo());
        yield return StartCoroutine(LerpBack());
    }
}
