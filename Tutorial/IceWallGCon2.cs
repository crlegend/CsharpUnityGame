using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceWallGCon2 : IceWallGCon {

    public Level11 level11;

    protected override void NextStep()
    {
        StartCoroutine(IceWallCheck());
    }

    IEnumerator IceWallCheck()
    {
        yield return new WaitForSeconds(2f);
        bool pass = true;
        IceWallCon[] iceWalls = GetComponentsInChildren<IceWallCon>();
        for (int i = 0; i < iceWalls.Length; i++)
        {
            if (!iceWalls[i].IceWallBroken())
            {
                pass = false;
            }
        }

        if (pass)
        {
            tutorialCon.enabled = false;
            level11.enabled = true;
            Destroy(gameObject, 1f);
        }
        else
        {
            for (int i = 0; i < iceWalls.Length; i++)
            {
                iceWalls[i].IceWallRecovery();
            }
            ResetAll();
            pass = true;
        }
        

    }
}
