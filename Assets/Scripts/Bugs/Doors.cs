using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Doors : BugBase
{
    [SerializeField] private CinemachineVirtualCamera TransitionCamera;
    [SerializeField] private CinemachineVirtualCamera MainCamera;
    void OnCollisionEnter(Collision collision)
    {
        TransitionCamera.Priority = 30;
        if (collision.gameObject.CompareTag("Player"))
        {
            Invoke("GameOverReference", 3);
        }
    }
}
