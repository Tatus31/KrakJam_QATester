using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatapultScript : MonoBehaviour
{
    private Vector3 catapultSpeed = new Vector3(0, 75, 25);
    [SerializeField]
    private Rigidbody playerRB;
    private Transform player;
    private Vector3 playerDeletePosition = new Vector3(0, 50, 0);
    private bool isFixed = false;

    private void Start()
    {
        playerRB = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        Debug.Log(playerRB.transform.position.y);
        if (playerRB.transform.position.y >= playerDeletePosition.y)
        {
            player.transform.gameObject.SetActive(false);
        }
    }

    private void OnCatapultEnter()
    {
        playerRB.velocity = new Vector3(playerRB.velocity.x, catapultSpeed.y, catapultSpeed.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            OnCatapultEnter();
        }
    }
}
