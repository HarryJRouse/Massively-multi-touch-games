using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabIngredient : MonoBehaviour
{
    public Camera cam;

    public Dictionary<int, TouchLocationGrab> touches = new();

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
                touches.Add(t.fingerId, new TouchLocationGrab(t.fingerId, GrabObject(t.position)));
                if (touches[t.fingerId].myObject != null)
                {
                    touches[t.fingerId].myObject.GetComponent<Rigidbody>().useGravity = false;
                }
            }
            else if (t.phase == UnityEngine.TouchPhase.Ended)
            {
                if (touches.Count > 0)
                {
                    if (touches[t.fingerId].myObject != null && touches[t.fingerId].myObject.GetComponent<Rigidbody>() != null)
                    {
                        GameObject obj = touches[t.fingerId].myObject;
                        obj.GetComponent<Rigidbody>().velocity = Vector3.zero;
                        obj.GetComponent<Rigidbody>().useGravity = true;
                        if (obj.GetComponent<CuttableObject>() != null)
                        {
                            foreach (Collider c in obj.GetComponent<CuttableObject>().trackingPos)
                            {
                                c.gameObject.SetActive(true);
                            }
                            Vector3 pos = obj.transform.position;
                            if (pos.x > -1.7 || pos.x < -7.2 || pos.y > -1.5 || pos.y < -4.63 || pos.z > 1)
                            {
                                obj.transform.position = new Vector3(-4.44f, -3.04f, 0);
                            }
                        }
                        else if (obj.GetComponent<Plate>() != null || obj.GetComponent<DirtyDish>() != null)
                        {
                            Vector3 pos = obj.transform.position;
                            if (pos.x < 0)
                            {
                                obj.transform.position = new Vector3(2.5f, -3.22f, pos.z);
                            }
                        }
                    }
                    touches.Remove(t.fingerId);
                }
            }
            else if (t.phase == TouchPhase.Moved)
            {
                if (touches.Count > 0)
                {
                    TouchLocationGrab thisTouch = touches[t.fingerId];
                    if (thisTouch.myObject != null)
                    {
                        thisTouch.myObject.transform.position = cam.ScreenToWorldPoint(new Vector3(t.position.x, t.position.y, 10));
                    }
                }
            }
            i++;
        }
    }

    GameObject GrabObject(Vector3 position)
    {
        RaycastHit hit;

        if (Physics.Raycast(cam.ScreenToWorldPoint(position), transform.forward, out hit, 50))
        {
            if (hit.collider.CompareTag("ingredient"))
            {
                IngredientStation igs = hit.collider.gameObject.GetComponent<IngredientStation>();
                if (igs.canGrabIngredient && igs.cuttingStation)
                {
                    foreach (IngredientStation i in FindObjectsOfType<IngredientStation>())
                    {
                        i.canGrabIngredient = false;
                    }
                    Vector3 spawnPos = new Vector3(cam.ScreenToWorldPoint(position).x, cam.ScreenToWorldPoint(position).y, 10);
                    return Instantiate(igs.ingredient, spawnPos, Quaternion.identity);
                }
                else if(!igs.cuttingStation)
                {
                    Vector3 spawnPos = new Vector3(cam.ScreenToWorldPoint(position).x, cam.ScreenToWorldPoint(position).y, 10);
                    return Instantiate(igs.ingredient, spawnPos, Quaternion.identity);
                }
            }
            else if (hit.collider.CompareTag("grabbable"))
            {
                return hit.collider.gameObject;
            }
        }
        return null;

    }
}
