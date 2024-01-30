using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointDisplayer : MonoBehaviour
{
    public List<GameObject> p1ScoresOff = new();
    public List<GameObject> p2ScoresOff = new();

    public List<GameObject> p1ScoresOn = new();
    public List<GameObject> p2ScoresOn = new();

    MainManager mm;

    void Awake()
    {
        mm = FindObjectOfType<MainManager>();    
    }

    void Start()
    {
        foreach (GameObject i in p1ScoresOn)
        {
            if (p1ScoresOn.IndexOf(i) < mm.player1Score)
            {
                i.SetActive(true);
            }
        }

        foreach (GameObject i in p2ScoresOn)
        {
            if (p2ScoresOn.IndexOf(i) < mm.player2Score)
            {
                i.SetActive(true);
            }
        }
    }
}
