using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : BugBase
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null)
                {
                    if (isFixed)
                    {
                        isFixed = false;
                        Debug.Log("Unfixing");
                        InvManager.AddItems(InvItem.DoorFixCode);
                    }
                    else if (isBlocked)
                    {
                        isBlocked = false;
                        Debug.Log("Unblocking");
                        InvManager.AddItems(InvItem.BarrierCrates);
                    }
                    else if (AcceptedItems.Contains(InvManager.SelectedItem))
                    {
                        // Check if the item is available
                        if (InvManager.TryToUseSelectedItem())
                        {
                            //Use items
                            switch (InvManager.SelectedItem)
                            {
                                case InvItem.DoorFixCode:
                                    isFixed = true;
                                    Debug.Log("Fixing");
                                    //TODO
                                    break;
                                case InvItem.BarrierCrates:
                                    isBlocked = true;
                                    Debug.Log("Blocking");
                                    //TODO
                                    break;
                            }
                        }
                    }
                }
            }
        }
    }
}
