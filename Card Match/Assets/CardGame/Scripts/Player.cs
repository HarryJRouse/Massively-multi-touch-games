using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public List<Card> pickUpPile;
    public List<Card> hand;
    public bool realPlayer = true;
    public Image Card1;
    public Image Card2;
    public Image Card3;
    public Image Card4;

    Game game;
    GrabManagement gm;

    void Start()
    {
        game = FindObjectOfType<Game>();
        gm = FindObjectOfType<GrabManagement>();
    }

    void Update()
    {
        if (realPlayer)
        {
            if (hand[0].number < 10 && hand[0].number != 0)
            {
                Card1.sprite = Resources.Load<Sprite>("Cards/" + hand[0].suit + "0" + hand[0].number);
            }
            else if (hand[0].number == 0)
            {
                Card1.sprite = Resources.Load<Sprite>("Cards/Joker_Color");
            }
            else
            {
                Card1.sprite = Resources.Load<Sprite>("Cards/" + hand[0].suit + hand[0].number);
            }
            if (hand[1].number < 10 && hand[1].number !=0)
            {
                Card2.sprite = Resources.Load<Sprite>("Cards/" + hand[1].suit + "0" + hand[1].number);
            }
            else if (hand[1].number == 0)
            {
                Card2.sprite = Resources.Load<Sprite>("Cards/Joker_Color");
            }
            else
            {
                Card2.sprite = Resources.Load<Sprite>("Cards/" + hand[1].suit + hand[1].number);
            }
            if (hand[2].number < 10 && hand[2].number != 0)
            {
                Card3.sprite = Resources.Load<Sprite>("Cards/" + hand[2].suit + "0" + hand[2].number);
            }
            else if (hand[2].number == 0)
            {
                Card3.sprite = Resources.Load<Sprite>("Cards/Joker_Color");
            }
            else
            {
                Card3.sprite = Resources.Load<Sprite>("Cards/" + hand[2].suit + hand[2].number);
            }
            if (hand[3].number < 10 && hand[3].number != 0)
            {
                Card4.sprite = Resources.Load<Sprite>("Cards/" + hand[3].suit + "0" + hand[3].number);
            }
            else if (hand[3].number == 0)
            {
                Card4.sprite = Resources.Load<Sprite>("Cards/Joker_Color");
            }
            else
            {
                Card4.sprite = Resources.Load<Sprite>("Cards/" + hand[3].suit + hand[3].number);
            }
        }
    }

    public void AddCard(Card cardToRemove)
    {
        game.PassCard(this, cardToRemove);
        hand.Remove(cardToRemove);
        hand.Add(pickUpPile[0]);
        pickUpPile.RemoveAt(0);
        if (hand[0].number == hand[1].number && hand[1].number == hand[2].number && hand[2].number == hand[3].number)
        {
            gm.canGrab = true;
        }
    }
}
