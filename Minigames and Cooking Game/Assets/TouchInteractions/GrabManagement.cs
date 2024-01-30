using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GrabManagement : MonoBehaviour
{   
    public Camera cam1;
    public Camera cam2;

    public Dictionary<int, TouchLocationGrab> touches = new();

    public float zPos = 10;

    ModeStart ms;

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
                    touches.Add(t.fingerId, new TouchLocationGrab(t.fingerId, GrabObject(t.position)));
                }
                else if (t.phase == UnityEngine.TouchPhase.Ended)
                {
                    if (touches.Count > 0)
                    {
                        if (touches[t.fingerId].myObject != null && touches[t.fingerId].myObject.GetComponent<AddVelocity>() != null)
                        {
                            touches[t.fingerId].myObject.GetComponent<AddVelocity>().FireProjectile();
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
                            if (thisTouch.myObject.CompareTag("grabbable1"))
                            {
                                thisTouch.myObject.transform.position = cam1.ScreenToWorldPoint(new Vector3(t.position.x, t.position.y, zPos));
                            }
                            if (thisTouch.myObject.CompareTag("grabbable2"))
                            {
                                thisTouch.myObject.transform.position = cam2.ScreenToWorldPoint(new Vector3(t.position.x, t.position.y, zPos));
                            }
                        }
                    }
                }
                i++;
            }
        }
    }

    GameObject GrabObject(Vector3 position)
    {
        RaycastHit hit;
        if (position.x < Screen.width / 2)
        {
            if (Physics.Raycast(cam1.ScreenToWorldPoint(position), transform.forward, out hit, 50))
            {
                if (hit.collider.CompareTag("grabbable1"))
                {
                    hit.collider.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    return hit.collider.gameObject;
                }
            }
            return null;
        }
        else
        {
            if (Physics.Raycast(cam2.ScreenToWorldPoint(position), transform.forward, out hit, 50))
            {
                if (hit.collider.CompareTag("grabbable2"))
                {
                    hit.collider.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    return hit.collider.gameObject;
                }
            }
            return null;
        }
    }
}
