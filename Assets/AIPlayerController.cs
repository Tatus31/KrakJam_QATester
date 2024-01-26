using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class AIPlayerController : MonoBehaviour
{
    private NavMeshAgent meshAgent;
    [SerializeField] private Transform cureentTarget;
    void Start()
    {
        meshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        meshAgent.SetDestination(cureentTarget.position);
    }
}
