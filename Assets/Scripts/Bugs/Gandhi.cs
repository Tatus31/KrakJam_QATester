using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gandhi : BugBase
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Invoke("GameOverReference", 3);
            GetComponent<AudioSource>().Play();

        }
    }
}
