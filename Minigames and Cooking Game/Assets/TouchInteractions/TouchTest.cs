using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchTest : MonoBehaviour
{
    public Camera cam1;
    public GameObject objectToZoom;
    public float zPos = 10;


    public Dictionary<int, TouchLocationGrab> touches = new();

    Vector3 touchPosCurrent1;
    Vector3 touchPosCurrent2;
    Vector3 touchPosPrev1;
    Vector3 touchPosPrev2;

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
                if (t.fingerId == 0)
                {
                    touchPosCurrent1 = t.position;
                }
                if (t.fingerId == 1)
                {
                    touchPosCurrent2 = t.position;
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
                if (touches.Count > 0)
                {
                    TouchLocationGrab thisTouch = touches[t.fingerId];
                    if (thisTouch.myObject != null && touches.Count == 1)
                    {
                        if (thisTouch.myObject.CompareTag("grabbable1"))
                        {
                            thisTouch.myObject.transform.position = cam1.ScreenToWorldPoint(new Vector3(t.position.x, t.position.y, zPos));
                        }
                    }
                    if (touches.Count == 2)
                    {
                        touchPosPrev1 = touchPosCurrent1;
                        touchPosPrev2 = touchPosCurrent2;
                        touchPosCurrent1 = Input.GetTouch(0).position;
                        touchPosCurrent2 = Input.GetTouch(1).position;

                        Vector3 prevDir = touchPosPrev2 - touchPosPrev1;
                        Vector3 currentDir = touchPosCurrent2 - touchPosCurrent1;

                        float angle = Vector3.SignedAngle(currentDir, prevDir, Vector3.forward);

                        if (angle > 1f || angle < -1f)
                        {
                            objectToZoom.transform.Rotate(0, 0, -angle);
                        }
                        else
                        {
                            if (Vector3.Distance(touchPosCurrent1, touchPosCurrent2) > Vector3.Distance(touchPosPrev1, touchPosPrev2))
                            {
                                objectToZoom.transform.localScale = new Vector3(objectToZoom.transform.localScale.x + 0.5f, objectToZoom.transform.localScale.y + 0.5f, objectToZoom.transform.localScale.z + 0.5f);
                            }
                            else if (Vector3.Distance(touchPosCurrent1, touchPosCurrent2) < Vector3.Distance(touchPosPrev1, touchPosPrev2) && objectToZoom.transform.localScale.x >= 0.01)
                            {
                                objectToZoom.transform.localScale = new Vector3(objectToZoom.transform.localScale.x - 0.5f, objectToZoom.transform.localScale.y - 0.5f, objectToZoom.transform.localScale.z - 0.5f);
                            }
                        }
                    }
                }
            }
            i++;
        }
    }
    GameObject GrabObject(Vector3 position)
    {
        RaycastHit hit;

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
}
