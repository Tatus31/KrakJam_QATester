using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugBase : MonoBehaviour
{
    public bool isFixed = false;
    public bool isBlocked = false;
    [SerializeField] public List<InvItem> AcceptedItems;
}
