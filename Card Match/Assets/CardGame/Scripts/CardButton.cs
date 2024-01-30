using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardButton : MonoBehaviour
{
    public Player player;
    
    Game game;

    void Start()
    {
        game = FindObjectOfType<Game>();
    }
    public void SwapCard()
    {
        if (player.pickUpPile.Count > 0 || game.players.IndexOf(player) == 0)
        {
            player.AddCard(player.hand[int.Parse(this.tag)]);
        }
    }
}
