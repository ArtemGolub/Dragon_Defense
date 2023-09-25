using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem : AEnemy
{
    private void Awake()
    {
       // UnitInit();
        SetMoveStrategy(new GroundMoveSrategy(wayPoints));
    }
    
    private void Update()
    {
        Move();
    }
}
