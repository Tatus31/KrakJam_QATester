using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class InvManager : MonoBehaviour
{
    public static InvUI invUI;
    public static Dictionary<InvItem, int> inv;
    public static List<InvItem> itemQueue;
    public static InvItem selectedItem;
    void Start()
    {
        InitInventory();
        selectedItem = InvItem.BarrierCrates;
        invUI = GameObject.Find("Inventory").GetComponent<InvUI>();
        itemQueue = new();
    }

    public void InitInventory()
    {
        inv = new()
        {
            { InvItem.DoorFixCode, 1 },
            { InvItem.HoleFixCode, 1 },
            { InvItem.BarrierCrates, 2 }
        };
    }

    public static void AddItems(InvItem itemToAdd)
    {
        inv[itemToAdd]++;
        invUI.UpdateCount();
    }
    public static void RemoveItems(InvItem itemToRemove)
    {
        inv[itemToRemove]--;
        invUI.UpdateCount();
    }
    public static void RetrieveItem()
    {
        Debug.Log("Item Retrieved");
        AddItems(itemQueue[0]);
        itemQueue.RemoveAt(0);
    }
    public static void SetSelectedItem(InvItem newItem)
    {
        selectedItem = newItem;
        invUI.ChangeSelected();
    }
    public static bool TryToUseSelectedItem() => TryToUseItem(selectedItem);
    public static bool TryToUseItem(InvItem requestedItem) => inv[requestedItem] > 0;
}
