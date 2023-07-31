using System;
using UnityEngine;

public class Tower : ATower
{
    private void Awake()
    {
        TowerInit();
     //   InvokeRepeating("Attack", 0, 0.5f);
    }

    private void FixedUpdate()
    {
        TryShoot();
    }

    private void TryShoot()
    {
        if (attackStrategy == null) return;
       // attackStrategy.Shooting(bulletPrefab, firePoint, AttackSpeed);
    }

    public override void Attack()
    {
        if (attackStrategy == null) return;
       // attackStrategy.UpdateTarget("Enemy", AttackRange, transform);
    }

    public GameObject InstantiateBullet()
    {
        var bullet = Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
        return bullet;
    }
}
