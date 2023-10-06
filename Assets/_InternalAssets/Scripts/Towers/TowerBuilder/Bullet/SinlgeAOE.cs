using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class SinlgeAOE : MonoBehaviour, IBullet
{
    private Transform target;
    public float speed;
    public float damageRadius = 5;
    public float Damage;


    public GameObject FXprefab;
    public float offSet = 0.5f;

    

    private void Update()
    {
        MoveBullet();
    }
    
    public void MoveBullet()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }
        Vector3 dir = new Vector3(target.position.x, target.position.y, target.position.z) - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;
        
        TargetLook.LookAtTarget(this.transform, target);

        if (dir.magnitude <= distanceThisFrame + offSet)
        {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }
    
    public void Seek(Transform Target)
    {
        target = Target;
    }

    public void HitTarget()
    {
        var a = Instantiate(FXprefab, transform.position, transform.rotation);
        AEnemy targetUnit = target.GetComponent<AEnemy>();
        if (targetUnit == null) return;
        Collider[] colliders = Physics.OverlapSphere(target.position, damageRadius);
        foreach (Collider collider in colliders)
        {
            AEnemy unit = collider.GetComponent<AEnemy>();
            if (unit != null)
            {
                AEnemy damageable = collider.GetComponent<AEnemy>();
                if (damageable != null)
                {
                    damageable.ReciveDamage(Damage);
                }
            }
        }
        Destroy(gameObject);
    }
}
