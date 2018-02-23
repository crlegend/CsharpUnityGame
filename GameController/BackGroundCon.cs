using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundCon : MonoBehaviour {

    public float fadeSpeed;

	void Start()
    {
        BackgoundShow(false);
        FadeSelf(1f,true);
    }



    public void FadeSelf(float target,bool onOff)
    {
        StartCoroutine(FadeBackGround(target,true));
    }	

    IEnumerator FadeBackGround(float tar,bool onOff)
    {
        MeshRenderer[] meshes;
        meshes = GetComponentsInChildren<MeshRenderer>();
        while (Mathf.Abs(meshes[0].material.color.a - tar) > 0.001)
        {
            for (int i = 0; i < meshes.Length; i++)
            {
                if(onOff)
                {
                    meshes[i].material.color = Color.Lerp(meshes[i].material.color, Color.white, Time.deltaTime * fadeSpeed);
                }
                else
                {
                    meshes[i].material.color = Color.Lerp(meshes[i].material.color, Color.clear, Time.deltaTime * fadeSpeed);
                }
                
            }
            yield return new WaitForSeconds(0.033f);
        }       


    }

    public void BackgoundShow(bool onOff)
    {
        MeshRenderer[] meshes;
        meshes = GetComponentsInChildren<MeshRenderer>();
        if (onOff)
        {
            for (int i = 0; i < meshes.Length; i++)
            {
                meshes[i].material.color = Color.white;
            }            
        }
        else
        {
            for (int i = 0; i < meshes.Length; i++)
            {
                meshes[i].material.color = Color.clear;
            }

        }
        
    }


}
