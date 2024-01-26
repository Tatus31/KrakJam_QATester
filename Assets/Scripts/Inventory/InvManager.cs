using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvManager : MonoBehaviour
{
    public static Dictionary<string, int> Inv;
    public static string SelectedItem;

    // Start is called before the first frame update
    void Start()
    {
        //Set default inventory items
        Inv = new()
        {
            { "DoorFix", 1 },
            { "HoleFix", 1 },
            { "Barrier", 2 }
        };
        SelectedItem = null;
    }
}
