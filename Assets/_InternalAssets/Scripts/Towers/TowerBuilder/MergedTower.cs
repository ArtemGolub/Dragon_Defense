using System;
using Unity.VisualScripting;
using UnityEngine;

public class MergedTower : AAttackTower
{
    public Transform target;
    
    public AttackType type1;
    public AttackType type2;
    
    public IAttackStrategy attackStrategy;
    
    public override void OnBuild()
    {
        InitTower();
        InitAttackTower();
        SetAttackStrategy();
        InvokeRepeating("StartUpdatingTarget", 0, 0.5f);
    }

    public override void DisableTower()
    {
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

    private void SetAttackStrategy()
    {
        attackStrategy = AttackStrategyFactory.CreateMergedStrategy(type1, type2,this);
    }

    public void StartUpdatingTarget()
    {
        attackStrategy.UpdateTarget("Enemy", AttackRange);
    }

    public void BuildMergedTower()
    {
        //BuildingSystem.current.objectToPlace = transform.GetComponent<PlaceableObject>();
        
        //transform.GetComponent<PlaceableObject>().Place();
    }
}
