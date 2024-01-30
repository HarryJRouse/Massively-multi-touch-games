using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    public List<string> ingredientsOnPlate = new();

    public void SetDishState(string state)
    {
        GameObject foundState = transform.Find(state).gameObject;

        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }

        if (foundState != null)
        {
            foundState.SetActive(true);
        }
        else
        {
            transform.Find("Spoiled").gameObject.SetActive(true);
        }
    }

    public void ResetDish()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
        transform.Find("Plate").gameObject.SetActive(true);
        ingredientsOnPlate.Clear();
    }
}
