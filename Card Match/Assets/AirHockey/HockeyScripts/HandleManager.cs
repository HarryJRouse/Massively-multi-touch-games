using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandleManager : MonoBehaviour
{
    public GameObject handlePrefab;
    GameObject puck;

    Camera cam;

    Dictionary<int, HandleTouch> touches = new();


    void Awake()
    {
        cam = Camera.main;
        Application.targetFrameRate = 30;
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
            Vector3 tPosition = new Vector3(cam.ScreenToWorldPoint(t.position).x, cam.ScreenToWorldPoint(t.position).y, 10);
            if (t.phase == UnityEngine.TouchPhase.Began)
            {

                GameObject handle = Instantiate(handlePrefab, tPosition, handlePrefab.transform.rotation);

                touches.Add(i, new HandleTouch(i, handle));

                touches[i].velocity = new Vector3(0, 0, 0);

            }
            else if (t.phase == UnityEngine.TouchPhase.Moved)
            {
                if (touches.Count > i)
                {
                    if (touches[i].myObject != null)
                    {
                        touches[i].myObject.transform.position = tPosition;
                        touches[i].velocity = CaluclateVelocity(touches[i], cam.ScreenToWorldPoint(t.position));
                        touches[i].myObject.GetComponent<Handle>().current = touches[i].current;
                        touches[i].myObject.GetComponent<Handle>().velocity = touches[i].velocity;
                    }
                }
            }
            else if (t.phase == UnityEngine.TouchPhase.Ended)
            {
                if (touches[t.fingerId] != null)
                {
                    if (touches[t.fingerId].myObject != null)
                    {
                        Destroy(touches[t.fingerId].myObject);
                    }
                    touches.Remove(t.fingerId);
                }
            }
            i++;
        }
    }
    Vector2 CaluclateVelocity(HandleTouch h, Vector3 touchPos)
    {
        Vector2 hv = h.velocity;
        h.previous = h.current;
        h.current = touchPos;
        h.velocity = (h.current - h.previous) / Time.deltaTime;
        return hv;
    }
}
