using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchLocationRotate : Object
{
    public int touchId;
    public GameObject myObject;
    public Vector3 previousTouchPos;
    public TouchLocationRotate(int newTouchId, GameObject newMyObject, Vector3 newPreviousPos)
    {
        touchId = newTouchId;
        myObject = newMyObject;
        previousTouchPos = newPreviousPos;
    }
}
