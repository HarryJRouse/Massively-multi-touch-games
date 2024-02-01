using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    public GameObject dirtyDish;
    public Transform dirtyDishSpawn;
    public ParticleSystem conveyorFx;

    OrderManager om;

    private void Start()
    {
        om = FindObjectOfType<OrderManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Plate>() != null)
        {
            List<string> ingredients = other.gameObject.GetComponent<Plate>().ingredientsOnPlate;

            int i = 0;
            bool remove = false;
            foreach(GameObject o in om.orders)
            {
                ingredients.Sort();
                string dishCode = "";

                foreach (string ing in ingredients)
                {
                    dishCode += ing;
                    dishCode += "-";
                }

                if (dishCode == o.GetComponent<Order>().order)
                {
                    om.UpdateScore();
                    Destroy(other.gameObject);
                    Destroy(o);
                    Instantiate(dirtyDish, dirtyDishSpawn.position, dirtyDish.transform.rotation);
                    Instantiate(conveyorFx, transform.position, Quaternion.identity);
                    om.score++;
                    om.UpdateScore();
                    remove = true;
                    break;
                }
                i++;
            }
            if (remove)
            {
                om.orders.RemoveAt(i);
                om.UpdateOrders();
            }
        }
    }
}
