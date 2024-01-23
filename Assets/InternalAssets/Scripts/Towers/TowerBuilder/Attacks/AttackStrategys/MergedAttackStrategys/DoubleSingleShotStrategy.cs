using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleSingleShotStrategy : IAttackStrategy
{
    private MergedTower _tower;
    public DoubleSingleShotStrategy(MergedTower tower)
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
            float distanceToEnemy = Vector3.Distance(_tower.transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        
        if (nearestEnemy != null && shortestDistance <= AttackRange)
        {
            _tower.target = nearestEnemy.transform;
        }
        else
        {
            _tower.target = null;
        }
    }

    public void Shooting()
    {
        if (_tower.target == null) return;
        //Debug.Log(_tower.FireCountdown);
        if (_tower.FireCountdown <= 0)
        {
            //  _tower.GetComponentInChildren<Animator>().SetBool("isAttack", true);
            Shoot();
            _tower.FireCountdown = 1f / _tower.AttackSpeed;
        }
        if (_tower.FireCountdown < 0)
        {
            _tower.FireCountdown = 1f / _tower.AttackSpeed;
        }
        _tower.FireCountdown -= Time.deltaTime;
    }
    
    public void Shoot()
    {
        if (_tower.target == null) return;
        Debug.Log("shoot");

        var bulletGO = _tower.InstantiateBullet();
        IBullet bullet = bulletGO.GetComponent<IBullet>();
        if (bullet != null)
        {
            bullet.Seek(_tower.target);
        }
        CoroutineRunner.Instance.StartRoutine(InstantiateSecondBullet());
    }

    IEnumerator InstantiateSecondBullet()
    {
        yield return new WaitForSeconds(0.3f);

        var bulletSecond = _tower.InstantiateBullet();
        IBullet bulletS = bulletSecond.GetComponent<IBullet>();
        if (bulletS != null)
        {
            bulletS.Seek(_tower.target);
        }
    }
}
