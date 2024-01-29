using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    Queue<Card> CurrentPile = new Queue<Card>();

    public Card DrawACard()
    {
        Card TopDeck = CurrentPile.Dequeue();
        return TopDeck;
    }

}
