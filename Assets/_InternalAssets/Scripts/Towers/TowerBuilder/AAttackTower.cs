using UnityEngine;

public abstract class AAttackTower : ATower, IAttackTower
{
    public SAttackTower AttackTowerPreset;
    public AttackType AttackType { get; set; }
    public IAttackStrategy attackStrategy { get; set; }
    public float Damage { get; set; }
    public float AttackSpeed { get; set; }
    public float AttackRange { get; set; }
    public float FireCountdown { get; set; }
    public string EnemyTag { get; set; }
    public GameObject BulletPrefab { get; set; }
    public Transform FirePoint;

    public void InitAttackTower()
    {
        AttackType = AttackTowerPreset.AttackType;
        SetAttackStrategy(AttackType);
        Damage = AttackTowerPreset.Damage;
        AttackSpeed = AttackTowerPreset.AttackSpeed;
        AttackRange = AttackTowerPreset.AttackRange;
        EnemyTag = "Enemy";
        BulletPrefab = AttackTowerPreset.BulletPrefab;
        
        InvokeRepeating("StartUpdatingTarget", 0, 0.5f);
    }
    
    public void SetAttackStrategy(AttackType attackType)
    {
        attackStrategy = AttackStrategyFactory.CreateStrategy(attackType, this);
    }
    
    public void StartUpdatingTarget()
    {
        attackStrategy.UpdateTarget("Enemy", AttackRange);
    }
    
    public GameObject InstantiateBullet()
    {
        var bullet = Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
        return bullet;
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position, AttackRange);
    }
}