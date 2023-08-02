using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public interface IMoveStrategy
{
    void Move(List<Transform> wayPoints, AIPath agent);
}
