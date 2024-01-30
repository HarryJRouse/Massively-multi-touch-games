using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadCardMatch : MonoBehaviour
{
    ScoreManager sm;

    void Start()
    {
        sm = FindObjectOfType<ScoreManager>();
    }

    public void TwoPlayers()
    {
        SceneManager.LoadScene(1);
        sm.players = 2;
        sm.SetPlayerScores();
    }

    public void ThreePlayers()
    {
        SceneManager.LoadScene(1);
        sm.players = 3;
        sm.SetPlayerScores();
    }

    public void FourPlayers()
    {
        SceneManager.LoadScene(1);
        sm.players = 4;
        sm.SetPlayerScores();
    }

    public void FivePlayers()
    {
        SceneManager.LoadScene(1);
        sm.players = 5;
        sm.SetPlayerScores();
    }

    public void SixPlayers()
    {
        SceneManager.LoadScene(1);
        sm.players = 6;
        sm.SetPlayerScores();
    }

    public void SevenPlayers()
    {
        SceneManager.LoadScene(1);
        sm.players = 7;
        sm.SetPlayerScores();
    }

    public void EightPlayers()
    {
        SceneManager.LoadScene(1);
        sm.players = 8;
        sm.SetPlayerScores();
    }
}
