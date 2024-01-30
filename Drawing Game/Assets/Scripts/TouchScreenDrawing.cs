using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchScreenDrawing : MonoBehaviour
{
    [SerializeField] Camera cam;
    public LineRenderer trailPrefab;

    public Dictionary<int, TouchLocationDraw> touches = new();


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
                touches.Add(t.fingerId, new TouchLocationDraw());
                CreateNewLine(touches[t.fingerId]);
            }
            else if (t.phase == TouchPhase.Ended)
            {
                if (touches.Count > 0)
                {
                    touches.Remove(t.fingerId);
                }
            }
            else if (t.phase == TouchPhase.Moved)
            {
                AddPoints(t.position, touches[t.fingerId]);
            }    

            i++;
        }
    }

    void CreateNewLine(TouchLocationDraw touch)
    {
        touch.currentTrail = Instantiate(trailPrefab);
        touch.currentTrail.transform.SetParent(transform, true);
        touch.points.Clear();
    }

    void UpdateLinePoints(TouchLocationDraw touch)
    {
        if (touch.currentTrail != null && touch.points.Count > 1)
        {
            touch.currentTrail.positionCount = touch.points.Count;
            touch.currentTrail.SetPositions(touch.points.ToArray());

        }
    }

    void AddPoints(Vector3 touchPos, TouchLocationDraw touch)
    {
        if (touchPos.x < 2200)
        {
            RaycastHit2D hit = Physics2D.Raycast(cam.ScreenToWorldPoint(touchPos), Vector2.zero);

            if (hit && hit.collider.CompareTag("Writeable"))
            {
                touch.points.Add(hit.point);
                UpdateLinePoints(touch);
                return;
            }
            else
            {
                return;
            }
        }
        else
        {
            return;
        }
    }

    public void ClearCanvas()
    {
        if (transform.childCount != 0)
        {
            foreach (Transform r in transform)
            {
                Destroy(r.gameObject);
            }
        }
    }
}
