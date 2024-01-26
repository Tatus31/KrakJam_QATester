using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class InvManager : MonoBehaviour
{
    public static InvUI invUI;
    public static Dictionary<InvItem, int> Inv;
    public static InvItem SelectedItem;

    // Start is called before the first frame update
    void Start()
    {
        //Set default inventory items
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
    public static bool TryToUseSelectedItem() => TryToUseItem(SelectedItem);
    public static bool TryToUseItem(InvItem requestedItem)
    {
        if (Inv[requestedItem] > 0)
        {
            Inv[requestedItem]--;
            invUI.UpdateCount();
            return true;
        }
        return false;
    }
}
