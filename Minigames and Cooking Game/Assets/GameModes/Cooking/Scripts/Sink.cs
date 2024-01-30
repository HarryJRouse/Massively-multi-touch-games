using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sink : MonoBehaviour
{
    public GameObject dish;
    public Transform spawnLocation;
    public ParticleSystem waterFx;

    public List<Collider> colliders = new();

    protected List<TouchLocation> touches = new();
    public Camera cam;

    DirtyDish dirtyDish;

    bool canTrigger = true;
    bool enumerating = false;

    public void EmptySink()
    {
        Destroy(dirtyDish.gameObject);
        Instantiate(dish, spawnLocation.position, dish.transform.rotation);
    }

    void OnTriggerEnter(Collider other)
    {
        if (!canTrigger)
        {
            return;
        }
        canTrigger = false;
        if (other.gameObject.GetComponent<DirtyDish>() != null && dirtyDish == null)
        {
            dirtyDish = other.gameObject.GetComponent<DirtyDish>();
        }
        else
        {
            other.gameObject.transform.position = FindObjectOfType<Conveyor>().dirtyDishSpawn.transform.position;
        }
        StartCoroutine(EndFrame());
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
                touches.Add(new TouchLocation(t.fingerId));
                Collider col = CheckForCollider(t.position);
                if (col != null && dirtyDish != null)
                {
                    dirtyDish.WashDish();
                    Instantiate(waterFx, new Vector3(cam.ScreenToWorldPoint(t.position).x, cam.ScreenToWorldPoint(t.position).y, 0.6f), Quaternion.identity); 
                }
            }
            else if (t.phase == UnityEngine.TouchPhase.Ended)
            {
                if (touches.Count > 0)
                {
                    TouchLocation thisTouch = touches.Find(TouchLocation => TouchLocation.touchId == t.fingerId);
                    if (thisTouch != null)
                    {
                        touches.RemoveAt(touches.IndexOf(thisTouch));
                    }
                }
            }
            else if (t.phase == UnityEngine.TouchPhase.Moved)
            {
                if (touches.Count > 0)
                {
                    Collider col = CheckForCollider(t.position);
                    if (col != null && dirtyDish != null)
                    {
                        dirtyDish.WashDish();
                        Instantiate(waterFx, new Vector3(cam.ScreenToWorldPoint(t.position).x, cam.ScreenToWorldPoint(t.position).y, 0.6f), Quaternion.identity);
                    }
                }
            }
            i++;
        }
    }

    Collider CheckForCollider(Vector3 position)
    {
        RaycastHit hit;

        if (Physics.Raycast(cam.ScreenToWorldPoint(position), transform.forward, out hit, 50))
        {
            if (hit.collider.CompareTag("sinkTrack"))
            {
                return hit.collider;
            }
        }
        return null;
    }

    IEnumerator EndFrame()
    {
        if (!enumerating)
        {
            enumerating = true;
            yield return new WaitForSeconds(0.1f);
            canTrigger = true;
            enumerating = false;
        }

    }
}
