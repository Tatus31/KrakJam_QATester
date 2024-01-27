using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    public static Action onUpdateMap;
    public void Start()
    {
        onUpdateMap += EventConfirmation;
    }
    public void EventConfirmation()
    {
        Debug.Log("Event Launched");
    }
}
