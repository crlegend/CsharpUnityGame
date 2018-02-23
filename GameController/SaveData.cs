using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

[Serializable]
class PlayerData
{
    public float[] sliderOptions;
    public int passed;
}



public class SaveData : MonoBehaviour {

    public Slider[] slidersOpts;//master,music,sound
    public KeepCon keeps;

    public void Save()
    {
        keeps = GameObject.FindGameObjectWithTag("Keeps").GetComponent<KeepCon>();
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/PlayerInfo.dat");

        PlayerData playData = new PlayerData();
        playData.sliderOptions = new float[slidersOpts.Length];
        for (int i =0; i< slidersOpts.Length;i++)
        {
            playData.sliderOptions[i] = slidersOpts[i].value;
        }

        
        playData.passed = keeps.passed;

        bf.Serialize(file, playData);
        file.Close();        
    }

    public void Load()
    {
        if(File.Exists(Application.persistentDataPath + "/PlayerInfo.dat"))
        {
            keeps = GameObject.FindGameObjectWithTag("Keeps").GetComponent<KeepCon>();
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/PlayerInfo.dat", FileMode.Open);
            PlayerData playData = (PlayerData)bf.Deserialize(file);
            file.Close();

            //slidersOpts = new Slider[playData.sliderOptions.Length]; //no way!

            for (int i = 0; i < slidersOpts.Length; i++)
            {
                slidersOpts[i].value = playData.sliderOptions[i];
            }
            keeps.passed = playData.passed;
        }       

    }
}
