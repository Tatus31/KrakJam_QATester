using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;



public class AIPlayerController : MonoBehaviour
{
    private PathfinderTargetManager targetManager;
    private NavMeshAgent meshAgent;
    [SerializeField] private Transform currentTarget;


    private void OnEnable()
    {

    }
    private void OnDisable()
    {

    }
    void Start()
    {
        targetManager = GetComponent<PathfinderTargetManager>();
        meshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //currentTarget = targetManager.UpdateTarget();
        meshAgent.SetDestination(currentTarget.position);


    }

   
}
