using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test1 : MonoBehaviour {

    //GestureTemplates gesT;
    ArrayList temp = new ArrayList();
	// Use this for initialization
	void Start () {

        GestureXml ges = new GestureXml();
        GestureContainer gesContainer = new GestureContainer();



        //gesT = new GestureTemplates();

        ges.pos = new Vector2[64];


        for (int j = 0; j < 2; j++)
        {
            temp = (ArrayList)GestureTemplates.Templates[j];

            for (int i = 0; i < temp.Count; i++)
            {
                ges.pos[i] = (Vector2)temp[i];
            }  

            ges.name = (string)GestureTemplates.TemplateNames[j];

            gesContainer.gestures.Add(ges);
        }

        //Debug.Log(ges.pos.Count);
        //Debug.Log(ges.name);

        gesContainer.Save("save.xml");





        //GestureContainer gesCon = GestureContainer.Load("save.xml");

        //Debug.Log(gesCon.gestures[0].pos[0]);






		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
