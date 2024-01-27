using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugBase : MonoBehaviour
{
    public bool isFixed = false;
    public bool isBlocked = false;
    [SerializeField] public InvItem fixingItem;
    [SerializeField] public InvItem blockingItem;

    public void OnClick()
    {
        if (isFixed)
        {
            Debug.Log("Unfixing");
            isFixed = false;
            EventManager.onUpdateMap.Invoke();
            InvManager.AddItems(fixingItem);
        }
        else if (isBlocked)
        {
            Debug.Log("Unblocking");
            isBlocked = false;
            EventManager.onUpdateMap.Invoke();
            InvManager.AddItems(blockingItem);
        }
        else if (InvManager.SelectedItem == fixingItem)
        {
            if (InvManager.TryToUseSelectedItem())
            {
                Debug.Log("Fixing");
                isFixed = true;
                EventManager.onUpdateMap.Invoke();
                InvManager.RemoveItems(fixingItem);
            }
            else
            {
                Debug.Log("No item to Fix");
            }
        }
        else if (InvManager.SelectedItem == blockingItem)
        {
            if (InvManager.TryToUseSelectedItem())
            {
                Debug.Log("Blocking");
                isBlocked = true;
                EventManager.onUpdateMap.Invoke();
                InvManager.RemoveItems(blockingItem);
            }
            else
            {
                Debug.Log("No item to Block");
            }
        }
        else
        {
            Debug.Log("Incorrect item");
        }
    }
}
