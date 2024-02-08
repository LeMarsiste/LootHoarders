using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AbilityConfig", menuName = "ScriptableObjects/AbilitiesConfigObject", order = 1)]
public class AbilitiesScriptableObject : ScriptableObject
{
    public List<AbilityData> AbilitiesInfo;
}
[System.Serializable]
public class AbilityData
{
    public Ability Ability;
    public Sprite AbilityImage;
    public string AbilityName;
}