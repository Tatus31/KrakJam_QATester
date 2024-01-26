using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class InvManager : MonoBehaviour
{
    public static Dictionary<InvItem, int> Inv;
    public static InvItem SelectedItem;

    // Start is called before the first frame update
    void Start()
    {
        //Set default inventory items
        Inv = new()
        {
            { InvItem.DoorFixCode, 1 },
            { InvItem.HoleFixCode, 1 },
            { InvItem.BarrierCrates, 2 }
        };
        SelectedItem = InvItem.BarrierCrates;
    }

    public static bool TryToUseItem(InvItem requestedItem)
    {
        if (Inv[requestedItem] > 0)
        {
            Inv[requestedItem]--;
            return true;
        }
        return false;
    }
}
