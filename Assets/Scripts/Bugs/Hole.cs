using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : BugBase
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Invoke("GameOverReference", 2);
        }
    }
}
