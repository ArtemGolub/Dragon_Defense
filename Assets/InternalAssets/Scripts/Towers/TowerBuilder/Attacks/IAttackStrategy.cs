using UnityEngine;

public interface IAttackStrategy
{
    void Attack(Transform target, ATower tower);
}
