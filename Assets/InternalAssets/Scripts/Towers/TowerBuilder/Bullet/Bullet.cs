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
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }
            
        Vector3 dir = new Vector3(target.position.x, target.position.y, target.position.z) - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;
        LookAtTarget();
            
        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }
            
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }
    
    private void LookAtTarget()
    {
        var lookPos =  target.position - transform.position;
        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 1000);
    }
    
    void HitTarget()
    {
        target.GetComponent<AEnemy>().ReciveDamage(Damage);
        Destroy(gameObject);
    }
}