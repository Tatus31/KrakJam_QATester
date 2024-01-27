using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class PathfinderTargetManager : MonoBehaviour
{
    public List<BugBase> listOfBugs { get; private set; }
    private List<float> listOfDistance = new List<float>();

    public delegate void UpdateBugState();
    public static Action onTargetUpdate;
    void Awake()
    {
        listOfBugs = FindAllBugs();
    }
    private void OnEnable()
    {
        onTargetUpdate += UpdateTarget;
    }
    private void OnDisable()
    {
        onTargetUpdate -= UpdateTarget;
    }

    private void UpdateTarget()
    {
        foreach (var bug in listOfBugs)
        {
            if (!bug.isBlocked && !bug.isFixed)
            {
                listOfDistance.Add(Vector3.Distance(bug.transform.position, gameObject.transform.position));
                Debug.Log(Vector3.Distance(bug.transform.position, gameObject.transform.position) + bug.name);
            }
        }
    }

    public Transform SetNearestTarget()
    {
        int currentItemIndex = 0;
        float distance = listOfDistance.Min();
        for (int i = 0; i < listOfBugs.Count; i++)
        {
            if (distance == Vector3.Distance(listOfBugs[i].transform.position, gameObject.transform.position))
            {
                Debug.Log(listOfBugs[i].transform);
                return listOfBugs[i].transform;
            }
        }

        Debug.Log(listOfBugs[currentItemIndex].transform);
        return listOfBugs[currentItemIndex].transform;
    }
    private List<BugBase> FindAllBugs()
    {
        IEnumerable<BugBase> dataPersistances = FindObjectsOfType<MonoBehaviour>().OfType<BugBase>();
        return new List<BugBase>(dataPersistances);
    }
}
