using UnityEngine;

public interface IAttackTower
{
    AttackType AttackType { get; set; }
   // IAttackStrategy attackStrategy { get; set; }
    float Damage { get; set; }
    float AttackSpeed { get; set; }
    float AttackRange { get; set; }
    float FireCountdown { get; set; }
    string EnemyTag { get; set; }
    GameObject BulletPrefab { get; set; }
    GameObject InstantiateBullet();

    void InitAttackTower();
   // void SetAttackStrategy(AttackType attackType);
   // void StartUpdatingTarget();
}