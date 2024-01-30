using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public SpawnMultipleObjects powerUpSpawner;

    int score = 0;

    private void Start()
    {
        powerUpSpawner = GameObject.Find("PowerUpSpawner").GetComponent<SpawnMultipleObjects>();
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        scoreText.text = score.ToString();
        if (score == 15)
        {
            powerUpSpawner.spawnTimeMax = 10;
        }
        else if (score == 30)
        {
            powerUpSpawner.spawnTimeMax = 7;
            powerUpSpawner.spawnTime = 3;
        }
        else if (score == 50)
        {
            powerUpSpawner.spawnTimeMax = 5;
            powerUpSpawner.spawnTime = 1;
        }
    }
}
