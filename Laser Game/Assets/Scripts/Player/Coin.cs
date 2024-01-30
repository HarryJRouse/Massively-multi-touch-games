using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public ParticleSystem particleFX;

    SpawnObjects so;
    ScoreManager sm;

    void Start()
    {
        so = GameObject.Find("CoinSpawner").GetComponent<SpawnObjects>();
        sm = FindObjectOfType<ScoreManager>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CollectCoin();
        }
    }

    public void CollectCoin()
    {
        Instantiate(particleFX, transform.position, particleFX.transform.rotation);
        so.SpawnObject();
        Coin[] coins = FindObjectsOfType<Coin>();
        if (coins.Length > 2)
        {
            foreach (Coin coin in coins)
            {
                if (coin != coins[0])
                {
                    Destroy(coin.gameObject);
                }
            }
        }
        else
        {
            sm.IncreaseScore(1);
        }
        Destroy(gameObject);
    }
}
