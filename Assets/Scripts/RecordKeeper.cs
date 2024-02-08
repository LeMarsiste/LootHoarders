using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordKeeper : MonoBehaviour
{
    public static RecordKeeper Instance { get; private set; }


    [Header("Global Game Settings")]
    public List<CharacterScriptableObject> AvailableCharacters = new List<CharacterScriptableObject>();
    [SerializeField] private AbilitiesScriptableObject AbilitiesConfig;
    [HideInInspector] public Dictionary<Ability,AbilityData> Abilities = new Dictionary<Ability, AbilityData>();

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

        InitializeAbilities();

    }
    #endregion

    #region Public Methods
    public void InitializeAbilities()
    {
        foreach (AbilityData data in AbilitiesConfig.AbilitiesInfo)
            Abilities[data.Ability] = data;
    }

    #endregion
}
