using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class GroundMoveSrategy : IMoveStrategy
{
    private List<Transform> waypoints;
    private int currentWaypointIndex = 0;
    private Transform targetPose;

    public GroundMoveSrategy(List<Transform> Waypoints)
    {
        waypoints = Waypoints;
    }
    
    public void Move(List<Transform> wayPoints, AIPath agent)
    {
        if (agent.reachedDestination)
        {
            currentWaypointIndex++;
        }

        if (currentWaypointIndex >= wayPoints.Count)
        {
            LastPointAchived(agent);
        }
        targetPose = agent.GetComponent<AEnemy>().wayPoints[currentWaypointIndex];
        agent.destination = targetPose.position;
    }

    public void LastPointAchived(AIPath agent)
    {
        agent.isStopped = true;
    }
}
