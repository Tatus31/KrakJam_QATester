using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class InvUI : MonoBehaviour
{
    [SerializeField] public List<GameObject> itemUIs;
    [SerializeField] public GameObject SelectedMarker;

    public void UpdateCount()
    {
        Debug.Log("Updating item counts in UI");
        TextMeshProUGUI textField;
        List<InvItem> itemNames = new();

        foreach (var item in InvManager.Inv)
        {
            itemNames.Add(item.Key);
        }

        for (int i = 0; i < itemUIs.Count && i < itemNames.Count; i++)
        {
            textField = itemUIs[i].GetComponentInChildren<TextMeshProUGUI>();
            textField.text = $"{InvManager.Inv[itemNames[i]]}/{textField.text.Split("/")[1]}";
        }
    }
    public void ChangeSelected()
    {
        switch (InvManager.SelectedItem)
        {
            case InvItem.DoorFixCode:
                SelectedMarker.GetComponent<RectTransform>().position = itemUIs[0].GetComponent<RectTransform>().position;
                break;
            case InvItem.HoleFixCode:
                SelectedMarker.GetComponent<RectTransform>().position = itemUIs[1].GetComponent<RectTransform>().position;
                break;
            case InvItem.BarrierCrates:
                SelectedMarker.GetComponent<RectTransform>().position = itemUIs[2].GetComponent<RectTransform>().position;
                break;
        }
    }
}
