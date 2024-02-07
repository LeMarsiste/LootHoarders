using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordKeeper : MonoBehaviour
{
    public static RecordKeeper Instance { get; private set; }


    [Header("Global Game Settings")]
    public List<CharacterScriptableObject> AvailableCharacters = new List<CharacterScriptableObject>();


    #region Unity Callbacks
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(Instance);
            Instance = this;
        }
        DontDestroyOnLoad(this);
        if (!PlayerPrefs.HasKey("Player_Character"))
            PlayerPrefs.SetInt("Player_Character", 0);
    }
    #endregion
}
