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

    public void UpdateCount()
    {
        TextMeshProUGUI textField = ItemA.GetComponentInChildren<TextMeshProUGUI>();
        textField.text = $"{InvManager.Inv[InvItem.DoorFixCode]}/{textField.text.Split("/")[1]}";

        textField = ItemB.GetComponentInChildren<TextMeshProUGUI>();
        textField.text = $"{InvManager.Inv[InvItem.HoleFixCode]}/{textField.text.Split("/")[1]}";

        textField = ItemC.GetComponentInChildren<TextMeshProUGUI>();
        textField.text = $"{InvManager.Inv[InvItem.BarrierCrates]}/{textField.text.Split("/")[1]}";
    }
    public void ChangeSelected(GameObject ItemUI)
    {

    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeSelected(ItemA);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeSelected(ItemB);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ChangeSelected(ItemC);
        }
    }
}
