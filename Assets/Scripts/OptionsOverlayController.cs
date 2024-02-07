using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionsOverlayController : MonoBehaviour
{
    [Header("Character Selection UI")]
    public Image CharacterImage;
    public TextMeshProUGUI CharacterNameText;

    private int selectedCharacterIndex = 0;

    #region Unity Callbacks
    private void Awake()
    {
        selectedCharacterIndex = PlayerPrefs.GetInt("Player_Character");
        UpdateCharacterIndex(0);
    }

    #endregion

    #region Public Methods

    public void UpdateCharacterIndex(int addedIndex)
    {
        selectedCharacterIndex += addedIndex;
        if (selectedCharacterIndex < 0)
            selectedCharacterIndex += RecordKeeper.Instance.AvailableCharacters.Count;
        selectedCharacterIndex %= RecordKeeper.Instance.AvailableCharacters.Count;
        CharacterImage.sprite = RecordKeeper.Instance.AvailableCharacters[selectedCharacterIndex].CharacterImage;
        CharacterNameText.text = RecordKeeper.Instance.AvailableCharacters[selectedCharacterIndex].CharacterName;
        PlayerPrefs.SetInt("Player_Character", selectedCharacterIndex);
    }
    public void SetMusicValue(float value)
    {

    }
    public void SetAudioValue(float value)
    {

    }
    public void SetMusicState(bool state)
    {

    }
    public void SetAudioState(bool state)
    {

    }
    public void ShareTheGame()
    {

    }
    public void RateUs()
    {

    }
    #endregion
}
