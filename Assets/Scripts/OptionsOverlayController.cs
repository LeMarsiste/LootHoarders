using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionsOverlayController : MonoBehaviour
{
    [Header("Character Selection UI")]
    [SerializeField] private Image CharacterImage;
    [SerializeField] private TextMeshProUGUI CharacterNameText;
    [SerializeField] private Transform RingsParent;
    [SerializeField] private GameObject RingItemObject;

    private int selectedCharacterIndex = 0;
    private List<GameObject> RingItemObjects = new List<GameObject>();

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

        CharacterScriptableObject characterData = RecordKeeper.Instance.AvailableCharacters[selectedCharacterIndex];
        CharacterImage.sprite = characterData.CharacterImage;
        CharacterNameText.text = characterData.CharacterName;

        if (characterData.PassiveAbilities.Count > RingItemObjects.Count)
        {
            int diff = Mathf.Abs(characterData.PassiveAbilities.Count - RingItemObjects.Count);
            for (int i = 0; i < diff; i++)
            {
                GameObject ringObject = Instantiate(RingItemObject, RingsParent);
                RingItemObjects.Add(ringObject);
            }
        }

        foreach (GameObject ringObject in RingItemObjects)
        {
            bool state = RingItemObjects.IndexOf(ringObject) < characterData.PassiveAbilities.Count;
            ringObject.SetActive(state);
            if (state)
                ringObject.GetComponent<OptionsUIRingItem>().Initialize(
                    RecordKeeper.Instance.Abilities[characterData.PassiveAbilities[RingItemObjects.IndexOf(ringObject)]]);
        }
                
        
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
