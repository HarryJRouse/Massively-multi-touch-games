using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class GameOverMenu : MonoBehaviour
{
    public GameObject winBanP1;
    public GameObject winBanP2;
    public GameObject loseBanP1;
    public GameObject loseBanP2;

    MainManager mm;
    void Start()
    {
        mm = FindObjectOfType<MainManager>();

        if (mm.winner == 1)
        {
            winBanP1.SetActive(true);
            loseBanP2.SetActive(true);

        }
        if (mm.winner == 2)
        {
            winBanP2.SetActive(true);
            loseBanP1.SetActive(true);
        }
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
