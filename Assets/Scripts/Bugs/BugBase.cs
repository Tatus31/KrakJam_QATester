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
            InvManager.AddItems(fixingItem);
            EventManager.onUpdateMap.Invoke();
        }
        else if (isBlocked)
        {
            Debug.Log("Unblocking");
            isBlocked = false;
            InvManager.AddItems(blockingItem);
            EventManager.onUpdateMap.Invoke();
        }
        else if (InvManager.SelectedItem == fixingItem)
        {
            if (InvManager.TryToUseSelectedItem())
            {
                Debug.Log("Fixing");
                isFixed = true;
                InvManager.RemoveItems(fixingItem);
                EventManager.onUpdateMap.Invoke();
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
                InvManager.RemoveItems(blockingItem);
                EventManager.onUpdateMap.Invoke();
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
