using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject players1;
    public GameObject players2;

    ScoreManager sm;

    void Start()
    {
        sm = FindObjectOfType<ScoreManager>();   
    }

    public void PlayHockey()
    {
        SceneManager.LoadScene(1);
    }

    public void CardMatch()
    {
        if (players1.activeInHierarchy == false)
        {
            players1.SetActive(true);
            players2.SetActive(true);
        }
        else
        {
            players1.SetActive(false);
            players2.SetActive(false);
        }
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
        sm.totalScore = 0;
    }

    public void NewGame()
    {
        SceneManager.LoadScene(1);
        sm.totalScore = 0;
        sm.SetPlayerScores();
    }
}
