using Unity.VisualScripting;
using UnityEngine;

public abstract class ATower : MonoBehaviour, ITower
{
    public STower preset;
    
    public AttackType AttackType { get; set; }
    public IAttackStrategy attackStrategy { get; set; }
    public float Damage { get; set; }
    public float ArmorReduction { get; set; }
    public float AttackSpeed { get; set; }
    public float AttackRange { get; set; }

    public Transform Target;
    public float FireCountdown;
    public GameObject BulletPrefab;
    public Transform FirePoint;
    
    
    
    public abstract void Attack();

    protected void TowerInit()
    {
        AttackType = preset.AttackType;
        SetAttackStrategy(AttackType);
        Damage = preset.Damage;
        ArmorReduction = preset.ArmorReduction;
        AttackSpeed = preset.AttackSpeed;
        AttackRange = preset.AttackRange;

        
    }

    private void SetAttackStrategy(AttackType attackType)
    {
        attackStrategy = AttackStrategyFactory.CreateStrategy(attackType);
    }
  
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position, AttackRange);
    }
    
    public void UpdateTarget()
    {
       InvokeRepeating("Method", 0, 0.5f);
    }

    public void StopUpdateTarget()
    {
        CancelInvoke("Method");
    }

    private void Method()
    {
        attackStrategy.UpdateTarget("Enemy", AttackRange, transform);
    }
}
