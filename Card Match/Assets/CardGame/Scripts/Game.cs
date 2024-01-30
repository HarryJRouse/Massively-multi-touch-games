using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public List<Image> nextCardImage;
    public List<Player> players;
    public Deck deck;
    List<Card> deckOrder;
    SpoonZone[] zones;
    int safeCount;
    SpoonsManager sm;


    void Start()
    {
        sm = FindObjectOfType<SpoonsManager>();
        zones = FindObjectsOfType<SpoonZone>();
        deckOrder = deck.cards;
        DealCards();
    }

    void Update()
    {
        safeCount = 0;
        foreach(SpoonZone zone in zones)
        {
            if (zone.safe)
            {
                safeCount++;
            }
        }
        if (safeCount == zones.Length - 1)
        {
            foreach (SpoonZone zone in zones)
            {
                if (!zone.safe)
                {
                    sm.Strike(zone.GetComponent<SpoonZone>().player);
                }
            }
        }
        foreach (Image image in nextCardImage)
        {
            if (nextCardImage.IndexOf(image) == 0)
            {
                if (deckOrder[0].number < 10 && deckOrder[0].number != 0)
                {
                    image.sprite = Resources.Load<Sprite>("Cards/" + deckOrder[0].suit + "0" + deckOrder[0].number);
                }
                else if (deckOrder[0].number == 0)
                {
                    image.sprite = Resources.Load<Sprite>("Cards/Joker_Color");
                }
                else
                {
                    image.sprite = Resources.Load<Sprite>("Cards/" + deckOrder[0].suit + deckOrder[0].number);
                }
            }
            else
            {
                if (players[nextCardImage.IndexOf(image)].pickUpPile.Count != 0)
                {
                    if (players[nextCardImage.IndexOf(image)].pickUpPile[0].number < 10 && players[nextCardImage.IndexOf(image)].pickUpPile[0].number != 0)
                    {
                        image.sprite = Resources.Load<Sprite>("Cards/" + players[nextCardImage.IndexOf(image)].pickUpPile[0].suit + "0" + players[nextCardImage.IndexOf(image)].pickUpPile[0].number);
                    }
                    else if (players[nextCardImage.IndexOf(image)].pickUpPile[0].number == 0)
                    {
                        image.sprite = Resources.Load<Sprite>("Cards/Joker_Color");
                    }
                    else
                    {
                        image.sprite = Resources.Load<Sprite>("Cards/" + players[nextCardImage.IndexOf(image)].pickUpPile[0].suit + players[nextCardImage.IndexOf(image)].pickUpPile[0].number);
                    }
                }
                else
                {
                    image.sprite = Resources.Load<Sprite>("Cards/BackColor_Black");
                }
            }
        }
    }

    public void DealCards()
    {
        foreach (Player p in players)
        {
            if (players.IndexOf(p) != players.Count - 1)
            {
                for (int i = 0; i < 4; i++)
                {
                    p.hand.Add(deckOrder[0]);
                    deckOrder.RemoveAt(0);
                }
            }
        }
    }

    public void PassCard(Player player, Card card)
    {
        if (players.IndexOf(player) == 0)
        {
            PassCardFromDeck();
        }
        int index = players.IndexOf(player) + 1; ;
        players[index].pickUpPile.Add(card);
        player.pickUpPile.Remove(card);
    }


    public void PassCardFromDeck()
    {
        Card card = deckOrder[0];
        deckOrder.RemoveAt(0);
        players[0].pickUpPile.Add(card);
    }
}
