using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectorCon : MonoBehaviour {

    public Slider slider;
    public Image level;
    public Text levelText;
    
    public Sprite[] levelSnapShot = new Sprite[35];
    public string[] levelNumber = new string[35]; 

    private int tempLvl;
    private KeepCon keeps;


    void Start () {

        keeps = GameObject.FindGameObjectWithTag("Keeps").GetComponent<KeepCon>();

        slider.value = 0;
        tempLvl = (int)slider.value;
        UpdateLevel();

		
	}
	
	// Update is called once per frame
	void Update () {

        if (slider.value != tempLvl)
        {
            
            tempLvl = (int)slider.value;
            //Debug.Log(tempLvl);
            UpdateLevel();
        }

        if (slider.value > keeps.passed)
        {
            slider.value = keeps.passed;
        }
		
	}

    void UpdateLevel()
    {
        level.sprite = levelSnapShot[(int)slider.value];
        levelText.text = levelNumber[(int)slider.value];

    }

    public void GoToLevels()
    {
        keeps.checkNum = (int)slider.value;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }
}
