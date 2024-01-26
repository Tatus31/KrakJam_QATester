using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class InvUI : MonoBehaviour
{
    [SerializeField] public GameObject ItemA;
    [SerializeField] public GameObject ItemB;
    [SerializeField] public GameObject ItemC;
    [SerializeField] public GameObject SelectedMarker;

    public void UpdateCount()
    {
        TextMeshProUGUI textField = ItemA.GetComponentInChildren<TextMeshProUGUI>();
        textField.text = $"{InvManager.Inv[InvItem.DoorFixCode]}/{textField.text.Split("/")[1]}";

        textField = ItemB.GetComponentInChildren<TextMeshProUGUI>();
        textField.text = $"{InvManager.Inv[InvItem.HoleFixCode]}/{textField.text.Split("/")[1]}";

        textField = ItemC.GetComponentInChildren<TextMeshProUGUI>();
        textField.text = $"{InvManager.Inv[InvItem.BarrierCrates]}/{textField.text.Split("/")[1]}";
    }
    public void ChangeSelected()
    {
        switch (InvManager.SelectedItem)
        {
            case InvItem.DoorFixCode:
                SelectedMarker.GetComponent<RectTransform>().position = ItemA.GetComponent<RectTransform>().position;
                break;
            case InvItem.HoleFixCode:
                SelectedMarker.GetComponent<RectTransform>().position = ItemB.GetComponent<RectTransform>().position;
                break;
            case InvItem.BarrierCrates:
                SelectedMarker.GetComponent<RectTransform>().position = ItemC.GetComponent<RectTransform>().position;
                break;
        }
    }
}
