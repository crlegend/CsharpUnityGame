using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputManager
{
    public static Vector3 MTPosition()
    {
        Vector3 pos;
        pos = Input.mousePosition;
        if (Input.touches.Length != 0)
        {
            Vector2 touchPos = Input.GetTouch(0).position;
            pos = new Vector3(touchPos.x, touchPos.y, 0f);
        }        
        
        return pos;        
    }

    public static bool MTRightButtonDown()
    {
        bool down;
        down = Input.GetMouseButtonDown(1);
        if (Input.touches.Length != 0)
        {
            down = (Input.touches[0].phase == TouchPhase.Began);

        }
        return (down);
    }

    public static bool MTRightButtonUp()
    {
        bool up;
        up = Input.GetMouseButtonUp(1);
        if (Input.touches.Length != 0)
        {
            up = (Input.touches[0].phase == TouchPhase.Ended);

        }
        return (up);

    }
	
}
