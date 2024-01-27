using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : BugBase
{
    private BoxCollider myCollider;

    void Start()
    {
        myCollider = GetComponent<BoxCollider>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != myCollider)
                {
                    if (isFixed)
                    {
                        Debug.Log("Unfixing");
                        isFixed = false;
                        InvManager.AddItems(InvItem.DoorFixCode);
                    }
                    else if (isBlocked)
                    {
                        Debug.Log("Unblocking");
                        isBlocked = false;
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
                                    Debug.Log("Fixing");
                                    isFixed = true;
                                    EventManager.onUpdateMap.Invoke();
                                    break;
                                case InvItem.BarrierCrates:
                                    Debug.Log("Blocking");
                                    isBlocked = true;
                                    //TODO
                                    break;
                            }
                        }
                        else
                        {
                            Debug.Log("Not enough items");
                        }
                    }
                    else
                    {
                        Debug.Log("Incorrect items");
                    }
                }
            }
        }
    }
}
