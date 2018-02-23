using UnityEngine;
using System.Collections;

public class Wind : RangeSkill {

    public GameObject earthWind;
    public GameObject waterWind;
    public GameObject fireWind;

    private bool addFireWind = false;
    private bool addedFireWind = false;

	// Use this for initialization
	void Start () {

        AddCombineSkill("EarthWall(Clone)", earthWind);
        AddCombineSkill("WaterPour(Clone)", waterWind);

	
	}
	
	// Update is called once per frame
    protected override void FixedUpdate () {

        base.FixedUpdate();
        if (addFireWind && !addedFireWind)
        {
            if (transform.parent.transform.Find("FireWind(Clone)") != null)
            {
                transform.parent.transform.Find("FireWind(Clone)").SendMessage("DestroySelf");
            }

            GameObject fw = Instantiate(fireWind, transform.position, Quaternion.identity) as GameObject;
            fw.transform.parent = transform.parent;
            addedFireWind = true;
        }

	}

    void AddFireWind()
    {
        addFireWind = true;
    }
}
