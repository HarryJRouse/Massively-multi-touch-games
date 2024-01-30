using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchLocationGrab : Object
{
    public int touchId;
    public GameObject myObject;
    public TouchLocationGrab(int newTouchId, GameObject newMyObject)
    {
        touchId = newTouchId;
        myObject = newMyObject;
    }
}
