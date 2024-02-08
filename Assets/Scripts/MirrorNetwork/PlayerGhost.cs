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
    }
    #endregion
    
    #endregion
}
