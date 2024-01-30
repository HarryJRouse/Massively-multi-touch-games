using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchLocationZoom : Object
{
    public int touchId;
    public GameObject myObject;
    public int touches = 0;
    public Vector3 touchPosCurrent1 = Vector3.zero;
    public Vector3 touchPosCurrent2 = Vector3.zero;
    public Vector3 touchPosPrev1 = Vector3.zero;
    public Vector3 touchPosPrev2 = Vector3.zero;
    public TouchLocationZoom(int newTouchId, GameObject newMyObject)
    {
        touchId = newTouchId;
        myObject = newMyObject;
    }
}
