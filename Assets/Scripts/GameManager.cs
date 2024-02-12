using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : NetworkBehaviour
{
    public static GameManager Instance;

    private Deck deck, discardPile;

    private readonly Dictionary<string, NetworkConnectionToClient> connectionByUsername = new Dictionary<string, NetworkConnectionToClient>();


    #region Unity Callbacks
    private void Awake()
    {
        Instance = this;
    }
    public override void OnStartServer()
    {
        base.OnStartServer();
    }
    #endregion


    #region Public Methods

    #region Game Logic
    /// <summary>
    /// Discards the card sent to it
    /// </summary>
    /// <param name="discardedCard">The card to be discarded</param>
    [Server]
    public void DiscardCard(Card discardedCard)
    {
        discardPile.AddCard(discardedCard);
    }
    #endregion

    #region Mirror
    /// <summary>
    /// Initializes the player on the Mirror Network
    /// </summary>
    /// <param name="username"> Username of the player</param>
    /// <param name="characterIndex">Index of the players character on the RecordKeepers List</param>
    /// <param name="ghostObject">The Object which player has authority on AKA Player prefab</param>
    [Server]
    public void InitializePlayer(string username, int characterIndex,GameObject ghostObject)
    {
        connectionByUsername[username] = ghostObject.GetComponent<NetworkIdentity>().connectionToClient;
    }

    #endregion


    #endregion


    #region Private Methods
    public void initializeMainDeck() { 

    }

    #endregion
}
