using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabInteraction : MonoBehaviour
{
    public Camera cam;

    public Dictionary<int, TouchLocationGrab> touches = new();

    void Update()
    {
        int i = 0;

        if (touches != null && Input.touchCount == 0)
        {
            touches.Clear();
        }

        while (i < Input.touchCount)
        {
            Touch t = Input.GetTouch(i);

            if (t.phase == TouchPhase.Began)
            {
                touches.Add(t.fingerId, new TouchLocationGrab(t.fingerId, GrabObject(t.position)));
                if (touches[t.fingerId].myObject != null)
                {
                }
            }
            else if (t.phase == UnityEngine.TouchPhase.Ended)
            {
                if (touches.Count > 0)
                {
                    touches.Remove(t.fingerId);
                }
            }
            else if (t.phase == TouchPhase.Moved)
            {
                if (touches.Count > 0)
                {
                    TouchLocationGrab thisTouch = touches[t.fingerId];
                    if (thisTouch.myObject != null)
                    {
                        thisTouch.myObject.transform.position = cam.ScreenToWorldPoint(new Vector3(t.position.x, t.position.y, 10));
                    }
                }
            }
            i++;
        }
    }

    GameObject GrabObject(Vector3 position)
    {
        RaycastHit hit;

        if (Physics.Raycast(cam.ScreenToWorldPoint(position), transform.forward, out hit, 50))
        {   
            if (hit.collider.CompareTag("grab"))
            {
                return hit.collider.gameObject;
            }
        }
        return null;

    }
}
