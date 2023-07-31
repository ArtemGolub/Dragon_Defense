using StateManager;
using UnityEngine;

public class Tower_Shoot: State
{

    private Transform target;
    private Tower_SM sm;
    private Tower_Idle idle;
    private Tower tower;
    
    public Tower_Shoot(Tower_SM Sm, Tower_Idle Idle)
    {
        sm = Sm;
        idle = Idle;
        tower = sm.GetComponent<Tower>();
    }

    public void SetTarget(Transform Target)
    {
        target = Target;
    }
    
    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        if (target == null)
        {
            sm._SM.ChangeState(idle);
        }

        Shooting();

    }
    
    private void Shooting()
    {
        if (target == null) return;

        if (tower.FireCountdown <= 0)
        {
            Shoot();
            tower.FireCountdown = 1f / tower.AttackSpeed;
        }

        tower.FireCountdown -= Time.deltaTime;
    }

    private void Shoot()
    {
        var bulletGO = tower.InstantiateBullet();
        IBullet bullet = bulletGO.GetComponent<IBullet>();
        if (bullet != null)
        {
            bullet.Seek(target);
        }
    }
}