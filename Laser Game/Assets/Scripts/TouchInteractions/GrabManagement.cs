using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GrabManagement : MonoBehaviour
{   
    public Camera cam;

    public Dictionary<int, TouchLocationGrab> touches = new();

    public float zPos = 0;

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
            if (t.phase == UnityEngine.TouchPhase.Began)
            {
                touches.Add(t.fingerId, new TouchLocationGrab(t.fingerId, GrabObject(t.position)));

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
                if (touches.Count > 0)
                {
                    TouchLocationGrab thisTouch = touches[t.fingerId];
                    if (thisTouch.myObject != null)
                    {
                        GameObject obj = thisTouch.myObject;
                        Vector3 touchWorldPos = cam.ScreenToWorldPoint(new Vector3(t.position.x, t.position.y, zPos));
                        if (thisTouch.myObject.CompareTag("PowerUp") || thisTouch.myObject.CompareTag("Coin"))
                        {
                            obj.transform.position = touchWorldPos;
                        }

                    }
                }
            }
            i++;

        }
    }

    GameObject GrabObject(Vector2 position)
    {
        Physics2D.queriesHitTriggers = false;
        RaycastHit2D hit = Physics2D.Raycast(cam.ScreenToWorldPoint(position), new Vector2(0, 0));

        if (hit.collider != null)
        {
            return hit.collider.gameObject;
        }
        return null;
    }
}
