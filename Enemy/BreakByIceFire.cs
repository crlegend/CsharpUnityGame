using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class BreakByIceFire : MonoBehaviour {

    public GameObject[] toBeClose;
    public GameObject[] toBeActivate;

    public SpriteCon spriteCon;

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Fireball(Clone)" && spriteCon.freeze)
        {
            for (int i = 0; i< toBeClose.Length;i++)
            {
                toBeClose[i].SetActive(false);
            }

            for(int i =0;i<toBeActivate.Length;i++)
            {
                toBeActivate[i].SetActive(true);
            }

            GetComponentInChildren<WaterWindDot>().gameObject.SetActive(false);
            
        }
    }
}
