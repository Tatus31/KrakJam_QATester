using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatapultScript : MonoBehaviour
{

    [SerializeField]
    private Rigidbody playerRB;
    private Transform player;

    private Vector3 catapultDirection;
    private Vector3 catapultSpeedMultiplier = new Vector3(3f, 3f, 3f);

    private Vector3 catapultOffset = new Vector3(5,5,5);

    [SerializeField]
    Camera cam;

    private void Start()
    {
        playerRB = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        Debug.Log(playerRB.transform.position.y);
        //if (playerRB.transform.position.y >= playerDeletePosition.y)
        //{
        //    player.transform.gameObject.SetActive(false);
        //}
    }

    private void OnCatapultEnter()
    {
        catapultDirection = cam.transform.position;
        Vector3 finalCatapultDir = new Vector3(catapultDirection.x * catapultSpeedMultiplier.x
            , catapultDirection.y * catapultSpeedMultiplier.y
            , catapultDirection.z * catapultSpeedMultiplier.z);

        playerRB.AddForce(finalCatapultDir, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            OnCatapultEnter();
        }
    }
}
