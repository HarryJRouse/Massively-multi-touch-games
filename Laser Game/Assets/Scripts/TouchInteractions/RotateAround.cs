using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour
{
    public float rotateFactor;

    public float minPos;
    public float maxPos;

    public Camera cam;
    public Dictionary<int, TouchLocationRotate> touches = new();

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
                touches.Add(t.fingerId, new TouchLocationRotate(t.fingerId, GrabObject(t.position), t.position));
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
                    TouchLocationRotate thisTouch = touches[t.fingerId];
                    if (thisTouch.myObject != null)
                    {
                        GameObject obj = thisTouch.myObject;
                        
                        RotateObject(obj, t);
                    }
                }
            }
            if (touches.Count > 0)
            {
                if (touches[t.fingerId].myObject != null)
                {
                    GameObject obj = touches[t.fingerId].myObject;
                    obj.GetComponent<CannonController>().Fire();
                }
            }

            i++;

        }
    }

    GameObject GrabObject(Vector2 position)
    {
        Physics2D.queriesHitTriggers = true;
        RaycastHit2D hit = Physics2D.Raycast(cam.ScreenToWorldPoint(position), new Vector2(0, 0));

        if (hit.collider != null && hit.collider.CompareTag("Cannon"))
        {
            return hit.collider.gameObject;
        }
        return null;
    }

    void RotateObject(GameObject obj, Touch t)
    {
        float distance = t.position.x - touches[t.fingerId].previousTouchPos.x;
        touches[t.fingerId].previousTouchPos = t.position;
        float x = obj.transform.position.x - obj.GetComponent<Hinge>().worldPoint.x;

        if (x > minPos && distance < 0)
        {
            obj.transform.RotateAround(obj.GetComponent<Hinge>().point.position, Vector3.forward, -distance * rotateFactor * Time.deltaTime * obj.GetComponent<Hinge>().axis);
            x = obj.transform.position.x - obj.GetComponent<Hinge>().worldPoint.x;
            if (x <= minPos)
            {
                obj.transform.RotateAround(obj.GetComponent<Hinge>().point.position, Vector3.forward, distance * rotateFactor * Time.deltaTime * obj.GetComponent<Hinge>().axis);
            }
        }
        if (x < maxPos && distance > 0)
        {
            obj.transform.RotateAround(obj.GetComponent<Hinge>().point.position, Vector3.forward, -distance * rotateFactor * Time.deltaTime * obj.GetComponent<Hinge>().axis);
            x = obj.transform.position.x - obj.GetComponent<Hinge>().worldPoint.x;
            if (x >= maxPos)
            {
                obj.transform.RotateAround(obj.GetComponent<Hinge>().point.position, Vector3.forward, distance * rotateFactor * Time.deltaTime * obj.GetComponent<Hinge>().axis);
            }
        }
    }
}
