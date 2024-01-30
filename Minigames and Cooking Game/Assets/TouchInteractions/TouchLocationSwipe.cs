using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchLocationSwipe : Object
{
    public int touchId;
    public int player;
    public bool swiped = false;
    public TouchLocationSwipe(int newTouchId, int newPlayer)
    {
        touchId = newTouchId;
        player = newPlayer;
    }
}
