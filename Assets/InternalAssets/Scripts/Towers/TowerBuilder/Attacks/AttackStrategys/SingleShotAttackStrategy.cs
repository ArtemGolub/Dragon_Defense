using UnityEngine;

public class SingleShotAttackStrategy : IAttackStrategy
{
    public Transform Target { get; set; }
    public float FireCountdown { get; set; }
    public GameObject BulletPrefab { get; set; }
    public Transform FirePoint { get; set; }
    public void StartUpdatingTarget()
    {
        throw new System.NotImplementedException();
    }
    
    public void UpdateTarget(string enemyTag, float AttackRange, Transform tower)
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        float shortestDistance = Mathf.Infinity;

        GameObject nearestEnemy = null;
            
            
        foreach (var enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(tower.transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= AttackRange)
        {
            Target = nearestEnemy.transform;
            
            var towerSM = tower.GetComponent<Tower_SM>();
            towerSM.TowerShoot.SetTarget(Target);
            towerSM._SM.ChangeState(towerSM.TowerShoot);
            
        }
        else
        {
            Target = null;
        }
    }
}
