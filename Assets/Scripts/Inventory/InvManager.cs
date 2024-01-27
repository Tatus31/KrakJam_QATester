using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class InvManager : MonoBehaviour
{
    public static InvUI invUI;
    public static Dictionary<InvItem, int> Inv;
    public static InvItem SelectedItem;
    void Start()
    {
        InitInventory();
        SelectedItem = InvItem.BarrierCrates;
        invUI = GameObject.Find("Inventory").GetComponent<InvUI>();
    }

    public void InitInventory()
    {
        Inv = new()
        {
            { InvItem.DoorFixCode, 1 },
            { InvItem.HoleFixCode, 1 },
            { InvItem.BarrierCrates, 2 }
        };
    }

    public static void AddItems(InvItem itemToAdd)
    {
        Inv[itemToAdd]++;
        invUI.UpdateCount();
    }
    public static void RemoveItems(InvItem itemToRemove)
    {
        Inv[itemToRemove]--;
        invUI.UpdateCount();
    }
    public static void SetSelectedItem(InvItem newItem)
    {
        SelectedItem = newItem;
        invUI.ChangeSelected();
    }
    public static bool TryToUseSelectedItem() => TryToUseItem(SelectedItem);
    public static bool TryToUseItem(InvItem requestedItem) => Inv[requestedItem] > 0;
}
