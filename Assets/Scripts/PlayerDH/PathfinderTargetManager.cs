using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PathfinderTargetManager : MonoBehaviour
{
    public List<BugBase> listOfBugs { get; private set; }
    void Awake()
    {
        listOfBugs = FindAllBugs();
    }


    public Transform UpdateTarget()
    {
        List<float> listOfDistance = new List<float>();
        int currentItemIndex = 0;
        foreach (var item in listOfBugs)
        {
            listOfDistance.Add(Vector3.Distance(item.transform.position, gameObject.transform.position));
            Debug.Log(Vector3.Distance(item.transform.position, gameObject.transform.position) + item.name);
        }

        float distance = listOfDistance.Min();
        for (int i = 0; i < listOfBugs.Count; i++)
        {
            if(distance == Vector3.Distance(listOfBugs[i].transform.position, gameObject.transform.position))
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
