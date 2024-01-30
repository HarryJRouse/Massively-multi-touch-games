using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Swipe: MonoBehaviour
{
    public Camera cam1;
    public Camera cam2;

    public Dictionary<int, TouchLocationSwipe> touches = new();

    ModeStart ms;

    protected Vector3 startPointP1;
    protected Vector3 endPointP1;

    protected Vector3 startPointP2;
    protected Vector3 endPointP2;

    void Start()
    {
        ms = FindObjectOfType<ModeStart>();
    }
    void Update()
    {
        if (ms.modeRunning)
        {
            int i = 0;

            if (touches != null && Input.touchCount == 0)
            {
                touches.Clear();
            }

            while (i < Input.touchCount)
            {
                Touch t = Input.GetTouch(i);
                if (t.phase == UnityEngine.TouchPhase.Began)
                {
                    if (t.position.x < Screen.width / 2)
                    {
                        touches.Add(t.fingerId, new TouchLocationSwipe(t.fingerId, 1));
                        startPointP1 = cam1.ScreenToWorldPoint(t.position);
                    }
                    else
                    {
                        touches.Add(t.fingerId, new TouchLocationSwipe(t.fingerId, 2));
                        startPointP2 = cam2.ScreenToWorldPoint(t.position);
                    }

                }
                else if (t.phase == UnityEngine.TouchPhase.Ended)
                {
                    if (touches.Count > 0)
                    {
                        touches.Remove(t.fingerId);
                    }
                }
                else if (t.phase == UnityEngine.TouchPhase.Moved)
                {
                    if (touches[t.fingerId].swiped == false)
                    {
                        DoThing(t);
                    }
                }
                i++;
            }
        }
    }

    public string CalculateDirection(Vector3 startPos, Vector3 endPos)
    {
        float xDistance = endPos.x - startPos.x;
        float yDistance = endPos.y - startPos.y;
        if (Mathf.Abs(xDistance) > Mathf.Abs(yDistance))
        {
            if (xDistance > 0)
            {
                return "right";
            }
            else if (xDistance < 0)
            {
                return "left";
            }
        }
        else if (Mathf.Abs(xDistance) < Mathf.Abs(yDistance))
        {
            if (yDistance > 0)
            {
                return "up";
            }
            else if (yDistance < 0)
            {
                return "down";
            }
        }
        return null;
    }

    public abstract void DoThing(Touch t);
}
