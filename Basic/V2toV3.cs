using UnityEngine;
using System.Collections;

public class V2toV3  {



    public Vector3 V2V3(Vector2 vec2, float y)
    {
        
        return (new Vector3 (vec2.x, y, vec2.y));
    }
    public Vector3 V3Normalize(Vector3 vec3, float y)
    {
        return(new Vector3(vec3.x, y, vec3.z));
    }
}
