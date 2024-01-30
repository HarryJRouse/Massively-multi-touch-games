using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookableObject : MonoBehaviour
{
    Ingredient ingredient;
    
    public int cookIndex = 0;

    void Start()
    {
        ingredient = gameObject.GetComponent<Ingredient>();   
    }

    public void CookObject()
    {
        if (cookIndex != ingredient.cookStates.Count - 1)
        {
            ingredient.cookStates[cookIndex].SetActive(false);
            ingredient.cookStates[cookIndex + 1].SetActive(true);
            cookIndex++;
        }
        if (cookIndex == ingredient.cookedState)
        {
            ingredient.platable = true;
        }
        else if (cookIndex == ingredient.burntState)
        {
            ingredient.platable = false;
        }
    }
}
