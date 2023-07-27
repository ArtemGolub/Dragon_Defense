using System;
using UnityEngine;

public class Tower : ATower
{
    private void Awake()
    {
        TowerInit();
    }

    public override void Attack(Transform target)
    {
        if (attackStrategy == null) return;
        attackStrategy.Attack(target, this);
    }
}
