using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Gandhi : BugBase
{
    [SerializeField] private CinemachineVirtualCamera TransitionCamera;
    [SerializeField] private CinemachineVirtualCamera MainCamera;
    [SerializeField] private GameObject particleObject;

    void OnCollisionEnter(Collision collision)
    {
        TransitionCamera.Priority = 30;
        if (collision.gameObject.CompareTag("Player"))
        {
            Invoke("GameOverReference", 2);
            particleObject.SetActive(true);
            GetComponent<AudioSource>().Play();
        }
    }
}
