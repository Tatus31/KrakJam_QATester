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
        rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
        StartCatapultTimer();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void StartCatapultTimer()
    {
        StartCoroutine(CatapultTimer());
    }

    private IEnumerator CatapultTimer()
    {
        yield return new WaitForSeconds(1f);
        rb.AddForce(Vector3.up * 50f, ForceMode.Impulse);
    }
}
