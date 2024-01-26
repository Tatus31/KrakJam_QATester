using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvManager : MonoBehaviour
{
    public static Dictionary<InvItem, int> Inv;
    public static string SelectedItem;

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
        SelectedItem = null;
    }

    public static void Clicked(ClickableObject ObjectType)
    {
        switch (ObjectType)
        {
            case ClickableObject.Door:

                break;
            case ClickableObject.Hole:

                break;
            case ClickableObject.Catapult:

                break;
        }
    }
}
