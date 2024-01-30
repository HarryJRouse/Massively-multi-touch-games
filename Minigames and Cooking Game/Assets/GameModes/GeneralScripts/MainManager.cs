using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;

    public int player1Score = 0;
    public int player2Score = 0;

    public int winner;

    public void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void IncrementScore(int player)
    {
        if (player == 1)
        {
            player1Score += 1;
        }
        if (player == 2)
        {
            player2Score += 1;
        }
    }
}
