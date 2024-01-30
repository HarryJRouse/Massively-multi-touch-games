using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatchCard : MonoBehaviour
{
    public int card;
    public GameObject cardFront;
    public GameObject cardBack;
    public int player;

    MatchManager mm;

    int timeToFlip = 3;
    private float timeRemaining;

    public bool flipped = false;

    void Start()
    {
        mm = FindObjectOfType<MatchManager>();
        FlipCard(false);
        timeRemaining = timeToFlip;
    }

    void Update()
    {
        if (flipped)
        {
            FlipCard(true);
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                mm.cards.Remove(this.gameObject);
                FlipCard(false);
                flipped = false;
                timeRemaining = timeToFlip;
            }
        }
        else
        {
            FlipCard(false);
        }
    }

    void FlipCard(bool facedUp)
    {
        cardBack.SetActive(!facedUp);
        cardFront.SetActive(facedUp);
    }
}
