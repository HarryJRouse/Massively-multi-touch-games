using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    public string ingredient;

    public List<GameObject> cutStates = new();
    public List<GameObject> cookStates = new();

    public bool platable = false;
    public bool needsToBeCooked = true;
    public float cookTime;
    public int cookedState;
    public int burntState;

    bool alreadyPlated = false;

    void OnTriggerEnter(Collider collider)
    {
        if (alreadyPlated)
        {
            return;
        }
        if (collider.gameObject.GetComponent<Plate>() != null && platable)
        {
            alreadyPlated = true;
            Plate plate = collider.gameObject.GetComponent<Plate>();

            List<string> ingredientsOnPlate = plate.ingredientsOnPlate;

            bool alreadyAdded = false;
            foreach (string s in ingredientsOnPlate)
            {
                if (s == ingredient)
                {
                    alreadyAdded = true;
                }
            }
            if (!alreadyAdded)
            {
                plate.ingredientsOnPlate.Add(ingredient);
                plate.ingredientsOnPlate.Sort();

                string dishCode = "";

                foreach (string ing in ingredientsOnPlate)
                {
                    dishCode += ing;
                    dishCode += "-";
                }

                plate.SetDishState(dishCode);
                Destroy(gameObject);
            }
        }

    }
}
