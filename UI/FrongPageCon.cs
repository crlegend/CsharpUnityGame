using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FrongPageCon : MonoBehaviour {

	
    public float waitSecs = 3f;
    public float fadeSpeed = 5f;
    //public BabySoundCon babySoundCon;

    public Image logo;
    public Text sub;
    public GameObject uI;

    

	void Start () {


        

        StartCoroutine(FadeItOut());
		
	}

    IEnumerator FadeItOut()
    {
        yield return new WaitForSeconds(waitSecs);

        while ( logo.color.a >= 0.01f)
        {
            
            logo.color = Color.Lerp(logo.color, Color.clear, fadeSpeed * Time.deltaTime);
            sub.color = Color.Lerp(sub.color, Color.clear, fadeSpeed * Time.deltaTime);
            yield return new WaitForSeconds(0.033f);

        }


        
        gameObject.SetActive(false);
        uI.SetActive(true);
        //babySoundCon.RandomPlayingSounds(1, 10f);


    }

    
	
	
}
