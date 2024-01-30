using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MatchManager : MonoBehaviour
{
    Camera cam;
    
    public List<GameObject> cards;
    public Dictionary<int, TouchLocationGrab> touches = new();
    void Start()
    {
        cam = Camera.main;
    }

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
                bool addTouch = true;
                GameObject obj = GrabObject(t.position);

                foreach (TouchLocationGrab value in touches.Values)
                {
                    if (value.myObject == obj)
                    {
                        addTouch = false;
                    }
                }

                if (addTouch)
                {
                    touches.Add(t.fingerId, new TouchLocationGrab(t.fingerId, obj));
                    if (obj != null)
                    {
                        Vector2 touchWorldPos = cam.ScreenToWorldPoint(new Vector3(t.position.x, t.position.y));
                        touches[t.fingerId].offset = new Vector2(obj.transform.position.x - touchWorldPos.x, obj.transform.position.y - touchWorldPos.y);
                        touches[t.fingerId].previousPos = obj.transform.position;
                    }
                }
                else
                {
                    touches.Add(t.fingerId, new TouchLocationGrab(t.fingerId, null));
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

                        thisTouch.previousPos = obj.transform.position;

                        Vector3 touchWorldPos = cam.ScreenToWorldPoint(new Vector3(t.position.x, t.position.y, 10));

                        obj.transform.position = new Vector3(touchWorldPos.x + thisTouch.offset.x, touchWorldPos.y + thisTouch.offset.y, touchWorldPos.z);
                        thisTouch.frame = Time.frameCount;
                    }
                }
            }
            else if (t.phase == UnityEngine.TouchPhase.Ended)
            {
                if (touches.Count > 0)
                {
                    TouchLocationGrab thisTouch = touches[t.fingerId];
                    if (thisTouch.myObject != null && thisTouch.myObject.GetComponent<Rigidbody2D>())
                    {
                        GameObject obj = thisTouch.myObject;
                        Vector3 touchPosWorldPoint = cam.ScreenToWorldPoint(new Vector3(t.position.x, t.position.y, 10));
                        obj.transform.position = new Vector3(touchPosWorldPoint.x + thisTouch.offset.x, touchPosWorldPoint.y + thisTouch.offset.y, touchPosWorldPoint.z);
                        if (Time.frameCount - thisTouch.frame < 38)
                        {
                            obj.GetComponent<Rigidbody2D>().velocity = ((obj.transform.position - thisTouch.previousPos) / Time.deltaTime)/15;
                        }
                        else
                        {
                            obj.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                        }
                    }
                    touches.Remove(t.fingerId);
                }
            }
            i++;
        }
    }

    GameObject GrabObject(Vector2 position)
    {
        Physics2D.queriesHitTriggers = false;
        RaycastHit2D hit = Physics2D.Raycast(cam.ScreenToWorldPoint(position), new Vector2 (0, 0));

        if (hit.collider != null && hit.collider.gameObject.GetComponent<Rigidbody2D>() != null)
        {
            GameObject obj = hit.collider.gameObject;
            obj.GetComponent<MatchCard>().flipped = true;
            return hit.collider.gameObject;
        }
        return null;
    }
}
