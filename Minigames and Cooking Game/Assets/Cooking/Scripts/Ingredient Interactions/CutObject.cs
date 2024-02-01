using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutObject : MonoBehaviour
{
    public List<Collider> colliders = new();

    public Camera cam;

    public GameObject objToCut;

    protected int maxIndex = 1;
    protected int currentIndex = 0;
    protected int nextIndex;

    protected List<TouchLocation> touches = new();

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
                Began(t);
            }
            else if (t.phase == UnityEngine.TouchPhase.Ended)
            {
                if (touches.Count > 0)
                {
                    Ended(t);
                }
            }
            else if (t.phase == UnityEngine.TouchPhase.Moved)
            {
                if (touches.Count > 0)
                {
                    Collider col = CheckForCollider(t.position);
                    if (colliders.IndexOf(col) == nextIndex)
                    {
                        objToCut.GetComponent<CuttableObject>().CutObject();
                        nextIndex++;
                        if (nextIndex == 2)
                        {
                            nextIndex = 0;
                        }
                        Debug.Log(nextIndex);
                    }
                }
            }
            i++;
        }
        
    }

    protected Collider CheckForCollider(Vector3 position)
    {
        RaycastHit hit;

        if (Physics.Raycast(cam.ScreenToWorldPoint(position), transform.forward, out hit, 50))
        {
            if (hit.collider.CompareTag("trackingPos"))
            {
                return hit.collider;
            }
        }
        return null;
    }

    public virtual void Began(Touch t)
    {
        touches.Add(new TouchLocation(t.fingerId));
        Collider col = CheckForCollider(t.position);
        if (col != null)
        {
            currentIndex = colliders.IndexOf(col);
            if (currentIndex != maxIndex)
            {
                nextIndex = currentIndex + 1;
            }
            else
            {
                nextIndex = 0;
            }
            
        }
    }

    public virtual void Ended(Touch t)
    {
        TouchLocation thisTouch = touches.Find(TouchLocation => TouchLocation.touchId == t.fingerId);
        if (thisTouch != null)
        {
            touches.RemoveAt(touches.IndexOf(thisTouch));
        }
    }
}
