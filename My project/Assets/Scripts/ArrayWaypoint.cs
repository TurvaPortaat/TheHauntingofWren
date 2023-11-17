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

        // Aseta ensimm�inen reittipiste hahmon kohteeksi
        SetNextWaypoint();
    }

    void Update()
    {
        Debug.Log("Distance to waypoint: " + Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position));

        // Tarkista et�isyys ja k�yt� my�s NavMeshAgentin remainingDistance-tarkistusta
        if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) < 0.5f ||
            agent.remainingDistance < 0.1f)
        {
            SetNextWaypoint();
        }
    }


    void SetNextWaypoint()
    {
        Debug.Log("Setting next waypoint");

        // Tarkista, onko taulukossa enemm�n reittipisteit�
        if (currentWaypointIndex < waypoints.Length - 1)
        {
            // Jos on, siirry seuraavaan reittipisteeseen
            currentWaypointIndex++;
        }
        else
        {
            // Jos ei, palaa ensimm�iseen reittipisteeseen
            currentWaypointIndex = 0;
        }

        // Aseta hahmon kohteeksi uusi reittipiste
        agent.SetDestination(waypoints[currentWaypointIndex].position);
    }
}
