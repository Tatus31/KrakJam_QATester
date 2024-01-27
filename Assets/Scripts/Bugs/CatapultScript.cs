using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CatapultScript : BugBase
{

    [SerializeField]
    private Rigidbody playerRB;
    private Transform player;

    private Vector3 catapultDirection;
    private Vector3 catapultSpeedMultiplier = new Vector3(25f, 25f, 25f);
    private Vector3 catapultOffset = new Vector3(50f, 50f, 50f);
    [SerializeField]
    Camera cam;

    private void Start()
    {
        playerRB = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {

        //if (playerRB.transform.position.y >= playerDeletePosition.y)
        //{
        //    player.transform.gameObject.SetActive(false);
        //}
    }

    private void OnCatapultEnter()
    {
        catapultDirection = cam.transform.position;
        Debug.Log("x" + catapultDirection.x + "y" + catapultDirection.y + "z" + catapultDirection.z);
        Vector3 finalCatapultDir = new Vector3(catapultDirection.x + catapultOffset.x * catapultSpeedMultiplier.x
            , catapultDirection.y * catapultSpeedMultiplier.y
            , -catapultDirection.z + -catapultOffset.z * catapultSpeedMultiplier.z);

        playerRB.AddForce(finalCatapultDir, ForceMode.Acceleration);
        //for (int i = 0; i <= 2; i++)
        //{
        //    catapultDirection[i] += Mathf.Lerp(playerRB.transform.position[i], catapultDirection[i], catapultSpeedMultiplier[i]);
        //}
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            OnCatapultEnter();
        }
    }
}
