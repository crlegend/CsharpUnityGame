using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllFadeIn : MonoBehaviour {

    //Image[] images;
    public CanvasGroup cg; 
    public float delay;
    public float speed;

	void Start () {

        //images = GetComponentsInChildren<Image>();

	}

    public void Fade(bool fade)
    {
        if (fade)
        {
            StartCoroutine(FadeOutImage());
        }
        
    }

    IEnumerator FadeOutImage()
    {
        yield return new WaitForSeconds(delay);
        /*while (images[0].color.a > 0.01f)
        {
            for (int i = 0; i < images.Length; i++)
            {
                images[i].color = Color.Lerp(images[i].color, Color.clear, speed * Time.deltaTime);
            }
            yield return new WaitForSeconds(0.033f);

        }*/
        while (cg.alpha > 0.01f)
        {
            cg.alpha -= speed * Time.deltaTime;
            yield return new WaitForSeconds(0.033f);
        }
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }	
	
}
