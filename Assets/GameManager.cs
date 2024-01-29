using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : NetworkBehaviour
{
    
    public List<LocalConnectionToClient> connections = new List<LocalConnectionToClient>();

    #region Unity Callbacks
    public void Update()
    {

    }
    #endregion

    #region Mirror
    public void Cmd_InitPlayer()
    {

    }
    #endregion

    #region Public Methods
    public void ShuffleTheDeck()
    {

    }

    #endregion


}
