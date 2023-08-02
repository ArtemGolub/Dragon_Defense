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
    
    // TODO Continue with ENEMYMOVE
    public void Move(List<Transform> wayPoints, AIPath agent)
    {
        Debug.Log(agent.reachedDestination);
        if (agent.reachedDestination)
        {
            currentWaypointIndex++;
        }
        targetPose = agent.GetComponent<AEnemy>().wayPoints[currentWaypointIndex];
        agent.destination = targetPose.position;
    }
}
