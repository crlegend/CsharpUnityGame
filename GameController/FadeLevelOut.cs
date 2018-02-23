using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeLevelOut : MonoBehaviour {

    public float destroyTime;
    public GeneralSoundCon genSound;
    public GameObject baby;

	public void FadeLevel()
    {
        baby.SetActive(false);
        GetComponentInChildren<BackGroundCon>().FadeSelf(0f,false);
        genSound.NormalSoundFade(3f, 0f);
        genSound.EnemySoundFade(3f, 0f);
        Destroy(gameObject, destroyTime);
    }
}
