using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpoonsManager : MonoBehaviour
{
    public SpoonsManager Instance;
    public int players;

    public List<int> playerStrikes = new();

    public void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        int i = 0;
        while (i < players)
        {
            playerStrikes.Add(3);
            i++;
        }
    }

    public void RemovePlayer(int player)
    {
        playerStrikes.RemoveAt(player);
        players--;
        SceneManager.LoadScene(players - 1);
    }

    public void Strike(int player)
    {
        playerStrikes[player]--;
        if (playerStrikes[player] == 0)
        {
            RemovePlayer(player);
        }
    }
}
