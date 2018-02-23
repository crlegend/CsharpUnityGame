using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FindTransfromsInChildrenWithName
{
    

    public static Transform[] FindTranformsWithName(this Transform trans, string name)
    {
        Transform[] allTransforms, targetTransforms;
        int number = 0;
        
        allTransforms = trans.GetComponentsInChildren<Transform>();
        for (int i =0;i<allTransforms.Length;i++)
        {
            if (allTransforms[i].name == name)
            {
                number++;
            }
        }

        targetTransforms = new Transform[number];
        number = 0;

        for (int i = 0; i < allTransforms.Length; i++)
        {
            if (allTransforms[i].name == name)
            {
                targetTransforms[number] = allTransforms[i];
                number++;
            }
        }

        return targetTransforms;
    }

    public static Transform[] FindTransformsWithTag(this Transform trans, string tag)
    {
        Transform[] allTransforms, targetTransforms;
        int number = 0;

        allTransforms = trans.GetComponentsInChildren<Transform>();
        for (int i = 0; i < allTransforms.Length; i++)
        {
            if (allTransforms[i].tag == tag)
            {
                number++;
            }
        }

        targetTransforms = new Transform[number];
        number = 0;

        for (int i = 0; i < allTransforms.Length; i++)
        {
            if (allTransforms[i].tag == tag)
            {
                targetTransforms[number] = allTransforms[i];
                number++;
            }
        }

        return targetTransforms;
    }

}
