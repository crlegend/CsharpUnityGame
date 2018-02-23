using UnityEngine;
using System.Collections;

public static class PublicStatic  {



    public static Transform FindChildWithTag(this Transform trans, string tag)
    {

        Transform t = trans;

       
        foreach (Transform tr in trans)
        {
            if (tr.tag == tag)
            {
                t = tr;
            }
        }

        if (t != null)
        {
            return (t);
        }
        else
        {
            return null;
        }

    }
}
