using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSelfDestroy : MonoBehaviour {

    public bool destroy = true;

    private void Start()
    {
        if (destroy)
        {
            Destroy(gameObject, GetComponent<ParticleSystem>().main.duration);
        }
        else
        {
            StartCoroutine(ParticleDeactivate());
        }
        
    }
    

    IEnumerator ParticleDeactivate()
    {
        yield return new WaitForSeconds(GetComponent<ParticleSystem>().main.duration);
        gameObject.SetActive(false);
    }
}
