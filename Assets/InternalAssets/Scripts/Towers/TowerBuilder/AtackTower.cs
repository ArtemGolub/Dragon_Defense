using System;
using Unity.VisualScripting;
using UnityEngine;

public class AtackTower : AAttackTower
{
    public Transform target;
    public Transform model;
    public IAttackStrategy attackStrategy;
    public override void OnBuild()
    {
        model = transform.GetChild(0);
        InitTower();
        InitAttackTower();
        SetAttackStrategy(AttackType);
        InvokeRepeating("StartUpdatingTarget", 0, 0.5f);
    }

    public override void DisableTower()
    {
        SetAttackStrategy(AttackType.NoAttack);
        CancelInvoke("StartUpdatingTarget");
    }

    private void FixedUpdate()
    {
        if(!builded) return;
        if (target != null)
        {
            TargetLook.LookAtNewTarget(transform.GetChild(0), target);
        }
        attackStrategy.Shooting();
    }
    
    private void SetAttackStrategy(AttackType attackType)
    {
        attackStrategy = AttackStrategyFactory.CreateStrategy(attackType, this);
    }
    
    public void StartUpdatingTarget()
    {
        attackStrategy.UpdateTarget("Enemy", AttackRange);
    }
}
