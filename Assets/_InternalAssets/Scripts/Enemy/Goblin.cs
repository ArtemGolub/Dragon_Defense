using System;

public class Goblin : AEnemy
{
    private void Awake()
    {
        UnitInit();
        SetMoveStrategy(new GroundMoveSrategy(wayPoints));
    }
    
    private void Update()
    {
        Move();
    }
}
