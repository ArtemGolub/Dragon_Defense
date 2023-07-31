using StateManager;

public class Tower_Idle: State
{
    private Tower tower;
    
    public Tower_Idle(Tower Tower)
    {
        tower = Tower;
    }
    
    public override void Enter()
    {
        tower.UpdateTarget();
    }

    public override void Exit()
    {
        tower.StopUpdateTarget();
    }

    public override void Update()
    {
       // tower.attackStrategy.UpdateTarget("Enemy", tower.AttackRange, tower.transform);
    }
}