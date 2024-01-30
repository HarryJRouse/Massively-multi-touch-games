using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnAtTouch : MonoBehaviour
{
    public Camera cam1;
    public Camera cam2;

    public GameObject spawnedObject1;
    public GameObject spawnedObject2;

    public List<TouchLocation> touches = new();

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
                SpawnObject(t.position);
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

    void SpawnObject(Vector3 position)
    {
        if (position.x < Screen.width / 2)
        {
            Instantiate(spawnedObject1, cam1.ScreenToWorldPoint(new Vector3(position.x, position.y, 10)), Quaternion.identity);
            FindObjectOfType<GameMode>().IncrementScore(1);
        }
        else
        {
            Instantiate(spawnedObject2, cam2.ScreenToWorldPoint(new Vector3(position.x, position.y, 10)), Quaternion.identity);
            FindObjectOfType<GameMode>().IncrementScore(2);
        }
    }
}
