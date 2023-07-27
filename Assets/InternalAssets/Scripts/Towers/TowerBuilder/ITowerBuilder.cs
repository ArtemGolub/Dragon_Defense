using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITowerBuilder
{
    void SetAttackType(AttackType attackType);
    void SetDamage(int damage);
    void SetAttackSpeed(float attackSpeed);
    void SetAttackRange(float attackRange);
    void SetVisualDesign(GameObject model, Material texture);
    ATower GetTower();
}
