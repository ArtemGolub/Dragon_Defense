using System;
using Unity.VisualScripting;
using UnityEngine;

public class MergedTower : AAttackTower
{
    public Transform target;
    public IAttackStrategy attackStrategy;
    
    public override void OnBuild()
    {
        InitTower();
        InitAttackTower();
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
    

    public void StartUpdatingTarget()
    {
       // attackStrategy.UpdateTarget("Enemy", AttackRange);
    }

    public void BuildMergedTower()
    {
        //BuildingSystem.current.objectToPlace = transform.GetComponent<PlaceableObject>();
        
        //transform.GetComponent<PlaceableObject>().Place();
    }
}
