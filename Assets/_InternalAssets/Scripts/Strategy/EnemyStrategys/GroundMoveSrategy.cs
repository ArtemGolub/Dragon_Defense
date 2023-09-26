using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class GroundMoveSrategy : IMoveStrategy
{
    private List<Transform> waypoints;
    private int currentWaypointIndex = 0;
    private Transform targetPose;
    private bool doOnce;

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
        else
        {
            if (!doOnce && wayPoints[currentWaypointIndex].tag == "GostPoint")
            {
                GostPointsAchived(agent.GetComponent<AEnemy>());
                doOnce = true;
            }
            targetPose = agent.GetComponent<AEnemy>().wayPoints[currentWaypointIndex];
            agent.destination = targetPose.position;
        }
        

    }

    public void LastPointAchived(AIPath agent)
    {
        agent.GetComponent<IEnemy>().Finished();
        agent.isStopped = true;
    }

    public void GostPointsAchived(AEnemy enemy)
    {
        enemy.GetComponent<EnemyInventory>().GetItemFromGost();
    }
}
