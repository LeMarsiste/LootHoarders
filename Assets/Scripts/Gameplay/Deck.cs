using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Deck : MonoBehaviour
{
    private Queue<Card> deck = new Queue<Card>();


    #region Public Methods
    /// <summary>
    /// Returns the X cards on the top of the deck WITHOUT removing them from the top
    /// </summary>
    /// <param name="cardCount">The amount of cards at the top of the deck</param>
    /// <returns>The X cards on the top of the deck</returns>
    public List<Card> GetXCardsOnTop(int cardCount)
    {
        List<Card> cardsList = new List<Card>();
        Queue<Card> tempDeck = new Queue<Card>(deck);

        for (int i = 0; i < cardCount && i < deck.Count; i++)
            cardsList.Add(tempDeck.Dequeue());

        return cardsList;
    }

    /// <summary>
    /// Returns the X cards on the top of the deck AND removes them
    /// </summary>
    /// <param name="cardCount">The amount of cards at the top of the deck</param>
    /// <returns>The X cards on the top of the deck</returns>
    public List<Card> RemoveXCardsOnTop(int cardCount)
    {
        List<Card> cardsList = new List<Card>();

        for (int i = 0; i < cardCount && i < deck.Count; i++)
            cardsList.Add(deck.Dequeue());

        return cardsList;
    }

    public void AddCard(Card cardData)
    {
        if (deck.Contains(cardData))
        {
            Debug.Assert(deck.Contains(cardData), "<color=red>The card added to </color>" + name + "<color=red> is a duplicate!</color>");
            return;
        }
        deck.Enqueue(cardData);
    }
    #endregion
}
