using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Card
{
    public string name;
    public string suit;
    public int number;

    public Card(string mySuit, int myNumber)
    {
        suit = mySuit;
        number = myNumber;
        if (number < 11 && number > 1)
        {
            name = number + " " + suit;
        }
        else if (number == 1)
        {
            name = "Ace " + mySuit;
        }
        else if (number == 11)
        {
            name = "Jack " + mySuit;
        }
        else if (number == 12)
        {
            name = "Queen " + mySuit;
        }
        else if (number == 13)
        {
            name = "King " + mySuit;
        }
        else if (number == 0)
        {
            name = "Joker";
        }
    }
}
