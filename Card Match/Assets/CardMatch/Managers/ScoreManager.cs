using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public int players;

    public Dictionary<int, int> playerScores = new();
    public List<TextMeshProUGUI> scoreText = new();

    public static ScoreManager Instance;

    public GameObject gameFinishCanvas;

    public int cardAmount;

    public int totalScore = 0;

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

    public void SetPlayerScores()
    {
        playerScores.Clear();
        scoreText.Clear();
        int i = 1;
        while (i <= players)
        {
            playerScores.Add(i, 0);
            i++;
        }
    }

    public void IncrementScore(int player)
    {
        playerScores[player]++;
        scoreText[player - 1].SetText("Score: " + playerScores[player]);
        totalScore++;
        if (totalScore == cardAmount)
        {
            Instantiate(gameFinishCanvas, Vector3.zero, Quaternion.identity);
        }
    }
}
