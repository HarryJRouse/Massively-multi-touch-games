using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabZoomRotate : MonoBehaviour
{
    public Camera cam1;
    public float zPos = 10;
    public float zoomScale;


    public Dictionary<int, TouchLocationGrab> touches = new();
    public Dictionary<GameObject, List<int>> objectTouches = new();
    public Dictionary<GameObject, TouchPositions> touchPositions = new();

    public struct TouchPositions
    {
        public Vector3 touchPosCurrent1;
        public Vector3 touchPosCurrent2;
        public Vector3 touchPosPrev1;
        public Vector3 touchPosPrev2;
    }

    void Update()
    {
        int i = 0;

        if (touches != null && Input.touchCount == 0)
        {
            touches.Clear();
            objectTouches.Clear();
            touchPositions.Clear();
        }

        while (i < Input.touchCount)
        {
            Touch t = Input.GetTouch(i);
            if (t.phase == UnityEngine.TouchPhase.Began)
            {
                GameObject obj = GrabObject(t.position);
                touches.Add(t.fingerId, new TouchLocationGrab(t.fingerId, obj));
                if (obj != null)
                {
                    if (objectTouches.ContainsKey(obj))
                    {
                        objectTouches[obj].Add(t.fingerId);
                        TouchPositions tp = touchPositions[obj];
                        tp.touchPosCurrent2 = cam1.ScreenToWorldPoint(new Vector3(t.position.x, t.position.y, zPos));
                        tp.touchPosPrev2 = cam1.ScreenToWorldPoint(new Vector3(t.position.x, t.position.y, zPos));
                        touchPositions[obj] = tp;
                    }
                    else
                    {
                        objectTouches.Add(obj, new());
                        objectTouches[obj].Add(t.fingerId);
                        touchPositions.Add(obj, new());
                        TouchPositions tp = touchPositions[obj];
                        tp.touchPosCurrent1 = cam1.ScreenToWorldPoint(new Vector3(t.position.x, t.position.y, zPos));
                        tp.touchPosPrev1 = cam1.ScreenToWorldPoint(new Vector3(t.position.x, t.position.y, zPos));
                        touchPositions[obj] = tp;
                    }
                    if (obj.GetComponent<DualPuzzlePiece>() != null)
                    {
                        obj.GetComponent<DualPuzzlePiece>().pieceHeld = true;
                    }
                }
            }
            else if (t.phase == UnityEngine.TouchPhase.Ended)
            {
                if (touches.Count > 0)
                {
                    TouchLocationGrab thisTouch = touches[t.fingerId];
                    if (thisTouch.myObject != null)
                    {
                        if (objectTouches[thisTouch.myObject].Contains(t.fingerId))
                        {
                            objectTouches[thisTouch.myObject].Remove(t.fingerId);
                        }
                        if (thisTouch.myObject.GetComponent<DualPuzzlePiece>() != null)
                        {
                            thisTouch.myObject.GetComponent<DualPuzzlePiece>().pieceHeld = false;
                        }
                    }
                    touches.Remove(t.fingerId);
                }
            }
            else if (t.phase == UnityEngine.TouchPhase.Moved)
            {
                if (touches.Count > 0)
                {
                    TouchLocationGrab thisTouch = touches[t.fingerId];
                    if (thisTouch.myObject != null && objectTouches[thisTouch.myObject].Count == 1)
                    {
                        if (thisTouch.myObject.CompareTag("grabbable1"))
                        {
                            thisTouch.myObject.transform.position = cam1.ScreenToWorldPoint(new Vector3(t.position.x, t.position.y, zPos));
                        }
                    }
                    if (thisTouch.myObject != null && objectTouches[thisTouch.myObject].Count == 2)
                    {
                        try
                        {
                            TouchPositions tp = touchPositions[thisTouch.myObject];
                            tp.touchPosPrev1 = tp.touchPosCurrent1;
                            tp.touchPosPrev2 = tp.touchPosCurrent2;
                            tp.touchPosCurrent1 = Input.GetTouch(objectTouches[thisTouch.myObject][0]).position;
                            tp.touchPosCurrent2 = Input.GetTouch(objectTouches[thisTouch.myObject][1]).position;

                            Vector3 prevDir = tp.touchPosPrev2 - tp.touchPosPrev1;
                            Vector3 currentDir = tp.touchPosCurrent2 - tp.touchPosCurrent1;

                            float angle = Vector3.SignedAngle(currentDir, prevDir, Vector3.forward);

                            if ((angle > 0.5f && angle < 10) || (angle < -0.5f && angle > -10))
                            {
                                thisTouch.myObject.transform.Rotate(0, 0, -angle);
                            }
                            else
                            {
                                if (Vector3.Distance(tp.touchPosCurrent1, tp.touchPosCurrent2) > Vector3.Distance(tp.touchPosPrev1, tp.touchPosPrev2))
                                {
                                    thisTouch.myObject.transform.localScale = new Vector3(thisTouch.myObject.transform.localScale.x * (1 + zoomScale), thisTouch.myObject.transform.localScale.y * (1 + zoomScale), thisTouch.myObject.transform.localScale.z * (1 + zoomScale));
                                }
                                else if (Vector3.Distance(tp.touchPosCurrent1, tp.touchPosCurrent2) < Vector3.Distance(tp.touchPosPrev1, tp.touchPosPrev2) && thisTouch.myObject.transform.localScale.x >= 0.01)
                                {
                                    thisTouch.myObject.transform.localScale = new Vector3(thisTouch.myObject.transform.localScale.x / (1 + zoomScale), thisTouch.myObject.transform.localScale.y / (1 + zoomScale), thisTouch.myObject.transform.localScale.z / (1 + zoomScale));
                                }
                            }
                            touchPositions[thisTouch.myObject] = tp;
                        }
                        catch
                        {

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
