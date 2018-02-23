using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
    [System.Serializable]
    public class LevelInfo
    {
        public GameObject levels;
        public bool onOff;
        public bool passed;
    }

    public LevelInfo[] level;
    public bool resetLevel = false;
      

    

    


	public void NextLevel(int levelNum)
    {
        level[levelNum - 1].levels.GetComponent<FadeLevelOut>().FadeLevel();
        StartCoroutine(Next(levelNum));
        
    }

    IEnumerator Next(int num)
    {
        yield return new WaitForSeconds(level[num - 1].levels.GetComponent<FadeLevelOut>().destroyTime);
        Instantiate(level[num].levels);
    }
}
