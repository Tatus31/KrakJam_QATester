using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class AIPlayerController : MonoBehaviour
{
    private PathfinderTargetManager targetManager;
    private NavMeshAgent meshAgent;
    [SerializeField] private Transform currentTarget;

    void Start()
    {
        targetManager = GetComponent<PathfinderTargetManager>();
        meshAgent = GetComponent<NavMeshAgent>();

    }
    void Update()
    {
        currentTarget = targetManager.SetNearestTarget();
        meshAgent.SetDestination(currentTarget.position);


    }
}
