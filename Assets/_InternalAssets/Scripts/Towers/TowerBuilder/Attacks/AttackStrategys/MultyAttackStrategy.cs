using System.Collections.Generic;
using UnityEngine;

public class MultyAttackStrategy : IAttackStrategy, IMultyAttackStrategy
{
    private AtackTower _tower;
    private List<Transform> targets = new List<Transform>(); 
    
    public MultyAttackStrategy(AtackTower tower)
    {
        _tower = tower;
    }

    public void UpdateTarget(string EnemyTag, float AttackRange)
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(EnemyTag);
        targets.Clear();

        foreach (var enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(_tower.model.transform.position, enemy.transform.position);
            if (distanceToEnemy <= AttackRange)
            {
                targets.Add(enemy.transform);
            }
        }
    }

    public void Shooting()
    {
        if (targets.Count == 0) return;

        if (_tower.FireCountdown <= 0)
        {
            Shoot();
            _tower.FireCountdown = 1f / _tower.AttackSpeed;
        }

        _tower.FireCountdown -= Time.deltaTime;
    }

    public void Shoot()
    {
        foreach (var target in targets)
        {
            var bulletGO = _tower.InstantiateBullet();
            IBullet bullet = bulletGO.GetComponent<IBullet>();
            if (bullet != null)
            {
                bullet.Seek(target);
            }
        }
    }
}
