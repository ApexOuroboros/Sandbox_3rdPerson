using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class enemyMovement : MonoBehaviour
{

    NavMeshAgent navMeshAgent;
    GameObject currentWaypoint;
    GameObject previousWaypoint;
    List<GameObject> allWaypoints = new List<GameObject>();
    bool travelling;

    // Start is called before the first frame update
    void Start()
    {
        
        navMeshAgent = GetComponent<NavMeshAgent>();
        allWaypoints = GameObject.FindGameObjectsWithTag("Waypoint").ToList<GameObject>();
        currentWaypoint = GetRandomWaypoint();
        SetDestination();

    }

    // Update is called once per frame
    void Update()
    {
        
        if(travelling && navMeshAgent.remainingDistance <= 1f)
        {
            travelling = false;
            SetDestination();
        }

    }

    void SetDestination()
    {

        previousWaypoint = currentWaypoint;
        currentWaypoint = GetRandomWaypoint();

        Vector3 targetVector = currentWaypoint.transform.position;
        navMeshAgent.SetDestination(targetVector);
        travelling = true;

    }

    GameObject GetRandomWaypoint()
    {

        if(allWaypoints.Count == 0)
        {
            return null;
        }
        else
        {
            int index = Random.Range(0, allWaypoints.Count);
            return allWaypoints[index];
        }

    }

}
