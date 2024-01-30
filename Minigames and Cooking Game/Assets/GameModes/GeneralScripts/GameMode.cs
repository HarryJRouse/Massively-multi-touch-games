using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameMode : MonoBehaviour
{
    public MyEnum GameModeType = new MyEnum();

    private int modeCount;
    MainManager mm;
    ModeStart ms;

    public int scoreLimit;
    public int timeLimit;

    private float timeRemaining;
    public int player1score;
    public int player2score;

    public TextMeshProUGUI player1Text;
    public TextMeshProUGUI player2Text;

    private void Awake()
    {
        mm = FindObjectOfType<MainManager>();
        ms = FindObjectOfType<ModeStart>();
        modeCount = SceneManager.sceneCountInBuildSettings;
        Application.targetFrameRate = 30;
        if (GameModeType == MyEnum.TimeBased)
        {
            scoreLimit = 0;
            timeRemaining = timeLimit;
        }
        else if (GameModeType == MyEnum.ScoreBased)
        {
            timeLimit = 0;
        }
    }

    void Update()
    {
        if (ms.modeRunning)
        {
            if (timeLimit > 0)
            {
                if (timeRemaining > 0)
                {
                    timeRemaining -= Time.deltaTime;
                }
                else
                {
                    if (player1score > player2score)
                    {
                        ModeEnded(1);
                    }
                    else if (player2score > player1score)
                    {
                        ModeEnded(2);
                    }
                    else
                    {
                        ModeEnded(0);
                    }
                }
            }
        }

        if (scoreLimit > 0)
        {
            if (player1score == scoreLimit)
            {
                ModeEnded(1);
            }
            else if (player2score == scoreLimit)
            {
                ModeEnded(2);
            }
        }
    }

    public void ModeEnded(int player)
    {
        mm.IncrementScore(player);
        if (mm.player1Score == 7)
        {
            mm.player1Score = 0;
            mm.player2Score = 0;
            mm.winner = 1;
            SceneManager.LoadScene(1);
            return;
        }
        if (mm.player2Score == 7)
        {
            mm.player1Score = 0;
            mm.player2Score = 0;
            mm.winner = 2;
            SceneManager.LoadScene(1);
            return;
        }
        int sceneToLoad = Random.Range(2, modeCount - 1);
        while (sceneToLoad == SceneManager.GetActiveScene().buildIndex)
        {
            sceneToLoad = Random.Range(2, modeCount - 1);
        }
        SceneManager.LoadScene(sceneToLoad);
    }

    public void IncrementScore(int player)
    {
        if (player == 1)
        {
            player1score++;
            if (player1Text != null)
            {
                player1Text.SetText(player1score.ToString());
            }
        }
        if (player == 2)
        {
            player2score++;
            if (player2Text != null)
            {
                player2Text.SetText(player2score.ToString());
            }
        }
    }

    public void DecrementScore(int player)
    {
        if (player == 1)
        {
            player1score--;
            if (player1Text != null)
            {
                player1Text.SetText(player1score.ToString());
            }
        }
        if (player == 2)
        {
            player2score--;
            if (player2Text != null)
            {
                player2Text.SetText(player2score.ToString());
            }
        }
    }
}
public enum MyEnum
{
    TimeBased,
    ScoreBased,
    SurvivalBased
};




