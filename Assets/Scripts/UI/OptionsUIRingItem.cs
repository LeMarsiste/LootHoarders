using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionsUIRingItem : MonoBehaviour
{
    [SerializeField] Image AbilityImage;
    [SerializeField] TextMeshProUGUI AbilityName;
    [SerializeField] Button ItemButton;

    string ringDescription;

    public void Initialize(AbilityData abilityData)
    {
        AbilityImage.sprite = abilityData.AbilityImage;
        AbilityName.text = abilityData.AbilityName;

        ItemButton.onClick.RemoveAllListeners();
        ItemButton.onClick.AddListener(() =>
        {
            //TODO: Open Description Pop-up
        });
    }
}
