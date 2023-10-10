using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class AOEBullet : MonoBehaviour, IBullet
{
    private Transform Target;
    public float speed;
    public float damageRadius = 5;
    public float Damage;
    private Vector3 targetPose;
    public float parabolaHeight = 2f;
    public float factor;
    public float HeightDependencyDistance = 0.01f;
    public float LowerDependencyDistance = -0.1f;
    public GameObject FXprefab;

    public Ease ease;
    private void Start()
    {
        targetPose = Vector3.zero;
    }

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
        if (targetPose == Vector3.zero)
        {
            targetPose = Target.transform.position;
            StartTween();
        }
    }
    
    private void StartTween()
    {
        var distance =  Vector3.Distance(targetPose, transform.position);
        var duration = distance / (speed * 10);
        var height = CalculateHeight(distance);

         Vector3 directionToTarget = targetPose - transform.position;
         Vector3 halfwayPoint = transform.position + directionToTarget * factor;
         halfwayPoint.y = height;

         transform.DOPath(GetPath(transform.position, halfwayPoint, targetPose), duration, PathType.CatmullRom)
            .SetEase(ease)
            .OnComplete(HitTarget);
    }
    
    private float CalculateHeight(float distance)
    {
        float a = HeightDependencyDistance;
        float b = LowerDependencyDistance;
        float c = parabolaHeight;

        return a * distance * distance + b * distance + c;
    }
    
    private Vector3[] GetPath(Vector3 start, Vector3 halfway, Vector3 end)
    {
        Vector3[] path = new Vector3[3];
        path[0] = start;
        path[1] = halfway;
        path[2] = end;
        return path;
    }

    public void Seek(Transform target)
    {
        Target = target;
    }

    public void HitTarget()
    {
        var a = Instantiate(FXprefab, transform.position, transform.rotation);
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
        Destroy(this.gameObject);
    }
}
