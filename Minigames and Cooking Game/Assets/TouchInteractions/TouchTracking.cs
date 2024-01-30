using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TouchTracking : MonoBehaviour
{
    public List<Collider> collidersP1 = new();
    public List<Collider> collidersP2 = new();

    public Camera cam1;
    public Camera cam2;

    public ParticleSystem particle;

    protected int maxIndexP1;
    protected int currentIndexP1 = 0;
    protected int nextIndexP1;

    protected int maxIndexP2;
    protected int currentIndexP2 = 0;
    protected int nextIndexP2;

    protected List<TouchLocation> touches = new();

    ModeStart ms;

    public virtual void Start()
    {
        ms = FindObjectOfType<ModeStart>();

        maxIndexP1 = collidersP1.Count - 1;
        maxIndexP2 = collidersP2.Count - 1;
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
                        if (CheckScreenSide(t.position) == 1)
                        {
                            Instantiate(particle, new Vector3(cam1.ScreenToWorldPoint(t.position).x, cam1.ScreenToWorldPoint(t.position).y, -5), Quaternion.identity);
                        }
                        if (CheckScreenSide(t.position) == 2)
                        {
                            Instantiate(particle, new Vector3(cam2.ScreenToWorldPoint(t.position).x, cam1.ScreenToWorldPoint(t.position).y, -5), Quaternion.identity);
                        }
                        particle.Play();
                        DoThing(t);
                    }
                }
                i++;
            }
        }
    }

    protected Collider CheckForCollider(Vector3 position)
    {
        RaycastHit hit;
        if (position.x < Screen.width / 2)
        {
            if (Physics.Raycast(cam1.ScreenToWorldPoint(position), transform.forward, out hit, 50))
            {
                if (hit.collider.CompareTag("trackingPos"))
                {
                    return hit.collider;
                }
            }

        }
        else
        {
            if (Physics.Raycast(cam2.ScreenToWorldPoint(position), transform.forward, out hit, 50))
            {
                if (hit.collider.CompareTag("trackingPos"))
                {
                    return hit.collider;
                }
            }
        }
        return null;
    }

    protected int CheckScreenSide(Vector3 position)
    {
        RaycastHit hit;
        if (position.x < Screen.width / 2)
        {
            if (Physics.Raycast(cam1.ScreenToWorldPoint(position), transform.forward, out hit, 50))
            {
                return 1;
            }

        }
        else
        {
            if (Physics.Raycast(cam2.ScreenToWorldPoint(position), transform.forward, out hit, 50))
            {
                return 2;
            }
        }
        return 0;
    }

    public virtual void Began(Touch t)
    {
        touches.Add(new TouchLocation(t.fingerId));
        Collider col = CheckForCollider(t.position);
        if (col != null)
        {
            if (CheckScreenSide(t.position) == 1)
            {
                currentIndexP1 = collidersP1.IndexOf(col);
                if (currentIndexP1 != maxIndexP1)
                {
                    nextIndexP1 = currentIndexP1 + 1;
                }
                else
                {
                    nextIndexP1 = 0;
                }
            }
            else if (CheckScreenSide(t.position) == 2)
            {
                currentIndexP2 = collidersP2.IndexOf(col);
                if (currentIndexP2 != maxIndexP2)
                {
                    nextIndexP2 = currentIndexP2 + 1;
                }
                else
                {
                    nextIndexP2 = 0;
                }
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
    public abstract void DoThing(Touch t);
}
