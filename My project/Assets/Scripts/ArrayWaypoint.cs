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

        // Aseta ensimmäinen reittipiste hahmon kohteeksi
        SetNextWaypoint();
    }

    void Update()
    {
        Debug.Log("Distance to waypoint: " + Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position));

        // Tarkista etäisyys ja käytä myös NavMeshAgentin remainingDistance-tarkistusta
        if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) < 0.5f ||
            agent.remainingDistance < 0.1f)
        {
            SetNextWaypoint();
        }
    }


    void SetNextWaypoint()
    {
        Debug.Log("Setting next waypoint");

        // Tarkista, onko taulukossa enemmän reittipisteitä
        if (currentWaypointIndex < waypoints.Length - 1)
        {
            // Jos on, siirry seuraavaan reittipisteeseen
            currentWaypointIndex++;
        }
        else
        {
            // Jos ei, palaa ensimmäiseen reittipisteeseen
            currentWaypointIndex = 0;
        }

        // Aseta hahmon kohteeksi uusi reittipiste
        agent.SetDestination(waypoints[currentWaypointIndex].position);
    }
}
