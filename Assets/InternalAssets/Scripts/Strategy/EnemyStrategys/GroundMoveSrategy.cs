using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GroundMoveSrategy : IMoveStrategy
{
    private List<Transform> waypoints;
    private int currentWaypointIndex = 0;

    public GroundMoveSrategy(List<Transform> Waypoints)
    {
        waypoints = Waypoints;
    }
    
    public void Move(List<Transform> wayPoints, NavMeshAgent agent)
    {
        if (currentWaypointIndex >= wayPoints.Count)
        {
            agent.isStopped = true;
            return;
        }

        agent.SetDestination(wayPoints[currentWaypointIndex].transform.position);

        if (agent.remainingDistance <= agent.stoppingDistance && !agent.pathPending)
        {
            currentWaypointIndex++;
            Move(wayPoints, agent);
        }
    }
}
