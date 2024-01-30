using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        int sceneToLoad = Random.Range(2, SceneManager.sceneCountInBuildSettings - 1);
        SceneManager.LoadScene(sceneToLoad);
    }

    public void PlayCooking()
    {
        SceneManager.LoadScene(8);
    }
}
