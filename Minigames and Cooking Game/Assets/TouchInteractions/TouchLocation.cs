using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchLocation : Object
{
    public int touchId;

    public TouchLocation(int newTouchId)
    {
        touchId = newTouchId;
    }
}
