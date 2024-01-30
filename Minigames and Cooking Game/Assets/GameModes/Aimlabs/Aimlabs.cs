using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Aimlabs : MonoBehaviour
{
    public Camera cam1;
    public Camera cam2;

    public GameObject target;

    public List<TouchLocation> touches = new List<TouchLocation>();

    bool initialTargetsSpawned = false;
    ModeStart ms;

    void Start()
    {
        ms = FindObjectOfType<ModeStart>();
    }

    void Update()
    {
        if (ms.modeRunning)
        {
            if (!initialTargetsSpawned)
            {
                InitialTargets();
                initialTargetsSpawned = true;
            }

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
                    CheckForTarget(t.position);
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
                i++;
            }
        }
    }

    public void SpawnTarget(int player)
    {
        if (player == 1)
        {
            Vector3 position = new Vector3(Random.Range((cam1.transform.position.x - cam1.orthographicSize + 1), (cam1.transform.position.x)), Random.Range((cam1.transform.position.y - 4), (cam1.transform.position.y + 4)), -6);
            GameObject target1 = Instantiate(target, position, Quaternion.identity);
            target1.GetComponent<Target>().player = 1;
        }
        if (player == 2)
        {
            Vector3 position = new Vector3(Random.Range((cam2.transform.position.x), (cam2.transform.position.x + cam2.orthographicSize) - 1), Random.Range((cam2.transform.position.y - 4), (cam2.transform.position.y + 4)), -6);
            GameObject target2 = Instantiate(target, position, Quaternion.identity);
            target2.GetComponent<Target>().player = 2;
        }
        
    }

    void CheckForTarget(Vector3 position)
    {
        RaycastHit hit;
        if (position.x < Screen.width / 2)
        {
            if (Physics.Raycast(cam1.ScreenToWorldPoint(position), transform.forward, out hit, 50))
            {
                if (hit.collider.CompareTag("target"))
                {
                    Destroy(hit.collider.gameObject);
                    FindObjectOfType<GameMode>().IncrementScore(1);
                    SpawnTarget(1);
                }
            }

        }
        else
        {
            if (Physics.Raycast(cam2.ScreenToWorldPoint(position), transform.forward, out hit, 50))
            {
                if (hit.collider.CompareTag("target"))
                {
                    Destroy(hit.collider.gameObject);
                    FindObjectOfType<GameMode>().IncrementScore(2);
                    SpawnTarget(2);
                }
            }
        }
    }

    void InitialTargets()
    {
        SpawnTarget(1);
        SpawnTarget(1);
        SpawnTarget(1);
        SpawnTarget(2);
        SpawnTarget(2);
        SpawnTarget(2);
    }
}
