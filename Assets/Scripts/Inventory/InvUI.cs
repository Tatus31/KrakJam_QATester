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

    public void UpdateCount(GameObject ItemUI, int newCount)
    {
        TextMeshPro textField = ItemUI.GetComponentInChildren<TextMeshPro>();
        textField.text = $"{newCount}/{textField.text.Split("/")[1]}";
    }
}
