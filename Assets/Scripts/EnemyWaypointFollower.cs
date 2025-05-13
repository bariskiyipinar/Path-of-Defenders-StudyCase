using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyWaypointFollower : MonoBehaviour
{

    private Transform[] waypoints;
    private int currentWaypointIndex = 0;
    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();

       
        GameObject waypointParent = GameObject.Find("Waypoints");
        waypoints = new Transform[waypointParent.transform.childCount];
        for (int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i] = waypointParent.transform.GetChild(i);
        }

        agent.SetDestination(waypoints[currentWaypointIndex].position);
    }

    private void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.3f)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex < waypoints.Length)
            {
                agent.SetDestination(waypoints[currentWaypointIndex].position);
            }
        }
    }

}
