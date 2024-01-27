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
        //PathfinderTargetManager.onTargetUpdate += SetCurrentTarget;
    }
    private void OnDisable()
    {

    }
    void Start()
    {
        targetManager = GetComponent<PathfinderTargetManager>();
        meshAgent = GetComponent<NavMeshAgent>();
        PathfinderTargetManager.onTargetUpdate?.Invoke();

    }
    public void SetCurrentTarget(Transform currentTargetPos)
    {
        currentTarget = currentTargetPos;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PathfinderTargetManager.onTargetUpdate?.Invoke();
        }
            //currentTarget = targetManager.SetNearestTarget();
        meshAgent.SetDestination(currentTarget.position);
    }

   
}
