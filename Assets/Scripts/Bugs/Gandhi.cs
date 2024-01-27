using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gandhi : BugBase
{
    [SerializeField] private GameObject particleObject;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Invoke("GameOverReference", 2);
            particleObject.SetActive(true);
            GetComponent<AudioSource>().Play();
        }
    }
}
