using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public int decks;
    public List<Card> cards;

    void Awake()
    {
        for (int a = 0; a < decks; a++)
        {
            for (int i = 0; i < 13; i++)
            {
                cards.Add(new Card("Club", i + 1));
            }
            for (int i = 0; i < 13; i++)
            {
                cards.Add(new Card("Spade", i + 1));
            }
            for (int i = 0; i < 13; i++)
            {
                cards.Add(new Card("Diamond", i + 1));
            }
            for (int i = 0; i < 13; i++)
            {
                cards.Add(new Card("Heart", i + 1));
            }
            cards.Add(new Card(null, 0));
            cards.Add(new Card(null, 0));
        }
        ShuffleDeck();
    }

    void ShuffleDeck()
    {
        List<Card> deckCopy = cards;
        List<Card> shuffledDeck = new();

        while (deckCopy.Count > 0)
        {
            int cardToAdd = Random.Range(0, deckCopy.Count);
            shuffledDeck.Add(deckCopy[cardToAdd]);
            deckCopy.RemoveAt(cardToAdd);
        }
        cards = shuffledDeck;
    }
}
