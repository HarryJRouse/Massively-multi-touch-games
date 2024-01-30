using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public List<GameObject> playButtons = new();
    public GameObject tutorial;
    public GameObject playButton;


    PlayerSettings ps;

    private void Start()
    {
        ps = FindObjectOfType<PlayerSettings>();
    }

    public void LeftGame()
    {
        ps.playerSide = "left";
        SceneManager.LoadScene(1);
    }
    public void RightGame()
    {
        ps.playerSide = "right";
        SceneManager.LoadScene(1);
    }
    public void UpGame()
    {
        ps.playerSide = "up";
        SceneManager.LoadScene(1);
    }
    public void DownGame()
    {
        ps.playerSide = "down";
        SceneManager.LoadScene(1);
    }

    public void Play()
    {
        foreach (GameObject button in playButtons)
        {
            button.SetActive(true);
        }    
    }

    public void HowToPlay()
    {
        playButton.SetActive(false);
        tutorial.SetActive(true);
    }

    public void Back()
    {
        playButton.SetActive(true);
        tutorial.SetActive(false);
    }
}
