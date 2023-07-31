using UnityEngine;

public class SingleShotAttackStrategy : IAttackStrategy, ISingleShotAttack
{
    public Transform Target { get; set; }
    
    private AAttackTower _tower;

    public SingleShotAttackStrategy(AAttackTower tower)
    {
        _tower = tower;
    }
    
    public void UpdateTarget(string enemyTag, float AttackRange)
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        float shortestDistance = Mathf.Infinity;

        GameObject nearestEnemy = null;
        
        foreach (var enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(_tower.model.transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= AttackRange)
        {
            Target = nearestEnemy.transform;
        }
        else
        {
            Target = null;
        }
        Shooting();
    }

    public void Shooting()
    {
        if (Target == null) return;
        if (_tower.FireCountdown <= 0)
        {
          
            Shoot();
            _tower.FireCountdown = 1f / _tower.AttackSpeed;
        }

        _tower.FireCountdown -= Time.deltaTime;
    }

    public void Shoot()
    {
        if (Target == null) return;
        var bulletGO = _tower.InstantiateBullet();
        IBullet bullet = bulletGO.GetComponent<IBullet>();
        if (bullet != null)
        {
            bullet.Seek(Target);
        }
    }
    
    
}
