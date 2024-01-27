using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugBase : MonoBehaviour
{
    public bool isFixed = false;
    public bool isBlocked = false;
    [SerializeField] public InvItem fixingItem;
    [SerializeField] public InvItem blockingItem;

    public void RetrieveItemReference()
    {
        InvManager.RetrieveItem();
    }
    public void OnClick()
    {
        if (isFixed)
        {
            Debug.Log("Unfixing");
            isFixed = false;
            InvManager.itemQueue.Add(fixingItem);
            Invoke("RetrieveItemReference", 3);
            EventManager.onUpdateMap.Invoke();
        }
        else if (isBlocked)
        {
            Debug.Log("Unblocking");
            isBlocked = false;
            InvManager.itemQueue.Add(blockingItem);
            Invoke("RetrieveItemReference", 3);

            EventManager.onUpdateMap?.Invoke();
        }
        else if (InvManager.selectedItem == fixingItem)
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
        else if (InvManager.selectedItem == blockingItem)
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
