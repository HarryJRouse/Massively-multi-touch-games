using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HockeyManager : MonoBehaviour
{
    public GameObject puck;
    public TextMeshProUGUI Score1;
    public TextMeshProUGUI Score2;

    public Canvas menu;
    
    int maxScore = 7;

    int player1Score = 0;
    int player2Score = 0;

    public void IncrementScore(int player)
    {
        if (player == 1)
        {
            player1Score++;
        }
        if(player == 2)
        {
            player2Score++;
        }
        Score1.SetText(player1Score + " - " + player2Score);
        Score2.SetText(player2Score + " - " + player1Score);

        if (player1Score == maxScore || player2Score == maxScore)
        {
            NewGameMenu();
            Destroy(GameObject.FindGameObjectWithTag("Puck"));
        }
        else
        {
            SpawnNewPuck(player);
        }

    }

    public void SpawnNewPuck(int player)
    {
        if (player == 1)
        {
            Instantiate(puck, new Vector3(-6, 0, 0), Quaternion.identity);
        }
        else
        {
            Instantiate(puck, new Vector3(6, 0, 0), Quaternion.identity);
        }   

    }

    void Start()
    {
        NewGameMenu();
    }

    void NewGameMenu()
    {
        menu.enabled = true;
    }

    public void NewGame5()
    {
        player1Score = 0;
        player2Score = 0;
        Score1.SetText(player1Score + " - " + player2Score);
        Score2.SetText(player2Score + " - " + player1Score);
        maxScore = 5;
        menu.enabled = false;
        SpawnNewPuck(1);
    }

    public void NewGame11()
    {
        player1Score = 0;
        player2Score = 0;
        Score1.SetText(player1Score + " - " + player2Score);
        Score2.SetText(player2Score + " - " + player1Score);
        maxScore = 11;
        menu.enabled = false;
        SpawnNewPuck(1);
    }

    public void NewGame21()
    {
        player1Score = 0;
        player2Score = 0;
        Score1.SetText(player1Score + " - " + player2Score);
        Score2.SetText(player2Score + " - " + player1Score);
        maxScore = 21;
        menu.enabled = false;
        SpawnNewPuck(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
