using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOEBullet : MonoBehaviour, IBullet
{
    private Transform Target;
    public float speed;
    public float damageRadius = 5;
    public float Damage;
    
    private void Update()
    {
        MoveBullet();
    }
    public void MoveBullet()
    {
        if (Target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = new Vector3(Target.position.x, Target.position.y, Target.position.z) - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;
        TargetLook.LookAtTarget(this.transform, Target);

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    public void Seek(Transform target)
    {
        Target = target;
    }

    public void HitTarget()
    {
        AEnemy targetUnit = Target.GetComponent<AEnemy>();
        if (targetUnit == null) return;
        Collider[] colliders = Physics.OverlapSphere(Target.position, damageRadius);
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
    }
}
