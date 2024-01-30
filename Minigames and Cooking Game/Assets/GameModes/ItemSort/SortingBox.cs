using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingBox : MonoBehaviour
{
    public GameObject objectToCollect;
    public int objectsNeeded;
    public int player;

    int objectsCollected = 0;

    GameMode gm;

    void Awake()
    {
        gm = FindObjectOfType<GameMode>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Identifier>().identity == objectToCollect.GetComponent<Identifier>().identity)
        {
            objectsCollected++;
            if (objectsCollected == objectsNeeded)
            {
                gm.IncrementScore(player);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Identifier>().identity == objectToCollect.GetComponent<Identifier>().identity)
        {
            if (objectsCollected == objectsNeeded)
            {
                gm.DecrementScore(player);
            }
            objectsCollected--;
        }
    }
}
