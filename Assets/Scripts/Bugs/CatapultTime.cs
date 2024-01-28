using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class CatapultTime : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Flying");
        rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
        rb.AddForce(Vector3.up * 50f, ForceMode.Impulse);
    }

}