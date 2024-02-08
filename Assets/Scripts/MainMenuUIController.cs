using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUIController : MonoBehaviour
{
    public Image CharacterSprite;

    #region Unity Callbacks
    private void Awake()
    {
        int characterIndex = PlayerPrefs.GetInt("Player_Character");
        CharacterScriptableObject characterData = RecordKeeper.Instance.AvailableCharacters[characterIndex];
        CharacterSprite.sprite = characterData.CharacterImage;

    }
    #endregion
}
