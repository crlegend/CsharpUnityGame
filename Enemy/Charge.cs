using UnityEngine;
using System.Collections;

public class Charge
{    
    private int chargeTurns;
    private int chargeContinueTurns;
    private Transform ObjTra;

    public Charge(int ct, int cct, Transform tra)
    {        
        chargeTurns = ct;
        chargeContinueTurns = cct;
        ObjTra = tra;
    }
    
    public void ChargeControl(int turns)

    {
        


        if (turns == chargeTurns)
        {
            Charging(true);


        }
        else if (turns == chargeTurns + chargeContinueTurns)
        {
            Charging(false);

        }    
    }



    void Charging(bool cha)
    {
        if (cha)
        {
            ObjTra.SendMessage("SpeedModifier", 10f);

        }
        else
        {
            ObjTra.SendMessage("StopMovement", true);
            ObjTra.SendMessage("SpeedModifier", 1f);
            ObjTra.SendMessage("StopMovement", false);
        }
    }
}
