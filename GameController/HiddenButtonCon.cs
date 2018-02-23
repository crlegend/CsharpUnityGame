using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenButtonCon : MonoBehaviour {

    public float changeSpeed;
    public float boxRotationSpeed;
    public Vector3 boxSize;
    public GameObject target;
    public bool onOff;
    public GameObject arrows;
    private MagicBoxCon boxCon;

    void Start()
    {
        boxCon = target.GetComponent<MagicBoxCon>();
    }

	void OnMouseDown()
    {
        

        boxCon.boxScale = boxSize;

        StartCoroutine(BoxSpeedFreeze());
        GetComponent<BoxCollider>().enabled = false;
        
    }

    IEnumerator BoxSpeedFreeze()
    {
        while (boxRotationSpeed - boxCon.RotateSpeed > 0.1f)
        {
            yield return new WaitForSeconds(0.03f);
            boxCon.RotateSpeed = Mathf.Lerp(boxCon.RotateSpeed, boxRotationSpeed, changeSpeed * Time.deltaTime);
        }

        while (boxCon.RotateSpeed > 0.1f)
        {
            yield return new WaitForSeconds(0.03f);
            boxCon.RotateSpeed = Mathf.Lerp(boxCon.RotateSpeed, 0f, changeSpeed * Time.deltaTime);
        }

        boxCon.RotateSpeed = 0f;

        // rotate the angle to one side slowly
        while(Mathf.Abs(target.transform.eulerAngles.z - 60) > 0.01)
        {
            yield return new WaitForSeconds(0.03f);
            target.transform.eulerAngles = Vector3.Lerp(target.transform.eulerAngles, new Vector3(0f, 0f, 60f), Time.deltaTime * changeSpeed);
        }
        arrows.SetActive(true);

    }


}
