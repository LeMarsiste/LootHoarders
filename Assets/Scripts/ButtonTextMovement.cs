using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonTextMovement : EventTrigger
{
    public TextMeshProUGUI targetText;

    public void Awake()
    {
        targetText = GetComponentInChildren<TextMeshProUGUI>();
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        Vector3 currentPos = targetText.transform.position;
        targetText.transform.position = new Vector3(currentPos.x, currentPos.y - 20f, currentPos.z);
    }
    public override void OnPointerUp(PointerEventData eventData)
    {
        Vector3 currentPos = targetText.transform.position;
        targetText.transform.position = new Vector3(currentPos.x, currentPos.y + 20f, currentPos.z);
    }
}
