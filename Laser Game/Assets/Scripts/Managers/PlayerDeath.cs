using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    public ParticleSystem particles;
    public GameObject deadMenu;

    GameObject player;
    

    private void Start()
    {
        player = GameObject.Find("KeyboardPlayer");
    }

    public void Dead()
    {
        Instantiate(particles, player.transform.position, particles.transform.rotation);
        Destroy(player);
        deadMenu.SetActive(true);
    }

    public void NewGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void BackToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
