using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class AsukasLiikkuu : MonoBehaviour
{
    NavMeshAgent agent;

    // Waypoints
    public Transform[] waypoints;
    int currentWaypointIndex = 0;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        SetNextWaypoint();
    }

    void Update()
    {
        Debug.Log("Distance to waypoint: " + Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position));

        if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) < 0.5f ||
            agent.remainingDistance < 0.1f)
        {
            SetNextWaypoint();
        }

        if (agent.pathStatus == NavMeshPathStatus.PathPartial)
        {
            //Jos jotaki on vikana 
            Debug.LogError("NavMesh path is partial.");
        }

    }


    void SetNextWaypoint()
    {
        Debug.Log("Setting next waypoint");

        if (currentWaypointIndex < waypoints.Length - 1)
        {
            currentWaypointIndex++;
        }
        else
        {
            currentWaypointIndex = 0;
        }

        agent.SetDestination(waypoints[currentWaypointIndex].position);
    }
}