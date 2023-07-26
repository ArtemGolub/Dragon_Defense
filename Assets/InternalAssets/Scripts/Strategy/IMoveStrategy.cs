using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public interface IMoveStrategy
{
    void Move(List<Transform> wayPoints, NavMeshAgent agent);
}
