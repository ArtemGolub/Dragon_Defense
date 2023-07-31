using System;
using UnityEngine;


public class Bullet : MonoBehaviour, IBullet
{
    private Transform target;
    public float speed;
    public float Damage;
    
    public void Seek(Transform Target)
    {
        target = Target;
    }

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

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }
    
    
    public void HitTarget()
    {
        target.GetComponent<AEnemy>().ReciveDamage(Damage);
        Destroy(gameObject);
    }
}