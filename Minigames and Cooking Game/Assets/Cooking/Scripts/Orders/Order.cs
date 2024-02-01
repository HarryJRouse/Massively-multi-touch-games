using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Order : MonoBehaviour
{
    public Image uiImage;
    public Image timer;
    public string order;

    public float timeLimit;

    float timeElapsed;

    OrderManager om;

    private void Start()
    {
        om = FindObjectOfType<OrderManager>();
    }

    void Update()
    {
        if (timeElapsed < timeLimit)
        {
            timeElapsed += Time.deltaTime;
            timer.fillAmount = (timeLimit - timeElapsed) / timeLimit;

        }
        else
        {
            om.MissedOrder();
            om.orders.Remove(gameObject);
            om.UpdateOrders();
            Destroy(gameObject);
        }
    }

}
