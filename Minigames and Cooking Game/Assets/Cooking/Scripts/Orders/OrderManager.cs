using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class OrderManager : MonoBehaviour
{
    public List<GameObject> orders = new();
    public List<GameObject> possibleOrders = new();

    public List<Transform> points = new();
    public List<GameObject> missedImages = new();

    public int score = 0;
    public int ordersMissed = 0;
    public TextMeshProUGUI scoreText;
    int orderSpeed = 20;

    bool waitingForOrder = false;

    private void Start()
    {
        int order = Random.Range(0, possibleOrders.Count);
        GameObject obj = Instantiate(possibleOrders[order], points[0].position, points[0].rotation);
        obj.transform.SetParent(FindObjectOfType<Canvas>().transform);
        orders.Add(obj);
        UpdateOrders();
    }

    void Update()
    {
        StartCoroutine(NewOrder());
    }

    IEnumerator NewOrder()
    {
        if (orders.Count < 3)
        {
            if (!waitingForOrder)
            {
                waitingForOrder = true;

                yield return new WaitForSeconds(orderSpeed);

                int order = Random.Range(0, possibleOrders.Count);
                GameObject obj = Instantiate(possibleOrders[order], points[0].position, points[0].rotation);
                obj.transform.SetParent(FindObjectOfType<Canvas>().transform);
                orders.Add(obj);
                UpdateOrders();
                waitingForOrder = false;
            }
        }
    }

    public void UpdateOrders()
    {
        foreach (GameObject o in orders)
        {
            o.transform.position = points[orders.IndexOf(o)].position;
        }
    }

    public void UpdateScore()
    {
        scoreText.text = "Score: " + score;
        if (score == 5)
        {
            orderSpeed = 15;
        }
        if (score == 10)
        {
            orderSpeed = 10;
        }
        if (score == 15)
        {
            orderSpeed = 5;
        }
    }

    public void MissedOrder()
    {
        ordersMissed++;
        if (ordersMissed == 3)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            missedImages[ordersMissed - 1].SetActive(true);
        }
    }
}
