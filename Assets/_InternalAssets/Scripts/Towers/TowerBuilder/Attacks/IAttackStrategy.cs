using UnityEngine;

public interface IAttackStrategy
{
    void UpdateTarget(string EnemyTag, float AttackRange);
}
