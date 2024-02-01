using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bin : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<CuttableObject>() != null)
        {
            Destroy(other.gameObject);
            foreach(IngredientStation i in FindObjectsOfType<IngredientStation>())
            {
                i.canGrabIngredient = true;
            }
        }
        if (other.gameObject.GetComponent<Plate>() != null)
        {
            other.gameObject.GetComponent<Plate>().ResetDish();
        }
        else
        {
            Destroy(other.gameObject);
        }
    }
}
