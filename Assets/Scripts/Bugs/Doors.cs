using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : BugBase
{
    [SerializeField]
    private Animator animator;


    private void Start()
    {
        animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetBool("IsStuck", true);
            Invoke("GameOverReference", 3);
        }
    }
}
