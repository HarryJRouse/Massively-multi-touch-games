using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttableObject : MonoBehaviour
{
    public List<Collider> trackingPos = new();

    public int cutIndex = 0;
    Ingredient ingredient;
    void Start()
    {
        FindObjectOfType<CutObject>().colliders = trackingPos;
        FindObjectOfType<CutObject>().objToCut = gameObject;
        ingredient = gameObject.GetComponent<Ingredient>();
        ingredient.cutStates[0].SetActive(true);
    }

    public void CutObject()
    {
        if (cutIndex != ingredient.cutStates.Count - 1)
        {
            ingredient.cutStates[cutIndex].SetActive(false);
            ingredient.cutStates[cutIndex + 1].SetActive(true);
            cutIndex++;
            if (cutIndex == ingredient.cutStates.Count - 1)
            {
                foreach(Collider c in trackingPos)
                {
                    c.gameObject.SetActive(false);
                }
                gameObject.tag = "grabbable";
                FindObjectOfType<CutObject>().colliders.Clear();
                FindObjectOfType<CutObject>().objToCut = null;
                foreach(IngredientStation i in FindObjectsOfType<IngredientStation>())
                {
                    i.canGrabIngredient = true;
                }
                if (ingredient.needsToBeCooked)
                {
                    gameObject.AddComponent<CookableObject>();
                }
                else
                {
                    ingredient.platable = true;
                }
                Destroy(this);
            }
        }
    }
}
