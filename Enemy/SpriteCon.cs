using UnityEngine;
using System.Collections;

public class SpriteCon : MonoBehaviour {

    public Color freezeColor;
    public Color deBurnColor;
    public float fadeSpeed;

    public bool freeze;
    public bool deBurn;
    private SpriteRenderer spr;
    private Color cor;
    private bool fade = false;
	
    void Start () {
        spr = GetComponent<SpriteRenderer>();
        cor = spr.color;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        if (!fade)
        {
            if (freeze)
            {
                spr.color = freezeColor;
            }
            else if(deBurn)
            {
                spr.color = Color.Lerp(spr.color, deBurnColor, fadeSpeed*Time.deltaTime);
            }
            else
            {
                spr.color = Color.Lerp(spr.color, cor, fadeSpeed * Time.deltaTime);
            }
        }
	}

    void Freeze(bool fre)
    {
        freeze = fre;
    }

    void FadeOut()
    {
        StartCoroutine(FadeOutSelf());
        fade = true;
    }

    IEnumerator FadeOutSelf()
    {
        while (spr.color.a >= 0.05f)
        {
            
            spr.color = Color.Lerp(spr.color, Color.clear, fadeSpeed * Time.deltaTime);
            yield return new WaitForSeconds(0.033f);
            //Debug.Log(spr.color.a);

        }
    }
}
