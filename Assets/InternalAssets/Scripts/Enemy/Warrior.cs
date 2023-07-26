using System;

public class Warrior : AEnemy
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
