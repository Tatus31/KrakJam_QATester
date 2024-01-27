using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : BugBase
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Invoke("GameOverReference", 3);
        }
    }
}
