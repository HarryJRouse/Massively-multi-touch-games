using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSnap : MonoBehaviour
{
    GameObject obj;

    void Update()
    {
        if (obj != null && !obj.GetComponent<SnappableObject>().isGrabbed)
        {
            obj.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -1);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        obj = collision.gameObject;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        obj = null;
    }
}
