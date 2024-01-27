using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public void GameOverReference()
    {
        SceneManager.LoadScene("GameOverScene");
    }
    public void OnClick()
    {
        if (isFixed)
        {
            Debug.Log("Unfixing");
            isFixed = false;
            InvManager.itemQueue.Add(fixingItem);
            Invoke("RetrieveItemReference", 3);
            PathfinderTargetManager.onTargetUpdate?.Invoke();
        }
        else if (isBlocked)
        {
            Debug.Log("Unblocking");
            isBlocked = false;
            InvManager.itemQueue.Add(blockingItem);
            Invoke("RetrieveItemReference", 3);
            PathfinderTargetManager.onTargetUpdate?.Invoke();
        }
        else if (InvManager.selectedItem == fixingItem)
        {
            if (InvManager.TryToUseSelectedItem())
            {
                Debug.Log("Fixing");
                isFixed = true;
                InvManager.RemoveItems(fixingItem);
                PathfinderTargetManager.onTargetUpdate?.Invoke();
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
                PathfinderTargetManager.onTargetUpdate?.Invoke();
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
