using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] GameObject playCanvas;

    private void Start()
    {
        Time.timeScale = 0;
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(0);
    }

    public void Play()
    {
        playCanvas.SetActive(false);
        Time.timeScale = 1;
    }
}
