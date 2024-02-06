using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterData", menuName = "ScriptableObjects/CharacterScriptableObject", order = 1)]
public class CharacterScriptableObject : ScriptableObject
{
    public Sprite CharacterImage;
    public string CharacterName;
    public List<Ability> PassiveAbilities;

}
