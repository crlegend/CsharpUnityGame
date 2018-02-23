using UnityEngine;
using System.Collections;

public class SpecialCondition : TurnBase {

    public bool chargeable = false;
    public int chargeTurns;
    public int chargeContiueTurns;


    //private NavMeshAgent nav;   
    private Charge cha;

	// Use this for initialization

    void Awake()
    {
        //nav = GetComponent<NavMeshAgent>();

    }
    protected override void Start () {

        if (chargeable)
        {
            cha = new Charge(chargeTurns, chargeContiueTurns, transform);
        }
        base.Start();
	
	}
	
    protected override void DoSomeThing()
    {

        if (chargeable)
        {
            cha.ChargeControl(coun.Count());
        }
    }

    void Chargeable()
    {
        chargeable = false;
    }
}
