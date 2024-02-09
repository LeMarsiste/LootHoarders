using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGhost : NetworkBehaviour
{
    #region Public Methods

    #region Mirror 
    public override void OnStartAuthority()
    {
        base.OnStartAuthority();
        Cmd_ContactGameManager(RecordKeeper.Instance.Username,
                               PlayerPrefs.GetInt("Player_Character"));
    }

    [Command]
    public void Cmd_ContactGameManager(string playerName, int playerCharacterIndex)
    {
        GameManager.Instance.InitializePlayer(playerName, playerCharacterIndex, gameObject);
    }
    #endregion
    

    #endregion
}
