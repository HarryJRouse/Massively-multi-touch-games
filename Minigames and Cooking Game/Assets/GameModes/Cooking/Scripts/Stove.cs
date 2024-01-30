using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stove : MonoBehaviour
{
    public float maxTime;
    float timePassed = 0;
    bool cooking = false;
    public GameObject objectBeingCooked;

    void Update()
    {
        if (cooking)
        {
            if (timePassed <= objectBeingCooked.GetComponent<Ingredient>().cookTime)
            {
                timePassed += Time.deltaTime;
            }
            else
            {
                objectBeingCooked.GetComponent<CookableObject>().CookObject();
                timePassed = 0;
            }

        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.GetComponent<CookableObject>() != null)
        {
            objectBeingCooked = collider.gameObject;
            cooking = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        cooking = false;
        timePassed = 0;
    }
}
