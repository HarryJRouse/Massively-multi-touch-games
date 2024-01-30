using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCards : MonoBehaviour
{
    public List<GameObject> cards = new();
    void Start()
    {
        foreach (GameObject card in cards)
        {
            for (int i = 0; i < 2; i++)
            {
                Vector2 randomPosition = new Vector2(Random.Range(-8f, 8f), Random.Range(-3.5f, 3.5f));
                while (Physics2D.OverlapBox(randomPosition, new Vector2(1, 1.5f), 0))
                {
                    randomPosition = new Vector2(Random.Range(-8f, 8f), Random.Range(-3.5f, 3.5f));
                }
                Instantiate(card, randomPosition, Quaternion.identity);
            }
        }
    }
}
