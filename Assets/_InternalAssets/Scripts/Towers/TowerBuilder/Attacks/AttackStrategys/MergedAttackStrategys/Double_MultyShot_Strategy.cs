using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Double_MultyShot_Strategy : IAttackStrategy
{
    private MergedTower _tower;
    private List<Transform> targets = new List<Transform>(); 
    
    public Double_MultyShot_Strategy(MergedTower tower)
    {
        _tower = tower;
        Debug.Log(_tower);
    }
    
    public void UpdateTarget(string EnemyTag, float AttackRange)
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(EnemyTag);
        targets.Clear();
        
        foreach (var enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(_tower.transform.position, enemy.transform.position);
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
        CoroutineRunner.Instance.StartRoutine(InstantiateSecondBullet());
    }
    
    IEnumerator InstantiateSecondBullet()
    {
        yield return new WaitForSeconds(0.3f);
        foreach (var target in targets)
        {
            var bulletSecond = _tower.InstantiateBullet();
            IBullet bulletS = bulletSecond.GetComponent<IBullet>();
            if (bulletS != null)
            {
                bulletS.Seek(target);
            }
        }
    }
}
