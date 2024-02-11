using Mirror;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(NetworkIdentity))]
public class PlayerController : NetworkBehaviour
{
    

    #region Private Members
    private Dictionary<CardType, List<Card>> playersHand;
    private List<int> maxPointPerType;
    private int totalPoints;
    #endregion

    #region Unity Callbacks
    public void Start()
    {
        initializeGeneralPlayer();
    }
    #endregion

    #region Public Methods
    /// <summary>
    /// Collects all of the cards on the board and activates the cards "on collect effect"
    /// </summary>
    /// <param name="currentBoard">current State of the board</param>
    public void CollectBoard(List<Card> currentBoard)
    {
        foreach (Card card in currentBoard)
            collectCard(card);

        bool hasKeyCard = currentBoard.Any(card => card.Type == CardType.Key);
        bool hasTreasureCard = currentBoard.Any(card => card.Type == CardType.Treasure);
        
        if (hasKeyCard && hasTreasureCard)
        {
            activateTreasure(currentBoard.Count);
        }
    }
    #region Mirror

    #endregion

    #region Cards Logic
    /// <summary>
    /// Activates the effect of the card
    /// </summary>
    /// <param name="cardData">The Card that should be Activated</param>
    /// <param name="addToBoard">If the Card needs to be added to the board</param>
    public void ActivateCardEffect(Card cardData,bool addToBoard = false)
    {
        switch (cardData.Type)
        {
            case CardType.Coin:

                break;
            case CardType.Key:

                break;
            case CardType.Compass:

                break;
            case CardType.Treasure:

                break;
            case CardType.Hunger:

                break;
            case CardType.Sword:

                break;
            case CardType.Gun:

                break;
            case CardType.Map:

                break;
            case CardType.Save:

                break;
            case CardType.WildCard:

                break;
        }
    }
    
    #endregion

    #endregion

    #region Private Methods
    /// <summary>
    /// Initializes everything related to all players, whether they're on a hosts computer, client or server
    /// </summary>
    private void initializeGeneralPlayer()
    {
        foreach (CardType type in Enum.GetValues(typeof(CardType)))
            playersHand[type] = new List<Card>();
        maxPointPerType = new List<int>(Enum.GetValues(typeof(CardType)).Length);
        totalPoints = 0;
    }

    #region Cards Logic
    /// <summary>
    /// Collects the Card and calculates the highest value of things
    /// </summary>
    /// <param name="cardData"></param>
    private void collectCard(Card cardData)
    {
        playersHand[cardData.Type].Add(cardData);
        int currentMaxPoint = maxPointPerType[(int)cardData.Type];

        if (currentMaxPoint < cardData.PointValue)
        {
            totalPoints += cardData.PointValue - currentMaxPoint;
            maxPointPerType[(int)cardData.Type] = cardData.PointValue;
        }


        //TODO: Add Card Specific Mechanics here! (We don't have any at the moment, maybe future card Ideas?)
    }
    private void activateTreasure(int cardCount)
    {

    }
    #endregion 


    #endregion
}
