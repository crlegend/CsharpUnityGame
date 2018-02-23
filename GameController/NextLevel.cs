using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour {

    public GameObject backGround;
    public int nextLevelNumber;
    public KeepCon keeps;
     

	void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Baby")
        {
            NextLvl();
        }        

    }

    public void NextLvl()
    {

        StartCoroutine(Next());
        //OnTriggerSave.Save();
        keeps.checkNum = nextLevelNumber;
        GameObject.FindGameObjectWithTag("MainControl").GetComponent<SaveData>().Save();
    }

    IEnumerator Next()
    {
        backGround.GetComponent<BackGroundCon>().FadeSelf(0.01f, false);
        yield return new WaitForSeconds(2f);
        //KeepCon keeps = GameObject.FindGameObjectWithTag("Keeps").GetComponent<KeepCon>();    
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }
}
