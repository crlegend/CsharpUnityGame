using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovementNew : MonoBehaviour
{

    public float delay, speed;
    public Vector3 direction;
    private bool move = false;

    // Use this for initialization
    public void StartMove(bool onOff)
    {
        if(onOff)
        {
            move = onOff;
            StartCoroutine(MoveTo());
            
        }
        else
        {
            move = onOff;
        }

    }

    IEnumerator MoveTo()
    {
        yield return new WaitForSeconds(delay);
        while (move)
        {
            transform.Translate(direction * speed * Time.deltaTime);
            yield return new WaitForSeconds(0.033f);
        }
    }


}
