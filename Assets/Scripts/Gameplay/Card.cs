using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Card : MonoBehaviour
{
    public CardType Type;
    public int PointValue;
    public abstract void Play();
    public virtual void Discard()
    {
        GameManager.Instance.DiscardCard(this);
    }
    
}
