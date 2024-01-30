using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GrabManagement : MonoBehaviour
{   
    public Camera cam1;

    public Dictionary<int, TouchLocationGrab> touches = new();

    public bool canGrab = false;

    void Update()
    {
        if (canGrab)
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
                        TouchLocationGrab thisTouch = touches[t.fingerId];
                        if (thisTouch.myObject != null)
                        {
                            thisTouch.myObject.GetComponent<Rigidbody2D>().velocity = ((thisTouch.myObject.transform.position - thisTouch.previousPos) / Time.deltaTime) / 10;
                        }
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
                            if (thisTouch.myObject.CompareTag("grabbable"))
                            {
                                thisTouch.previousPos = thisTouch.myObject.transform.position;
                                thisTouch.myObject.transform.position = cam1.ScreenToWorldPoint(new Vector3(t.position.x, t.position.y, 10));
                            }
                        }
                    }
                }
                i++;
            }
        }
    }

    GameObject GrabObject(Vector2 position)
    {
        RaycastHit2D hit = Physics2D.Raycast(cam1.ScreenToWorldPoint(position), -Vector2.up);

        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("grabbable"))
            {
                hit.collider.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                return hit.collider.gameObject;
            }
        }
        return null;
    }
}
