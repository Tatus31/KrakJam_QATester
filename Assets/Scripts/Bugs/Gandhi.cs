using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gandhi : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with a GameObject tagged as "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            // Perform actions specific to collision with the player
            Debug.Log("Collision with the player!");
        }
    }
}
