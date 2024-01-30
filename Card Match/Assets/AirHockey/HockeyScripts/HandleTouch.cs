using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleTouch : Object
{
    public int touchId;
    public GameObject myObject;
    public Vector2 velocity;
    public Vector2 current;
    public Vector2 previous;

    public HandleTouch(int newTouchId, GameObject newMyObject)
    {
        touchId = newTouchId;
        myObject = newMyObject;
    }
}
